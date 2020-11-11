using Microsoft.AspNetCore.Mvc.Rendering;
using Picks.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Picks.Infrastructure.ViewModels
{
    public class BrowseImagesViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public List<FileUpload> FileUpload { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}