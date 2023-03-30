using api.Common;
using api.Entities;
using api.Message;
using api.StorageLayer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
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

        public async Task<string> AddToDoItem(IToDoItem item)
        {
            var messageModel = item as ToDoItemModel;

            var messageResource = await MessageResource.CreateAsync(
                body: item.Message,
                from: new Twilio.Types.PhoneNumber(_fromNumber),
                to: new Twilio.Types.PhoneNumber(_countryCode + messageModel.ToNumberStripped)
            );

            await _storageProvider.SaveAsync(item);
            return messageResource.Sid;

            //in a full app you'd inject an ILogger and log the error and allow graceful continuation
            throw new Exception("Error sending sms");

        }

    }
}
