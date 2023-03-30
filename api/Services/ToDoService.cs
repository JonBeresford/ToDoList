using api.Common;
using api.Message;
using api.Models;
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

            if (await _storageProvider.SaveAsync(todoModel))
            {
                return;
            }  
            
            //in a production app you'd inject an ILogger and a custom error handler to log the error and allow graceful continuation
            throw new Exception("Error adding todo item");

        }

        public async Task ChangeToDoState(IsDoneModel isDoneModel)
        {           
            if (await _storageProvider.UpdateIsDone(isDoneModel))
            {
                return;
            }

            //in a production app you'd inject an ILogger and a custom error handler to log the error and allow graceful continuation
            throw new Exception("Error updating todo item");
        }
    }
}
