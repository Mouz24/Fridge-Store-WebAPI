using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDTO userForAuth);
        Task<bool> ValidateExpiredTokenClaims(string userName, string refreshToken);
        Task<string> CreateAccessToken();
        string CreateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        void ReassignRefreshToken(string refreshToken);
        Task AddRefreshToken(UserForAuthenticationDTO userForAuth, string refreshToken);
        Task RevokeRefreshToken(string userName);

    }
}
