using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Picks.Core.Models;

namespace Picks.Core.Models
{
    public class CartSession : Cart
    {
        [JsonIgnore]
        public ISession Session { get; private set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            CartSession cart = session.GetJson<CartSession>(customerCartKey) ?? new CartSession();
            cart.Session = session;
            return cart;
        }
        public override void AddImage(FileUpload image, int quantity)
        {
            base.AddImage(image, quantity);
            CommitToSession();
        }
        public override void RemoveCartRow(FileUpload image)
        {
            base.RemoveCartRow(image);
            CommitToSession();
        }
        public override void EmptyCart()
        {
            base.EmptyCart();
            Session.Remove(customerCartKey);
        }
        public void CommitToSession()
        {
            Session.SetJson(customerCartKey, this);
        }
    }
}
