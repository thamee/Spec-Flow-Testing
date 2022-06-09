using ApiTesting2.Models;
using Refit;
using System;
using System.Threading.Tasks;

namespace ApiTesting2.Apis
{
    public interface IAuthApi
    {
        [Post("/admin")]
        Task<ApiResponse<TokenResponse>> CreateAdmin([Body] CreateUserRequest request);

        [Post("/admin")]
        Task<ApiResponse<TokenResponse>> Login([Body] LoginRequest request);


    }
}
