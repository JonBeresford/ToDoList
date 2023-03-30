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

        public async Task SaveAsync(IToDoItem todoItem)
        {

            var todoItemEntity = (todoItem as ToDoItemModel).ToEntitiy();

            await _dbContext.ToDoItemEntities.AddAsync(todoItemEntity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<IToDoItem> GetToDoList()
        {
            return _dbContext.ToDoItemEntities;
        }
    }
}
