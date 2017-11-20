using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPublishersProject.Models
{
    public class PhoneType : BusinessObject
    {
        [Required]
        [StringLength(150)]
        public virtual string Title { get; set; }
    }
}