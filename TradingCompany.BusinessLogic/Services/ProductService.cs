using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Services
{
    public class ProductService :IProductService
    {
        private readonly LogsService _logsService;
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {

            _logsService = new LogsService(context);
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            Logs logs = new Logs() { Name = "Create a new Product", Time = DateTime.Now };
            _logsService.Create(logs);
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
            _logsService.Create(logs);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            return product;
        }

        public void Update(int id, Product product)
        {
            var oldProduct = _context.Products.Find(id);
            _context.Entry(oldProduct).CurrentValues.SetValues(product);

            Logs logs = new Logs() { Name = "Update a  Product", Time = DateTime.Now };
            _logsService.Create(logs);

            _context.SaveChanges();
        }
    }
}
