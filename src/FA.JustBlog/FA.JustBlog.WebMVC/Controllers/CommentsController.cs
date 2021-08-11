using FA.JustBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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