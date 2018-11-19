using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VahanBlog.Entities;

namespace VahanBlog.Models
{
    public class AdminViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public string CurrentCategory { get; set; }
    }
}