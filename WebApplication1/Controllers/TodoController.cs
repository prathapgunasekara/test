using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Common.Models;
using WebApplication1.Common;
using System;
using WebApi.Common.Interfaces.Services;
using AutoMapper;
using WebApi.Common.DTOs;
using System.Threading.Tasks;
using WebApi.Common.Mappers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/Todo")]
    [ApiController]

    public class TodoController : Controller
    {
        private readonly ITodoService _service;
        private readonly IMapper _mapper;
        public TodoController(ITodoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
         
        }

        [HttpGet]
        public async Task<ActionResult<List<Todoitem>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());

        }

        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<ActionResult<Todoitem>> GetByid(long id)
        {
            return Ok(await _service.GetByidAsync(id));

        }
        [HttpPost]
        public async Task<IActionResult> Create(TodoItemDto itemdto)
        {
            
                Todoitem item = _mapper.Map<Todoitem>(itemdto);
                return Ok(await _service.CreateAsync(item));

        }
        [HttpPut("{id}")]
        //public async Task<ActionResult<Todoitem>> Update(TodoItemDto itemdto)

       public async Task<IActionResult> Update(TodoItemDto itemdto)
        {


            Todoitem item = _mapper.Map<Todoitem>(itemdto);
         
            return Ok(await _service.UpdateAsync(item));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(TodoItemDto itemdto)
        {
            Todoitem item = _mapper.Map<Todoitem>(itemdto);
            return Ok(await _service.DeleteAsync(item));

            
        }
    }
    
   
}
