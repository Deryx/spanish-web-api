using System;

namespace SpanishWebApi.Models
{
    public class ConjugationsWide
    {
        public int ConjugationId { get; set; }
        public required string Yo { get; set; }
        public required string Tu { get; set; }
        public required string El { get; set; }
        public required string Nosotros { get; set; }
        public required string Vosotros { get; set; }
        public required string Ellos { get; set; }
        public required int VerbId { get; set; }
        public required Verb Verb { get; set; }
        public required int TenseId { get; set; }
        public required Tense Tense { get; set; }
}
}