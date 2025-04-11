using AutoMapper;
using ApiTest.Core.Contracts.Factories.Common;
using ApiTest.Core.Contracts.Services;
using Microsoft.Extensions.Configuration;
using ApiTest.Services.Users;

namespace ApiTest.Services
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IUnitOfWork UnitOfWork = null;
        private readonly IMapper mapper = null;
        private readonly Func<string, IServiceFactory> serviceFactory = null;
        protected readonly IConfiguration configuration;

        private IServiceUsers serviceUsers = null;


        public ServiceFactory(IUnitOfWork unitOfWork, Func<string, IServiceFactory> serviceFactory, IMapper mapper, IConfiguration configuration)
        {
            UnitOfWork = unitOfWork;
            this.mapper = mapper;
            this.serviceFactory = serviceFactory;
            this.configuration = configuration;
        }

        public IServiceUsers ServiceUsers => serviceUsers ??= new ServiceUsers(UnitOfWork, serviceFactory, mapper);
    }
}
