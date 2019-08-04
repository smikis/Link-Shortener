using Api.Domain.UrlHasher;
using Xunit;

namespace Api.Tests.UrlHasher
{
    public class EncodeUrlInBase62
    {
        [Fact]
        public void Should_Correctly_Encode_Number_In_Base62()
        {
            var encoder = new UrlBaseEncoder();
            var result = encoder.EncodeUrlInBase62(100);
            Assert.Equal("bM", result);
        }
    }
}