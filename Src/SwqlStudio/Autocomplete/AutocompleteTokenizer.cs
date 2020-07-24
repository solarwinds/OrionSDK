using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SwqlStudio.Autocomplete
{
    internal class AutocompleteTokenizer
    {
        public enum Token
        {
            Special,
            Number,
            Identifier,
            String,
            EOF
        }

        private readonly string _input;
        private static readonly IEnumerable<Regex> _ignoredRegexes;
        private static readonly IEnumerable<Tuple<Regex, Token>> _regexes;
        static AutocompleteTokenizer()
        {
            _ignoredRegexes = new[]
            {
                new Regex(@"\G--.*\n"), // comment
                new Regex(@"\G\s+") // whitespace
            };
            _regexes = new[]
            {

                Tuple.Create(new Regex(@"\G[0-9]+.[0-9]*([eE][0-9]+)?"), Token.Number), // number
                Tuple.Create(new Regex(@"\G@[a-zA-Z_]\w*"), Token.Identifier), // ident
                Tuple.Create(new Regex(@"\G\[[^\]]*\]"), Token.Identifier), // quoted ident
                Tuple.Create(new Regex(@"\G""(?:[^""\\]|\\.)*"""), Token.String), // quoted string
                Tuple.Create(new Regex(@"\G[a-zA-Z_][a-zA-Z_0-9]*"), Token.Identifier) // ident
            };
        }

        public AutocompleteTokenizer(string input)
        {
            _input = input;
        }

        public IEnumerator<Tuple<int, int, Token>> GetEnumerator()
        {
            int position = 0;
            while (position < _input.Length)
            {
                foreach (var ignored in _ignoredRegexes)
                {
                    var m = ignored.Match(_input, position);
                    if (m.Success)
                    {
                        position += m.Groups[0].Length;
                        goto end;
                    }
                }

                foreach (var rx in _regexes)
                {
                    var m = rx.Item1.Match(_input, position);
                    if (m.Success)
                    {
                        yield return Tuple.Create(position, m.Groups[0].Length, rx.Item2);
                        position += m.Groups[0].Length;
                        goto end;
                    }
                }
                yield return Tuple.Create(position, 1, Token.Special);
                position++;
            end:
                ;
            }

            yield return Tuple.Create(position, 0, Token.EOF);
        }
    }
}