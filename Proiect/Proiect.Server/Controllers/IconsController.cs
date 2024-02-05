using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models.Enums;
using Proiect.Models.LeagueData;
using System;
using System.Linq;
using System.Threading.Tasks;
using Proiect.Helpers.Attributes;

[Route("[controller]")]
[ApiController]
public class IconsController : ControllerBase
{
    private readonly ProiectContext _context;

    public IconsController(ProiectContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetIcons()
    {
        var icons = await _context.Icons.ToListAsync();
        return Ok(icons);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIcon(Guid id)
    {
        var icon = await _context.Icons.FindAsync(id);

        if (icon == null)
        {
            return NotFound();
        }

        return Ok(icon);
    }

    [Authorize(Role.Admin)]
    [HttpPost]
    public async Task<IActionResult> AddIcon(Icons icon)
    {
        _context.Icons.Add(icon);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetIcon), new { id = icon.Id }, icon);
    }

    [Authorize(Role.Admin)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIcon(Guid id)
    {
        var icon = await _context.Icons.FindAsync(id);

        if (icon == null)
        {
            return NotFound();
        }

        _context.Icons.Remove(icon);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
