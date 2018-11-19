using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VahanBlog.Entities
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        public byte[] ImageDataA { get; set; }
        public string ImageMimeTypeA { get; set; }

        public virtual Car Car { get; set; }
    }
}