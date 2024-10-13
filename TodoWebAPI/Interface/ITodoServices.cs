using TodoWebAPI.Contract;
using TodoWebAPI.Models;

namespace TodoWebAPI.Interface
{
    public  interface ITodoServices
    {
       Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> GetTodoItemByIdAsync(Guid id);
        Task<TodoItem> CreateTodoItemAsync(CreateTodoRequest createTodoRequest);
        Task<TodoItem> UpdateTodoItemAsync(Guid id, UpdateTodoRequest updateTodoRequest);
        Task DeleteTodoItemAsync(Guid id);
    }
}
