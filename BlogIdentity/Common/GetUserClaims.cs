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
                return _accessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        private readonly IHttpContextAccessor _accessor;

        public GetUserClaims(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
    }
}
