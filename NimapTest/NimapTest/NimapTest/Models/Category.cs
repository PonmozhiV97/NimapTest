using System.ComponentModel.DataAnnotations;

namespace NimapTest.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name Required")]
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }

    }
}