using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class OpenAIHealthCheckService : IHealthCheck
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public OpenAIHealthCheckService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _configuration = configuration;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var config = new ConfigRetunrHealthCheckOpenAI("teste");

        var token = _configuration.GetValue<string>("ChatGptSecretKey");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var requestBody = JsonSerializer.Serialize(config);
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);

        if (response.IsSuccessStatusCode)
            return HealthCheckResult.Healthy();

        return HealthCheckResult.Unhealthy($"API returned {response.StatusCode} status code");
    }

    public class ConfigRetunrHealthCheckOpenAI
    {
        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public decimal temperature { get; set; }

        public ConfigRetunrHealthCheckOpenAI(string prompt)
        {
            this.prompt = $"return ok status code: {prompt}";
            temperature = 0.2m;
            max_tokens = 100;
            model = "text-davinci-003";
        }
    }
}

