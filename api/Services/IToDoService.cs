using api.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.tests.Services
{
    public interface IToDoService
    {
        IQueryable<IToDoItem> GetToDoList();
        Task<string> AddToDoItem(IToDoItem message);
    }
}