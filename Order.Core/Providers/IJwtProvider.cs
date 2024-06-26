using CSharpFunctionalExtensions;
using Order.Core.Entities;

namespace Order.Infrastructure.Providers
{
    public interface IJwtProvider
    {
        Result<string> Generate(AppUser user);
    }
}