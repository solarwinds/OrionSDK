using FluentAssertions;
using SwqlStudio.Autocomplete;
using Xunit;

namespace SwqlStudio.Tests
{
    public class QueryEntityNameParserTests
    {
        [Theory]
        [InlineData("SELECT n.Caption FROM Orion.Nodes n", "Orion.Nodes")]
        [InlineData("SELECT n.Caption FROM [Orion].[Nodes] n", "Orion.Nodes")]
        [InlineData("SELECT (SELECT i.Name FROM Orion.Interfaces i) AS Name FROM Orion.Nodes n", "Orion.Nodes")]
        [InlineData("-- FROM Orion.Interfaces\nSELECT n.Caption FROM Orion.Nodes n", "Orion.Nodes")]
        [InlineData("SELECT n.Caption FROM (SELECT i.Name FROM Orion.Interfaces i) n", null)]
        public void GetPrimaryEntityName_UsesTopLevelFromSource(string query, string expectedEntityName)
        {
            QueryEntityNameParser.GetPrimaryEntityName(query).Should().Be(expectedEntityName);
        }
    }
}