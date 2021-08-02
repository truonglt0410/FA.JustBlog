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
        public async  Task<ActionResult> Index(int? pageIndex = 1, int? pageSize = 3)
        {
            Expression<Func<Post, bool>> filter = null;

            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = o => o.OrderBy(p => p.Title);
            var posts = await _postService.GetAsync(filter: filter, orderBy: orderBy,
                pageIndex: pageIndex ?? 1, pageSize: pageSize ?? 3);
            return View(posts);
        }
        public async Task<ActionResult> LastestPosts()
        {
            var lastestPosts = await _postService.GetLatestPostAsync(3);
            return PartialView(lastestPosts);
        }

        public async Task<ActionResult> Detail(Guid id)
        {
            var post = await _postService.GetByIdAsync(id);
            return View(post);
        }
    }
}