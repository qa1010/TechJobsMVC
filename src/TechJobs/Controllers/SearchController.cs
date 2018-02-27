using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();


            if (searchTerm == null)
            {
                if (searchType != "all")
                {
                    ViewBag.jobs = jobs;
                }

                else if (searchType == "all")
                {
                    jobs = JobData.FindAll();
                    ViewBag.title = "All Jobs";
                    ViewBag.jobs = jobs;
                }
            }

            else if (searchTerm != null)
            {
                if (searchType == "all")
                {
                    jobs = JobData.FindByValue(searchTerm);
                    ViewBag.title = "All Jobs";
                    ViewBag.jobs = jobs;
                }
                else
                {
                    jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
            }
            ViewBag.jobs = jobs;
            return View(viewName: "Index");
        }
    }

}
