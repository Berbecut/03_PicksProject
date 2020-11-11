using Picks.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Picks.Infrastructure.ViewModels
{
    public class ImageCartViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
