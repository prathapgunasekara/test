using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.DTOs;
using WebApplication1.Common.Models;

namespace WebApplication1.Common
{
    public interface ITodoRepository 
    {
        Task<List<Todoitem>> GetAllAsync();
        Task<Todoitem> GetByIdAsync(long id);
        Task<Todoitem> CreateAsync(Todoitem item);
        Task<Todoitem> UpdateAsync(Todoitem item);
        Task<Todoitem> DeleteAsync(Todoitem item);
        Task SaveAsync();
    }
}
