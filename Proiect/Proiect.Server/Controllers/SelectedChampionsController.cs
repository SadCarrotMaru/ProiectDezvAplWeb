using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models.LeagueData;
using System;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SelectedChampionsController : ControllerBase
{
    private readonly ProiectContext _context;

    public SelectedChampionsController(ProiectContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetSelectedChampions()
    {
        var selectedChampions = await _context.SelectedChampions.ToListAsync();
        return Ok(selectedChampions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSelectedChampion(Guid id)
    {
        var selectedChampion = await _context.SelectedChampions
            .Include(sc => sc.ModelsRelations)
            .FirstOrDefaultAsync(sc => sc.Id == id);

        if (selectedChampion == null)
        {
            return NotFound();
        }

        return Ok(selectedChampion);
    }

    [HttpPost]
    public async Task<IActionResult> AddSelectedChampion(SelectedChampions selectedChampion)
    {
        _context.SelectedChampions.Add(selectedChampion);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSelectedChampion), new { id = selectedChampion.Id }, selectedChampion);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSelectedChampion(Guid id)
    {
        var selectedChampion = await _context.SelectedChampions
            .Include(sc => sc.ModelsRelations)
            .FirstOrDefaultAsync(sc => sc.Id == id);

        if (selectedChampion == null)
        {
            return NotFound();
        }

        _context.SelectedChampions.Remove(selectedChampion);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
