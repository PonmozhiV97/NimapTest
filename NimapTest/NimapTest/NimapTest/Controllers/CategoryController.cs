using NimapTest.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NimapTest.Controllers
{
    public class CategoryController : Controller
    {

        ProductInfoContext objDataContext = new ProductInfoContext();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Category objCategory)
        {
            Category categoryInfo = new Category();
            try
            {
                categoryInfo = objDataContext.Categories.Add(objCategory);
                objDataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (categoryInfo != null)
            {
                ViewBag.Alert = "Category has been added.";
            }
            else
            {
                ViewBag.Alert = "Category has been failed.";
            }

            return View("Index",categoryInfo);

        }

        //GET: CategoryList
        public ActionResult CategoryList()
        {

            return View(objDataContext.Categories.Where(x=>x.IsActive==true).ToList());
        }

        //Category View Page
        public ActionResult Details(int id)
        {
            var emp = objDataContext.Categories.Find(id);
            return View(emp);
        }

        //GET: Edit Category Info
        public ActionResult Edit(int id)
        {
            var emp = objDataContext.Categories.Find(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Category objCategory)
        {
            Category categoryInfo = new Category();
            try
            {
                categoryInfo = objDataContext.Categories.Find(objCategory.CategoryID);
                if (categoryInfo != null)
                {
                    categoryInfo.CategoryName = objCategory.CategoryName;
                    categoryInfo.IsActive = true;

                    objDataContext.SaveChanges();
                    ViewBag.Alert = "Category has been added.";
                }
                else
                {
                    ViewBag.Alert = "Category has been failed.";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Edit",categoryInfo);
        }

        public ActionResult Delete(int id)
        {
            var emp = objDataContext.Categories.Find(id);


            return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(Category objCategory)
        {

            var emp = objDataContext.Categories.Find(objCategory.CategoryID);
            if (emp != null)
            {
                emp.IsActive = false;
                objDataContext.SaveChanges();
            }
            

            return RedirectToAction("CategoryList");
        }




    }
}