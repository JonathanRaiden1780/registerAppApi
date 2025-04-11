using ApiTest.Core.Dtos.Common.Request;
using ApiTest.Core.Dtos.Common.Response;

namespace ApiTest.Core.Contracts.Repositories.Common
{
    public interface IRepositoryUsers
    {
        bool Register(RegisterRequestDto req);
        List<GetUsersResponseDto> GetUsers();
    }
}

