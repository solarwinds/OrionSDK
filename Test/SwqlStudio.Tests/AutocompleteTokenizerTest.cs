using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SwqlStudio.Autocomplete;
using Xunit;

namespace SwqlStudio.Tests
{
    public class AutocompleteTokenizerTest
    {
        [Fact]
        public void TokenizerTestSuite()
        {
            var tokenizer = new AutocompleteTokenizer(
                "SELECT n. Orion.Nodes 123 \"abc\"");

            IEnumerable<(int Position, int Length, AutocompleteTokenizer.Token Token)> Enumerate()
            {
                foreach(var t in tokenizer)
                    yield return t;
            }

            Enumerate().Should().BeEquivalentTo(new []
            {
                (0, 6, AutocompleteTokenizer.Token.Identifier),
                (7, 1, AutocompleteTokenizer.Token.Identifier),
                (8, 1, AutocompleteTokenizer.Token.Special),
                (10, 5, AutocompleteTokenizer.Token.Identifier),
                (15, 1, AutocompleteTokenizer.Token.Special),
                (16, 5, AutocompleteTokenizer.Token.Identifier),
                (22, 4, AutocompleteTokenizer.Token.Number),
                (26, 5, AutocompleteTokenizer.Token.String),
                (31, 0, AutocompleteTokenizer.Token.EOF),
            });

        }
    }
}
