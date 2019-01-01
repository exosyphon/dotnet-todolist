using System.Collections.Generic;
using DotNetReact.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DotNetReact.Services
{
    [TestFixture]
    public class TodoItemServiceTest
    {

        private DbContextOptionsBuilder<TodoContext> builder;
        private TodoContext context;

        [OneTimeSetUp]
        public void Setup()
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
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            context.RemoveRange(context.TodoItems);
            context.SaveChanges();
        }

        [Test]
        public void GetTodoItems_ShouldReturnAllTodoItems()
        {
            CollectionAssert.AreEquivalent(new List<TodoItem> {
                    new TodoItem { Id = 1, Name = "Mow the Lawn", IsComplete = false},
                    new TodoItem { Id = 2, Name = "Do the Dishes", IsComplete = false }
                }, new TodoItemService(context).GetTodoItems());
        }

        [Test]
        public void GetTodoItem_ShouldReturnTodoItemMatchingGivenId()
        {
            Assert.That(
                    new TodoItem
                    {
                        Id = 2,
                        Name = "Do the Dishes",
                        IsComplete = false
                    },
                    Is.EqualTo(new TodoItemService(context).GetTodoItem(2L)
                     ));
        }

        [Test]
        public void GetTodoItem_ShouldReturnNullIfNoMatch()
        {
            Assert.That(
                    null,
                    Is.EqualTo(new TodoItemService(context).GetTodoItem(3L)
                     ));
        }
    }
}