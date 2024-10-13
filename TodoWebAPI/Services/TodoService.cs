using AutoMapper;
using TodoWebAPI.Context;
using TodoWebAPI.Contract;
using TodoWebAPI.Interface;
using TodoWebAPI.Models;

namespace TodoWebAPI.Services
{
    public class TodoService : ITodoServices
    {
        private readonly TodoDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TodoService> _logger;

        public TodoService(TodoDbContext context, IMapper mapper, ILogger<TodoService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // create to items
        public async Task<TodoItem> CreateTodoItemAsync(CreateTodoRequest createTodoRequest)
        {
            try
            {

                var todoItem = _mapper.Map<TodoItem>(createTodoRequest);
                todoItem.CreatedAt = DateTime.UtcNow;
                _context.TodoItems.Add(todoItem);
                await _context.SaveChangesAsync();
                return todoItem;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a todo item");
                throw new Exception("An error occurred while creating a todo item");
            }
        }

        public Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            var todoItems = _context.TodoItems.ToList();
            if (todoItems.Count == 0)
            {
                throw new Exception("No todo items found");
            }
            return Task.FromResult(todoItems.AsEnumerable());
        }



        public Task<TodoItem> GetTodoItemByIdAsync(Guid id)
        {
            var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem == null)
            {
                throw new Exception("Todo item not found");
            }
            return Task.FromResult(todoItem);
        }

        public async Task<TodoItem> UpdateTodoItemAsync(Guid id, UpdateTodoRequest updateTodoRequest)
        {
            try
            {
                var todoItem = await _context.TodoItems.FindAsync(id);
                if (todoItem == null)
                {
                    throw new Exception("Todo item not found");
                }

                if (!string.IsNullOrEmpty(updateTodoRequest.Title))
                {
                    todoItem.Title = updateTodoRequest.Title;
                }

                if (updateTodoRequest.DueDate != null)
                {
                    todoItem.DueDate = updateTodoRequest.DueDate.Value;
                }

                if (!string.IsNullOrEmpty(updateTodoRequest.Discription))
                {
                    todoItem.Discription = updateTodoRequest.Discription;
                }

                if (updateTodoRequest.IsComplete != null)
                {
                    todoItem.IsComplete = updateTodoRequest.IsComplete.Value;
                }

                if (updateTodoRequest.priority != null)
                {
                    todoItem.priority = updateTodoRequest.priority.Value;
                }

                await _context.SaveChangesAsync();
                return todoItem;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a todo item");
                throw;
            }
        }
        public Task DeleteTodoItemAsync(Guid id)
        {
            try
            {
                var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);
                if (todoItem == null)
                {
                    throw new Exception($"Todo  with this {id}  found");
                }

                _context.TodoItems.Remove(todoItem);
                _context.SaveChanges();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a todo item");
                throw new InvalidOperationException("An error occurred while deleting a todo item");
            }

        }






    }
}
