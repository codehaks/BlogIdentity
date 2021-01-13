using Microsoft.AspNetCore.Http;
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
                var user = _accessor.HttpContext;
                var userName = user.User.Identity.Name;

                return _accessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        private readonly IHttpContextAccessor _accessor;
        public GetUserClaims(IHttpContextAccessor accessor)
        {
            _accessor = accessor;

            var uid = accessor.HttpContext?.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        }
    }
}
