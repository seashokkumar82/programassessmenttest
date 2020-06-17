using System;
using System.Collections.Generic;

namespace ProgramAssessment.Entities.Models
{
    public partial class Files
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string FileExtention { get; set; }
        public string VideoLink { get; set; }
        public int? ProgramAssessId { get; set; }

        public ProgramAssessments ProgramAssess { get; set; }
    }
}
