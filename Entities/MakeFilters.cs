using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VahanBlog.Entities
{
    public class MakeFilters
    {
        [Key]
        public int id { get; set; }

        public string Make { get; set; }

        public Boolean isSelected { get; set; }
    }
}