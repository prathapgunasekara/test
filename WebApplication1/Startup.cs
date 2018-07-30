using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Common;
using WebApi.Common.Interfaces.Services;
using WebApi.Service;
using AutoMapper;
using WebApi.Common.Mappers;

namespace WebApplication1
{
    public class Startup
    {
      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("ToDoList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient<ITodoService, TodoService>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Mappers>();
            });



        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();

        }
        
    }
}
