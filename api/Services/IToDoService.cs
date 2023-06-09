﻿using api.Common;
using api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace api.tests.Services
{
    public interface IToDoService
    {
        IQueryable<IToDoItem> GetToDoList();
        Task AddToDoItem(IToDoItem message);
        Task ChangeToDoState(IsDoneModel isDoneModel);
    }
}