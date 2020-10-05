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
        public string ShortenUrl([FromBody] UrlData url)
        {
            var shortUrl = _linkShortener.ShortenLink(url.Url);
            return shortUrl;
        }

        public class UrlData
        {
            public string Url { get; set; }
        }
    }
}