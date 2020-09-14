using BusinessLogic.Interfaces;
using DataAccess;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    class StatusService : IStatusService
    {
        private readonly DataContext _context;

        public StatusService(DataContext context)
        {
            _context = context;
        }

        public void Create(Status status)
        {
            _context.Status.Add(status);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var status = _context.Status.Find(id);

            if (status == null)
            {
            }
            _context.Status.Remove(status);

            _context.SaveChanges();
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return _context.Status;
        }

        public Status GetStatus(int id)
        {
            var status = _context.Status.Find(id);
            if (status != null)
            {
                return status;
            }
            return null;
        }

        public void Update(int id, Status status)
        {
            var oldStatus = _context.Status.Find(id);
            if (oldStatus != null && status != null)
            {

                _context.Status.Remove(oldStatus);
                _context.Status.Add(status);
            }

            _context.SaveChanges();
        }
    }
}