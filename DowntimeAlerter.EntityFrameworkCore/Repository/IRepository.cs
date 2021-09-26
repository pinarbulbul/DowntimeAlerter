using DowntimeAlerter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowntimeAlerter.EntityFrameworkCore.Repository
{
    public interface IRepository<T> where T : Base
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
