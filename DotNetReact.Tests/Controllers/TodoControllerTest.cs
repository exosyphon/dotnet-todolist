using System.Collections.Generic;
using DotNetReact.Controllers;
using DotNetReact.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Moq;
using DotNetReact.Services;

namespace DotNetReact.Tests.Controllers
{
    [TestFixture]
    public class TodoControllerTest
    {

        private TodoController controller;


        [OneTimeSetUp]
        public void Initialize()
        {
            var mockService = new Mock<ITodoItemService>(MockBehavior.Strict);
            mockService.Setup(p => p.GetTodoItems()).Returns(new List<TodoItem>(new TodoItem[] {
                    new TodoItem { Id = 1, Name = "Mow the Lawn", IsComplete = false },
                    new TodoItem { Id = 2, Name = "Do the Dishes", IsComplete = false }
                }));
            mockService.Setup(p => p.GetTodoItem(1)).Returns(new TodoItem { Id = 1, Name = "Mow the Lawn", IsComplete = false });

            controller = new TodoController(mockService.Object);
        }

        [Test]
        public void ShouldReturnAllTodoItems()
        {
            var expected = new List<TodoItem>(new TodoItem[] {
                    new TodoItem { Id = 1, Name = "Mow the Lawn", IsComplete = false },
                    new TodoItem { Id = 2, Name = "Do the Dishes", IsComplete = false }
                });

            CollectionAssert.AreEquivalent(expected, controller.GetAll().Value);
        }

        [Test]
        public void ShouldReturnSpecificTodoItem()
        {
            Assert.That(new TodoItem { Id = 1, Name = "Mow the Lawn", IsComplete = false }, Is.EqualTo(controller.GetById(1L).Value));
        }
    }
}