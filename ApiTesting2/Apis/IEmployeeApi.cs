using ApiTesting2.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesting2.Apis
{
    public interface IEmployeeApi
    {
        [Get("/api/protected/employe")]
        Task<ApiResponse<List<EmployeeResponse>>> GetEmployees([Query] int limit = 5);

        [Post("/api/protected/employe")]
        Task<ApiResponse<EmployeeResponse>> CreateEmployee([Body] CreateEmployeeRequest request);

        [Delete("/api/protected/employe/{id}")]
        Task<ApiResponse<EmployeeResponse>> DeleteEmployee(int id);

        [Get("/api/protected/employe/{id}")]
        Task<ApiResponse<EmployeeResponse>>GetEmployeeById(int id);

        [Put("/api/protected/employe")]
        Task<ApiResponse<EmployeeResponse>> UpdateEmployee([Body] UpdateEmployeRequest request);
    }
}
