using NUnit.Framework;
using DotNetReact.Models;

namespace DotNetReact.Tests.Models
{
    [TestFixture]
    public class TodoItemTest
    {
        [TestFixture]
        public class ToStringTests
        {
            [Test]
            public void ShouldReturnIdNameIsComplete()
            {
                Assert.That(new TodoItem { Id = 1, Name = "Do Dishes", IsComplete = false }.ToString(), Is.EqualTo("1:Do Dishes:False"));
            }
        }
    }
}