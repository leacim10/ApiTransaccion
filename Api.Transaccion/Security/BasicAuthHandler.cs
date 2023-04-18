using Api.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Api.Transaccion.Security
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private IManagerSecurity _manager;
        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IManagerSecurity manager
            ) : base (options, logger, encoder, clock)
        {
            _manager = manager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No se tiene el Header para la consulta.");

            bool result = false;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var creatialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(creatialBytes).Split(new[] { ':' }, 2);
                var user = credentials[0];
                var password = credentials[1];
                result = _manager.User(user, password);

                if(!result)
                    return AuthenticateResult.Fail("Usuario o contraseña invalida.");

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "ID"),
                    new Claim(ClaimTypes.Name, "user")
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            catch(Exception ex)
            {
                return AuthenticateResult.Fail("Se tuvo problemas con la autenticación.");
            }
        }
    }
}
