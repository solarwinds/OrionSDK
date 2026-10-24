using FluentAssertions;
using Xunit;

namespace SwqlStudio.Tests
{
    public class RecentFilesTests
    {
        [Fact]
        public void Add_PutsNewFileFirst()
        {
            RecentFiles.Add(new[] { @"C:\a.swql", @"C:\b.swql" }, @"C:\c.swql", 10)
                .Should().Equal(@"C:\c.swql", @"C:\a.swql", @"C:\b.swql");
        }

        [Fact]
        public void Add_MovesExistingFileToTopIgnoringCase()
        {
            RecentFiles.Add(new[] { @"C:\a.swql", @"C:\b.swql" }, @"c:\B.swql", 10)
                .Should().Equal(@"c:\B.swql", @"C:\a.swql");
        }

        [Fact]
        public void Add_TrimsToMaxCount()
        {
            RecentFiles.Add(new[] { @"C:\a.swql", @"C:\b.swql" }, @"C:\c.swql", 2)
                .Should().Equal(@"C:\c.swql", @"C:\a.swql");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Parse_EmptySettingReturnsNoItems(string packed)
        {
            RecentFiles.Parse(packed).Should().BeEmpty();
        }

        [Fact]
        public void Parse_SplitsPathsContainingSemicolons()
        {
            RecentFiles.Parse(@"C:\x;y\a.swql|C:\b.swql")
                .Should().Equal(@"C:\x;y\a.swql", @"C:\b.swql");
        }
    }
}
