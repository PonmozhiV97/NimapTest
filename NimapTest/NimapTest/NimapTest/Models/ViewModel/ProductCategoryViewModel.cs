using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NimapTest.Models.ViewModel
{
    public class ProductCategoryViewModel
    {
        public List<Product> Products { get; set; }

        public List<Category> Category { get; set; }

        //public int CategoryID { get; set; }

        //public string CategoryName { get; set; }

        //public int ProductId { get; set; }

        //public string ProductName { get; set; }

        //public bool ProductIsActive { get; set; }

        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }

    }
}