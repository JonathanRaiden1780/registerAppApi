using ApiTest.Core.Contracts.Factories.Common;
using ApiTest.Core.Dtos;
using ApiTest.Core.Dtos.Common.Request;
using ApiTest.Core.Exceptions;
using ApiTest.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Api.Controllers.Users
{
    [ApiController]
    [Produces(Constants.ContentType)]
    [Route(Constants.RouteUsers, Name = Constants.UsersTitle)]
    public class UsersController : BaseController
    {
        public UsersController(Func<string, IServiceFactory> serviceFactory) : base(serviceFactory)
        {
        }

        /// <summary>
        /// Registrar usuario
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost(Constants.Register)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult Register(RegisterRequestDto req)
        {
            ActionResult result;
            try
            {
                var response = serviceFactory("Test").ServiceUsers.Register(req);
                result = Ok(response);
            }

            catch (BusinessException busex)
            {
                var trackingCode = new Guid().ToString();
                result = Conflict(new 
                {
                    Origin = Constants.OriginService, Message = new[] {busex.Message},
                    TrackingCode = trackingCode
                });
            }
            catch (Exception ex)
            {
                var trackingCode = new Guid().ToString();
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    new 
                    {
                        Origin = Constants.OriginService, Message = new[] {ex.ToString()}, TrackingCode = trackingCode
                    });
            }
            finally
            {
            }

            return result;
        }
        
        /// <summary>
        /// Obtener usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet(Constants.GetUsers)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult GetUsers()
        {
            ActionResult result;
            try
            {
                var response = serviceFactory("Test").ServiceUsers.GetUsers();
                result = Ok(response);
            }

            catch (BusinessException busex)
            {
                var trackingCode = new Guid().ToString();
                result = Conflict(new 
                {
                    Origin = Constants.OriginService, Message = new[] {busex.Message},
                    TrackingCode = trackingCode
                });
            }
            catch (Exception ex)
            {
                var trackingCode = new Guid().ToString();
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    new 
                    {
                        Origin = Constants.OriginService, Message = new[] {ex.ToString()}, TrackingCode = trackingCode
                    });
            }
            finally
            {
            }

            return result;
        }
        
               
    }
}