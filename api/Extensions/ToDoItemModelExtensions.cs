using api.Common;
using api.Entities;
using System;

namespace api.Extensions
{
    public static class ToDoItemModelExtensions
    {
        public static ToDoItemEntity ToEntitiy(this IToDoItem item)
        {
            var itemEntity = new ToDoItemEntity
            {
                Name = item.Name,
                Description = item.Description,
                IsDone = item.IsDone,
                AddedDate = DateTime.Now
            };

            return itemEntity;
        }
    }
}
