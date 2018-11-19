using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using VahanBlog.Models;
using VahanBlog.Repository;
using VahanBlog.Entities;

namespace VahanBlog.Controllers
{
    public class PortalsController : Controller
    {
        private CarRepository repository = new CarRepository();
        public int CarsInPage = 8;


        public PortalsController() { }
        public PortalsController(CarRepository repo)
        {
            this.repository = repo;
        }


        // GET: Portals
        public ActionResult Buy(FilterListViewModel Filters, int page = 1)
        {
        //Method is for the CarPortal Screen in the View.

            CarListViewModel model = new CarListViewModel
            {
                Cars = repository.Cars.OrderBy(p => p.CarId).Skip((page - 1) * CarsInPage).Take(CarsInPage),
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = CarsInPage, TotalItems = repository.Cars.Count() }
            };

            if ((Filters.TransmissionTypeFilters == null) && (Filters.MakeFilters == null) && (Filters.FuelTypeFilters == null) && (Filters.OwnerFilters == null) && (Filters.PriceFilters == null))
            {
                //No Option was selected. 
                //Just redirect to the view of Portal with the whole list.  
                return View(model);
            }
            else
            {
                //This is to retain the checked boxes by the user
                TempData["MakesFilters"] = Filters.MakeFilters;
                TempData["FuelTypeFilters"] = Filters.FuelTypeFilters;
                TempData["TransmissionTypeFilters"] = Filters.TransmissionTypeFilters;
                TempData["OwnerFilters"] = Filters.OwnerFilters;
                TempData["PriceFilters"] = Filters.PriceFilters;
                #region ApplyFilters
                List<Car> toAppend = new List<Car>();
                if (Filters.MakeFilters.Any(s => s.isSelected))
                {
                    foreach (var item in Filters.MakeFilters)
                    {
                        if (item.isSelected == true)
                        {
                            toAppend.AddRange(model.Cars.Where(p => p.Make.Equals(item.Make)));
                        }
                    }
                    model.Cars = toAppend;
                }
                List<Car> toAppendFuel = new List<Car>();
                if (Filters.FuelTypeFilters.Any(s => s.isSelected))
                {
                    foreach (var item in Filters.FuelTypeFilters)
                    {
                        if (item.isSelected == true)
                        {
                            toAppendFuel.AddRange(model.Cars.Where(p => p.FuelType.Equals(item.FuelType)));
                        }
                    }
                    model.Cars = toAppendFuel;
                }
                List<Car> toAppendTransmission = new List<Car>();
                if (Filters.TransmissionTypeFilters.Any(s => s.isSelected))
                {
                    foreach (var item in Filters.TransmissionTypeFilters)
                    {
                        if (item.isSelected == true)
                        {
                            toAppendTransmission.AddRange(model.Cars.Where(p => p.TransmissionType.Equals(item.TransmissionType)));
                        }
                    }
                    model.Cars = toAppendTransmission;
                }
                List<Car> toAppendOwner = new List<Car>();
                if (Filters.OwnerFilters.Any(s => s.isSelected))
                {
                    foreach (var item in Filters.OwnerFilters)
                    {
                        if (item.isSelected == true)
                        {
                            toAppendOwner.AddRange(model.Cars.Where(p => p.Owners.Equals(item.Owner)));
                        }
                    }
                    model.Cars = toAppendOwner;
                }
                List<Car> toSortPrice = new List<Car>();
                if (Filters.PriceFilters.Any(s => s.isSelected))
                {
                    foreach (var item in Filters.PriceFilters)
                    {
                        if (item.isSelected == true)
                        {
                            switch (item.PriceRange)
                            {
                                case "Below 1 lac":
                                    toSortPrice.AddRange(model.Cars.Where(p => p.Price < 100000));
                                    break;
                                case "1 to 2 lacs":
                                    toSortPrice.AddRange(model.Cars.Where(p => (p.Price >= 100000) && (p.Price < 200000)));
                                    break;
                                case "2 to 3 lacs":
                                    toSortPrice.AddRange(model.Cars.Where(p => (p.Price >= 200000) && (p.Price < 300000)));
                                    break;
                                case "3 to 4 lacs":
                                    toSortPrice.AddRange(model.Cars.Where(p => (p.Price >= 300000) && (p.Price < 400000)));
                                    break;
                                case "4 to 5 lacs":
                                    toSortPrice.AddRange(model.Cars.Where(p => (p.Price >= 400000) && (p.Price < 500000)));
                                    break;
                                case "5 to 6 lacs":
                                    toSortPrice.AddRange(model.Cars.Where(p => (p.Price >= 500000) && (p.Price < 600000)));
                                    break;
                                case "6 to 8 lacs":
                                    toSortPrice.AddRange(model.Cars.Where(p => (p.Price >= 600000) && (p.Price < 800000)));
                                    break;
                                case "8 to 10 lacs":
                                    toSortPrice.AddRange(model.Cars.Where(p => (p.Price >= 800000) && (p.Price < 1000000)));
                                    break;
                                case "10 to 30 lacs":
                                    toSortPrice.AddRange(model.Cars.Where(p => (p.Price >= 1000000) && (p.Price < 3000000)));
                                    break;
                                case "Above 30 lacs":
                                    toSortPrice.AddRange(model.Cars.Where(p => p.Price >= 3000000));
                                    break;
                                default: break;
                            }
                        }

                    }
                    model.Cars = toSortPrice;
                }
                #endregion
                //send the filtered list to the view of the portal.
                return View(model);

            }
        }
        public ActionResult Details(int id)
        {
            var Car = repository.Cars.Where(p => p.CarId == id).FirstOrDefault();
            return View(Car);
        }
        public string GetPrice(decimal price)
        {
            CultureInfo hindi = new CultureInfo("hi-IN");
            string IndianCurrency = string.Format(hindi, "{0:c}", price);
            return IndianCurrency;
        }

        public FileContentResult GetImage(int carid, int imgid)
        {
            Car prod = repository.Cars.FirstOrDefault(p => p.CarId == carid);
            if (prod != null)
            {
                return File(prod.Images[imgid].ImageDataA, prod.Images[imgid].ImageMimeTypeA);
            }
            else
            {
                return null;
            }
        }
    }
}
