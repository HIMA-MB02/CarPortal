using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web.Mvc;
using VahanBlog.Abstract;
using VahanBlog.Entities;

namespace VahanBlog.Controllers
{
    public class BlogController : Controller
    {
        private IBlogPostRepository repo;
        private BlogPost blogPost;
        public BlogController(IBlogPostRepository repoBlog)
        {
            this.repo = repoBlog;
        }

        public ViewResult RecentPosts()
        {
            return View(repo.BlogPosts.OrderByDescending(p => p.PostId).Take(2));
        }
        public ViewResult AllPosts()
        {
            return View(repo.BlogPosts);
        }

        public ViewResult DisplayPost(int postId)
        {
            blogPost = repo.BlogPosts.FirstOrDefault(b => b.PostId.Equals(postId));
            ViewBag.Title = blogPost.Title;
            return View(blogPost);
        }

        public FileContentResult GetImage(int postId)
        {
            BlogPost post = repo.BlogPosts
            .FirstOrDefault(p => p.PostId == postId);
            if (post != null)
            {
                return File(post.ImageData, post.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }

}