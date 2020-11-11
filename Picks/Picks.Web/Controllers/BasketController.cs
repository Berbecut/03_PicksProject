using System.IO;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Picks.Core.Models;
using Picks.Infrastructure.Repositories;
using Picks.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace Picks.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IDataRepository repo;

        private Cart _cart;

        private readonly IHostingEnvironment _environment;

        public BasketController(Cart cart, IDataRepository repository, IHostingEnvironment environment)
        {
            _cart = cart;
            repo = repository;
            _environment = environment;
        }

        public IActionResult Index(string returnThisUrl)
        {
            var viewModel = new ImageCartViewModel
            {
                Cart = _cart,
                ReturnUrl = returnThisUrl
            };

            return View(viewModel);
        }


        public RedirectToActionResult AddImageToCart(int id, string returnUrl)
        {
            var oneImage = repo.GetFileUploadForCart().FirstOrDefault(x => x.Id.Equals(id));
            if (oneImage != null)
            {
                _cart.AddImage(oneImage, 1);
            }
            return RedirectToAction("Index", "Categories");
        }


        public RedirectToActionResult RemoveImageFromCart(int id, string returnUrl)
        {
            var fileUploadObject = repo.GetFileUploadForCart().FirstOrDefault(x => x.Id.Equals(id));
            if (fileUploadObject != null)
            {
                _cart.RemoveCartRow(fileUploadObject);
            }

            return RedirectToAction(nameof(Index), new { returnUrl });
        }


        public IActionResult DeleteAllFromCart(string returnUrl)
        {
            _cart.EmptyCart();
            return RedirectToAction(nameof(Index), new { returnUrl });
        }


        public IActionResult DownloadOnlyAnImage(int UploadIdForDownloadAnImage)
        {
            var FileUploadToDownloadAnImage = repo.GetFileUploadForCart().Where(x => x.Id == UploadIdForDownloadAnImage).FirstOrDefault();

            string webRootPath = _environment.WebRootPath;

            byte[] onebyte;

            using (var memoryStream = new MemoryStream())
            {
                using (var oneImageZip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))

                    //Implement download using local server
                    //imagezip.CreateEntryFromFile($"F:/Florin/Campus Varnamo_02/02 Molnbaserat_arkitektur/Florin_Picks/Picks/Picks.Web/wwwroot{FileUploadToDownload.FilePath}", FileUploadToDownload.FileTitle.ToString() + ".jpg", CompressionLevel.Fastest);

                    //Implement download using Azure server
                    oneImageZip.CreateEntryFromFile($"{webRootPath}/{FileUploadToDownloadAnImage.FilePath}", FileUploadToDownloadAnImage.FileTitle.ToString() + ".jpg", CompressionLevel.Fastest);

                onebyte = memoryStream.ToArray();
            }
            return File(onebyte, "application/zip", "One image.zip");
        }


        public IActionResult DownloadZipAllPhotos()
        {
            //Estabish string for wwwroot => F:\\Florin\\Campus Varnamo_02\\02 Molnbaserat_arkitektur\\Florin_Picks\\Picks\\Picks.Web\\wwwroot
            string thisWebRootPath = _environment.WebRootPath;

            byte[] moreBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var allImagesZip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    foreach (var image in _cart.CartRows)

                        //Implement downloadAll on local server
                        //imagezip.CreateEntryFromFile($"F:/Florin/Campus Varnamo_02/02 Molnbaserat_arkitektur/Florin_Picks/Picks/Picks.Web/wwwroot{image.FileUpload.FilePath}", image.FileUpload.FileTitle.ToString() + ".jpg", CompressionLevel.Fastest);

                        //Implement downloadAll using Azure
                        allImagesZip.CreateEntryFromFile($"{thisWebRootPath}/{image.FileUpload.FilePath}", image.FileUpload.FileTitle.ToString() + ".jpg", CompressionLevel.Fastest);

                moreBytes = memoryStream.ToArray();
            }
            return File(moreBytes, "application/zip", "Multiple images.zip");
        }
    }
}