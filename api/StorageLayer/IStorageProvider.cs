﻿using api.Common;
using System.Linq;
using System.Threading.Tasks;

namespace api.StorageLayer
{
    public interface IStorageProvider
    {
        IQueryable<IToDoItem>GetToDoList();
        Task SaveAsync(IToDoItem todoItem);
    }
}