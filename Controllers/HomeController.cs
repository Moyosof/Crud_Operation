using CRUD_Operation.Inferfaces;
using CRUD_Operation.Models;
using CRUD_Operation.ViewModel;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_Operation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobService _jobService;

        public HomeController(ILogger<HomeController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        [Authorize]

        public async Task<IActionResult> Index()
        {
            var job = await _jobService.GetJobs();
            return View(job);
        }

        [Authorize]
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddJob(JobViewModel jobView)
        {
            if (ModelState.IsValid)
            {
                var job = await _jobService.AddJob(jobView);
                return RedirectToAction("Index", job);
            }
            return View("Add", jobView);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var obj = await _jobService.GetJobById(id);
            return View(obj);
        }

        [Authorize]

        [HttpPost]

        public async Task<IActionResult> UpdateJob(Job job)
        {
            if (ModelState.IsValid)
            {
                await _jobService.UpdateJob(job);
                return RedirectToAction("Index", job);
            }
            return View("Update", job);
        }

        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _jobService.GetJobById(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteJob(Job job)
        {
            await _jobService.DeleteJob(job);
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}