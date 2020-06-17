using System;
using System.Collections.Generic;

namespace ProgramAssessment.Models
{
    public class PorgramAssessment
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string CompanyInfo { get; set; }
        public string Description { get; set; }
        public string CandidateProfile { get; set; }
        public string AccountInfo { get; set; }
        public string FilePath { get; set; }
        public Guid RowUniqueId { get; set; }

        public ICollection<Files> Files { get; set; }
    }

    public class Files
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string FileExtention { get; set; }
        public string VideoLink { get; set; }
        public int? ProgramAssessId { get; set; }        
    }
}
