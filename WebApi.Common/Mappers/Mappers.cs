using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WebApi.Common.DTOs;
using WebApplication1.Common.Models;

namespace WebApi.Common.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Todoitem, TodoItemDto>();
          //  CreateMap<TodoItemDto, Todoitem>();

          //  Mapper.Configuration.AssertConfigurationIsValid();

        }

    }
}
