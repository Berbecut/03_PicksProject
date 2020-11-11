using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Picks.Core.Models
{
    [Table("OrderRows")] //We don't want this table to be named "CartRow"
    public class CartRow
    {
        public int Id { get; set; }
        public FileUpload FileUpload { get; set; }
        public int Quantity { get; set; }
    }
}
