using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.DTOs;
using WebApplication1.Common.Models;
namespace WebApi.Common.Interfaces.Services
{
    public interface ITodoService
    {
        Task<List<TodoItemDto>> GetAllAsync();
        Task<TodoItemDto> GetByidAsync(long id);
        Task<TodoItemDto> CreateAsync(Todoitem item);
        Task<TodoItemDto> UpdateAsync(Todoitem item);
        Task<TodoItemDto>  DeleteAsync(Todoitem item);
    }
}
