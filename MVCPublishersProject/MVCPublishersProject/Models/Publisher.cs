using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPublishersProject.Models
{
    public class Publisher : BusinessObject
    {

        [Required]
        [StringLength(200)]
        public virtual string Title { get; set; }

        [Required]
        [StringLength(200)]
        public virtual string Address { get; set; }

        public virtual ICollection<Phone> Phone { get; set; }
    }
}