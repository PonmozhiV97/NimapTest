using NimapTest.Models;
using NimapTest.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NimapTest.Controllers
{
    public class ProductController : Controller
    {
        ProductInfoContext objDataContext = new ProductInfoContext();

        //GET: Product Create Page
        public ActionResult Index()
        {
            Product product = new Product();
            return View(product);
        }

        //POST: Product Create Page
        [HttpPost]
        public ActionResult Index(Product objProduct)
        {
            Product productinfo = new Product();
            try
            {
                objProduct.IsActive = true;
                productinfo = objDataContext.Products.Add(objProduct);
                objDataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (productinfo != null)
            {
                ViewBag.Alert = "Product has been added.";
            }
            else
            {
                ViewBag.Alert = "Product has been failed.";
            }

            
            return View();

        }

        [HttpGet]
        public ActionResult ProductList()
        {

            return View(this.GetProducts(1));
        }
        [HttpPost]
        public ActionResult ProductList(int currentPageIndex)
        {
            return View(this.GetProducts(currentPageIndex));
        }

        public ProductCategoryViewModel GetProducts(int currentPage)
        {

            ProductCategoryViewModel objPrdCatmapping = new ProductCategoryViewModel();

            int maxRows = 10;

            objPrdCatmapping.Products = (from prd in objDataContext.Products
                                         where prd.IsActive.Equals(true)
                                         select prd)
                           .OrderBy(prd => prd.ProductId)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList();


            var lstCatInfo = objDataContext.Categories.Where(x => x.IsActive == true).ToList();
            objPrdCatmapping.Category = lstCatInfo;



            double pageCount = (double)((decimal)objDataContext.Products.Count() / Convert.ToDecimal(maxRows));
            objPrdCatmapping.PageCount = (int)Math.Ceiling(pageCount);

            objPrdCatmapping.CurrentPageIndex = currentPage;

            return objPrdCatmapping;

        }

        //Products View Page
        public ActionResult Details(int id)
        {
            var emp = objDataContext.Products.Find(id);
            emp.Category = objDataContext.Categories.Where(x => x.CategoryID == emp.CategoryID).FirstOrDefault();
            return View(emp);
        }

        //GET: Edit Products Info
        public ActionResult Edit(int id)
        {
            
            var emp = objDataContext.Products.Find(id);

            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Product objProduct)
        {
            Product productinfo = new Product();
            try
            {
                productinfo = objDataContext.Products.Find(objProduct.ProductId);
                if (productinfo != null)
                {
                    productinfo.ProductName = objProduct.ProductName;
                    productinfo.IsActive = true;
                    productinfo.CategoryID = objProduct.CategoryID;

                    objDataContext.SaveChanges();
                    ViewBag.Alert = "Product has been added.";
                }
                else
                {
                    ViewBag.Alert = "Product has been failed.";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var emp = objDataContext.Products.Find(id);
            emp.Category = objDataContext.Categories.Where(x => x.CategoryID == emp.CategoryID).FirstOrDefault();
            return View(emp);
        }

        [HttpPost]
        public ActionResult Delete(Product objProduct)
        {

            var emp = objDataContext.Products.Find(objProduct.ProductId);
            if (emp != null)
            {
                emp.IsActive = false;
                objDataContext.SaveChanges();
            }
          

            return RedirectToAction("ProductList");
        }




    }
}