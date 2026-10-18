using System;

namespace SpanishWebApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryText { get; set; }
    }
}   