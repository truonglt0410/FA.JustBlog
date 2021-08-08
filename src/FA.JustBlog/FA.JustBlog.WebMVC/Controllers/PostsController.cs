using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        //private readonly PostsController : Controller;
        public PostsController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }
        
        // GET: Posts
        public async Task<ActionResult> Index()
        {
            var allPosts = await _postService.GetAllAsync();
            return View(allPosts);
        }

        public ActionResult LastestPosts()
        {
            var lastestPosts = Task.Run(() => _postService.GetLatestPostAsync(5)).Result;
            ViewBag.PartialViewTitle = "Lastest Posts";
            return PartialView("_ListPost", lastestPosts);
        }

        public ActionResult MostViewPosts()
        {
            var lastestPosts = Task.Run(() => _postService.GetMostViewPostsAsync(5)).Result;
            ViewBag.PartialViewTitle = "Most View Posts";
            return PartialView("_PopularPosts", lastestPosts);
        }

        public ActionResult HighestPosts()
        {
            var lastestPosts = Task.Run(() => _postService.GetMostViewPostsAsync(5)).Result;
            ViewBag.PartialViewTitle = "Highest Posts";
            return PartialView("_ListPost", lastestPosts);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
    }
}