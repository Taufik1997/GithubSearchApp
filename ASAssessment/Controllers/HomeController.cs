using ASAssessment.Services.Interfaces;
using System;
using System.Web.Mvc;

namespace ASAssessment.Controllers
{
    public class HomeController : Controller
    {

        private readonly IGithubService _githubService;

        public HomeController(IGithubService githubService)
        {
            _githubService = githubService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchUser(string username)
        {
            try
            {
                var viewModel = _githubService.GetUserAndRepositories(username);

                if (viewModel is null)
                    return RedirectToAction("Index");

                return View("Result", viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }

        }

    }
}