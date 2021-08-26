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
    public class TagsController : ApiController
    {
        private JustBlogDbContext db = new JustBlogDbContext();
        
        private readonly ITagService _tagService;
        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }
        // GET: api/Tags
        public async Task<IHttpActionResult> GetTags()
        {
            return Ok(await _tagService.GetAllAsync());
        }

        // GET: api/Tags/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetTag(Guid id)
        {
            var category = await _tagService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Tags/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTag(Guid id, TagEditViewModel tagEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = await _tagService.GetByIdAsync(id);
            if (tag == null)
            {
                return BadRequest();
            }

            tag.Name = tagEditViewModel.Name;
            tag.UrlSlug = tagEditViewModel.UrlSlug;
            tag.Description = tagEditViewModel.Description;

            var result = await _tagService.UpdateAsync(tag);
            if (!result)
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tags
        [ResponseType(typeof(Tag))]
        public async Task<IHttpActionResult> PostTag(TagEditViewModel tagEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tag = new Tag()
            {
                Id = tagEditViewModel.Id,
                Name = tagEditViewModel.Name,
                UrlSlug = tagEditViewModel.UrlSlug,
                Description = tagEditViewModel.Description,
            };

            var result = await _tagService.AddAsync(tag);
            if (result <= 0)
            {
                return BadRequest(ModelState);
            }

            var tagViewModel = new TagViewModel
            {
                Id = tag.Id,
                Name = tag.Name,
                UrlSlug = tag.UrlSlug,
                Description = tag.Description,
                IsDeleted = tag.IsDeleted,
                InsertedAt = tag.InsertedAt,
                UpdatedAt = tag.UpdatedAt,
            };

            return CreatedAtRoute("DefaultApi", new { id = tag.Id }, tagViewModel);
        }

        // DELETE: api/Tags/5
        [ResponseType(typeof(Tag))]
        public async Task<IHttpActionResult> DeleteTag(Guid id)
        {
            var tag = await _tagService.GetByIdAsync(id);
            if (tag == null)
            {
                NotFound();
            }
            var result = await _tagService.DeleteAsync(tag);

            if (result)
            {
                return Ok(tag);
            }
            return BadRequest();
        }

        
    }
}