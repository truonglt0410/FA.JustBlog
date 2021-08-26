using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FA.JustBlog.Data;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using FA.JustBlog.WebAPI.ViewModels;

namespace FA.JustBlog.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private JustBlogDbContext db = new JustBlogDbContext();
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/Categories
        public async Task<IHttpActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategory(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(Guid id, CategoryEditViewModel categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return BadRequest();
            }

            category.Name = categoryEditViewModel.Name;
            category.UrlSlug = categoryEditViewModel.UrlSlug;
            category.Description = categoryEditViewModel.Description;

            var result = await _categoryService.UpdateAsync(category);
            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PostCategory(CategoryEditViewModel categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new Category()
            {
                Id = categoryEditViewModel.Id,
                Name = categoryEditViewModel.Name,
                UrlSlug = categoryEditViewModel.UrlSlug,
                Description = categoryEditViewModel.Description,
            };

            var result = await _categoryService.AddAsync(category);
            if (result <= 0)
            {
                return BadRequest(ModelState);
            }

            var categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                UrlSlug = category.UrlSlug,
                Description = category.Description,
                IsDeleted = category.IsDeleted,
                InsertedAt = category.InsertedAt,
                UpdatedAt = category.UpdatedAt,
            };

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, categoryViewModel);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> DeleteCategory(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                NotFound();
            }
            var result = await _categoryService.DeleteAsync(category);

            if (result)
            {
                return Ok(category);
            }
            return BadRequest();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(Guid id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}