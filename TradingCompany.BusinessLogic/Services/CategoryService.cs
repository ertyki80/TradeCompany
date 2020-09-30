using System;
using System.Collections.Generic;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly DataContext _context;
        private readonly LogsService _logsService;

        public CategoryService(DataContext context)
        {
          _logsService = new LogsService(context);
        _context = context;
        }
        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            Logs logs =new Logs(){Name="Create a new Category",Time = DateTime.Now};
            _logsService.Create(logs);
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
            }
            _context.Categories.Remove(category);

            _context.SaveChanges();
            Logs logs = new Logs() { Name = "Delete a  Category: ID= "+id.ToString(), Time = DateTime.Now };
            _logsService.Create(logs);

        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _context.Categories;
        }

        public Category GetCategory(int id)
        {
            var categories = _context.Categories.Find(id);
            return categories ?? null;
        }

        public void Update(int id, Category category)
        {
            var oldCategory = _context.Categories.Find(id);
            if (oldCategory != null && category != null)
            {

                _context.Categories.Remove(oldCategory);
                _context.Categories.Add(category);
            }

            _context.SaveChanges();
            Logs logs = new Logs() { Name = "Update a  Category: ID= " + id.ToString(), Time = DateTime.Now };
            _logsService.Create(logs);
        }
    }
}
