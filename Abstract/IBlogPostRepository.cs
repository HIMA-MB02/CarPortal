using VahanBlog.Entities;
using System.Collections.Generic;

namespace VahanBlog.Abstract
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> BlogPosts { get; }

        void SavePost(BlogPost blogPost);

        BlogPost DeletePost(int postId);

        IEnumerable<Car> Cars { get; }

        void SaveCar(Car car);

        Car DeleteCar(int carId);

        IEnumerable<MakeFilters> MakeFilters { get; }

        void SaveMake(MakeFilters Make);

        MakeFilters DeleteMake(int makeId);
    }
}