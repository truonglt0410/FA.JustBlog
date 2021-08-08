﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FA.JustBlog.WebMVC.Areas.Admin.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} must between {2} and {1} characters", MinimumLength = 3)]
        public string Description { get; set; }
    }
}