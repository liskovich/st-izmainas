using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Entities;

namespace Izmainas.FileUploadService.Workers
{
    public class JokeService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private const string JokeApiUrl = "https://karljoke.herokuapp.com/jokes/programming/random";

        public JokeService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetJokeAsync()
        {
            try
            {
                List<Joke> jokes = await _httpClient.GetFromJsonAsync<List<Joke>>(JokeApiUrl, _options);
                Joke joke = jokes?[0];

                return joke is not null
                    ? $"{joke.Setup}{Environment.NewLine}{joke.Punchline}"
                    : "No jokes nigga!";
            }
            catch (Exception ex)
            {
                return $"Not funny bitch! {ex}";
            }
        }
    }
}