using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DJT.Vertical.Http
{
    /// <summary>
    /// Relies on the implementation of System.Security.Claims to allow dependency injection of 
    /// authorisation data into request handlers.
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    public class AuthService(IHttpContextAccessor httpContextAccessor)
    {
        public bool CheckClaim(string claimType, string claimValue)
        {
            HttpContext context = httpContextAccessor.HttpContext
                ?? throw new NullReferenceException("No HttpContext found for AuthService");
            return context.User.Claims
                .Where(uc => uc.Type == claimType && uc.Value == claimValue).Any();
        }
        public string? GetFirstClaim(string claimType)
        {
            HttpContext context = httpContextAccessor.HttpContext
                ?? throw new NullReferenceException("No HttpContext found for AuthService");

            return context.User.Claims
                .Where(uc => uc.Type == claimType)
                .Select(uc => uc.Value)
                .FirstOrDefault();
        }

        public IEnumerable<string> GetClaimValues(string claimType)
        {
            HttpContext context = httpContextAccessor.HttpContext
                ?? throw new NullReferenceException("No HttpContext found for AuthService");

            return context.User.Claims
                .Where(uc => uc.Type == claimType)
                .Select(uc => uc.Value);
        }

        public IEnumerable<Claim> GetClaimsByType(string claimType)
        {
            HttpContext context = httpContextAccessor.HttpContext
                ?? throw new NullReferenceException("No HttpContext found for AuthService");
            return context.User.Claims
                .Where(uc => uc.Type == claimType);
        }
    }
}
