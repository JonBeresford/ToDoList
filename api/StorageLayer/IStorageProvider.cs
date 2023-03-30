using api.Common;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace api.StorageLayer
{
    public interface IStorageProvider
    {
        IQueryable<IToDoItem>GetToDoList();
        Task SaveAsync(IToDoItem message);
    }
}