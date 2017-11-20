using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPublishersProject.Models
{
    public class Phone : BusinessObject
    {
        [Required]
        public virtual long PhoneType_ID { get; set; }

        [Required]
        public virtual long Publisher_ID { get; set; }

        [ForeignKey("PhoneType_ID")]
        public virtual PhoneType PhoneType { get; set; }

        [ForeignKey("Publisher_ID")]
        public virtual Publisher Publisher { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Number { get; set; }
    }
}