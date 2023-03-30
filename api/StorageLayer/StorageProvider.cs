using api.Common;
using api.Extensions;
using api.Message;
using EFCoreInMemoryDbDemo;
using System.Linq;
using System.Threading.Tasks;

namespace api.StorageLayer
{
    public class StorageProvider : IStorageProvider
    {
        private readonly StorageDbContext _dbContext;

        public StorageProvider(StorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveAsync(IToDoItem todoItem)
        {

            var toDoItemEntity = (todoItem as ToDoItemModel).ToEntitiy();

            await _dbContext.ToDoItemEntities.AddAsync(toDoItemEntity);
            return await SaveAsync() > 0;
        }

        public async Task<int> SaveAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }

        public IQueryable<IToDoItem> GetToDoList()
        {
            return _dbContext.ToDoItemEntities;
        }
    }
}
