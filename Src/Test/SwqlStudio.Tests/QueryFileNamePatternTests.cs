using System;
using FluentAssertions;
using Xunit;

namespace SwqlStudio.Tests
{
    public class QueryFileNamePatternTests
    {
        [Fact]
        public void Format_UsesCustomTimestampAndEntityPosition()
        {
            var timestamp = new DateTime(2024, 1, 2, 3, 4, 0);

            QueryFileNamePattern.Format("{entity}_{timestamp:yyyyMMdd_HHmm}", "Orion.Nodes", timestamp)
                .Should().Be("Orion.Nodes_20240102_0304.swql");
        }

        [Fact]
        public void Format_DefaultPatternPreservesExistingFilename()
        {
            var timestamp = new DateTime(2024, 1, 2, 3, 4, 0);

            QueryFileNamePattern.Format(QueryFileNamePattern.DefaultPattern, "Orion.Nodes", timestamp)
                .Should().Be("2024-01-02 03-04 Orion.Nodes.swql");
        }

        [Fact]
        public void TryFormat_InvalidPatternReturnsFalse()
        {
            QueryFileNamePattern.TryFormat("{entity}", "Orion.Nodes", DateTime.Now, out _).Should().BeFalse();
        }
    }
}