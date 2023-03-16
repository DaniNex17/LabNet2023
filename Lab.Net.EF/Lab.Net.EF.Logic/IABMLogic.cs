using Lab.Net.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.EF.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
