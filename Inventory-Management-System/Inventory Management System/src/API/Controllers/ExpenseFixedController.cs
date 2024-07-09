using Domain.Entities.Models;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseFixedController : ControllerBase
{
    private readonly DataContext _context;

    public ExpenseFixedController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.ExpenseFixeds.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var expense = await _context.ExpenseFixeds.FindAsync(id);
        if (expense == null)
        {
            return NotFound();
        }
        return Ok(expense);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ExpenseFixed expense)
    {
        _context.ExpenseFixeds.Add(expense);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ExpenseFixed expense)
    {
        if (id != expense.Id)
        {
            return BadRequest();
        }

        _context.Entry(expense).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.ExpenseFixeds.AnyAsync(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var expense = await _context.ExpenseFixeds.FindAsync(id);
        if (expense == null)
        {
            return NotFound();
        }

        _context.ExpenseFixeds.Remove(expense);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
