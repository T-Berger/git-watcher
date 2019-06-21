﻿using Git_Watcher.Models;
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
        void Save(GitRepository g);
    }
    public class GitRepo : IDisposable, IGitRepo
    {
        private DataContext _context;

        public GitRepo(DataContext context)
        {
            context = _context;
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
            _context.Dispose();
        }

        public GitRepository Get(string name)
        {
            return _context.GitRepos.FirstOrDefault(g => g.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public GitRepository Get(Guid id)
        {
            return _context.GitRepos.FirstOrDefault(g => g.Id == id);
        }

        public void Save(GitRepository g)
        {
            g.Id = Guid.NewGuid();
            if (Get(g.Id) != null)
                return;
            _context.GitRepos.Add(g);
            _context.SaveChanges();
        }
    }
}