using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    static class CodeGenerator
    {
        public static void GenerateCSharpCode(IEnumerable<Entity> entities, string path)
        {
            foreach (var entity in entities.Where(e => !e.IsIndication))
                GenerateCSharpCode(entity, path);
        }

        private static void GenerateCSharpCode(Entity entity, string path)
        {
            var targetUnit = new CodeCompileUnit();
            var targetNamespace = new CodeNamespace(entity.FullName.Substring(0, entity.FullName.LastIndexOf('.')));
            targetNamespace.Imports.Add(new CodeNamespaceImport("System"));
            var targetClass = new CodeTypeDeclaration(entity.FullName.Substring(entity.FullName.LastIndexOf('.') + 1))
            {
                IsClass = true,
                IsPartial = true,
                TypeAttributes = TypeAttributes.Public
            };
            targetNamespace.Types.Add(targetClass);
            targetUnit.Namespaces.Add(targetNamespace);

            foreach (var property in entity.Properties)
            {
                CodeTypeReference propertyType;
                if (property.IsNavigable)
                {
                    propertyType = new CodeTypeReference(typeof(List<>));
                    propertyType.TypeArguments.Add((string)RemapTypeForCSharp(property.Type));
                }
                else
                {
                    propertyType = new CodeTypeReference(RemapTypeForCSharp(property.Type));
                }

                var backingField = new CodeMemberField(propertyType, "_" + property.Name) {Attributes = MemberAttributes.Private};

                if (property.IsNavigable)
                    backingField.InitExpression = new CodeObjectCreateExpression(propertyType);

                targetClass.Members.Add(backingField);

                var codeProperty = new CodeMemberProperty
                {
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                    Name = property.Name,
                    HasGet = true,
                    HasSet = true,
                    Type = propertyType,
                };
                codeProperty.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), backingField.Name)));
                codeProperty.SetStatements.Add(
                    new CodeAssignStatement(
                        new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), backingField.Name),
                        new CodeVariableReferenceExpression("value")));

                targetClass.Members.Add(codeProperty);
            }

            var provider = CodeDomProvider.CreateProvider("CSharp");
            var options = new CodeGeneratorOptions {BracingStyle = "C"};
            using (var writer = new StreamWriter(Path.Combine(path, entity.FullName + '.' + provider.FileExtension)))
            {
                provider.GenerateCodeFromCompileUnit(targetUnit, writer, options);
            }
        }

        private static string RemapTypeForCSharp(string type)
        {
            if (type.Equals("System.Binary", StringComparison.OrdinalIgnoreCase))
                return "System.Byte[]";
            if (type.Equals("System.Type", StringComparison.OrdinalIgnoreCase))
                return "System.String";

            return type;
        }
    }
}