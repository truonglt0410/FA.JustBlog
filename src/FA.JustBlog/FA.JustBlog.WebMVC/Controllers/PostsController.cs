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

        //private readonly PostsController : Controller;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        // GET: Posts
        public async  Task<ActionResult> Index()
        {
           
            var posts = await _postService.GetAllAsync();
            return View(posts);
        }
    }
}