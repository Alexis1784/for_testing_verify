using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace lesson18_4_finish.Models
{
    public class ComputerRepository : IRepository
    {
        private CompContext db;
        public ComputerRepository()
        {
            this.db = new CompContext();
        }
        public List<Computer> GetComputerList()
        {
            return db.Computers.ToList();
        }
        public Computer GetComputer(int id)
        {
            return db.Computers.Find(id);
        }

        public void Create(Computer c)
        {
            db.Computers.Add(c);
        }

        public void Update(Computer c)
        {
            db.Entry(c).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Computer c = db.Computers.Find(id);
            if (c != null)
                db.Computers.Remove(c);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}