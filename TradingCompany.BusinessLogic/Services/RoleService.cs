using System.Collections.Generic;
using BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _context;

        public RoleService(DataContext context)
        {
            _context = context;
        }

        public void Create(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = _context.Roles.Find(id);

            if (role == null)
            {
            }
            _context.Roles.Remove(role);

            _context.SaveChanges();
        }

        public IEnumerable<Role> GetAllRole()
        {
            return _context.Roles;
        }

        public Role GetRole(int id)
        {
            var role = _context.Roles.Find(id);
            return role ?? null;
        }

        public void Update(int id, Role role)
        {
            var oldRole = _context.Roles.Find(id);
            if (oldRole != null && role != null)
            {

                _context.Roles.Remove(oldRole);
                _context.Roles.Add(role);
            }

            _context.SaveChanges();
        }
    }
}