using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson18_4_finish.Models
{
    public interface IRepository : IDisposable
    {
        List<Computer> GetComputerList();
        Computer GetComputer(int id);
        void Create(Computer item);
        void Create();
        void Create2(string st);
        void Update(Computer item);
        void Delete(int id);
        void Save();
    }
}
