using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace NimapTest.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }

        public bool IsActive { get; set; }

        // Foreign key   
        [Display(Name = "Category")]
        public virtual int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public IEnumerable<SelectListItem> Skills { get; set; }


    }
}