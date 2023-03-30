using System.Collections.Generic;
using Xunit;
using api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using api.tests.Services;
using api.Message;
using EFCoreInMemoryDbDemo;
using api.StorageLayer;
using System.Threading.Tasks;
using api.Entities;

namespace api.tests.Controllers
{
    public class ToDoControllerTests
    {
        private readonly IToDoService _toDoService;
        private readonly ToDoItemModel _toDoItemModel;
        private readonly IStorageProvider _storageProvider;


        public ToDoControllerTests()
        {           
            _storageProvider = new StorageProvider(new StorageDbContext());
            _toDoService = new ToDoService(_storageProvider);
            _toDoItemModel = new ToDoItemModel
            {
                Name = "item1",
                Description = "This is a test todo item"
            };
        }

        [Fact]
        public void GetReturnsActionResultWithCollectionItemObjects()
        {
            var todoController = new ToDoController(_toDoService);
            var result = todoController.Get(null);

        
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ToDoItemEntity>>(viewResult.Value);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task PostReturnsActionResultWith200Status()
        {
            var todoController = new ToDoController(_toDoService);
            var result = await todoController.Post(_toDoItemModel);

         
            var viewResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, viewResult.StatusCode);
        }
    }
}
