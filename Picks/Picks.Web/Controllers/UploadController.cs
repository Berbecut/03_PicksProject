using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Picks.Infrastructure.Repositories;
using Picks.Infrastructure.ViewModels;

namespace Picks.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly IDataRepository repo;


        public UploadController(IDataRepository repository)
        {
            repo = repository;
        }


        public IActionResult Index()
        {
            var viewModObj = new UploadImageViewModel();

            var listOfCategories = repo.GetCategories().ToList();

            viewModObj.Categories = listOfCategories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            return View(viewModObj);
        }


        public IActionResult CreateNewCategory(string categoryName)
        {
            repo.AddANewCategory(categoryName);

            //Implementation in Upload/Index.cshtml
            TempData["Success"] = $"Success! The category \"{categoryName}\" has been added";

            return RedirectToAction("Index", "Upload");
        }


        [HttpPost]
        public async Task<IActionResult> UploadNewImages(UploadImageViewModel viewModObj, ICollection<IFormFile> images)
        {
            if (images.Count() != 0)
            {
                foreach (var image in images)
                {
                    if (Path.GetExtension(image.FileName) != ".jpeg"
                        &&
                        Path.GetExtension(image.FileName) != ".jpg"
                        &&
                        Path.GetExtension(image.FileName) != ".png")
                    {
                        TempData["FileNotAccepted"] = "File not accepted." +
                            " File must be of type jpg, jpeg or png";
                        return RedirectToAction("Index", "Upload");
                    }
                    else
                    {
                        if (viewModObj.Image.FileName == null)
                        {
                            TempData["InfoName"] = "Please type a folder name";
                            return RedirectToAction("Index", "Upload");
                        }
                        else
                        {
                            await repo.UploadAndSaveAllImages(viewModObj, images);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            else
            {
                if (viewModObj.Image.FileName != null)
                {
                    //Implementation in Upload/Index.cshtml
                    TempData["Info"] = "There is no images selected, please choose one or more!";
                    return RedirectToAction("Index", "Upload");
                }
                else
                {
                    TempData["InfoName"] = "Please choose a image and type a folder name where you want to save your photo !";
                    return RedirectToAction("Index", "Upload");
                }
            }
            return Ok();
        }
    }
}