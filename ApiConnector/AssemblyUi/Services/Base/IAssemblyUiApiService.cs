
using ApiConnector.AssemblyUi.Responses;
using ApiConnector.Helpers;

namespace ApiConnector.AssemblyUi.Services.Base;

public interface IAssemblyUiApiService
{
    Task<ApiResult<StartTranscribeResponse>> GetTranscript(string id);
    Task<ApiResult<StartTranscribeResponse>> StartTranscribe(string audioUrl);
    Task<ApiResult<string>> UploadFileAsync(Stream fileStream);
}
