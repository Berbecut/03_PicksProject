using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Picks.Infrastructure.Repositories;
using Picks.Infrastructure.ViewModels;

namespace Picks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository repo;

        public HomeController(IDataRepository repository)
        {
            repo = repository;
        }

        public IActionResult Index()
        {
            var AllImages = repo.GetFileUploads().OrderByDescending(x=>x.Image.DateAdded);

            var viewModelObj = new FileUploadViewModel
            {
                FileUpload = AllImages.ToList()
            };

            return View(viewModelObj);
        }
    }
}
