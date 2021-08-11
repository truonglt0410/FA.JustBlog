using FA.JustBlog.Services;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentServices;

        public CommentsController(ICommentService commentServices)
        {
            _commentServices = commentServices;
        }

        
    }
}