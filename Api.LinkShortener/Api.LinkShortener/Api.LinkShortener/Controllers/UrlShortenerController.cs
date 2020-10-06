using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.LinkShortener;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.LinkShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly ILinkShortener _linkShortener;
        public UrlShortenerController(ILinkShortener linkShortener)
        {
            _linkShortener = linkShortener;
        }
        // POST api/urlShortener
        [HttpPost]
        public async Task<string> ShortenUrl([FromBody] UrlData url)
        {
            var shortUrl = await _linkShortener.ShortenLink(url.Url);
            return shortUrl;
        }

        [HttpGet]
        [Route("{shortUrl}")]
        public string GetFullUrl(string shortUrl)
        {
            var fullUrl = _linkShortener.GetFullUrl(shortUrl);
            return fullUrl;
        }

        public class UrlData
        {
            public string Url { get; set; }
        }
    }
}