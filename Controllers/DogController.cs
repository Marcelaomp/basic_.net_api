using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Infra;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace Controller;

[Route("api/[controller]")]
[ApiController]
public class DogController : ControllerBase
{
    private readonly DogDb _context;
    
    public DogController(DogDb context)
    {
        _context = context;
    }

    [HttpGet("/all")]
    public async Task<ActionResult<IEnumerable<Dog>>> GetDogs() 
    {
        return await _context.Dogs.ToListAsync();
    }

    [HttpGet("/{id}")]
    public async Task<ActionResult<Dog>> GetDog(int id) 
    {
        var dog = await _context.Dogs.FindAsync(id);
        if (dog == null) 
        {
            return NotFound();
        }
        return dog;
    }

    [HttpPost]
    public async Task<ActionResult<Dog>> PostDogs(Dog dog) 
    {
        _context.Dogs.Add(dog);
        await _context.SaveChangesAsync();

        return Created("GetDog", dog);
    }

    [HttpPut("/{id}")]
    public async Task<IActionResult> PutDogs(int id, Dog newDog) 
    {
        var dog = await _context.Dogs.FindAsync(id);

        if ( dog == null || newDog.Id != newDog.Id) 
        {
            return BadRequest();
        }

        _context.Entry(newDog).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("/{id}")]
    public async Task<IActionResult> DeleteDogs(int id) 
    {
        var dog = await _context.Dogs.FindAsync("id");

        if (dog == null) 
        {
            return NotFound();
        }

        _context.Dogs.Remove(dog);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}