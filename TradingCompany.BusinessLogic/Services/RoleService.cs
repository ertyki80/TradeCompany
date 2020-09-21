using System;
using System.Collections.Generic;
using TradingCompany.BusinessLogic.Interfaces;
using TradingCompany.DataAccess.Context;
using TradingCompany.DataAccess.Models;

namespace TradingCompany.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _context;
        private LogsService logsService;

        public RoleService(DataContext context)
        {
            logsService = new LogsService(context);
            _context = context;
        }

        public void Create(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            Logs logs = new Logs() { Name = "Create a new Role", Time = DateTime.Now };
            logsService.Create(logs);
        }

        public void Delete(int id)
        {
            var role = _context.Roles.Find(id);

            if (role == null)
            {
            }
            _context.Roles.Remove(role);
            Logs logs = new Logs() { Name = "Delete a  Role", Time = DateTime.Now };
            logsService.Create(logs);
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
            Logs logs = new Logs() { Name = "Update a new Role", Time = DateTime.Now };
            logsService.Create(logs);
            _context.SaveChanges();
        }
    }
}