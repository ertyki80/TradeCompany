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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        
        public CategoryService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<CategoryDTO> GetAllCategory()
        {
            using (DataContext dataContext = new DataContext())
            {
                return _mapper.Map<List<CategoryDTO>>(dataContext.Categories.ToList());

            }
        }

        public CategoryDTO GetCategory(int id)
        {
            using (var entities = new DataContext())
            {
                var user = entities.Users.SingleOrDefault(mm => mm.Id == id);

                return _mapper.Map<CategoryDTO>(user);
            }
        }

        public void Update(int id, CategoryDTO category)
        {
            using (var entity = new DataContext())
            {

                User m = _mapper.Map<User>(category);
                entity.Users.AddOrUpdate(m);
                entity.SaveChanges();
            }
        }
    }
}
