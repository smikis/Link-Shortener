using System;

namespace Api.Domain.DatabaseService.Models
{
    public class ShortLink
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}