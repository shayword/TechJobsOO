using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using System;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view
            Models.Job job = null;
            foreach (var tempJob in jobData.Jobs)
            {
                if (tempJob.ID == id)
                {
                    job = tempJob;
                    break;
                }
            }

            if (job == null)
            {
                return Content($"No job found with id {id}.");
            }
            else
            {
                ViewBag.title = $"{job.Name}, {job.Employer.Value}";
                return View(job);
            }            
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if(ModelState.IsValid)
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            return View(newJobViewModel);
        }
    }
}
