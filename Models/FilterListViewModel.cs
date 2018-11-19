using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VahanBlog.Entities;

namespace VahanBlog.Models
{
    public class FilterListViewModel
    {
        public IEnumerable<MakeFilters> MakeFilters { get; set; }

        public IEnumerable<FuelTypeFilters> FuelTypeFilters { get; set; }

        public IEnumerable<TransmissionTypeFilters> TransmissionTypeFilters { get; set; }

        public IEnumerable<OwnerFilter> OwnerFilters { get; set; }

        public IEnumerable<PriceFilters> PriceFilters { get; set; }
    }
}