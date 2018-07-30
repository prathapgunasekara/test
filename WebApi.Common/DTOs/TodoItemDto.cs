using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Common.DTOs
{
    public class TodoItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
