using System;
using System.Text;

namespace SwqlStudio.Autocomplete
{
    internal static class QueryEntityNameParser
    {
        internal static string GetPrimaryEntityName(string queryText)
        {
            var entityName = new StringBuilder();
            var foundFrom = false;
            var afterDot = false;
            var parenthesisDepth = 0;

            foreach (var (position, length, token) in new AutocompleteTokenizer(queryText))
            {
                if (token == AutocompleteTokenizer.Token.Special)
                {
                    var character = queryText[position];
                    if (character == '(')
                    {
                        if (parenthesisDepth == 0 && foundFrom && entityName.Length == 0)
                            foundFrom = false;
                        parenthesisDepth++;
                        continue;
                    }

                    if (character == ')')
                    {
                        parenthesisDepth--;
                        continue;
                    }

                    if (parenthesisDepth != 0)
                        continue;

                    if (foundFrom && character == '.' && entityName.Length > 0)
                    {
                        entityName.Append('.');
                        afterDot = true;
                        continue;
                    }

                    if (entityName.Length > 0)
                        return entityName.ToString();

                    continue;
                }

                if (parenthesisDepth != 0 || token != AutocompleteTokenizer.Token.Identifier)
                    continue;

                var identifier = queryText.Substring(position, length);
                if (!foundFrom)
                {
                    foundFrom = string.Equals(identifier, "FROM", StringComparison.OrdinalIgnoreCase);
                    continue;
                }

                if (entityName.Length == 0 || afterDot)
                {
                    if (identifier.StartsWith("[") && identifier.EndsWith("]"))
                        identifier = identifier.Substring(1, identifier.Length - 2);

                    entityName.Append(identifier);
                    afterDot = false;
                    continue;
                }

                return entityName.ToString();
            }

            return entityName.Length > 0 ? entityName.ToString() : null;
        }
    }
}