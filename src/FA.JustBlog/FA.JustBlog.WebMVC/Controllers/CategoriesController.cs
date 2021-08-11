﻿using FA.JustBlog.Services;
using FA.JustBlog.WebMVC.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IPostService _postServices;
        private readonly ICategoryService _categoryServices;

        public CategoriesController(IPostService postServices, ICategoryService categoryServices)
        {
            _postServices = postServices;
            _categoryServices = categoryServices;
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var category = await _categoryServices.GetByIdAsync(id);
            //ViewBag.CategoryName = category.Name;
            var posts = await _postServices.GetPostsByCategoryAsync(id);
            return View(posts);
        }
        public ActionResult CategoryRightMenu()
        {
            var categoriesRightMenuViewModel = _categoryServices.GetAll().Select(x => new CategoryRightMenuViewModel
            {
                Id = x.Id,
                Name = x.Name,
                PostCount = x.Posts.Count
            }).OrderByDescending(c => c.PostCount);
            return PartialView("_CategoryRightMenu", categoriesRightMenuViewModel);

        }
    }
}