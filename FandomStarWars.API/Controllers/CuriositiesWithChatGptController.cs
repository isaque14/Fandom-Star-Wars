using FandomStarWars.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FandomStarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuriositiesWithChatGptController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CuriositiesWithChatGptController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Utilize o Chat GPT para obter Curiosidades, Notícias e Informações sobre o Universo de Star Wars
        /// </summary>
        /// <param name="text">Texto de Busca</param>
        /// <returns>Informações de acordo com o texto informado</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string text, [FromServices] IConfiguration configuration)
        {
            var token = configuration.GetValue<string>("ChatGptSecretKey");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var model = new ChatGptInputModel(text);
            var requestBody = JsonSerializer.Serialize(model);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);
            var result = await response.Content.ReadFromJsonAsync<ChatGptResponseModel>();
            var promptResponse = result.choices.First();

            return Ok(promptResponse.text.Replace("\n", "").Replace("t", ""));
        }
    }
}