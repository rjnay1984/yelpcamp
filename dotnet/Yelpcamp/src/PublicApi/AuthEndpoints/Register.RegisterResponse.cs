using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yelpcamp.PublicApi.AuthEndpoints
{
    public class RegisterResponse : BaseResponse
    {
        public RegisterResponse(Guid correlationId) : base(correlationId)
        { }

        public RegisterResponse()
        { }

        public string Username { get; set; }
        public string Token { get; set; }
    }
}
