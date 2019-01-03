using System;
using System.Collections.Generic;
using DotNetReact.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetReact.Services
{
    public interface ITodoItemService
    {
        List<TodoItem> GetTodoItems();
        TodoItem GetTodoItem(long id);
    }

    public class TodoItemService : ITodoItemService
    {
        private readonly TodoContext _context;

        public TodoItemService(TodoContext todoContext)
        {
            _context = todoContext;
        }

        public List<TodoItem> GetTodoItems()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem GetTodoItem(long id)
        {
            return _context.TodoItems.Find(id);
        }
    }
}