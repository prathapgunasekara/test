using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Common.Models;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Common
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            this._context = context;
            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new Todoitem { Name = "item1" });
                _context.SaveChanges();
            }
        }
        public async Task<List<Todoitem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }
        public async Task<Todoitem> GetByIdAsync(long id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();

            }
            return item;
        }

        private Todoitem NotFound()
        {
            throw new NotImplementedException();
        }

        public async Task<Todoitem> CreateAsync(Todoitem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Todoitem> UpdateAsync(Todoitem item)
        {
            var todo =  await _context.TodoItems.FindAsync(item.Id);
            if (todo == null)
            {
                 NotFound();
            }

            todo.IsComplete = item.IsComplete;
           todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return todo;
        }

        private void NoContent()
        {
            throw new NotImplementedException();
        }

        public async Task<Todoitem> DeleteAsync(Todoitem item)
        {
            var todo = await _context.TodoItems.FindAsync(item.Id);
            if (todo == null)
            {
                 NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            
            return todo;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
