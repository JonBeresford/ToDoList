using api.Common;
using api.Entities;
using EFCoreInMemoryDbDemo;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api.StorageLayer
{
    public class StorageProvider : IStorageProvider
    {
        private readonly StorageDbContext _dbContext;

        public StorageProvider(StorageDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync(IToDoItem message)
        {
            ToDoItemEntity entity = new()
            {
                ToPhoneNumber = message.ToPhoneNumber,
                Message = message.Message,
                SentDate = DateTime.Now
            };

            await _dbContext.TwilioMessageEntities!.AddAsync(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<IToDoItem> GetToDoList()
        {
            return _dbContext.TwilioMessageEntities;
        }
    }
}
