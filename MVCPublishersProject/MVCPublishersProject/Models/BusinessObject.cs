using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCPublishersProject.Models
{
    public class BusinessObject
    {
        [Key]
        public virtual long ID { get; set; }
    }
}