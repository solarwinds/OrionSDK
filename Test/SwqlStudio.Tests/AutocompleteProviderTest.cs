using System.Collections.Generic;
using FluentAssertions;
using SwqlStudio.Autocomplete;
using Xunit;

namespace SwqlStudio.Tests
{
    public class AutocompleteProviderTest
    {
        [Theory]
        [MemberData(nameof(DoTheParsing_TestCases))]
        public void DoTheParsing_IdentifiesAliases(string query, Dictionary<string, string> expected)
        {
            var provider = new AutocompleteProvider(query);
            var aliases = new Dictionary<string, string>();
            provider.DoTheParsing(9, aliases);

            aliases.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> DoTheParsing_TestCases()
        {
            yield return new object[]
            {
                "select n. from Orion.Nodes n inner join Orion.Interfaces as i",
                new Dictionary<string, string> {["n"] = "Orion.Nodes", ["i"] = "Orion.Interfaces"}
            };

            yield return new object[]
            {
                "SELECT n. FROM Orion.Nodes n INNER JOIN Orion.Interfaces AS i",
                new Dictionary<string, string> {["n"] = "Orion.Nodes", ["i"] = "Orion.Interfaces"}
            };

            yield return new object[]
            {
                "select n. from Orion.Nodes n",
                new Dictionary<string, string> {["n"] = "Orion.Nodes"}
            };

        }
    }
}
