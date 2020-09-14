using BusinessLogic.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductService :IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
            }
            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public void Update(int id, Product product)
        {
            var oldProduct = _context.Products.Find(id);
            if (oldProduct != null && product != null)
            {

                _context.Products.Remove(oldProduct);
                _context.Products.Add(product);
            }

            _context.SaveChanges();
        }
    }
}
