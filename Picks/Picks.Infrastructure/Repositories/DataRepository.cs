using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picks.Core.Models;
using Picks.Infrastructure.DataAccess;
using Picks.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Picks.Infrastructure.Helpers;

namespace Picks.Infrastructure.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly PicksDatabaseContext ctx;
        private readonly IHostingEnvironment _appEnvironment;
        private IMemoryCache _memoryCache;

        public DataRepository(PicksDatabaseContext context, IHostingEnvironment appEnvironment, IMemoryCache cacheMemory)
        {
            ctx = context;
            _appEnvironment = appEnvironment;
            _memoryCache = cacheMemory;
        }

        public IEnumerable<Category> Categories => ctx.Categories;
        public IEnumerable<Category> GetCategories()
        {
            return ctx.Categories;
        }


        public IEnumerable<FileUpload> FileUploads => ctx.FileUploads;
        public IEnumerable<FileUpload> GetFileUploads()
        {
            return ctx.FileUploads.Include(x => x.Image);
        }


        public IEnumerable<FileUpload> GetFileUploadForCart()
        {
            return ctx.FileUploads;
        }


        public void AddANewCategory(string categoryName)
        {
            var cat = new Category();
            cat.Name = categoryName;
            ctx.Categories.Add(cat);
            ctx.SaveChanges();
        }


        public async Task<IActionResult> UploadAndSaveAllImages(UploadImageViewModel viewModObj, ICollection<IFormFile> images)
        {
            //Create "MyImages" folder on wwwroot, where will be saved images on disk!
            var imageFolder = "\\MyImages";

            // Define wwwroot
            string rootPath = _appEnvironment.WebRootPath;

            // Create path for imageFolder folder; //wwwroot/MyImages
            string imageFolderPath = rootPath + imageFolder;

            // Create targetFolder path where will be saved a folder name (viewModObj.Image.FileName;)
            //Example: wwwroot/MyImages\\Animals
            string targetFolder = imageFolderPath + "\\" + viewModObj.Image.FileName;

            // Create Registration folder
            Directory.CreateDirectory(targetFolder);

            // Create an empty array "imagesGallery" to store each image
            List<FileUpload> imagesGallery = new List<FileUpload>();

            string targetFileName = "";

            foreach (var image in images)
            {
                Guid uniqueGuid = Guid.NewGuid();
                targetFileName = uniqueGuid + "-" + image.FileName;
                string finalTargetFilePath = targetFolder + "\\" + targetFileName;

                // Replace backslash with forward slash
                finalTargetFilePath = finalTargetFilePath.Replace("\\", "/");


                //Save images into RegNr folder on disk
                if (image.Length > 0)
                {
                    using (var stream = new FileStream(finalTargetFilePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                }


                // Dinamic saving path
                var imageProperty = new FileUpload
                {

                    FileTitle = uniqueGuid,
                    FilePath = imageFolder.Replace("\\", "/") + "/" + viewModObj.Image.FileName + "/" + targetFileName
                };
                imagesGallery.Add(imageProperty);
            }

            // Save images to database
            viewModObj.Image.FileUpload = imagesGallery;
            viewModObj.Image.DateAdded = DateTime.Now;
            viewModObj.Image.CategoryId = viewModObj.CategoryId;


            // viewModObj object will take the URL path
            viewModObj.Image.ImageUrl = viewModObj.Image.FileName.ToString() + "/" + targetFileName.ToString();


            //! Important = > First removes all cache on upload images
            _memoryCache.Remove(CacheKeysClass.AllImagesFound);

            // Add in Images DataBase a new viewModObj
            ctx.Images.Add(viewModObj.Image);
            await ctx.SaveChangesAsync();

            return new OkResult();
        }
    }
}
