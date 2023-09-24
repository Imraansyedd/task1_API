using System.Collections.Generic;
using System.Data;
using Dapper;
using Task1.Models;
namespace Task1.Repository
{

    public class EmployeeRepository
    {
        private readonly IDbConnection _dbConnection;

        public EmployeeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbConnection.Query<Employee>("SELECT * FROM Employeez");
        }
    }

}
