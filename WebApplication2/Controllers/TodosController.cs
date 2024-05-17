using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication2.Dtos;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        // https://jsonplaceholder.typicode.com/todos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            HttpClient http = new();
            string uri = " https://jsonplaceholder.typicode.com/todos";
            HttpResponseMessage htttpErrorResponse = await http.GetAsync(uri);
            if (htttpErrorResponse.IsSuccessStatusCode)
            {
                List<Todo>? todos = await htttpErrorResponse.Content.ReadFromJsonAsync<List<Todo>>();
                if (todos is not null)
                {
                    return Ok(todos);
                }
            }
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoDto request)
        {
            string uri = " https://jsonplaceholder.typicode.com/todos";
            string content = JsonSerializer.Serialize(request);
            StringContent stringContent = new(content,Encoding.UTF8,"application/json");
            HttpClient http = new();
            HttpResponseMessage message = await http.PostAsync(uri, stringContent);
            if (message.IsSuccessStatusCode)
            {
                Todo? todo = await message.Content.ReadFromJsonAsync<Todo>();
                if (todo is not null)
                {
                    return Ok(todo);
                }
            }
            return BadRequest(new { Message = "Something went wong...." });
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {

        }
    }
}
