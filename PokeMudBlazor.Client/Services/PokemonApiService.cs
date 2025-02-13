using SharedModels;
using System.Net.Http.Json;

namespace PokeMudBlazor.Client.Services
{
    public class PokemonApiService
    {
        private readonly HttpClient _httpClient;

        public PokemonApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Pokemon>> GetPokemonsAsync(int count = 4)
        {
            try
            {
                // Llama al endpoint del servidor
                var pokemons = await _httpClient.GetFromJsonAsync<List<Pokemon>>($"api/pokemon/pokemons?count={count}");
                return pokemons ?? new List<Pokemon>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener pokemons: {ex.Message}");
                return new List<Pokemon>();
            }
        }
    }
}