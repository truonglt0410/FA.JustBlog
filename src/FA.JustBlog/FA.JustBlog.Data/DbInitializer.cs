using FA.JustBlog.Models.Common;
using FA.JustBlog.Models.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Data
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<JustBlogDbContext>
    {
        protected override void Seed(JustBlogDbContext context)
        {
            InitializeIdentity(context);
            var categories = new Category[]
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Travel",
                    UrlSlug =   "travel",
                    Description ="Travel Blog",
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Recipe",
                    UrlSlug =   "recipe",
                    Description ="Recipe Blog",
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Tips",
                    UrlSlug =   "tips",
                    Description ="Tips Blog",
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Life Style",
                    UrlSlug =   "life-style",
                    Description ="Life Style Blog",
                    IsDeleted = false
                }
            };

            var tag1 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "travel",
                UrlSlug = "travel",
                Description = "Travel Tag",
                IsDeleted = false
            };

            var tag2 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "food",
                UrlSlug = "food",
                Description = "food Tag",
                IsDeleted = false
            };

            var tag3 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "recipe",
                UrlSlug = "recipe",
                Description = "recipe Tag",
                IsDeleted = false
            };

            var tag4 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "tips",
                UrlSlug = "tips",
                Description = "tips Tag",
                IsDeleted = false
            };

            var tag5 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "study",
                UrlSlug = "study",
                Description = "study Tag",
                IsDeleted = false
            };

            var tag6 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "life style",
                UrlSlug = "life-style",
                Description = "life style Tag",
                IsDeleted = false
            };

            var tag7 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "setup",
                UrlSlug = "setup",
                Description = "setup Tag",
                IsDeleted = false
            };

            var posts = new List<Post>
            {
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "MCSE boot camps have its supporters and its detractors",
                    UrlSlug = "MCSE-boot-camps-have-its-supporters-and-its-detractors",
                    ShortDescription = "MCSE boot camps have its supporters and",
                    ImageUrl = "blog-1.jpg",
                    PostContent = "Content post 01",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[0].Name),
                    Tags = new List<Tag>{tag1, tag2,tag3},
                    ImageSlider = "post-s-2.jpg"
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "MCSE boot camps have its supporters and its detractors",
                    UrlSlug = "MCSE-boot-camps-have-its-supporters-and-its-detractors",
                    ShortDescription = "MCSE boot camps have its supporters",
                    ImageUrl = "blog-2.jpg",
                    PostContent = "Content post 02",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[3].Name),
                    Tags = new List<Tag>{tag1, tag4,tag3},
                    ImageSlider = "post-s-4.jpg"
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Which is the best website platform",
                    UrlSlug = "which-is-the-best-website-platform",
                    ShortDescription = "WordPress is free, open source",
                    ImageUrl = "blog-3.jpg",
                    PostContent = "Content post 03",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[1].Name),
                    Tags = new List<Tag>{tag5, tag2,tag3},
                    ImageSlider = "post-s-3.jpg"
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "How to make the most of this create a website tutorial",
                    UrlSlug = "how-to-make-the-most-of-this-create-a-website-tutorial",
                    ShortDescription = "This is a step by step tutorial on how ",
                    ImageUrl = "blog-4.jpg",
                    PostContent = "Content post 04",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[2].Name),
                    Tags = new List<Tag>{tag1, tag5,tag3},
                    ImageSlider = "post-s-2.jpg"
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "How much does a WordPress website cost",
                    UrlSlug = "how-much-does-a-WordPress-website-cost",
                    ShortDescription = "The answer to this question really ",
                    ImageUrl = "blog-5.jpg",
                    PostContent = "Content post 05",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[1].Name),
                    Tags = new List<Tag>{tag2,tag3},
                    ImageSlider = "post-s-1.jpg"
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "How Many WordPress Categories Should You Have",
                    UrlSlug = "How-Many-WordPress-Categories-Should-You-Have",
                    ShortDescription = "There’s no specific number of categories ",
                    ImageUrl = "blog-6.jpg",
                    PostContent = "Content post 06",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[0].Name),
                    Tags = new List<Tag>{tag6,tag3},
                    ImageSlider = "post-s-4.jpg"
                }
            };
            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.SaveChanges();
        
        }
        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentity(JustBlogDbContext db)
        {
            var userManager = new UserManager<User>(new UserStore<User>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new User { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}