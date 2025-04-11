using AutoMapper;
using ApiTest.Core.Contracts.Factories.Common;

namespace ApiTest.Services
{
    public class BaseService
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly Func<string, IServiceFactory> serviceFactory;

        protected BaseService(IUnitOfWork UnitOfWork, Func<string, IServiceFactory> serviceFactory, IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.serviceFactory = serviceFactory;
            this.mapper = mapper;
        }

    }
}
