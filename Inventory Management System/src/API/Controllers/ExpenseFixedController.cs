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
        return Ok(_mapper.Map<IReadOnlyList<ExpenseFixedDto.WithoutId>>(await _work.GetAllAsync<ExpenseFixed>(pageIndex, pageSize)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFixedExpenseById(int id)
    {
        var expense = await _work.Repository<ExpenseFixed>().GetByIdAsync(id);

        if (expense == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<ExpenseFixedDto.WithId>(expense));
    }

    [HttpPost]
    public async Task<IActionResult> CreateFixedExpense([FromBody] ExpenseFixedDto.WithoutId expenseDto)
    {
        if (expenseDto == null)
        {
            return BadRequest("Expense data is null");
        }

        var expense = _mapper.Map<ExpenseFixed>(expenseDto);
        await _work.Repository<ExpenseFixed>().AddAsync(expense);
        await _work.SaveAsync();

        var expenseWithIdDto = _mapper.Map<ExpenseFixedDto.WithId>(expense);

        return CreatedAtAction(nameof(GetFixedExpenseById), new { id = expenseWithIdDto.Id }, expenseWithIdDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFixedExpense(int id, [FromBody] ExpenseFixedDto.WithId expenseDto)
    {
        if (expenseDto == null)
        {
            return BadRequest("Expense data is null");
        }

        var existingExpense = await _work.Repository<ExpenseFixed>().GetByIdAsync(id);

        if (existingExpense == null)
        {
            return NotFound();
        }

        _mapper.Map(expenseDto, existingExpense);
        await _work.Repository<ExpenseFixed>().UpdateAsync(id, existingExpense);
        await _work.SaveAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFixedExpense(int id)
    {
        var expense = await _work.Repository<ExpenseFixed>().GetByIdAsync(id);

        if (expense == null)
        {
            return NotFound();
        }

        await _work.Repository<ExpenseFixed>().DeleteAsync(id);
        await _work.SaveAsync();

        return NoContent();
    }
}
