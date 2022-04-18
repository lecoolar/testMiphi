using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testMiphi.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string PublishingHouse { get; set; }
        public string Section { get; set; }
        public bool IsAvailability { get; set; }
        public string SubjectiveAssessment { get; set; }

        public Book(long id, string author, string publishingHouse, string section, bool isAvailability, string subjectiveAssessment)
        {
            Id = id;
            Author = author;
            PublishingHouse = publishingHouse;
            Section = section;
            IsAvailability = isAvailability;
            SubjectiveAssessment = subjectiveAssessment;
        }
    }
}
