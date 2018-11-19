using VahanBlog.Abstract;
using VahanBlog.Entities;
using System.Collections.Generic;
using System;

namespace VahanBlog.Concrete
{
    public class EFBlogPostRepository : IBlogPostRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<BlogPost> BlogPosts
        {
            get { return context.BlogPosts; }
        }

        public IEnumerable<Car> Cars
        {
            get { return context.Cars; }
        }

        public IEnumerable<MakeFilters> MakeFilters { get { return context.MakeFilters; } }

        public void SavePost(BlogPost blogPost)
        {
            if (blogPost.PostId == 0)
            {
                context.BlogPosts.Add(blogPost);
            }
            else
            {
                BlogPost dbEntry = context.BlogPosts.Find(blogPost.PostId);
                if (dbEntry != null)
                {
                    dbEntry.Title = blogPost.Title;
                    dbEntry.Description = blogPost.Description;
                    dbEntry.Content = blogPost.Content;
                    dbEntry.ImageData = blogPost.ImageData;
                    dbEntry.ImageMimeType = blogPost.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public BlogPost DeletePost(int postId)
        {
            BlogPost dbEntry = context.BlogPosts.Find(postId);
            if (dbEntry != null)
            {
                context.BlogPosts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveCar(Car car)
        {
            if (car.CarId == 0)
            {
                context.Cars.Add(car);
            }
            else
            {
                Car dbEntry = context.Cars.Find(car.CarId);
                if (dbEntry != null)
                {
                    dbEntry.Make = car.Make;
                    dbEntry.Price = car.Price;
                    dbEntry.Model = car.Model;
                    dbEntry.FuelType = car.FuelType;
                    dbEntry.TransmissionType = car.TransmissionType;
                    dbEntry.Owners = car.Owners;
                    dbEntry.Kilometers = car.Kilometers;
                    //This is for the image
                    dbEntry.Images = car.Images;
                }
            }
            context.SaveChanges();
        }

        public Car DeleteCar(int carId)
        {
            Car dbEntry = context.Cars.Find(carId);

            if (dbEntry != null)
            {
                if(dbEntry.Images != null)
                {
                    for (int i = 0; i < dbEntry.Images.Count; i++)
                    {
                        var type = dbEntry.Images[i];
                        context.Images.Remove(type);
                    }
                    context.SaveChanges();
                }
                
                context.Cars.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveMake(MakeFilters make)
        {
            if (make.id == 0)
            {
                context.MakeFilters.Add(make);
            }
            else
            {
                MakeFilters dbEntry = context.MakeFilters.Find(make.id);
                if (dbEntry != null)
                {
                    dbEntry.Make = make.Make;
                    dbEntry.isSelected = make.isSelected;
                }
            }
            context.SaveChanges();
        }

        public MakeFilters DeleteMake(int makeId)
        {
            MakeFilters dbEntry = context.MakeFilters.Find(makeId);
            if (dbEntry != null)
            {
                context.MakeFilters.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}