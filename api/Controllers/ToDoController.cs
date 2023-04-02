using api.Message;
using api.Models;
using api.tests.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _todoService;

        public ToDoController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        //I thought about using odata here
        //[EnableQuery] 
        [HttpGet]
        public IActionResult Get([FromQuery] DateTime? date)
        {
            //normally you wouldn't directly return the entities and you'd use an intermediary DTO to return just the fields you want to expose
            var toDoList = _todoService.GetToDoList();         
            return Ok(toDoList);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItemModel addItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _todoService.AddToDoItem(addItem);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] IsDoneModel isDoneModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _todoService.ChangeToDoState(isDoneModel);
            return Ok();
        }
    }
}
