using api.Common;
using api.Entities;
using api.Message;
using api.tests.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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

        //I thought about using odata here but didn't have time
        //[EnableQuery] 
        [HttpGet]
        public IActionResult Get([FromQuery] DateTime? date)
        {
            //normally you wouldn't directly return the entities and you'd use a DTO to return just the fields you want to expose
            var messages = _todoService.GetToDoList();
            if (date != null)
            {
                messages = messages.Where(m => (m as ToDoItemEntity).SentDate == date);
            }

            return this.Ok(messages);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItemModel sendMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sid = await _todoService.AddToDoItem(sendMessage);
            return Ok(sid);
        }
    }
}
