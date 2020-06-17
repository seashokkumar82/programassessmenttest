using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgramAssessment.Entities.Models;
using ProgramAssessment.Models;
using ProgramAssessment.ViewModels;
using Files = ProgramAssessment.Entities.Models.Files;

namespace ProgramAssessment.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(iContext ic, IHostingEnvironment appEnvironment) : base(ic, appEnvironment)
        {            
        }
    }
}
