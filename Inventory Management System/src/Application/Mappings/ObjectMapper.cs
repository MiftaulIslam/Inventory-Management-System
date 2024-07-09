using API.Models;
using AutoMapper;
using Domain.Entities.Models;

namespace Application.Mappings;
public class ObjectMapper : Profile
{
    public ObjectMapper()
    {
        CreateMap<ExpenseFixed, ExpenseFixedDto.WithId>().ReverseMap();
        CreateMap<ExpenseFixed, ExpenseFixedDto.WithoutId>().ReverseMap();
    }
}
