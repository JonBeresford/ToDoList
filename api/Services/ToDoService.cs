using api.Common;
using api.Message;
using api.StorageLayer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api.tests.Services
{
    public class ToDoService : IToDoService
    {
        //secrets would be configured away in production code and env vcars if needed would be injected
        private readonly IStorageProvider _storageProvider;
        

        public ToDoService(IStorageProvider storageProvider) 
        {
           
            _storageProvider = storageProvider;
        }

        public IQueryable<IToDoItem> GetToDoList()
        {
            return _storageProvider.GetToDoList();
        }

        public async Task AddToDoItem(IToDoItem item)
        {
            var todoModel = item as ToDoItemModel;     

            await _storageProvider.SaveAsync(item);
            
            //in a full app you'd inject an ILogger and log the error and allow graceful continuation
            throw new Exception("Error adding todo item");

        }

    }
}
