using ApiConnector.AssemblyUi.Requests;
using ApiConnector.AssemblyUi.Responses;
using ApiConnector.AssemblyUi.Services.Base;
using ApiConnector.Helpers;
using ApiConnector.Helpers.Base;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ApiConnector.AssemblyUi.Services;

public class AssemblyUiApiService : ApiService, IAssemblyUiApiService
{
    public AssemblyUiApiService()
    {
        httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("authorization", ApiKey);
    }

    public async Task<ApiResult<string>> UploadFileAsync(Stream fileStream)
    {
        using (var fileContent = new StreamContent(fileStream))
        {
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            using (var result = await httpClient.PostAsync("https://api.assemblyai.com/v2/upload", fileContent))
            {
                if (result.IsSuccessStatusCode)
                {
                    var jsonDoc = await result.Content.ReadFromJsonAsync<JsonDocument>();

                    // Add null check to fix CS8602 warning
                    return jsonDoc?.RootElement.GetProperty("upload_url").GetString() ??
                       throw new InvalidOperationException("Failed to get upload URL from response");
                }
                else
                    return BuildApiResult<string>(result.StatusCode, result.Content.ToString() ?? "Unknown Message");
            }
        }
    }

    public async Task<ApiResult<StartTranscribeResponse>> StartTranscribe(string audioUrl)
    {
        using (var httpRequest = new HttpRequestMessage())
        {
            var request = new TempReauest()
            {
                audio_url = audioUrl,
                language_code = "ru",
            };

            httpRequest.Content = JsonContent.Create(request);
            httpRequest.RequestUri = new Uri(ApiUrl + "/v2/transcript");
            httpRequest.Method = HttpMethod.Post;

            using (HttpResponseMessage result = await httpClient.SendAsync(httpRequest))
            {
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadFromJsonAsync<StartTranscribeResponse>();
                }
                else
                    return BuildApiResult<StartTranscribeResponse>(result.StatusCode, result.Content.ToString() ?? "Unknown Message");
            }
        }
    }

    public async Task<ApiResult<StartTranscribeResponse>> GetTranscript(string id)
    {
        string pollingEndpoint = $"{ApiUrl}/v2/transcript/{id}";

        using (var result = await httpClient.GetAsync(pollingEndpoint))
        {
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<StartTranscribeResponse>();
            }
            else
                return BuildApiResult<StartTranscribeResponse>(result.StatusCode, result.Content.ToString() ?? "Unknown Message");
        }   
    }

    private readonly HttpClient httpClient;

    private readonly string ApiUrl = "https://api.assemblyai.com";
    private readonly string ApiKey = "222f7276509c47b8a634f721c7ba70e6";
}
