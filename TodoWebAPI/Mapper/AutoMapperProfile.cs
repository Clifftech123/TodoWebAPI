using AutoMapper;
using TodoWebAPI.Contract;
using TodoWebAPI.Models;

namespace TodoWebAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            // Create a mapping from the  <CreateTodoRequest  to Todo Models
            CreateMap<CreateTodoRequest, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore the Guid property
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Ignore the CreatedAt,  property
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore()); // Ignore the UpdatedAt property


            CreateMap<UpdateTodoRequest, TodoItem>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore the Guid property
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Ignore the CreatedAt,  property
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore()); // Ignore the UpdatedAt property


        }
    }
}
