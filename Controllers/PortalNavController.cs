using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VahanBlog.Repository;
using VahanBlog.Entities;
using VahanBlog.Models;

namespace VahanBlog.Controllers
{
    public class PortalNavController : Controller
    {   
        private CarRepository repository = new CarRepository();
        public int CarsInPage = 6;
        public PortalNavController() { }
        public PortalNavController(CarRepository repo) { repository = repo; }

        // GET: Nav
        public PartialViewResult Menu()
        {
            if (TempData["MakesFilters"] == null || TempData["FuelTypeFilters"] == null || TempData["TransmissionTypeFilters"] == null || TempData["OwnerFilters"] == null || TempData["PriceFilters"] == null)
            {
                #region FilterListInitialization
                FilterListViewModel model = new FilterListViewModel
                {
                    MakeFilters = repository.MakeFilters,
                    FuelTypeFilters = new List<FuelTypeFilters>() {
                        new FuelTypeFilters {
                            FuelType = "Petrol",
                            isSelected = false
                        },
                        new FuelTypeFilters {
                            FuelType = "Diesel",
                            isSelected = false
                        },
                        new FuelTypeFilters {
                            FuelType = "CNG",
                            isSelected = false
                        },
                        new FuelTypeFilters {
                            FuelType = "LPG",
                            isSelected = false
                        },
                        new FuelTypeFilters {
                            FuelType = "Electric",
                            isSelected = false
                        }
                    },
                    TransmissionTypeFilters = new List<TransmissionTypeFilters>()
                    {
                        new TransmissionTypeFilters
                        {
                            TransmissionType = "Automatic",
                            isSelected = false
                        },
                        new TransmissionTypeFilters
                        {
                            TransmissionType = "Manual",
                            isSelected = false
                        }
                    },
                    OwnerFilters = new List<OwnerFilter>()
                    {
                        new OwnerFilter
                        {
                            Owner = "1",
                            isSelected = false
                        },
                        new OwnerFilter
                        {
                            Owner = "2",
                            isSelected = false
                        },
                        new OwnerFilter
                        {
                            Owner = "3",
                            isSelected = false
                        },
                        new OwnerFilter
                        {
                            Owner = "4 or more",
                            isSelected = false
                        }
                    },
                    PriceFilters = new List<PriceFilters>()
                    {
                        new PriceFilters
                        {
                            PriceRange = "Below 1 Lac",
                            isSelected = false
                        },
                        new PriceFilters
                        {
                            PriceRange = "1 to 2 lacs",
                            isSelected = false
                        },
                        new PriceFilters
                        {
                            PriceRange = "2 to 3 lacs",
                            isSelected = false
                        },
                        new PriceFilters
                        {
                            PriceRange = "3 to 4 lacs",
                            isSelected = false
                        },
                        new PriceFilters
                        {
                            PriceRange = "4 to 5 lacs",
                            isSelected = false
                        },
                        new PriceFilters
                        {
                            PriceRange = "5 to 6 lacs",
                            isSelected = false
                        },new PriceFilters
                        {
                            PriceRange = "6 to 8 lacs",
                            isSelected = false
                        },new PriceFilters
                        {
                            PriceRange = "8 to 10 lacs",
                            isSelected = false
                        },new PriceFilters
                        {
                            PriceRange = "10 to 30 lacs",
                            isSelected = false
                        },new PriceFilters
                        {
                            PriceRange = "Above 30 lacs",
                            isSelected = false
                        }
                    }
                };
                #endregion
                return PartialView(model);
            }
            else
            {
                FilterListViewModel model = new FilterListViewModel
                {
                    FuelTypeFilters = TempData["FuelTypeFilters"] as List<FuelTypeFilters>,
                    MakeFilters = TempData["MakesFilters"] as List<MakeFilters>,
                    TransmissionTypeFilters = TempData["TransmissionTypeFilters"] as List<TransmissionTypeFilters>,
                    OwnerFilters = TempData["OwnerFilters"] as List<OwnerFilter>,
                    PriceFilters = TempData["PriceFilters"] as List<PriceFilters>
                };

                return PartialView(model);
            }
        }
    }
}