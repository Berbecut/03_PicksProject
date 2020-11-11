using System;
using System.Collections.Generic;
using System.Text;

namespace Picks.Core.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        public Guid FileTitle { get; set; }
        public string FilePath { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
