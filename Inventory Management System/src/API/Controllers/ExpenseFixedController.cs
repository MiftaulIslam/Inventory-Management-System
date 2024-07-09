using API.Models;
using AutoMapper;
using Domain.Entities.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseFixedController : ControllerBase
{
    private readonly IUnitOfWork _work;
    private readonly IMapper _mapper;

    public ExpenseFixedController(IUnitOfWork work, IMapper mapper)
    {
        _work = work ?? throw new ArgumentNullException(nameof(work));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFixedExpenses(int pageIndex = 1, int pageSize = 10)
    {
        return Ok(_mapper.Map<IReadOnlyList<ExpenseFixedDto.WithId>>(await _work.GetAllAsync<ExpenseFixed>(pageIndex, pageSize)));
    }
}
