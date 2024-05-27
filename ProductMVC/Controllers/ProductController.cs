using Dapper;
using ProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(ProductORM.ReturnList<ProductModel>("ViewAll"));
        }

        [HttpGet]
        public ActionResult AddOrEdit(int ID = 0)
        {
            if (ID == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ID", ID);
                return View(ProductORM.ReturnList<ProductModel>("ProductViewByID", param).FirstOrDefault<ProductModel>());
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(ProductModel Product)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("ID", Product.ID);
            param.Add("Code", Product.Code);
            param.Add("Name", Product.Name);
            param.Add("Description", Product.Description);
            param.Add("Price", Product.Price);
            ProductORM.ExecuteWithoutReturn("ProductAddEdit", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", id);
            ProductORM.ExecuteWithoutReturn("ProductDeleteByID", param);
            return RedirectToAction("Index");
        }
    }
}