using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FA.JustBlog.WebAPI.ViewModels
{
    public class TagEditViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(255, ErrorMessage = "The {0} is at least {1} characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The {0} is at least {1} characters")]
        public string UrlSlug { get; set; }

        [MaxLength(1000, ErrorMessage = "The {0} is at least {1} characters")]
        public string Description { get; set; }
    }
}