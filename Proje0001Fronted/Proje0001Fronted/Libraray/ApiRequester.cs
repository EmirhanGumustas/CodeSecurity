using System.Text;
using System.Text.Json;

public static class ApiRequester
{
    private static readonly HttpClient _httpClient = new HttpClient();

    static ApiRequester()
    {
        // Eğer global ayarlar yapılacaksa (örneğin zaman aşımı vs.), burası kullanılabilir
        _httpClient.Timeout = TimeSpan.FromSeconds(30);
    }

    public static async Task<string> SendRequestAsync(string url, object body)
    {
        try
        {
            // JSON formatına dönüştürme
            var jsonBody = JsonSerializer.Serialize(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // POST isteği yapma
            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            return "exception";
        }
        catch (Exception)
        {
            return "exception";
        }
    }
}
