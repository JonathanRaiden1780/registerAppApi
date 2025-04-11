using System.Data;
using ApiTest.Core.Dtos.Common.Request;
using ApiTest.Core.Contracts.Repositories.Common;
using Dapper;
using AutoMapper;
using ApiTest.Core.Dtos.Common.Response;
using ApiTest.Core.Helpers;

namespace ApiTest.Repositories.Context
{
    public class RepositoryUsers : BaseRepository, IRepositoryUsers
    {
        public RepositoryUsers(IDbConnection connection, Func<IDbTransaction> transaction, IMapper mapper) : base(
            connection, transaction, mapper)
        {
        }

        public bool Register(RegisterRequestDto req)
        {
            string query = "INSERT INTO [dbo].[Users] (name, email, age) VALUES (@name, @email, @age)";
            int rowsAffected = Connection.Execute(query, new { req.name, req.email, req.age });
            return rowsAffected > 0;
            
        }
        public List<GetUsersResponseDto> GetUsers()
        {
            string query = "SELECT * FROM [dbo].[Users]";
            return Connection.Query<GetUsersResponseDto>(query, commandType: CommandType.Text).ToList();
        }
    }

}
