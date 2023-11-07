using NOVOROV.Models;

namespace NOVOROV.Services.Interfaces
{
    public interface IApiService
    {
        Task<ApiAuthResponse> GetApiAuthToken();
        Task<ApiResponse> GetApiData(string token);
    }
}
