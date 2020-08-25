using System;
using System.Collections.Generic;
using System.Linq;

namespace SwqlStudio.Autocomplete
{
    // we are not reusing full swis grammar, we can do more 'educated guess' here.
    internal class AutocompleteProvider
    {
        private static readonly HashSet<string> _keyWords;
        private readonly string _text;

        public AutocompleteProvider(string text)
        {
            _text = text;
        }

        static AutocompleteProvider()
        {
            _keyWords = new HashSet<string>(Grammar.General);
        }

        private enum LastInterestingElement
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

            switch (rv.Item2)
            {
                case LastInterestingElement.Nothing:
                    return new ExpectedCaretPosition(ExpectedCaretPositionType.Entity | ExpectedCaretPositionType.Keyword, null);
                case LastInterestingElement.Dot:
                    if (!aliasList.TryGetValue(rv.Item1, out possibleAlias))
                    {
                        // expand alias for navigation property
                        // n.blahblah becomes node.blahblah (if we have alias node n)
                        if (rv.Item1.Contains('.'))
                        {
                            var firstPortion = rv.Item1.Substring(0, rv.Item1.IndexOf('.'));
                            if (aliasList.TryGetValue(firstPortion, out possibleAlias))
                            {
                                possibleAlias = possibleAlias + rv.Item1.Substring(rv.Item1.IndexOf('.'));
                            }
                            else
                            {
                                possibleAlias = rv.Item1;
                            }
                        }
                        else
                        {
                            possibleAlias = rv.Item1;
                        }
                    }


                    return new ExpectedCaretPosition(ExpectedCaretPositionType.Column, possibleAlias);
                case LastInterestingElement.As:

                    if (!aliasList.TryGetValue(rv.Item1, out possibleAlias))
                        possibleAlias = rv.Item1;

                    return new ExpectedCaretPosition(ExpectedCaretPositionType.Keyword | ExpectedCaretPositionType.Column, possibleAlias);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Tuple<string, LastInterestingElement> DoTheParsing(int caretPosition,
            IDictionary<string, string> aliasList)
        {
            string lastIdentifier = "";
            var lastInterestingElement = LastInterestingElement.Nothing;

            string underCaretIdentifier = "";
            var underCaretInterestingElement = LastInterestingElement.Nothing;

            bool detected = false;

            foreach (var tok in new AutocompleteTokenizer(_text))
            {
                if (tok.Item3 == AutocompleteTokenizer.Token.Special)
                {
                    if (_text[tok.Item1] == '.')
                    {
                        lastInterestingElement = LastInterestingElement.Dot;
                    }
                    else
                    {
                        lastInterestingElement = LastInterestingElement.Nothing;
                    }
                }

                if (!detected && tok.Item1 <= caretPosition && (tok.Item1 + tok.Item2) >= caretPosition)
                {
                    // here we are. what do we see right now?
                    detected = true;
                    underCaretIdentifier = lastIdentifier;
                    underCaretInterestingElement = lastInterestingElement;
                }

                switch (tok.Item3)
                {
                    case AutocompleteTokenizer.Token.Identifier:
                        var value = _text.Substring(tok.Item1, tok.Item2);
                        if (value == "as")
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


            return Tuple.Create(underCaretIdentifier, underCaretInterestingElement);
        }
    }
}
