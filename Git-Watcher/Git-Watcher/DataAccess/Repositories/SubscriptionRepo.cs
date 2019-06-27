using Git_Watcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Watcher.DataAccess.Repositories
{
    public interface ISubscriptionRepo
    {
        List<Subscription> GetByUser(Guid id);
        List<Subscription> GetByRepo(Guid id);
        Subscription Get(Guid id);
        void Update(Subscription s);
        void Delete(Guid id);
        void Save(Subscription s);
    }
    public class SubscriptionRepo : ISubscriptionRepo
    {
        private DataContext _context;

        public SubscriptionRepo(DataContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            var s = Get(id);
            if (id != null)
                _context.Subscriptions.Remove(s);
            _context.SaveChanges();
        }

        public List<Subscription> GetByUser(Guid id)
        {
            return _context.Subscriptions.Where(s => s.UserId == id).ToList();
        }

        public Subscription Get(Guid id)
        {
            return _context.Subscriptions.FirstOrDefault(s => s.Id == id);
        }

        public void Save(Subscription s)
        {
            s.Id = Guid.NewGuid();
            if (Get(s.Id) != null)
                return;
            _context.Subscriptions.Add(s);
            _context.SaveChanges();

        }

        public void Update(Subscription s)
        {
            if (Get(s.Id) == null)
                return;
            _context.Subscriptions.Update(s);
            _context.SaveChanges();
        }

        public List<Subscription> GetByRepo(Guid id)
        {
            return _context.Subscriptions.Where(s => s.RepoId == id).ToList();
        }
    }
}
