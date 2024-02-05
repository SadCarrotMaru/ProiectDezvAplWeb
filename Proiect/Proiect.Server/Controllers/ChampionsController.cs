using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;
using Proiect.Models.LeagueData;
using System;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Data.DTOs;
using Proiect.Helpers.Attributes;
using Proiect.Models.Enums;
using Proiect.Services.UserService;


[Route("[controller]")]
[ApiController]
public class ChampionController : ControllerBase
{
    private readonly ProiectContext _context;

    public ChampionController(ProiectContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetChampions()
    {
        var groupedChampions = await _context.Champions
            .GroupBy(c => c.Role)
            .ToListAsync();

        return Ok(groupedChampions);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetChampion(Guid id)
    {
        var champion = await _context.Champions
            .Include(c => c.SelectedChampions)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (champion == null)
        {
            return NotFound();
        }

        return Ok(champion);
    }

    [Authorize(Role.Admin)]
    [HttpPost]
    public async Task<IActionResult> AddChampion(Champion champion)
    {
        _context.Champions.Add(champion);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetChampion), new { id = champion.Id }, champion);
    }

    [Authorize(Role.Admin)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChampion(Guid id)
    {
        var champion = await _context.Champions
            .Include(c => c.SelectedChampions)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (champion == null)
        {
            return NotFound();
        }

        _context.Champions.Remove(champion);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
