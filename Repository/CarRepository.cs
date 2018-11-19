using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VahanBlog.Concrete;
using VahanBlog.Models;
using VahanBlog.Entities;

namespace VahanBlog.Repository
{
    public class CarRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<Car> Cars { get { return context.Cars; } }
        public IEnumerable<Images> Images { get { return context.Images; } }
        public IEnumerable<MakeFilters> MakeFilters { get { return context.MakeFilters; } }
    }
}