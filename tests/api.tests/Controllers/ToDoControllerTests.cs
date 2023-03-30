using System;
using System.Collections.Generic;
using Xunit;
using api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using api.tests.Services;
using api.Message;
using EFCoreInMemoryDbDemo;
using api.StorageLayer;
using Moq;

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
        public void Get_ReturnsActionResult_WithCollectionItemObjects()
        {
            var todoController = new ToDoController(_toDoService);
            var result = todoController.Get(null);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<string>>(
                viewResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Post_ReturnsActionResult_With200Status()
        {
            var todoController = new ToDoController(_toDoService);
            var result = todoController.Post(_toDoItemModel);

            // Assert
            var viewResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, viewResult.StatusCode);
        }
    }
}
