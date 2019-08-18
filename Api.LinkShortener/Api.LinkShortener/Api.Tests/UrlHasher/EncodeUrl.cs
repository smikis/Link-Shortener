using Api.Domain.UrlHasher;
using Xunit;

namespace Api.Tests.UrlHasher
{
    public class EncodeUrl
    {
        [Fact]
        public void Should_Correctly_Encode_Number()
        {
            var encoder = new UrlBaseEncoder();
            var result = encoder.EncodeUrl(100);
            Assert.Equal("bM", result);
        }
    }
}