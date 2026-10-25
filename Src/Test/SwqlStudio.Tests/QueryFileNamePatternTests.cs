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
                .Should().Be("2024-01-02 03-04-00 Orion.Nodes.swql");
        }

        [Fact]
        public void TryFormat_InvalidPatternReturnsFalse()
        {
            QueryFileNamePattern.TryFormat("{entity}", "Orion.Nodes", DateTime.Now, out _).Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("{timestamp:%}")]
        public void TryFormat_EmptyPatternOrInvalidTimestampFormatReturnsFalse(string pattern)
        {
            QueryFileNamePattern.TryFormat(pattern, "Orion.Nodes", DateTime.Now, out _).Should().BeFalse();
        }

        [Fact]
        public void Format_ReplacesInvalidFileNameCharactersInEntity()
        {
            var timestamp = new DateTime(2024, 1, 2, 3, 4, 0);

            QueryFileNamePattern.Format("{timestamp:yyyyMMdd} {entity}", "a:b/c*d", timestamp)
                .Should().Be("20240102 a_b_c_d.swql");
        }

        [Fact]
        public void Format_EntityWithBracesDoesNotThrow()
        {
            var timestamp = new DateTime(2024, 1, 2, 3, 4, 0);

            QueryFileNamePattern.Format(QueryFileNamePattern.DefaultPattern, "x{y}", timestamp)
                .Should().Be("2024-01-02 03-04-00 x_y_.swql");
        }

        [Fact]
        public void Format_DoesNotDuplicateSwqlExtension()
        {
            var timestamp = new DateTime(2024, 1, 2, 3, 4, 0);

            QueryFileNamePattern.Format("{timestamp:yyyyMMdd}.swql", null, timestamp)
                .Should().Be("20240102.swql");
        }
    }
}