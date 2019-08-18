using Api.Domain.UrlHasher;
using Xunit;

namespace Api.Tests.UrlHasher
{
    public class DecodeUrl
    {
        [Fact]
        public void Should_Correctly_Decode_Url()
        {
            var encoder = new UrlBaseEncoder();
            var result = encoder.DecodeUrl("bM");
            Assert.Equal(100, result);
        }
    }
}