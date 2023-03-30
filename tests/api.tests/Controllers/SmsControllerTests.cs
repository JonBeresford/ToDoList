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
    public class SmsControllerTests
    {
        private readonly IToDoService _toDoService;
        private readonly ToDoItemModel _toDoItemModel;
        private readonly IStorageProvider _storageProvider;


        public SmsControllerTests()
        {
           
           
            _storageProvider = new StorageProvider(new StorageDbContext());
            _toDoService = new ToDoService(_storageProvider);
            _toDoItemModel = new ToDoItemModel
            {
                ToPhoneNumber = "07984123556",
                Message = "This is a test message"
            };
        }

        [Fact]
        public void Get_ReturnsActionResult_WithCollectionMessageObjects()
        {
            var smsController = new ToDoController(_toDoService);
            var result = smsController.Get(null);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<string>>(
                viewResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Post_ReturnsActionResult_With200Status()
        {
            var smsController = new ToDoController(_toDoService);
            var result = smsController.Post(_toDoItemModel);

            // Assert
            var viewResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, viewResult.StatusCode);
        }
    }
}
