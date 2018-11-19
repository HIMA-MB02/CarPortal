using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VahanBlog.Abstract;
using VahanBlog.Entities;
using VahanBlog.Models;

namespace VahanBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IBlogPostRepository repo;

        public AdminController(IBlogPostRepository repository)
        {
            this.repo = repository;
        }

        #region BlogPosts
        // GET: Admin
        public ActionResult AdminView()
        {
            return View(repo.BlogPosts);
        }
        public ViewResult Edit(int postId)
        {
            BlogPost Post = repo.BlogPosts
            .FirstOrDefault(p => p.PostId == postId);
            return View(Post);
        }
        public ActionResult Instructions()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(BlogPost post, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    post.ImageMimeType = image.ContentType;
                    post.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(post.ImageData, 0, image.ContentLength);
                }
                repo.SavePost(post);
                TempData["message"] = string.Format("{0} has been saved", post.Title);
                return RedirectToAction("AdminView");
            }
            else
            {// there is something wrong with the data values
                return View(post);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new BlogPost());
        }

        public ActionResult Delete(int postId)
        {
            BlogPost deletedProduct = repo.DeletePost(postId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Title);
            }
            return RedirectToAction("AdminView");
        }
        #endregion

        #region Cars
        // GET: Admin
        public ActionResult Cars(string category)
        {
            return View(repo.Cars);
        }
        public ViewResult EditCar(int carId)
        {
            List<string> GetMakes = new List<string>();
            foreach (var item in repo.MakeFilters)
            {
                GetMakes.Add(item.Make);
            }
            EditCarViewModel model = new EditCarViewModel
            {
                Car = repo.Cars.FirstOrDefault(p => p.CarId == carId),
                Makes = GetMakes.Select(x => new SelectListItem { Value = x, Text = x }).ToList()
            };

            return View(model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditCar(EditCarViewModel post)
        {
            if (ModelState.IsValid && post.File.Count() <= 5)
            {
                if(post.File != null)
                {
                    List<Images> List = new List<Images>();
                    
                    foreach (var item in post.File)
                    {
                        Images fileUploadModel = new Images();
                        if (item != null)
                        {

                            byte[] uploadFile = new byte[item.InputStream.Length];
                            item.InputStream.Read(uploadFile, 0, uploadFile.Length);

                            fileUploadModel.ImageMimeTypeA = item.FileName;
                            fileUploadModel.ImageDataA = uploadFile;

                            List.Add(fileUploadModel);
                        }
                        
                    }
                    post.Car.Images = List;
                }
               
                repo.SaveCar(post.Car);
                TempData["message"] = string.Format("{0} has been saved", post.Car.Make + post.Car.Model);
                return RedirectToAction("Cars");
            }
            else
            {// there is something wrong with the data values
                if(post.File.Count() > 5)
                {
                    TempData["exceedImageCount"] = "You have selected more than 5 images. Please re-select";
                }
                return View(post);
            }
        }
        public FileContentResult GetImage(int carid, int imgid) {
            Car prod = repo.Cars.FirstOrDefault(p => p.CarId == carid);
            if (prod != null) {
                return File(prod.Images[imgid].ImageDataA, prod.Images[imgid].ImageMimeTypeA);
            } else {
                return null;
            }
        }
        public ViewResult CreateCar()
        {
            List<string> GetMakes = new List<string>();
            foreach (var item in repo.MakeFilters)
            {
                GetMakes.Add(item.Make);
            }
            
            EditCarViewModel model = new EditCarViewModel
            {
                Car = new Car() { Images = new List<Images>(10)},
                Makes = GetMakes.Select(x => new SelectListItem { Value = x, Text = x }).ToList()
            };
            return View("EditCar", model);
        }
        public ActionResult DeleteCar(int carId)
        {
            Car deletedProduct = repo.DeleteCar(carId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Make + deletedProduct.Model);
            }
            return RedirectToAction("Cars");
        }
        #endregion

        #region Makes
        public ActionResult Makes()
        {
            return View(repo.MakeFilters);
        }
        public ViewResult EditMakes(int carId)
        {
            MakeFilters Post = repo.MakeFilters
            .FirstOrDefault(p => p.id == carId);
            return View(Post);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditMakes(MakeFilters post)
        {
            if (ModelState.IsValid && !(repo.MakeFilters.Any(i => i.Make.Equals(post.Make))))
            {
                repo.SaveMake(post);
                TempData["message"] = string.Format("{0} has been saved", post.Make);
                return RedirectToAction("Makes");
            }
            else
            {// there is something wrong with the data values
                if (repo.MakeFilters.Any(i => i.Make.Equals(post.Make)))
                {
                    TempData["Duplicate"] = "This Make already exists.";
                }
                return View(post);
            }
        }
        public ViewResult CreateMakes()
        {
            return View("EditMakes", new MakeFilters());
        }
        public ActionResult DeleteMakes(int id)
        {
            MakeFilters deletedProduct = repo.DeleteMake(id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Make);
            }
            return RedirectToAction("Makes");
        }
        #endregion
    }
}