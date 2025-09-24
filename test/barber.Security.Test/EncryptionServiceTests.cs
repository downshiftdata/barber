using NSubstitute;

namespace barber.Security.Test
{
    public class EncryptionServiceTests
    {
        private readonly Microsoft.Extensions.Options.IOptions<SecurityOptions> _OptionsMock;

        public EncryptionServiceTests()
        {
            _OptionsMock = Substitute.For<Microsoft.Extensions.Options.IOptions<SecurityOptions>>();
            _OptionsMock.Value.Returns(new SecurityOptions() { AesIv = "changemechangeme", AesKey = "changemechangemechangemechangeme" });
        }

        [Xunit.Fact]
        public void TestDecrypt()
        {
            // Arrange
            var service = new Services.EncryptionService(_OptionsMock);

            // Act
            var value = service.Decrypt("VnZPloXbt005ykfahyZqhw==");

            // Assert
            Xunit.Assert.Equal("foobar", value);
        }

        [Xunit.Fact]
        public void TestEncrypt()
        {
            // Arrange
            var service = new Services.EncryptionService(_OptionsMock);

            // Act
            var value = service.Encrypt("foobar");

            // Assert
            Xunit.Assert.Equal("VnZPloXbt005ykfahyZqhw==", value);
        }

        [Xunit.Fact]
        public void TestOneWayEncrypt()
        {
            // Arrange
            var service = new Services.EncryptionService(_OptionsMock);

            // Act
            var value = service.OneWayEncrypt("foobar");

            // Assert
            Xunit.Assert.Equal("w6uP8Tcg6K2QR905Rms8iXTlksL6OD1KOWBxTK7wxPI=", value);
        }
    }
}