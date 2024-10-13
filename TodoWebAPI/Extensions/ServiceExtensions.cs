using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Context;
using TodoWebAPI.Interface;
using TodoWebAPI.Middleware;
using TodoWebAPI.Services;

namespace TodoWebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
            });

            builder.Services.AddScoped<ITodoServices, TodoService>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
