using AutoMapper;
using ApiTest.Core.Contracts.Factories.Common;
using ApiTest.Core.Contracts.Services;
using ApiTest.Core.Dtos.Common.Request;
using ApiTest.Core.Dtos.Common.Response;
using System.Net.Mail;
using System.Net;

namespace ApiTest.Services.Users
{
    public class ServiceUsers : BaseService, IServiceUsers
    {
        public ServiceUsers(IUnitOfWork UnitOfWork, Func<string, IServiceFactory> serviceFactory, IMapper mapper) : base(UnitOfWork, serviceFactory, mapper)
        {
        }
        public bool Register(RegisterRequestDto req){
            return UnitOfWork.RepositoryUsers.Register(req); 
        }
        public List<GetUsersResponseDto> GetUsers(){
            return UnitOfWork.RepositoryUsers.GetUsers(); 
        }

        
    }
}
