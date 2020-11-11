using Microsoft.AspNetCore.Mvc;
using Picks.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Picks.Web.ViewComponents
{
    public class CartWidgetViewComponent : ViewComponent
    {
        private Cart _cart;

        public CartWidgetViewComponent(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}