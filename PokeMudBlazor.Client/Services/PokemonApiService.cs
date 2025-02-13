using RestSharp;
using SharedModels;

namespace PokeMudBlazor.Client.Services
{
    public class PokemonApiService
    {
        private readonly RestClient _client;
        private readonly int MaxPokemonId = 1010; // Hasta el último Pokémon en la PokéAPI

        public PokemonApiService()
        {
            _client = new RestClient("https://pokeapi.co/api/v2/");
        }

        public async Task<List<Pokemon>> GetPokemonsAsync(int count = 16)
        {
            var pokemons = new List<Pokemon>();
            var randomIds = GetRandomIds(count);

            foreach (var id in randomIds)
            {
                var request = new RestRequest($"pokemon/{id}", Method.Get);
                var response = await _client.ExecuteAsync<Pokemon>(request);

                if (response.IsSuccessful && response.Data != null)
                {
                    pokemons.Add(response.Data);
                }
            }

            return pokemons;
        }

        private List<int> GetRandomIds(int count)
        {
            var random = new Random();
            var ids = new HashSet<int>();

            while (ids.Count < count)
            {
                int randomId = random.Next(1, MaxPokemonId + 1);
                ids.Add(randomId);
            }

            return ids.ToList();
        }
    }
}