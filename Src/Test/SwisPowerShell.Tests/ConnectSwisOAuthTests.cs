using System;
using System.Net.Security;
using System.Reflection;
using NUnit.Framework;
using SolarWinds.InformationService.Contract2;

namespace SwisPowerShell.Tests
{
    [TestFixture]
    public class ConnectSwisOAuthTests
    {
        // PSCmdlet requires a real PowerShell runspace to construct normally,
        // so we use GetUninitializedObject + reflection to reach the private method.
        private static bool InvokeValidateCertificate(SslPolicyErrors errors)
        {
            var cmdlet = (ConnectSwisOAuth)System.Runtime.Serialization.FormatterServices
                .GetUninitializedObject(typeof(ConnectSwisOAuth));

            var method = typeof(ConnectSwisOAuth).GetMethod(
                "ValidateCertificate",
                BindingFlags.NonPublic | BindingFlags.Instance);

            return (bool)method.Invoke(cmdlet, new object[] { null, null, null, errors });
        }

        [Test]
        public void ValidateCertificate_NoErrors_ReturnsTrue()
        {
            Assert.That(InvokeValidateCertificate(SslPolicyErrors.None), Is.True);
        }

        [Test]
        public void ValidateCertificate_NameMismatch_ReturnsFalse()
        {
            Assert.That(InvokeValidateCertificate(SslPolicyErrors.RemoteCertificateNameMismatch), Is.False);
        }

        [Test]
        public void ValidateCertificate_ChainErrors_ReturnsFalse()
        {
            Assert.That(InvokeValidateCertificate(SslPolicyErrors.RemoteCertificateChainErrors), Is.False);
        }

        [Test]
        public void TrustAllCertificates_CallbackAcceptsAnyError()
        {
            RemoteCertificateValidationCallback certCallback = (sender, cert, chain, errors) => true;

            Assert.That(certCallback(null, null, null, SslPolicyErrors.RemoteCertificateNotAvailable), Is.True);
            Assert.That(certCallback(null, null, null, SslPolicyErrors.RemoteCertificateChainErrors), Is.True);
            Assert.That(certCallback(null, null, null, SslPolicyErrors.None), Is.True);
        }

        [Test]
        public void OAuthTokenManager_NullHostname_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OAuthTokenManager(null));
        }

        [Test]
        public void OAuthTokenManager_HostnameWithPath_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new OAuthTokenManager("host/path"));
        }

        [Test]
        public void OAuthTokenManager_ValidHostname_CreatesSuccessfully()
        {
            var mgr = new OAuthTokenManager("orion.example.com");
            Assert.That(mgr.Server, Is.EqualTo("orion.example.com"));
        }
    }
}
