using System;
using System.Collections.Generic;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Interfaces;
using TradingCompany.DataAccess.Services;
using TradingCompanyDataTransfer;

namespace TradingCompany.BusinessLogic.Concrete
{
    public class ProductManager : IProductManager
    {

        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        public ProductManager(IProductService productService, IUserService userService,ICategoryService categoryService)
        {
            _productService = productService;
            _userService = userService;
            _categoryService = categoryService;

        }


        public ProductDTO AddProduct(ProductDTO product)
        {
            return _productService.Create(product);
        }

        public void DeleteProduct(int productId)
        {
            _productService.Delete(productId);
        }

        public List<CategoryDTO> GetListOfCategory()
        {
            return _categoryService.GetAllCategory();
        }

        public List<UserDTO> GetListOfPeople()
        {
            return _userService.GetAllUsers();
        }

        public List<ProductDTO> GetListOfProducts()
        {
            return _productService.GetAllProducts();
        }

        public ProductDTO UpdateProduct(ProductDTO product)
        {
            return _productService.Update(product);
        }
    }
}
