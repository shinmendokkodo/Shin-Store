using Newtonsoft.Json;
using Shin.Web.Models;
using Shin.Web.Models.Dtos;
using Shin.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shin.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto response { get; set; }
        private readonly IHttpClientFactory httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            response = new();
            this.httpClient = httpClient;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("ShinApi");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = null;
                message.Method = apiRequest.ApiType switch
                {
                    UrlConfig.ApiType.POST => HttpMethod.Post,
                    UrlConfig.ApiType.PUT => HttpMethod.Put,
                    UrlConfig.ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get,
                };

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;

            }
            catch (Exception e)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }
    }
}
