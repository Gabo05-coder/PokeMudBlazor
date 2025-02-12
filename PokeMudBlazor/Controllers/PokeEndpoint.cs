using Microsoft.AspNetCore.Mvc;
using PokeMudBlazor.Service;
using SharedModels;

namespace PokeMudBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // Endpoint para obtener una lista de pokemons
        [HttpGet("pokemons")]
        public async Task<IActionResult> GetPokemons(int count = 4)
        {
            try
            {
                var pokemons = await _pokemonService.GetPokemonsAsync(count);
                return Ok(pokemons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}