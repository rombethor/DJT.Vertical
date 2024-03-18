using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DJT.Vertical.Http
{
    /// <summary>
    /// Relies on the implementation of System.Security.Claims to allow dependency injection of 
    /// authorisation data into request handlers.
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    public class AuthService(IHttpContextAccessor httpContextAccessor)
    {
        /// <summary>
        /// Check if the user has the specific claim with given value.
        /// </summary>
        /// <param name="claimType">Type of claim to check</param>
        /// <param name="claimValue">Value assigned to specified type to check for</param>
        /// <returns>True if the user has the given claim and value</returns>
        /// <exception cref="NullReferenceException">Thrown if no HttpContext</exception>
        public bool CheckClaim(string claimType, string claimValue)
        {
            HttpContext context = httpContextAccessor.HttpContext
                ?? throw new NullReferenceException("No HttpContext found for AuthService");
            return context.User.Claims
                .Where(uc => uc.Type == claimType && uc.Value == claimValue).Any();
        }

        /// <summary>
        /// Get the string value of the first of a specific claim.
        /// </summary>
        /// <param name="claimType"></param>
        /// <returns>The string value for the specified claim type, or null if no claim 
        /// of the specified type exists.</returns>
        /// <exception cref="NullReferenceException">Thrown if no HttpContext</exception>
        public string? GetFirstClaim(string claimType)
        {
            HttpContext context = httpContextAccessor.HttpContext
                ?? throw new NullReferenceException("No HttpContext found for AuthService");

            return context.User.Claims
                .Where(uc => uc.Type == claimType)
                .Select(uc => uc.Value)
                .FirstOrDefault();
        }

        /// <summary>
        /// Get all values for a specific claim type.
        /// </summary>
        /// <param name="claimType"></param>
        /// <returns>Enumerated values for the given claim type, if any</returns>
        /// <exception cref="NullReferenceException">Thrown if no HttpContext</exception>
        public IEnumerable<string> GetClaimValues(string claimType)
        {
            HttpContext context = httpContextAccessor.HttpContext
                ?? throw new NullReferenceException("No HttpContext found for AuthService");

            return context.User.Claims
                .Where(uc => uc.Type == claimType)
                .Select(uc => uc.Value);
        }

        /// <summary>
        /// Get all claim objects for a specified type.
        /// </summary>
        /// <param name="claimType">Type of claim to retrieve</param>
        /// <returns>Enumerated claims of the specified type</returns>
        /// <exception cref="NullReferenceException">Thrown if no HttpContext</exception>
        public IEnumerable<Claim> GetClaimsByType(string claimType)
        {
            HttpContext context = httpContextAccessor.HttpContext
                ?? throw new NullReferenceException("No HttpContext found for AuthService");
            return context.User.Claims
                .Where(uc => uc.Type == claimType);
        }
    }
}
