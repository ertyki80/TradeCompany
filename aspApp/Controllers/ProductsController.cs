using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompanyDataTransfer;

namespace aspApp.Controllers
{
    public class ProductsController : Controller
    {

        ITraderManager _managerT;
        IProductManager _managerP;
        public ProductsController(ITraderManager traderManager, IProductManager productManager)
        {
            _managerT = traderManager;
            _managerP = productManager;
        }
        // GET: ProductsController
        public ActionResult Index()
        {
            var products = _managerT.GetAllProduct();
            return View(products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var product = _managerT.GetAllProduct().Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ProductDTO p = new ProductDTO();
            return View(p);
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                _managerP.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            
                return View();
            
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {

            var product = _managerT.GetAllProduct().Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductDTO product)
        {
            if(ModelState.IsValid)
            {
                _managerP.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            
            return View(product);
            
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _managerT.GetAllProduct().Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductDTO product)
        {
            try
            {
                _managerP.DeleteProduct(product.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
