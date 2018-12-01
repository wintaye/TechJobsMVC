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
        //[Route("/Search/Index")] //route it's coming from, View location 
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
            if (searchTerm != null)
            {
                if (searchType.Equals("all"))
                {
                    jobs = JobData.FindByValue(searchTerm);
                }
                else
                {
                    jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
                ViewBag.jobs = jobs;
                ViewBag.title = "Search Results";
                ViewBag.columns = ListController.columnChoices;
                return View("Index");
            }
            else
            {
                ViewBag.title = "Search Results";
                ViewBag.columns = ListController.columnChoices;
                return View("Index");
            }
        }
    }
}