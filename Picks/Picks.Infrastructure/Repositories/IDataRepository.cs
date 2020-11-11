using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picks.Core.Models;
using Picks.Infrastructure.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Picks.Infrastructure.Repositories
{
    public interface IDataRepository
    {
        IEnumerable<Category> Categories { get; }

        void AddANewCategory(string categoryName);

        Task<IActionResult> UploadAndSaveAllImages(UploadImageViewModel viewModObj, ICollection<IFormFile> images);

        IEnumerable<Category> GetCategories();
        IEnumerable<FileUpload> GetFileUploads();
        IEnumerable<FileUpload> GetFileUploadForCart();
    }
}