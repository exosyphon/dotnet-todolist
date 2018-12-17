using System;

namespace DotNetReact.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public override bool Equals(object obj)
        {
            TodoItem todoItem = obj as TodoItem;

            return Id == todoItem.Id &&
            Name == todoItem.Name &&
                IsComplete == todoItem.IsComplete;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, IsComplete);
        }
    }
}