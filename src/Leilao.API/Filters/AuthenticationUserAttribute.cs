using Leilao.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Immutable;

namespace Leilao.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);
            var repository = new LeilaoDbContext();

            var email = FromBase64String(token);
            var exist = repository.Users.Any(user => user.Email.Equals(email));

            if (exist == false)
            {
                context.Result = new UnauthorizedObjectResult("E-mail not valid");
            }
        }
        catch (Exception ex)
        {

            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }
    private string TokenOnRequest(HttpContext context)
    {
        var authentication = context.Request.Headers.Authorization.ToString();
        if(string.IsNullOrEmpty(authentication))
        {
            throw new Exception("Token is missign.");
        }
        return authentication["Bearer ".Length..];
        // "Bearer Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20=" vai receber assim mas temos q usar apenas o token
    }
    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
