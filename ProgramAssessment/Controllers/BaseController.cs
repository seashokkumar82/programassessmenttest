using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProgramAssessment.Entities.Models;
using ProgramAssessment.ViewModels;

namespace ProgramAssessment.Controllers
{
    public class BaseController : Controller
    {
        private iContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public BaseController(iContext ic, IHostingEnvironment appEnvironment)
        {
            _context = ic;
            _appEnvironment = appEnvironment;
        }
        public virtual IActionResult Index(string id)
        {
            var model = new ProgramAssessmentVM();
            if (string.IsNullOrEmpty(id))
            {
                return View(model);
            }
            else
            {
                //Guid i;
                
                if (IsValidGuid(id))
                {
                    var gid = ParseGuid(id);
                    //Guid gid = new Guid(id);
                    //var ids = Guid.TryParse(gid, out i);
                    if (gid != null)
                    {
                        var getDetails = (from c in _context.ProgramAssessments
                                          where c.RowUniqueId == gid
                                          select c).ToList();

                        if (getDetails.Any())
                        {
                            model.JobTitle = getDetails[0].JobTitle;
                            model.CompanyInfo = getDetails[0].CompanyInfo;
                            model.Description = getDetails[0].Description;
                            model.CandidateProfile = getDetails[0].CandidateProfile;
                            model.ApplicationInformation = getDetails[0].AccountInfo;
                            //model.Id = getDetails[0].Id.ToString();
                            model.Identifier = getDetails[0].RowUniqueId.ToString();
                            ViewBag.File = "jobs.jpg";
                            return View(model);
                        }
                        else
                        {
                            ViewData["Error"] = "Your requested data not available";
                            return View(model);
                        }
                    }
                    else
                    {
                        ViewData["Error"] = "Invalid parameter";
                        return View(model);
                    }
                }
                else
                {
                    ViewData["Error"] = "Invalid parameter";
                    return View(model);
                }
            }
        }

        [HttpPost]
        public IActionResult Create(ProgramAssessmentVM pavm)
        {
            if (ModelState.IsValid)
            {
                var pa = new ProgramAssessments();
                pa.JobTitle = pavm.JobTitle;
                pa.CompanyInfo = pavm.CompanyInfo;
                pa.Description = pavm.Description;
                pa.CandidateProfile = pavm.CandidateProfile;
                pa.AccountInfo = pavm.ApplicationInformation;
                pa.FilePath = GetWwwRootPath(_appEnvironment);
                //pa.Id = pavm.Identifier != null ? GetProgramAssessment(pavm.Identifier) : pavm.Id;

                if (!string.IsNullOrEmpty(pavm.Identifier))
                {
                    var i = ParseGuid(pavm.Identifier.ToString());
                    pa.Id = GetProgramAssessment(i);
                    pa.RowUniqueId = ParseGuid(pavm.Identifier);
                    // _context.Entry(pa).State = EntityState.Modified;
                    _context.Update(pa);
                }
                else
                {
                    pa.RowUniqueId = Guid.NewGuid();
                    
                    _context.ProgramAssessments.Add(pa);
                }

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewData["Error"] = "Unexpected error. Please try again";
                    return View("Index", pavm);
                }
                pavm.Identifier = pa.RowUniqueId.ToString();
                ViewData["Success"] = "Your data saved successfully";
                ViewBag.File = "jobs.jpg";
                return View("Index", pavm);
            }
            else
            {
                ViewData["Error"] = "Please fill all the fields";
                return View("Index", pavm);
            }
        }

        protected IActionResult GetProgramAssessment(ProgramAssessmentVM pavm)
        {
            ViewData["Success"] = "Your data saved successfully";
            ViewBag.File = "jobs.jpg";
            return View("Index", pavm);
        }

        protected int GetProgramAssessment(Guid id)
        {
            var getDetails = (from c in _context.ProgramAssessments
                              where c.RowUniqueId == id
                              select c.Id).ToList();

            return getDetails[0];
        }

        protected string GetWwwRootPath(IHostingEnvironment _environment)
        {
            var path = string.Empty;

            if (!string.IsNullOrWhiteSpace(_environment.WebRootPath))
            {
                path = Path.Combine("~", "\\wwwroot\\images");
            }

            return path;
        }

        protected Guid ParseGuid(string id)
        {           
            return Guid.Parse(id.Replace("\"", ""));            
        }

        protected bool IsValidGuid(string id)
        {
            var isValidInput = true;

            try
            {
                Guid.Parse(id.Replace("\"", ""));                
            }
            catch (Exception ex)
            {
                isValidInput =  false;
            }

            return isValidInput;
        }
    }
}