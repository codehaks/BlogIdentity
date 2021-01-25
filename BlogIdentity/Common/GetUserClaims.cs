using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogIdentity.Common
{
    public class GetUserClaims : IGetUserClaims
    {
        public string UserId
        {
            get
            {
                return _accessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        public string Continent { get { return _accessor.HttpContext.GetRouteValue("Continent")?.ToString(); } }
        private readonly IHttpContextAccessor _accessor;

        public GetUserClaims(IHttpContextAccessor accessor)
        {
            _accessor = accessor;


        }
    }
}
