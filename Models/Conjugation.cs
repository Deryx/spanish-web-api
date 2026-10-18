using System;

namespace SpanishWebApi.Models
{
    public class Conjugation
    {
        public int ConjugationId { get; set; }
        public required string ConjugationText { get; set; }
        public int SubjectId { get; set; }
        public required Subject Subject { get; set; }    
        public int TenseId { get; set; }
        public required Tense Tense { get; set; }
        public int VerbId { get; set; }
        public required Verb Verb { get; set; }
    }
}       