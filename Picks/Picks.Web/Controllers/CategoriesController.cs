using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Picks.Core.Models;
using Picks.Infrastructure.DataAccess;
using Picks.Infrastructure.Helpers;
using Picks.Infrastructure.Repositories;
using Picks.Infrastructure.ViewModels;

namespace Picks.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IDataRepository repo;
        private IMemoryCache _memoryCache;

        public CategoriesController(IDataRepository repository, IMemoryCache memoryCache)
        {
            repo = repository;
            _memoryCache = memoryCache;
        }


        public IActionResult Index(BrowseImagesViewModel viewModel)
        {
            //Implement an empty cache List named cacheEntryList
            List<FileUpload> cacheEntryList;

            if (!_memoryCache.TryGetValue(CacheKeysClass.AllImagesFound, out cacheEntryList))
            {
                // cacheEntryList will be created taking images from DataRepository using repo.GetFileUploads()
                cacheEntryList = repo.GetFileUploads().OrderByDescending(x => x.Image.DateAdded).ToList();

                // Add image in CacheKeysClass in AllImagesFound property
                _memoryCache.Set(CacheKeysClass.AllImagesFound, cacheEntryList);
            }


            var listOfAllCategories = repo.GetCategories().ToList();
            var IdForAllCategories = repo.GetCategories().Where(x => x.Id == viewModel.CategoryId).FirstOrDefault();

            if (viewModel.CategoryId == 0 || IdForAllCategories.Name == "All Categories")
            {
                //Initial, before to implement cache, AllImages came from DataRepository
                //var AllImages = repo.GetFileUploads().ToList();


                var viewObjectWithCache = new BrowseImagesViewModel
                //{ FileUpload = AllImages };

                // Now, FileUpload property of viewObjectWithCache object is taken from cacheEntryList instead of AllImages
                { FileUpload = cacheEntryList };

                viewObjectWithCache.Categories = listOfAllCategories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                return View(viewObjectWithCache);
            }
            else
            {
                // Initial, before to implement cache, AllImages came from DataRepository using repo.GetFileUploads()
                //var AllImages = repo.GetFileUploads().ToList();

                var selectedViewObject = new List<FileUpload>();

                //selectedViewObject contains initial AllImages from DB with specific CategoryId
                //selectedViewObject = AllImages.Where(x => x.Image.CategoryId == vm.CategoryId).ToList();


                // Now, selectedViewObject list is taken from cacheEntryList 
                selectedViewObject = cacheEntryList.Where(x => x.Image.CategoryId == viewModel.CategoryId).ToList();


                var objectWithCache = new BrowseImagesViewModel

                // Now, FileUpload property of objectWithCache object is taken from selectedViewObject list
                { FileUpload = selectedViewObject };

                objectWithCache.Categories = listOfAllCategories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()

                });

                return View(objectWithCache);
            }
        }
    }
}