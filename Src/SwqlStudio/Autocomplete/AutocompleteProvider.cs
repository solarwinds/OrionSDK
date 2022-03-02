using System;
using System.Collections.Generic;
using System.Linq;

namespace SwqlStudio.Autocomplete
{
    // we are not reusing full swis grammar, we can do more 'educated guess' here.
    internal class AutocompleteProvider
    {
        private static readonly HashSet<string> _keyWords = new HashSet<string>(Grammar.General, StringComparer.OrdinalIgnoreCase);
        private readonly string _text;

        public AutocompleteProvider(string text)
        {
            _text = text;
        }

        internal enum LastInterestingElement
        {
            Nothing, // nothing interesting
            Dot, // last thing was dot, so when we find identifier, we append
            As // last thing was identifier (or AS keyword) , we want to detect alias
        }

        public ExpectedCaretPosition ParseFor(int caretPosition)
        {
            var aliasList = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var rv = DoTheParsing(caretPosition, aliasList);
            string possibleAlias;

            switch (rv.LastElement)
            {
                case LastInterestingElement.Nothing:
                    return new ExpectedCaretPosition(ExpectedCaretPositionType.Entity | ExpectedCaretPositionType.Keyword, null);
                case LastInterestingElement.Dot:
                    if (!aliasList.TryGetValue(rv.CurrentIdentifier, out possibleAlias))
                    {
                        // expand alias for navigation property
                        // n.blahblah becomes node.blahblah (if we have alias node n)
                        if (rv.CurrentIdentifier.Contains('.'))
                        {
                            var firstPortion = rv.CurrentIdentifier.Substring(0, rv.CurrentIdentifier.IndexOf('.'));
                            if (aliasList.TryGetValue(firstPortion, out possibleAlias))
                            {
                                possibleAlias = possibleAlias + rv.CurrentIdentifier.Substring(rv.CurrentIdentifier.IndexOf('.'));
                            }
                            else
                            {
                                possibleAlias = rv.CurrentIdentifier;
                            }
                        }
                        else
                        {
                            possibleAlias = rv.CurrentIdentifier;
                        }
                    }


                    return new ExpectedCaretPosition(ExpectedCaretPositionType.Column, possibleAlias);
                case LastInterestingElement.As:

                    if (!aliasList.TryGetValue(rv.CurrentIdentifier, out possibleAlias))
                        possibleAlias = rv.CurrentIdentifier;

                    return new ExpectedCaretPosition(ExpectedCaretPositionType.Keyword | ExpectedCaretPositionType.Column, possibleAlias);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal (string CurrentIdentifier, LastInterestingElement LastElement) DoTheParsing(int caretPosition,
            IDictionary<string, string> aliasList)
        {
            string lastIdentifier = "";
            var lastInterestingElement = LastInterestingElement.Nothing;

            string underCaretIdentifier = "";
            var underCaretInterestingElement = LastInterestingElement.Nothing;

            bool detected = false;

            foreach ((int position, int length, var token) in new AutocompleteTokenizer(_text))
            {
                if (token == AutocompleteTokenizer.Token.Special)
                {
                    if (_text[position] == '.')
                    {
                        lastInterestingElement = LastInterestingElement.Dot;
                    }
                    else
                    {
                        lastInterestingElement = LastInterestingElement.Nothing;
                    }
                }

                if (!detected && position <= caretPosition && (position + length) >= caretPosition)
                {
                    // here we are. what do we see right now?
                    detected = true;
                    underCaretIdentifier = lastIdentifier;
                    underCaretInterestingElement = lastInterestingElement;
                }

                switch (token)
                {
                    case AutocompleteTokenizer.Token.Identifier:
                        var value = _text.Substring(position, length);
                        if (string.Equals(value, "as", StringComparison.OrdinalIgnoreCase))
                        // alias. only interesting keyword for us. however, ignore, since Table X and Table as X are equivalent.
                        // this may mean someone writing SELECT A B FROM D - A B are aliases - but, whatever. Full scan would be much worse.
                        {
                        }
                        else if (_keyWords.Contains(value)) // reset the interesting stuff state
                        {
                            lastInterestingElement = LastInterestingElement.Nothing;
                            lastIdentifier = "";
                        }
                        else
                        {
                            var realIdentifier = value[0] == '[' ? value.Substring(1, value.Length - 2) : value;

                            switch (lastInterestingElement)
                            {
                                case LastInterestingElement.Nothing:
                                    lastIdentifier = realIdentifier;
                                    lastInterestingElement = LastInterestingElement.As;
                                    break;
                                case LastInterestingElement.Dot:
                                    lastIdentifier += "." + realIdentifier;
                                    lastInterestingElement = LastInterestingElement.As;
                                    break;
                                case LastInterestingElement.As:
                                    aliasList[realIdentifier] = lastIdentifier;
                                    lastInterestingElement = LastInterestingElement.Nothing;
                                    lastIdentifier = "";
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                        break;
                    case AutocompleteTokenizer.Token.Number:
                    case AutocompleteTokenizer.Token.String:
                        // we do not care here
                        lastInterestingElement = LastInterestingElement.Nothing;
                        break;
                }
            }


            return (underCaretIdentifier, underCaretInterestingElement);
        }
    }
}
