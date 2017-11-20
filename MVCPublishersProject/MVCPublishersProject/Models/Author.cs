using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPublishersProject.Models
{
    public class Author : BusinessObject
    {
        [Required]
        [StringLength(250)]
        [Display(Name = "First name")]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Last name")]
        public virtual string LastName { get; set; }
    }
}