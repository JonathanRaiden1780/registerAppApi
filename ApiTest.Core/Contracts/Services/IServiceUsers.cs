
using ApiTest.Core.Dtos.Common.Request;
using ApiTest.Core.Dtos.Common.Response;

namespace ApiTest.Core.Contracts.Services
{
    public interface IServiceUsers
    {
        bool Register(RegisterRequestDto req);
        List<GetUsersResponseDto> GetUsers();
    }
}
