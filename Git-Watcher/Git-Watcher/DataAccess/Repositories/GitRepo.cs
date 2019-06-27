using Git_Watcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Watcher.DataAccess.Repositories
{
    public interface IGitRepo // haha
    {
        GitRepository Get(string name);
        GitRepository Get(Guid id);
        void Delete(Guid id);
        Guid Save(GitRepository g);
    }
    public class GitRepo : IGitRepo, IDisposable
    {
        private DataContext _context;

        public GitRepo(DataContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            var g = Get(id);
            if (g != null)
                _context.GitRepos.Remove(g);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if(_context != null)
                _context.Dispose();
        }

        public GitRepository Get(string name)
        {
            return _context.GitRepos.FirstOrDefault(g => g.RepoId.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public GitRepository Get(Guid id)
        {
            return _context.GitRepos.FirstOrDefault(g => g.Id == id);
        }

        public Guid Save(GitRepository g)
        {
            g.Id = Guid.NewGuid();
            if (Get(g.Id) != null)
                return Guid.Empty;
            _context.GitRepos.Add(g);
            _context.SaveChanges();
            return g.Id;
        }
    }
}
