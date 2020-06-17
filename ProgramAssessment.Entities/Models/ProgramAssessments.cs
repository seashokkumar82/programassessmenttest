using System;
using System.Collections.Generic;

namespace ProgramAssessment.Entities.Models
{
    public partial class ProgramAssessments
    {
        public ProgramAssessments()
        {
            Files = new HashSet<Files>();
        }

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
}
