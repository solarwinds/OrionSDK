using System;
using System.Collections.Generic;
using System.Xml;

namespace SolarWinds.InformationService.Contract2
{
    public class InformationServiceQuery<T> : InformationServiceQuery, IEnumerable<T> where T : new()
    {
        public const string EntityCollectionResponseParserType = "EntityCollectionResponseParser";

        private readonly Type type = typeof(T);
        private readonly IResponseParser<T> parser;

        public InformationServiceQuery(InformationServiceContext context, string queryString)
            : this(context, queryString, null)
        {
        }

        public InformationServiceQuery(InformationServiceContext context, string query, PropertyBag parameters) 
            : base(context, query, parameters)
        {
            object[] attributes = type.GetCustomAttributes(typeof(InformationServiceEntityAttribute), false);

            if (attributes.Length > 0)
            {
                InformationServiceEntityAttribute entityAttribute = attributes[0] as InformationServiceEntityAttribute;
                this.parser = entityAttribute != null ? this.ChooseResponseParser(entityAttribute.ParserType) : new ResponseParser<T>();
            }
            else
            {
                this.parser = new ResponseParser<T>();
            }
        }

        private IResponseParser<T> ChooseResponseParser(ParserType parserInstance)
        {
            switch (parserInstance)
            {
                case ParserType.EntityCollectionResponseParser:
                    return new EntityCollectionResponseParser<T>();
                default:
                    return new ResponseParser<T>();
            }
        }

        #region IEnumerable<T> Members

        public virtual IEnumerator<T> GetEnumerator()
        {
            XmlReader reader = Execute();

            T instance;

            do
            {
                instance = parser.ReadNextEntity(reader);
                if (instance != null)
                    yield return instance;
            }
            while (instance != null);
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
