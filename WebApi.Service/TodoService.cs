using WebApi.Common.Interfaces.Services;
using WebApplication1.Common;
using WebApplication1.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Common.Mappers;
using AutoMapper;
using WebApi.Common.DTOs;
using System.Threading.Tasks;

namespace WebApi.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _dorepo;
        public TodoService(ITodoRepository dorepo)
        {
            this._dorepo = dorepo;
        }

        public async Task<TodoItemDto> CreateAsync(Todoitem toDoItem)
        {
            return Mapper.Map<TodoItemDto>(await _dorepo.CreateAsync(toDoItem));
        }

        public async Task<TodoItemDto> DeleteAsync(Todoitem toDoItem)
        {
            return Mapper.Map<TodoItemDto>( await _dorepo.DeleteAsync(toDoItem));

        }

        public async Task<List<TodoItemDto>> GetAllAsync()
        {

            return Mapper.Map<List<TodoItemDto>>(await _dorepo.GetAllAsync());

        }

        public async Task<TodoItemDto> GetByidAsync(long id)
        {

            return Mapper.Map<TodoItemDto>(await _dorepo.GetByIdAsync(id));
        }

        public async Task<TodoItemDto> UpdateAsync(Todoitem toDoItem)
        {
            return Mapper.Map<TodoItemDto>(await _dorepo.UpdateAsync(toDoItem));
        }
    }
}
