using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VahanBlog.Entities;

namespace VahanBlog.Models
{
    public class EditCarViewModel
    {
        public Car Car { get; set; }
        public List<SelectListItem> Makes { get; set; }

        [DisplayName("Select Files to Upload")]
        public IEnumerable<HttpPostedFileBase> File { get; set; }
    }
}