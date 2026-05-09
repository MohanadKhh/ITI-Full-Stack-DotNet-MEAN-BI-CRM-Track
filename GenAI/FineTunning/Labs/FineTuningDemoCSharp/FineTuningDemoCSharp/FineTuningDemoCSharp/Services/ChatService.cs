using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FineTuningDemoCSharp.Services
{
    public class ChatService
    {
        public string Endpoint { get; set; }
        public string APIKey { get; set; }
        public string ModelName { get; set; }

        public async Task<string> ChatWithAI(string Message)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", APIKey);

            var body = new
            {
                model = ModelName,
                messages = new[]
                {
                    new { role = "user", content = Message }
                }
            };

            var json = JsonSerializer.Serialize(body);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(Endpoint, content);
            var result = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(result);

            var res = doc
                .RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return res;
        }
    }
}
