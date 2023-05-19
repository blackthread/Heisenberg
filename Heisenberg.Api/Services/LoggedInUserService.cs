using Heisenberg.Application.Contracts;
using System.Security.Claims;

namespace Heisenberg.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoggedInUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }


        public string UserId {
            get
            {
                try
                {
                    return _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                }
                catch (Exception)
                {

                    return "Steve";
                }
              
            }
 }
    }
}
