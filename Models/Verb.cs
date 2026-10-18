using System;

namespace SpanishWebApi.Models
{
    public class Verb
    {
        public int VerbId { get; set; }
        public required string Infinitive { get; set; }
        public required string Translation { get; set; }
        public required string Pronunciation { get; set; }
    }
}   