namespace Order.Application.Features.Users.Register
{
    public record RegisterRequest(string username, string email, string password);
}
