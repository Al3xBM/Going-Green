using System;
using System.Collections.Generic;
using FormGenerator.Entities;
using Microsoft.VisualBasic.CompilerServices;

namespace FormGenerator.Data
{
    public interface IRepository<T> where T : BaseProduct
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        public void Create(T entity);
    }
}
