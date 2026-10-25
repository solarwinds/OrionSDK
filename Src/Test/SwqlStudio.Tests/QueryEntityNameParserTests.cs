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
        [InlineData("SELECT 'from' AS x FROM Orion.Nodes", "Orion.Nodes")]
        [InlineData("SELECT 'it''s from (here' AS x FROM Orion.Nodes", "Orion.Nodes")]
        [InlineData("-- don't\nSELECT n.Caption FROM Orion.Nodes n", "Orion.Nodes")]
        [InlineData("SELECT n.Caption FROM Orion.Nodes AS n", "Orion.Nodes")]
        [InlineData("SELECT TOP 5 * FROM Orion.Nodes WHERE NodeID = 1", "Orion.Nodes")]
        [InlineData("SELECT 1 AS x", null)]
        [InlineData("SELECT a) FROM Orion.Nodes", null)]
        public void GetPrimaryEntityName_UsesTopLevelFromSource(string query, string expectedEntityName)
        {
            QueryEntityNameParser.GetPrimaryEntityName(query).Should().Be(expectedEntityName);
        }
    }
}