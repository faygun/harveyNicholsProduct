
using HarveyNichols.Service.Interface;
using HarveyNicholsProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HarveyNicholsProduct.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductRequest request)
        {
            try
            {
                var result = _productService.Create(new HarveyNichols.DTO.Product.ProductModel
                { 
                    Colour = request.Colour,
                    Price = request.Price,
                    Sku = request.Sku,
                    Stock = request.Stock,
                    Style = request.Style,
                    Title = request.Title
                });

                if (!result.Success) Json(new { message = "message" });

                return Json(new { result="OK"}, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { result = "Error", ex = ex }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
