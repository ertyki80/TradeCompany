using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Interfaces;
using TradingCompany.DataAccess.Models;
using TradingCompanyDataTransfer;

namespace TradingCompany.DataAccess.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ProductDTO Create(ProductDTO product)
        {
            using (var entities = new DataContext())
            {
                Product m = _mapper.Map<Product>(product);
                entities.Products.Add(m);
                entities.SaveChanges();
                return _mapper.Map<ProductDTO>(m);
            }
        }

        public void Delete(int id)
        {
            using (var entities = new DataContext())
            {
                Product m = entities.Products.SingleOrDefault(mm => mm.Id == id);
                if (m == null)
                {
                    return;
                }
                List<Transaction> transactions = entities.Transactions.Where(t => t.Product.Id == id).ToList();
                entities.Transactions.RemoveRange(transactions);
                entities.Products.Remove(m);
                entities.SaveChanges();
            }
        }

        public List<ProductDTO> GetAllProducts()
        {
            using (var e = new DataContext())
            {
                return _mapper.Map<List<ProductDTO>>(e.Products.ToList());

            }
        }

        public ProductDTO GetProduct(int id)
        {
            using (var entities = new DataContext())
            {
                var m = entities.Users.SingleOrDefault( mm => mm.Id == id );

                return _mapper.Map<ProductDTO>(m);
            }
        }

        public ProductDTO Update( ProductDTO product)
        {
            using (var entity = new DataContext())
            {

                Product m = _mapper.Map<Product>(product);
                entity.Products.AddOrUpdate(m);
                entity.SaveChanges();
            }
            using (var entities = new DataContext())
            {
                var productInDB = entities.Products.SingleOrDefault(m => m.Id == product.Id);
                if (productInDB == null)
                {
                    product.TimeOfAdd = DateTime.UtcNow;
                    productInDB = _mapper.Map<Product>(product);
                    entities.Products.Add(productInDB);
                }
                else
                {
                    productInDB.TimeOfAdd = DateTime.UtcNow;
                    _mapper.Map(product, productInDB);
                }
                entities.SaveChanges();
                return _mapper.Map<ProductDTO>(product);
            }
        }
    }
}
