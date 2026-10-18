using System;

namespace SpanishWebApi.Models
{
    public class Dictionary
    {
        public int WordId { get; set; }
        public required string WordText { get; set; }
        public required string Translation { get; set; }
        public required string Pronunciation { get; set; }
        public string? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}