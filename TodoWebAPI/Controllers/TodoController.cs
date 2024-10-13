using Microsoft.AspNetCore.Mvc;
using TodoWebAPI.Contract;
using TodoWebAPI.Interface;
using TodoWebAPI.Models;

namespace TodoWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private ITodoServices _todoServices;

        public TodoController(ITodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        // create a new todo item
        [HttpPost]
        public async Task<IActionResult> CreateTodoItemAsync(CreateTodoRequest createTodoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _todoServices.CreateTodoItemAsync(createTodoRequest);
                return Ok(new { message = "Todo is created  successfully  " });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the Todo item ", error = ex.Message });
            }


        }
        // Get all todo items
        [HttpGet]
        public async Task<IActionResult> GetTodoItemsAsync()
        {
            try
            {
                var todoItems = await _todoServices.GetTodoItemsAsync();
                if (todoItems == null || !todoItems.Any())
                {
                    return Ok(new List<TodoItem>());
                }
                return Ok(todoItems);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching the todo items", error = ex.Message });
            }
        }

        // Get todo item by id
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTodoItemByIdAsync(Guid id)
        {
            try
            {
                var todoItem = await _todoServices.GetTodoItemByIdAsync(id);
                if (todoItem == null)
                {
                    return NotFound(new { message = "Todo item not found" });
                }
                return Ok(todoItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching the todo item", error = ex.Message });
            }
        }

        // Update todo item
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTodoItemAsync(Guid id, UpdateTodoRequest updateTodoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var todoItem = await _todoServices.GetTodoItemByIdAsync(id);
                if (todoItem == null)
                {
                    return NotFound(new { message = "Todo item not found" });
                }
                await _todoServices.UpdateTodoItemAsync(id, updateTodoRequest);
                return Ok(new { message = "Todo item updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the todo item", error = ex.Message });
            }
        }

        // Delete todo item
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItemAsync(Guid id)
        {
            try
            {
                await _todoServices.DeleteTodoItemAsync(id);
                return Ok(new { message = "Todo item deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the todo item", error = ex.Message });
            }
        }
    }
}

