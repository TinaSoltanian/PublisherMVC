using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPublishersProject.Models
{
    public class ActivityType : BusinessObject
    {
        [Required]
        [StringLength(100)]
        public virtual string Title { get; set; }
    }
}