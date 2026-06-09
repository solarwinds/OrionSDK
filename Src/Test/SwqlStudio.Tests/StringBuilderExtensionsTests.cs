using System;
using System.Collections.Generic;
using System.Text;
using SwqlStudio.Metadata;
using Xunit;

namespace SwqlStudio.Tests
{
    public class StringBuilderExtensionsTests
    {
        [Fact]
        public void AllMethodsThrowExceptionOnNullBuilder()
        {
            StringBuilder stringBuilder = null;
            var methods = new List<Action>
            {
                () => stringBuilder.AppendName(string.Empty),
                () => stringBuilder.AppendType(string.Empty),
                () => stringBuilder.AppendObsoleteSection(null),
                () => stringBuilder.AppendSummary(string.Empty),
                () => stringBuilder.AppendSummaryParagraph(string.Empty),
                () => stringBuilder.AppendAccessControl(null, null),
            };

            foreach (Action method in methods)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    method();
                });    
            }
        }

        [Theory]
        [MemberData(nameof(AppendSummaryTrimsInputTestCases))]
        public void AppendSummaryTests(string input, string expected)
        {
            TestAppendMethod(input, expected, (s, stringB) => stringB.AppendSummary(s));
        }

        public static IEnumerable<object[]> AppendSummaryTrimsInputTestCases = new List<object[]>
        {
            new object[]{ "a", "a"},
            new object[]{ "a ", "a"},
            new object[]{ " a", "a"},
            new object[]{ null, ""},
            new object[]{ string.Empty, ""},
            new object[]{ "  a", "a"},
            new object[]{ "a {0} ", "a {0}"}
        };

        [Theory]
        [MemberData(nameof(AppendSummaryParagraphTestCases))]
        public void AppendSummaryParagraphTests(string input, string expected)
        {
            TestAppendMethod(input, expected, (s, stringB) => stringB.AppendSummaryParagraph(s));
        }

        public static IEnumerable<object[]> AppendSummaryParagraphTestCases = new List<object[]>
        {
            new object[]{ "a ", $"{Environment.NewLine}{Environment.NewLine}a"},
            new object[]{ " ", $"{Environment.NewLine}{Environment.NewLine}"}
        };


        [Theory]
        [MemberData(nameof(AppendNameTestCases))]
        public void AppendNameTests(string input, string expected)
        {
            TestAppendMethod(input, expected, (s, stringB) => stringB.AppendName(s));
        }

        public static IEnumerable<object[]> AppendNameTestCases = new List<object[]>
        {
            new object[]{ "a", $"Name: a{Environment.NewLine}"},
            new object[]{ string.Empty, $"Name: {Environment.NewLine}"},
        };

        [Theory]
        [MemberData(nameof(AppendTypeTestCases))]
        public void AppendTypeTests(string input, string expected)
        {
            TestAppendMethod(input, expected, (s, stringB) => stringB.AppendType(s));
        }

        public static IEnumerable<object[]> AppendTypeTestCases = new List<object[]>
        {
            new object[]{ "a", $"Type: a{Environment.NewLine}"},
            new object[]{ string.Empty, $"Type: {Environment.NewLine}"},
        };

        [Theory]
        [MemberData(nameof(AppendObsoleteSectionTestCases))]
        public void AppendObsoleteSectionTests(string input, string expected, bool isObsolete)
        {
            IObsoleteMetadata entity = new Entity { IsObsolete = isObsolete, ObsolescenceReason = input };
            TestAppendMethod(input, expected, (s, stringB) => stringB.AppendObsoleteSection(entity));
        }

        public static IEnumerable<object[]> AppendObsoleteSectionTestCases = new List<object[]>
        {
            new object[]{ "a", $"Obsolete: a{Environment.NewLine}", true},
            new object[]{ string.Empty, $"Obsolete: {Environment.NewLine}", true},
            new object[]{ string.Empty, string.Empty, false},
        };

        [Fact]
        public void AppendAccessControlTests_IsIndication()
        {
            var stringBuilder = new StringBuilder();

            var connectionInfo = new ConnectionInfo("localhost", "admin", "pass", "orion");
            var entity = new Entity { IsIndication = true };

            stringBuilder.AppendAccessControl(connectionInfo, entity);

            var result = stringBuilder.ToString();

            Assert.Equal("Can Subscribe: False", result);
        }

        [Fact]
        public void AppendAccessControlTests_NotIndication()
        {
            var stringBuilder = new StringBuilder();

            var connectionInfo = new ConnectionInfo("localhost", "admin", "pass", "orion");
            var entity = new Entity { IsIndication = false };

            stringBuilder.AppendAccessControl(connectionInfo, entity);

            var result = stringBuilder.ToString();

            Assert.Equal(
                $"Can Read: False{Environment.NewLine}" +
                $"Can Create: False{Environment.NewLine}" +
                $"Can Update: False{Environment.NewLine}" +
                $"Can Delete: False{Environment.NewLine}",
                result);
        }


        private static void TestAppendMethod(string input, string expected, Action<string, StringBuilder> funcToTest)
        {
            var stringBuilder = new StringBuilder();
            funcToTest(input, stringBuilder);
            var result = stringBuilder.ToString();
            Assert.Equal(expected, result);
        }

    }
}
