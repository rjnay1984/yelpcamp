using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Yelpcamp.ApplicationCore.Interfaces;
using Yelpcamp.Infrastructure.Identity;

namespace Yelpcamp.PublicApi.AuthEndpoints
{
    public class Register : BaseAsyncEndpoint<RegisterRequest, RegisterResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenClaimsService _tokenClaimsService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Register(
            UserManager<ApplicationUser> userManager, 
            ITokenClaimsService tokenClaimsService, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _tokenClaimsService = tokenClaimsService;
            _signInManager = signInManager;
        }

        [HttpPost("api/register")]
        public override async Task<ActionResult<RegisterResponse>> HandleAsync(
            RegisterRequest request, CancellationToken cancellationToken)
        {
            if (await UserExists(request.Email) != null) return BadRequest("User already exists");

            var response = new RegisterResponse(request.CorrelationId());

            var user = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.Email,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(user, request.Password, false, true);
                response.Username = user.UserName;
                response.Token = await _tokenClaimsService.GetTokenAsync(request.Email);
            }

            return response;
        }

        private async Task<ApplicationUser> UserExists(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
