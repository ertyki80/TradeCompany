using System;
using System.Collections.Generic;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Services
{
    public class ProductService :IProductService
    {
        private LogsService logsService;
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {

            logsService = new LogsService(context);
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            Logs logs = new Logs() { Name = "Create a new Product", Time = DateTime.Now };
            logsService.Create(logs);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
            }
            _context.Products.Remove(product ?? throw new InvalidOperationException("product is null"));
            Logs logs = new Logs() { Name = "Delete a  Product", Time = DateTime.Now };
            logsService.Create(logs);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            return product ?? null;
        }

        public void Update(int id, Product product)
        {
            var oldProduct = _context.Products.Find(id);
            if (oldProduct != null && product != null)
            {

                _context.Products.Remove(oldProduct);
                _context.Products.Add(product);
            }
            Logs logs = new Logs() { Name = "Update a  Product", Time = DateTime.Now };
            logsService.Create(logs);

            _context.SaveChanges();
        }
    }
}
