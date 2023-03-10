using Shin.Web.Models;
using Shin.Web.Models.Dtos;
using System;
using System.Threading.Tasks;

namespace Shin.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto response { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
