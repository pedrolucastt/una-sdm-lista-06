using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsumerPokeApi.Model;

Console.Write("Digite o nome do Pokémon: ");
string nome = Console.ReadLine();

string url = $"https://pokeapi.co/api/v2/pokemon/{nome}";

HttpClient client = new HttpClient();

HttpResponseMessage response = await client.GetAsync(url);

if (response.IsSuccessStatusCode)
{
    string json = await response.Content.ReadAsStringAsync();

    Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(json);

    Console.WriteLine("\nDados do Pokémon:");
    Console.WriteLine($"Id: {pokemon.Id}");
    Console.WriteLine($"Nome: {pokemon.Nome}");
    Console.WriteLine($"Altura: {pokemon.Altura}");
    Console.WriteLine($"Peso: {pokemon.Peso}");
}
else
{
    Console.WriteLine("Pokémon não encontrado.");
}