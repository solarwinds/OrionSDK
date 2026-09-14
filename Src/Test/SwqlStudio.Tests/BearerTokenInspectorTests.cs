using System.Net;
using System.ServiceModel.Channels;
using FluentAssertions;
using SolarWinds.InformationService.Contract2;
using Xunit;

namespace SwqlStudio.Tests
{
    public class BearerTokenInspectorTests
    {
        private static Message CreateEmptyMessage()
        {
            return Message.CreateMessage(MessageVersion.Soap11, "test/action");
        }

        [Fact]
        public void BeforeSendRequest_AddsAuthorizationHeader_WhenNoExistingProperty()
        {
            var inspector = new BearerTokenInspector(() => "mytoken");
            var message = CreateEmptyMessage();

            inspector.BeforeSendRequest(ref message, null);

            var prop = (HttpRequestMessageProperty)message.Properties[HttpRequestMessageProperty.Name];
            prop.Headers[HttpRequestHeader.Authorization].Should().Be("Bearer mytoken");
        }

        [Fact]
        public void BeforeSendRequest_MergesIntoExistingProperty_WhenHttpPropertyAlreadyPresent()
        {
            var inspector = new BearerTokenInspector(() => "mytoken");
            var message = CreateEmptyMessage();
            var existing = new HttpRequestMessageProperty();
            existing.Headers["X-Custom"] = "custom-value";
            message.Properties[HttpRequestMessageProperty.Name] = existing;

            inspector.BeforeSendRequest(ref message, null);

            var prop = (HttpRequestMessageProperty)message.Properties[HttpRequestMessageProperty.Name];
            prop.Headers[HttpRequestHeader.Authorization].Should().Be("Bearer mytoken");
            prop.Headers["X-Custom"].Should().Be("custom-value");
        }

        [Fact]
        public void BeforeSendRequest_InvokesTokenProviderOnEveryCall()
        {
            int callCount = 0;
            var inspector = new BearerTokenInspector(() =>
            {
                callCount++;
                return "token" + callCount;
            });

            var msg1 = CreateEmptyMessage();
            var msg2 = CreateEmptyMessage();

            inspector.BeforeSendRequest(ref msg1, null);
            inspector.BeforeSendRequest(ref msg2, null);

            callCount.Should().Be(2);
            var prop1 = (HttpRequestMessageProperty)msg1.Properties[HttpRequestMessageProperty.Name];
            var prop2 = (HttpRequestMessageProperty)msg2.Properties[HttpRequestMessageProperty.Name];
            prop1.Headers[HttpRequestHeader.Authorization].Should().Be("Bearer token1");
            prop2.Headers[HttpRequestHeader.Authorization].Should().Be("Bearer token2");
        }

        [Fact]
        public void CredentialType_ReturnsBearerValue()
        {
            var creds = new BearerTokenCredentials(() => "token");
            creds.CredentialType.Should().Be(CredentialType.Bearer);
        }
    }
}
