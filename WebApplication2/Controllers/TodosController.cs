using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            if(htttpErrorResponse.IsSuccessStatusCode) 
            { 
              List<Todo>? todos=await htttpErrorResponse.Content.ReadFromJsonAsync<List<Todo>>();            
            }
            return Ok();
        }
    }
}
