using System;
using System.Collections.Generic;
using System.Text;

namespace Picks.Core.Models
{
    public class Image
    {
        //Image
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int FileUploadId { get; set; }
        public string ImageGuid { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual List<FileUpload> FileUpload { get; set; }
        public virtual Category Category { get; set; }
    }
}