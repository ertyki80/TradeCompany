using aspApp.Models;
using AutoMapper;
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
        IMapper mapper;
        ITraderManager _managerT;
        IProductManager _managerP;
        public ProductsController(ITraderManager traderManager, IProductManager productManager)
        {
            if (LoginController.active)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>().ReverseMap());
                mapper = new Mapper(config);


                _managerT = traderManager;
                _managerP = productManager;
            }
            else
            {
                 Redirect("../Login/Index");
            }
        }
        // GET: ProductsController
        public ActionResult Index()
        {
            if (LoginController.active)
            {
                var products = _managerT.GetAllProduct();
                return View(products);
            }

            return View("../Login/Index",new LoginViewModel());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            ProductViewModel product = mapper.Map<ProductViewModel>(_managerT.GetAllProduct().Where(p => p.Id == id).FirstOrDefault());
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            var p = new ProductViewModel();
            return View(p);
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                ProductDTO productDTO = _managerP.AddProduct(mapper.Map<ProductDTO>(product));
                return RedirectToAction(nameof(Index));
            }
            
                return View();
            
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {

            var product = mapper.Map < ProductViewModel > (_managerT.GetAllProduct().Where(p => p.Id == id).FirstOrDefault());
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            if(ModelState.IsValid)
            {
                _managerP.UpdateProduct(mapper.Map < ProductDTO > (product));
                return RedirectToAction(nameof(Index));
            }
            
            return View(product);
            
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = mapper.Map < ProductViewModel >( _managerT.GetAllProduct().Where(p => p.Id == id).FirstOrDefault());
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
