using Microsoft.AspNetCore.Mvc;
using ApiTest.Core.Contracts.Factories.Common;

namespace ApiTest.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly Func<string, IServiceFactory> serviceFactory;

        protected BaseController(Func<string, IServiceFactory> serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }
    }
}
