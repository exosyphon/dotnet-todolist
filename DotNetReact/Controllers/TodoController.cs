using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotNetReact.Models;
using DotNetReact.Services;

namespace DotNetReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoItemService _service;

        public TodoController(ITodoItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return _service.GetTodoItems();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(long id)
        {
            var item = _service.GetTodoItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
