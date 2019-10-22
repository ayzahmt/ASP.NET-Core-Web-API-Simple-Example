using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Article.API.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> SelectAll();

        T SelectById(int id);

        void Insert([FromBody] T entity);

        void Update([FromBody] T entity);

        void DeleteById(int id);

        void Save();
    }
}
