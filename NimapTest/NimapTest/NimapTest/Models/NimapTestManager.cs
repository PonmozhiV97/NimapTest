using NimapTest.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NimapTest.Models
{
    public static class NimapTestManager
    {
        public static ProductInfoContext objDataContext = new ProductInfoContext();

        static NimapTestManager()
        {

        }


        public static List<Category> GetCategories()
        {

            List<Category> categorieslist = new List<Category>();

            categorieslist = objDataContext.Categories.Where(x=>x.IsActive==true).OrderBy(x => x.CategoryName).ToList();
            return categorieslist;
        }
    }
}