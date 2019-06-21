using Git_Watcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Watcher.DataAccess.Repositories
{
    public interface IUserRepo
    {
        User Get(string name);
        User Get(Guid id);
        Guid GetKey(Guid id);
        void Save(User u);
        void Delete(Guid id);
    }
    public class UserRepo : IUserRepo
    {
        private DataContext _context;
        public UserRepo(DataContext context)
        {
            _context = context;
        }
        public void Delete(Guid id)
        {
            var user = Get(id);
            if (user != null)
                _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User Get(string name)
        {
            return _context.Users.FirstOrDefault(u => u.GitUserName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public User Get(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public Guid GetKey(Guid id)
        {
            var u = Get(id);
            if(u != null)
                return u.ApiKey;
            return Guid.Empty;
        }

        public void Save(User u)
        {
            u.Id = Guid.NewGuid();
            u.ApiKey = Guid.NewGuid();
            if (Get(u.Id) != null)
                return;
            if (_context.Users.FirstOrDefault(x => x.ApiKey == u.ApiKey) != null)
                return;
            _context.Users.Add(u);
            _context.SaveChanges();
        }
    }
}
