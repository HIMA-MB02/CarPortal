using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VahanBlog.Entities;

namespace VahanBlog.Models
{
    public class CarListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}