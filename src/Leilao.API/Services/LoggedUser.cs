using Leilao.API.Contracts;
using Leilao.API.Entities;

namespace Leilao.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;
    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) 
    { 
        _httpContextAccessor = httpContext;
        _repository = repository;
    }
    public User User()
    {

        var token = TokenOnRequest();
        var email = FromBase64String(token);
        
        return _repository.GetUserByEmail(email);
    }

    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..];
        // "Bearer Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20=" vai receber assim mas temos q usar apenas o token
    }
    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
