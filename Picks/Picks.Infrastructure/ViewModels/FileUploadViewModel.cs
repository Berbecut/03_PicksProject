using Microsoft.AspNetCore.Mvc.Rendering;
using Picks.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Picks.Infrastructure.ViewModels
{
    public class FileUploadViewModel
    {
        public List<FileUpload> FileUpload { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}