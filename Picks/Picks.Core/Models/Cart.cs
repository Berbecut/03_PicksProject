using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Picks.Core.Models
{
    public class Cart
    {
        internal const string customerCartKey = "customer_cart";

        private List<CartRow> _cartRows = new List<CartRow>();

        public virtual void AddImage(FileUpload image, int quantity)
        {
            var cartRow = _cartRows.Where(x => x.FileUpload.Id.Equals(image.Id)).FirstOrDefault();
            if (cartRow == null)
            {
                _cartRows.Add(new CartRow
                {
                    FileUpload = image,
                    Quantity = quantity
                });
            }
            else
            {
                cartRow.Quantity += quantity;
            }
        }

        public virtual void RemoveCartRow(FileUpload image)
        {
            _cartRows.RemoveAll(x => x.FileUpload.Id.Equals(image.Id));
        }

        public virtual void EmptyCart()
        {
            _cartRows.Clear();
        }

        public virtual IEnumerable<CartRow> CartRows => _cartRows;
    }
}
