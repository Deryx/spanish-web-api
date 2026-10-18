using System;

namespace SpanishWebApi.Models
{
    public class Tense
    {
        public int TenseId { get; set; }
        public required string TenseText { get; set; }
    }
}