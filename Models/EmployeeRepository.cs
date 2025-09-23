using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BlazorEmployeeApp.Models
{
    public class EmployeeRepository
    {
        private readonly IConfiguration _config;
        public EmployeeRepository(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Employee>("sp_GetEmployees", commandType: CommandType.StoredProcedure);
        }

        public async Task AddEmployee(Employee emp)
        {
            using var conn = GetConnection();
            await conn.ExecuteAsync("sp_AddEmployee", new { emp.Name, emp.Department, emp.Salary }, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateEmployee(Employee emp)
        {
            using var conn = GetConnection();
            await conn.ExecuteAsync("sp_UpdateEmployee", new { emp.EmployeeId, emp.Name, emp.Department, emp.Salary }, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteEmployee(int id)
        {
            using var conn = GetConnection();
            await conn.ExecuteAsync("sp_DeleteEmployee", new { EmployeeId = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
