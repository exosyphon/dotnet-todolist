using System.Collections.Generic;
using DotNetReact.Controllers;
using DotNetReact.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetReact.Tests.Controllers
{
    [TestClass]
    public class TodoControllerTest
    {

        private TodoController controller;

        private DbContextOptionsBuilder<TodoContext> builder;
        private TodoContext context;

        [TestInitialize]
        public void Initialize()
        {
            builder = new DbContextOptionsBuilder<TodoContext>();
            builder.UseInMemoryDatabase("MyInMemoryDb");
            var options = builder.Options;

            context = new TodoContext(options);
            var todos = new List<TodoItem>
                {
                    new TodoItem { Id = 1, Name = "Mow the Lawn", IsComplete = false},
                    new TodoItem { Id = 2, Name = "Do the Dishes", IsComplete = false }
                };

            context.AddRange(todos);
            context.SaveChanges();

            controller = new TodoController(context);
        }

        [TestCleanup]
        public void TearDown()
        {
            context.RemoveRange(context.TodoItems);
            context.SaveChanges();
        }


        [TestMethod]
        public void ShouldReturnAllTodoItems()
        {
            var expected = new List<TodoItem>(new TodoItem[] {
                    new TodoItem { Id = 1, Name = "Mow the Lawn", IsComplete = false },
                    new TodoItem { Id = 2, Name = "Do the Dishes", IsComplete = false }
                });

            CollectionAssert.AreEquivalent(expected, controller.GetAll().Value);
        }

        [TestMethod]
        public void ShouldReturnSpecificTodoItem()
        {
            Assert.AreEqual(new TodoItem { Id = 1, Name = "Mow the Lawn", IsComplete = false }, controller.GetById(1L).Value);
        }
    }
}