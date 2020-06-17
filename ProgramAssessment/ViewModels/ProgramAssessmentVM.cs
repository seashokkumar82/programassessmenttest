using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramAssessment.ViewModels
{
    public class ProgramAssessmentVM
    {
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Display(Name = "Picture or Video")]
        public List<GetFiles> GetFiles { get;set;}

        [Required]
        [Display(Name = "Company Information")]
        public string CompanyInfo { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Candidate Profile")]
        public string CandidateProfile { get; set; }

        [Required]
        [Display(Name = "Application Information")]
        public string ApplicationInformation { get; set; }

        //public string Id { get; set; }

        public string Identifier { get; set; }
    }

    public class GetFiles
    {
        public string FilePath { get; set; }

    }
}
