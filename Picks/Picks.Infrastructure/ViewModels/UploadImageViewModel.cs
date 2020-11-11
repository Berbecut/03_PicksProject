using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Picks.Core.Models;

namespace Picks.Infrastructure.ViewModels
{
    public class UploadImageViewModel
    {
        public Image Image { get; set; }
        public ICollection<IFormFile> Images { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string CategoryName { get; set; }
        public List<FileUpload> FileUpload { get; set; }

    }
}
