namespace Animals.Web.Controllers;

using System.Net;
using Animals.Core.DTOs;
using Animals.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnimals()
    {
        var animals = await _animalService.GetAllAnimalsAsync();
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimal(int id)
    {
        var animal = await _animalService.GetAnimalByIdAsync(id);
        if (animal == null) return NotFound();
        return Ok(animal);
    }

    [HttpPost()]
    public async Task<IActionResult> CreateAnimal(CreateAnimalDto animalDto)
    {
        try
        {
            var animal = await _animalService.CreateAnimalAsync(animalDto);
            if (animal == null) return NotFound();
            return Ok(animal);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "An unexpected error occurred.", details = ex.Message });
        }

    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAnimal(int id, AnimalDto animalDto)
    {
        try
        {
            animalDto.Id = id;
            await _animalService.UpdateAnimalAsync(animalDto);

            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
        try
        {
            await _animalService.DeleteAnimalAsync(id);

            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "An unexpected error occurred.", details = ex.Message });
        }

    }
}