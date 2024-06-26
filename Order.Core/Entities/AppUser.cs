using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;
using Entity = Order.Core.Common.Entity;

namespace Order.Core.Entities
{
    public class AppUser : Entity
    {
        private AppUser(Guid id, string userName, string email, string passwordHash) : base(id)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
        } 
        private AppUser() { }
        public string UserName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;

        public static Result<AppUser> Create(Guid id, string userName, string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return Result.Failure<AppUser>("User name cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<AppUser>("Email cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(passwordHash))
                return Result.Failure<AppUser>("Password cannot be null or empty.");


            return new AppUser(id, userName, email, passwordHash);
        }

    }
}
