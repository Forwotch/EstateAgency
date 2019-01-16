using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EstateAgency.Authentification.Services
{
    public interface IAuthentificationService
    {
        /// <summary>
        /// Logs user in.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        /// <returns>Returns success of operation</returns>
        Task<bool> LogIn(string email, string password);

        /// <summary>
        /// Logs user out.
        /// </summary>
        Task LogOut();

        /// <summary>
        /// Registers user.
        /// </summary>
        /// <param name="email">User email</param>
        /// <param name="password">User password</param>
        /// <param name="confirmPassword">User password for confirmation</param>
        /// <param name="roles">User roles</param>
        /// <returns>Returns collection of errors</returns>
        Task<IEnumerable<IdentityError>> Register(string email, string password, string confirmPassword,
            params string[] roles);
    }
}