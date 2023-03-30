using api.Common;
using api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace api.StorageLayer
{
    public interface IStorageProvider
    {
        IQueryable<IToDoItem>GetToDoList();
        Task<bool> SaveAsync(IToDoItem todoItem);
        Task<bool> UpdateIsDone(IsDoneModel isDoneModel);
    }
}