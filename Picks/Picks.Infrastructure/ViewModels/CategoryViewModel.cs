using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Picks.Core.Models;

namespace Picks.Infrastructure.ViewModels
{
    public class CategoryViewModel
    {
        public List<Image> Images { get; set; }
        public Image Image { get; set; }

        public Category Category { get; set; }
        public List<Category> AllCategories { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}

