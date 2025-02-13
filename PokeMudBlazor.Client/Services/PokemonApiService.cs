using RestSharp;
using SharedModels;

namespace PokeMudBlazor.Client.Services
{
    public class PokemonApiService
    {
        private readonly RestClient _client;

        public PokemonApiService()
        {
            _client = new RestClient("https://localhost:7019/api/pokemon/");
        }

        public async Task<List<Pokemon>> GetPokemonsAsync(int count = 4)
        {
            var request = new RestRequest($"pokemons?count={count}", Method.Get);
            var response = await _client.ExecuteAsync<List<Pokemon>>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                return new List<Pokemon>();
            }
        }
    }
}