using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace SolarWinds.InformationService.Contract2
{
    /**
     * Class derived from ResponsePareser that collect unknown entities inti list.
     * */
    internal class EntityCollectionResponseParser<T> : IResponseParser<T> where T : new()
    {
        internal ParserState state = ParserState.Start;
        internal EntityInfo entityInfo = null;
        protected Stack<StackFrame> stack = new Stack<StackFrame>();
        protected Type rootType = typeof(T);
        internal List<object> arrayItems = new List<object>();
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(ErrorMessage));

        private List<ErrorMessage> errorMessages;

        public IEnumerable<ErrorMessage> ErrorMessages
        {
            get { return errorMessages; }
        }

        private readonly bool hasAddMethod = typeof(IEntityPropertySetter).IsAssignableFrom(typeof(T));

        public T ReadNextEntity(XmlReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (this.state)
                        {
                            case ParserState.Start:
                                // Assumption:
                                // - skip the soap response tags
                                if ((reader.LocalName == "QueryXmlResponse") ||
                                    (reader.LocalName == "QueryXmlResult"))
                                    continue;

                                if (string.CompareOrdinal(reader.LocalName, "queryResult") == 0)
                                    this.state = ParserState.Root;
                                else
                                    throw new InvalidOperationException("Expecting <queryResult> element but found " + reader.LocalName);
                                break;

                            case ParserState.Root:
                                if (string.CompareOrdinal(reader.LocalName, "template") == 0)
                                {
                                    this.state = ParserState.Template;
                                }
                                else if (string.CompareOrdinal(reader.LocalName, "data") == 0)
                                {
                                    if (this.entityInfo == null)
                                        throw new InvalidOperationException("No root entity was defined in the template section");

                                    this.state = ParserState.Data;
                                }
                                else
                                {
                                    throw new InvalidOperationException("Unexepected element " + reader.LocalName);
                                }
                                break;

                            case ParserState.Template:
                                if (string.CompareOrdinal(reader.LocalName, "entity") == 0)
                                {
                                    if (this.entityInfo != null)
                                        throw new InvalidOperationException("Only one root entity is supported at this time");

                                    StackFrame state = new StackFrame();
                                    state.entity = new EntityInfo(reader["name"], reader["type"], Boolean.Parse(reader["dynamic"]));
                                    stack.Push(state);

                                    this.entityInfo = state.entity;

                                    this.state = ParserState.EntityTemplate;
                                }

                                break;

                            case ParserState.EntityTemplate:
                                if (string.CompareOrdinal(reader.LocalName, "property") == 0)
                                {
                                    stack.Peek().entity.Properties.Add(XmlConvert.DecodeName(reader["name"]), new EntityPropertyInfo(XmlConvert.DecodeName(reader["name"]), reader["type"]));

                                    // Sometime empty elements come with an end element, adjust the statemachine state accordingly
                                    if (!reader.IsEmptyElement)
                                        this.state = ParserState.PropertyTemplate;
                                }
                                else if (string.CompareOrdinal(reader.LocalName, "entity") == 0)
                                {
                                    StackFrame state = new StackFrame();
                                    state.entity = new EntityInfo(reader["name"], reader["type"], Boolean.Parse(reader["dynamic"]));

                                    stack.Peek().entitySet.Entities.Add(state.entity.EntityName, state.entity);

                                    stack.Push(state);
                                }
                                else if (string.CompareOrdinal(reader.LocalName, "entitySet") == 0)
                                {
                                    StackFrame state = new StackFrame();
                                    state.entitySet = new EntitySetInfo(reader["name"]);

                                    stack.Peek().entity.EntitySets.Add(state.entitySet.Name, state.entitySet);

                                    stack.Push(state);
                                }
                                break;

                            case ParserState.Data:
                                BeginRootEntity(reader);
                                break;

                            case ParserState.Entity:
                                if (stack.Peek().entity.Properties.ContainsKey(XmlConvert.DecodeName(reader.LocalName)))
                                {
                                    BeginProperty(reader);
                                }
                                else if (stack.Peek().entity.EntitySets.ContainsKey(XmlConvert.DecodeName(reader.LocalName)))
                                {
                                    BeginEntitySet(reader);
                                }
                                else
                                {
                                    throw new InvalidOperationException("Don't know how to handle element " + reader.LocalName);
                                }
                                break;

                            case ParserState.EntitySet:
                                if (stack.Peek().entitySet.Entities.ContainsKey(reader.LocalName))
                                {
                                    BeginNestedEntity(reader);
                                }
                                else
                                {
                                    throw new InvalidOperationException("Don't know how to handle element " + reader.LocalName);
                                }
                                break;

                            case ParserState.ArrayProperty:
                                if (string.CompareOrdinal(reader.LocalName, "item") == 0)
                                    this.state = ParserState.ArrayItem;
                                else
                                    throw new InvalidOperationException("Expecting <item> but encountered " + reader.LocalName);
                                break;

                            case ParserState.Errors:
                                if (string.CompareOrdinal(reader.LocalName, "errors") == 0)
                                {
                                    this.state = ParserState.Error;
                                    break;
                                }
                                return default(T);

                            case ParserState.Error:
                                if (string.CompareOrdinal(reader.LocalName, "error") == 0)
                                {
                                    ReadErrorMessages(reader);
                                }
                                break;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        switch (this.state)
                        {
                            case ParserState.Root:
                                ValidateEndElement(reader.LocalName, "queryResult", ParserState.Errors);
                                break;

                            case ParserState.Errors:
                                if (string.CompareOrdinal(reader.LocalName, "errors") == 0)
                                    ValidateEndElement(reader.LocalName, "errors", ParserState.Root);
                                return default(T);

                            case ParserState.Error:
                                if (string.CompareOrdinal(reader.LocalName, "error") == 0)
                                    break;

                                ValidateEndElement(reader.LocalName, "errors", ParserState.Root);
                                return default(T);



                            case ParserState.Data:
                                ValidateEndElement(reader.LocalName, "data", ParserState.Root);
                                break;

                            case ParserState.Template:
                                ValidateEndElement(reader.LocalName, "template", ParserState.Root);
                                break;

                            case ParserState.EntityTemplate:
                                if ((string.CompareOrdinal(reader.LocalName, "entity") != 0) &&
                                    (string.CompareOrdinal(reader.LocalName, "entitySet") != 0))
                                    throw new InvalidOperationException("Expecting </entity> or </entitySet> but encountered " + reader.LocalName);

                                stack.Pop();
                                if (stack.Count == 0)
                                    this.state = ParserState.Template;
                                break;

                            case ParserState.PropertyTemplate:
                                ValidateEndElement(reader.LocalName, "property", ParserState.EntityTemplate);
                                break;

                            case ParserState.Property:
                                EndProperty(reader);
                                break;

                            case ParserState.ArrayProperty:
                                EndArrayProperty(reader);
                                break;

                            case ParserState.ArrayItem:
                                ValidateEndElement(reader.LocalName, "item", ParserState.ArrayProperty);
                                break;

                            case ParserState.Entity:
                                if (string.CompareOrdinal(reader.LocalName, this.stack.Peek().elementName) != 0)
                                    throw new InvalidOperationException(string.Format("Expecting </{0}> but encountered {1}", this.stack.Peek().elementName, reader.LocalName));

                                if (this.stack.Count == 1)
                                {
                                    return EndRootEntity();
                                }
                                else
                                {
                                    EndNestedEntity();
                                }
                                break;

                            case ParserState.EntitySet:
                                EndEntiySet(reader);
                                break;

                            default:
                                throw new InvalidOperationException(string.Format("Not expecting element {0} while in state {1}", reader.LocalName, this.state));
                        }
                        break;

                    case XmlNodeType.Text:
                        switch (this.state)
                        {
                            case ParserState.Property:
                                ProcessPropertyValue(reader);
                                break;

                            case ParserState.ArrayItem:
                                ProcessArrayPropertyItem(reader);
                                break;
                        }
                        break;
                }
            }

            return default(T);
        }

        private void ReadErrorMessages(XmlReader reader)
        {
            if (errorMessages == null)
                errorMessages = new List<ErrorMessage>();

            ErrorMessage message = (ErrorMessage)serializer.Deserialize(reader.ReadSubtree());

            if (message != null)
                errorMessages.Add(message);
        }

        private void ProcessArrayPropertyItem(XmlReader reader)
        {
            StackFrame topFrame = this.stack.Peek();

            EntityPropertyType itemType = topFrame.entity.Properties[topFrame.elementName].EntityPropertyType;
            Type targetType = topFrame.entity.Properties[topFrame.elementName].Type.GetElementType();

            object value = DeserializeScalarValue(reader.Value, itemType, targetType);
            arrayItems.Add(value);
        }

        private void BeginRootEntity(XmlReader reader)
        {
            // Assumptions: 
            // - expecting top level elements to be entities of the type expected by the query
            // - name must match exactly between the XML element and the type name
            // - not handling simple scalar results at this point, only classes/structs with properties
            // - not handling fields
            StackFrame frame = new StackFrame
            {
                entity = entityInfo,
                elementName = reader.LocalName,
                property = null,
                instance = Activator.CreateInstance<T>(),
                instanceType = rootType,
                state = state
            };

            stack.Push(frame);

            state = ParserState.Entity;
        }

        private void BeginProperty(XmlReader reader)
        {
            StackFrame topFrame = stack.Peek();

            string localName = XmlConvert.DecodeName(reader.LocalName);
            EntityPropertyInfo entityPropertyInfo = topFrame.entity.Properties[localName];

            PropertyInfo property;
            if (!topFrame.dynamic
                && (property = topFrame.instanceType.GetProperty(localName)) != null)
            {
                // Assumptions:
                // - No type conversion is performed to assign the variable
                // Improvements:
                // - Process this validation when the metadata has been processed.
                if (!property.PropertyType.IsAssignableFrom(stack.Peek().entity.Properties[localName].Type))
                    throw new InvalidOperationException(string.Format("Property {0} cannot be assigned from type {1}", localName, entityInfo.Properties[localName].TypeName));

                StackFrame frame = topFrame.Clone();
                frame.elementName = localName;
                frame.property = property;
                frame.state = state;

                stack.Push(frame);
            }
            else
            {
                StackFrame frame = topFrame.Clone();
                frame.elementName = localName;
                frame.state = state;

                if (hasAddMethod)
                {
                    frame.iAddInstance = (IEntityPropertySetter)frame.instance;
                }
                else
                {
                    MethodInfo addMethod = topFrame.instanceType.GetMethod("Add");
                    frame.addMethod = addMethod;
                }

                stack.Push(frame);
            }

            if (entityPropertyInfo.IsArray)
                this.state = ParserState.ArrayProperty;
            else
                this.state = ParserState.Property;
        }

        private void ProcessPropertyValue(XmlReader reader)
        {
            if (state != ParserState.Property)
                throw new InvalidOperationException("Not expecting element content for state " + state);

            StackFrame topFrame = stack.Peek();

            Type targetType = topFrame.entity.Properties[topFrame.elementName].Type;
            EntityPropertyType itemType = topFrame.entity.Properties[topFrame.elementName].EntityPropertyType;

            if (!topFrame.dynamic && topFrame.property != null)
            {
                topFrame.property.SetValue(topFrame.instance, DeserializeScalarValue(reader.Value, itemType, targetType), null);
            }
            else
            {
                if (hasAddMethod)
                {
                    topFrame.iAddInstance.SetPropertyValue(topFrame.elementName, DeserializeScalarValue(reader.Value, itemType, targetType));
                }
                else
                {
                    topFrame.addMethod.Invoke(topFrame.instance,
                                             new[]
                                              {
                                                  topFrame.elementName,
                                                  DeserializeScalarValue(reader.Value, itemType, targetType)
                                              });
                }
            }
        }

        private void ValidateEndElement(string elementName, string expectedName, ParserState targetState)
        {
            if (string.CompareOrdinal(elementName, expectedName) != 0)
                throw new InvalidOperationException(string.Format("Expecting </{0}> but encountered {1}", expectedName, elementName));

            this.state = targetState;
        }

        private void BeginNestedEntity(XmlReader reader)
        {
            EntityInfo nestedEntity = stack.Peek().entitySet.Entities[reader.LocalName];

            StackFrame topFrame = this.stack.Peek();

            StackFrame frame = topFrame.Clone();
            frame.entity = nestedEntity;
            frame.elementName = reader.LocalName;
            if (frame.property != null)
            {
                frame.instance = Activator.CreateInstance(topFrame.instanceType);
            }
            else //keep reference to current instance - for non mapped properties
            {
                frame.instance = topFrame.instance;
            }
            frame.state = this.state;
            frame.dynamic = nestedEntity.Dynamic;

            stack.Push(frame);

            this.state = ParserState.Entity;
        }

        private void EndNestedEntity()
        {
            StackFrame nestedFrame = this.stack.Pop();
            StackFrame topFrame = this.stack.Peek();

            // Add nested entity to the parent's entity property (of type List<nested_entity_type>)
            if (nestedFrame.property != null)
            {
                MethodInfo method = nestedFrame.property.PropertyType.GetInterface("ICollection`1").GetMethod("Add");
                object listInstance = nestedFrame.property.GetValue(topFrame.instance, null);
                method.Invoke(listInstance, new object[] { nestedFrame.instance });
            }

            this.state = nestedFrame.state;
        }

        private void BeginEntitySet(XmlReader reader)
        {
            string localName = XmlConvert.DecodeName(reader.LocalName);

            EntitySetInfo entitySet = stack.Peek().entity.EntitySets[localName];

            StackFrame topFrame = this.stack.Peek();

            Type instanceType = topFrame.instance.GetType();

            PropertyInfo property = instanceType.GetProperty(localName);
            Type[] arguments;

            //if(property==null)
            //{
            //    property = instanceType.GetProperty("NonMappedProperties");
            //}

            StackFrame frame = topFrame.Clone();

            if (property != null)
            {
                if (!property.PropertyType.IsGenericType)
                    throw new InvalidOperationException(string.Format("Property {0}.{1} is not a generic type", instanceType.Name, localName));

                // figure out what type of elements are allowed in the collection
                arguments = property.PropertyType.GetGenericArguments();

                // Only support generic ICollection<T> for nested entities
                Type collType = typeof(ICollection<>).MakeGenericType(arguments[0]);
                if (!collType.IsAssignableFrom(property.PropertyType))
                    throw new InvalidOperationException(string.Format("Property {0} is not an ICollection<T>", property.Name));

                frame.instanceType = arguments[0];

                //frame.instance = property.PropertyType;
            }
            //throw new InvalidOperationException(string.Format("Property {0} does not exist on type {1}", reader.LocalName, instanceType.Name));

            frame.entitySet = entitySet;
            frame.elementName = localName;
            frame.property = property;
            frame.state = this.state;

            stack.Push(frame);

            this.state = ParserState.EntitySet;
        }

        private void EndEntiySet(XmlReader reader)
        {
            if (string.CompareOrdinal(XmlConvert.DecodeName(reader.LocalName), this.stack.Peek().elementName) != 0)
                throw new InvalidOperationException(string.Format("Expecting </{0}> but encountered {1}", this.stack.Peek().elementName, reader.LocalName));

            StackFrame frame = stack.Pop();
            this.state = frame.state;
        }

        private void EndProperty(XmlReader reader)
        {
            if (string.CompareOrdinal(XmlConvert.DecodeName(reader.LocalName), this.stack.Peek().elementName) != 0)
                throw new InvalidOperationException(string.Format("Expecting </{0}> but encountered {1}", this.stack.Peek().elementName, reader.LocalName));

            StackFrame frame = this.stack.Pop();

            this.state = frame.state;
        }

        private void EndArrayProperty(XmlReader reader)
        {
            if (string.CompareOrdinal(XmlConvert.DecodeName(reader.LocalName), this.stack.Peek().elementName) != 0)
                throw new InvalidOperationException(string.Format("Expecting </{0}> but encountered {1}", this.stack.Peek().elementName, reader.LocalName));

            StackFrame frame = this.stack.Pop();

            Type itemType = frame.entity.Properties[frame.elementName].Type.GetElementType();

            Array array = Array.CreateInstance(itemType, arrayItems.Count);
            for (int i = 0; i < arrayItems.Count; i++)
            {
                array.SetValue(arrayItems[i], i);
            }

            if (hasAddMethod)
            {
                frame.iAddInstance.SetPropertyValue(frame.elementName, array);
            }
            else
            {
                frame.addMethod.Invoke(frame.instance,
                                         new object[]
                                              {
                                                  frame.elementName,
                                                  array
                                              });
            }

            arrayItems.Clear();

            this.state = frame.state;
        }

        private T EndRootEntity()
        {
            StackFrame topFrame = this.stack.Pop();

            this.state = topFrame.state;

            return (T)topFrame.instance;
        }

        private object DeserializeScalarValue(string value, EntityPropertyType columnType, Type targetType)
        {
            switch (columnType)
            {
                case EntityPropertyType.Boolean:
                case EntityPropertyType.Byte:
                case EntityPropertyType.Char:
                case EntityPropertyType.Decimal:
                case EntityPropertyType.Double:
                case EntityPropertyType.Int16:
                case EntityPropertyType.Int32:
                case EntityPropertyType.Int64:
                case EntityPropertyType.Single:
                case EntityPropertyType.String:
                case EntityPropertyType.Type:
                case EntityPropertyType.Uri:
                    return Convert.ChangeType(value, targetType, CultureInfo.InvariantCulture);

                case EntityPropertyType.Blob:
                    return Convert.FromBase64String(value);

                case EntityPropertyType.Guid:
                    return new Guid(value);

                case EntityPropertyType.DateTime:
                    return DateTime.Parse(value, CultureInfo.InvariantCulture);

                case EntityPropertyType.Null:
                    return null;
                default:
                    throw new InvalidOperationException(string.Format("Unsupported property type {0}", columnType));
            }
        }
    }
}
