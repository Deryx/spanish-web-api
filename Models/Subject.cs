using System;

namespace SpanishWebApi.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public required string SubjectPronoun { get; set; }
        public required string SubjectTranslation { get; set; }
    }
}