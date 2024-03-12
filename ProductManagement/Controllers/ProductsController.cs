using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IPBLL;
using ProductManagement.Models;
using AutoMapper;
using IPDAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            ProductService ProductService = new ProductService();
            var Products = ProductService.GetProducts();
            //List<Product> productVMs = new List<Product>();

            // destination object = Mapper.Map<source class, destination class>(source object)
            //ProductVMs =  Mapper.Map<List<Product>, List<ProductVM>>(Product);

            return Json(Products);
            //return Json(ProductsVM, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            ProductService ProductService = new ProductService();
            var Product = ProductService.GetProduct(id);
            return Json(Product);
        }

        [HttpPost]
        public JsonResult AddProduct([FromBody] product Product)
        {
            ProductService ProductService = new ProductService();
            var ProductAdded = ProductService.AddProduct(Product);
            return Json(ProductAdded);
        }

        [HttpPost]
        public JsonResult UpdateProduct([FromBody] product Product)
        {
            ProductService ProductService = new ProductService();
            var ProductUpdated = ProductService.UpdateProduct(Product);
            return Json(ProductUpdated);
        }

        [HttpPost]
        public JsonResult DeleteProduct(int id)
        {
            ProductService ProductService = new ProductService();
            if (ProductService.DeleteProduct(id))
            {
                return Json(true);
            }
            return null;
        }
    }
}