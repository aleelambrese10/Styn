using Styn.Application.Models;
using Styn.Domain.DTOs;
using Styn.Domain.Entities;
using AutoMapper;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Styn.Application.Services
{


    public interface IAuthService
    {
        Task<SignInResult> Login(string email, string password);
        Task<UserDTO> GetLoggedUser(string token);
        Task Logout();
        Task<int?> GetUserTenantId();
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<IdentityResult> Register(RegisterRequest model);
        Task<string> GenerateToken(string email);
        ClaimsPrincipal ValidateToken(string token);
        Task<bool> ValidateCredentials(string email, string password);
        Task<bool> ActivateUser(string email);
        Task<bool> DesactivateUser(string email);
        Task<bool> Update(UserDTO user);

        IEnumerable<string> GetRoles();

        Task<IdentityResult> AssignRoleToUser(string userId, string roleName);
        Task<IEnumerable<string>> GetUserRoles(string userId);
        Task<List<UserDTO>> GetUsersWithRoles();
        Task<IdentityResult> ResetPassword(string email);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordRequest request);
        Task<IdentityResult> DeleteUser(string id);
        Task<bool> AssignPayToUser(string userId, Pago pago);
    }

    public class AuthService : IAuthService
    {
        // ... (como anteriormente)

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mappingProfile;
        public AuthService(IHttpContextAccessor httpContextAccessor, IMapper mappingProfile, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _mappingProfile = mappingProfile;

        }


        private readonly string _secretKey = "TuClaveSecretaSuperSeguraDe256BitsReLargisima"; // Cambia esto por una clave secreta real
        public async Task<bool> AssignPayToUser(string userId, Pago pago)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) return false;
                user.MembresiaInicio = pago.FechaPago;
                user.MembresiaFin = pago.FechaPago.AddMonths(1);

                var res = await _userManager.UpdateAsync(user);
                if (res.Succeeded)
                    return true;
                return false;
            }
            catch (Exception e)
            {

                throw;
            }


        }
        public async Task<string> GenerateToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);  // Obtén los roles del usuario

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
            };

            // Agrega los roles como claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "NotFound" });


            var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);


            return result;


        }
        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User Not Found" });
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded) { return result; }
            return IdentityResult.Failed();
        }
        private string GenerateRandomPassword(ApplicationUser user)
        {
            string seed = user.Nombre + user.Dni + user.Email;

            // Convertir la semilla a un array de bytes
            byte[] bytes = Encoding.UTF8.GetBytes(seed);

            // Calcular un hash de la semilla
            int hash = BitConverter.ToInt32(System.Security.Cryptography.MD5.Create().ComputeHash(bytes), 0);

            // Usar el hash para generar una cadena aleatoria
            Random random = new Random(hash);
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int passwordLength = 10;
            var password = new char[passwordLength];
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }
            var finalPass = new string(password) + "-";
            return finalPass;

        }
        public async Task<IdentityResult> ResetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "NotFound" });

            var newPassword = GenerateRandomPassword(user);
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            var message = $"Tu nueva contraseña es: {newPassword}\n Para realizar el cambio de contraseña dirijase a: Mi Perfil>Cambiar contraseña";

            await SendEmailAsync(email, "Nueva contraseña Styn", message);
            //await _sendEmailService.SendEmailAsync(email, "Nueva contraseña", message);
            if (result.Succeeded) return result;

            return IdentityResult.Failed();


        }
        private async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            var address = "info@Styn.org";
            var pass = "userdB01.";
            emailMessage.From.Add(new MailboxAddress(subject, address));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = message };
            try
            {

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("smtp.hostinger.com", 465, SecureSocketOptions.Auto);
                    await client.AuthenticateAsync(address, pass);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        private async Task SendEmailAsyncWelcome(string email)
        {
            var emailMessage = new MimeMessage();

            var address = "info@Styn.org";
            var pass = "userdB01.";
            emailMessage.From.Add(new MailboxAddress("Styn | ASOCIACIÓN SANTOTOMESINA DE USUARIOS DE CANNABIS", address));
            emailMessage.To.Add(new MailboxAddress("", email));
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "TemplateEmail.html");
            if (!File.Exists(path))
            {
                Console.WriteLine("El archivo de la plantilla de correo no existe.");

            }
            string htmlBody = File.ReadAllText(path);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = htmlBody;

            // Asignar el cuerpo del mensaje al MimeMessage
            emailMessage.Body = bodyBuilder.ToMessageBody();
            emailMessage.Subject = "Cuenta creada";
            //var bodyBuilder = new BodyBuilder
            //{
            //    HtmlBody = body
            //};
            //emailMessage.Body = bodyBuilder.ToMessageBody();
            try
            {

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("smtp.hostinger.com", 465, SecureSocketOptions.Auto);
                    await client.AuthenticateAsync(address, pass);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_secretKey);
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }

        //public async Task<SignInResult> Login(string email, string password)
        //{
        //    var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
        //    if (result.Succeeded)
        //    {
        //        var user = await _userManager.FindByEmailAsync(email);
        //        var token = await GenerateJwtToken(user);

        //        _httpContextAccessor.HttpContext.Response.Headers.Add("Access-Token", token);


        //        var claims = new List<Claim>
        //        {
        //            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            new Claim("TenantId", user.TenantId.ToString()),
        //             new Claim(ClaimTypes.Email, user.Email),
        //        };


        //        var claimsIdentity = new ClaimsIdentity(claims, "Jwt");
        //        _httpContextAccessor.HttpContext.User = new ClaimsPrincipal(claimsIdentity);
        //    }

        //    return result;
        //}

        public async Task<SignInResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);

                var userRoles = await _userManager.GetRolesAsync(user);
                var claims = BuildClaims(user, userRoles);
                var token = GenerateToken(claims);

                _httpContextAccessor.HttpContext.Response.Headers.Add("Access-Token", token);

                var claimsIdentity = new ClaimsIdentity(claims, "Jwt");
                _httpContextAccessor.HttpContext.User = new ClaimsPrincipal(claimsIdentity);
            }

            return result;
        }


        private List<Claim> BuildClaims(ApplicationUser user, IList<string> roles = null)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim("role", role));
                }
            }

            return claims;
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
            var symmetricSecurityKey = new SymmetricSecurityKey(key);
            var creds = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(1));

            var token = new JwtSecurityToken(
                "yourdomain.com",
                "yourdomain.com",
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        public class UserResult
        {
            public string Id { get; set; }
            public Dictionary<string, string> Claims { get; set; }
        }

        public async Task<UserDTO> GetLoggedUser(string token)
        {
            var principal = ValidateToken(token);
            if (principal != null)
            {
                var emailClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                if (emailClaim != null)
                {
                    var user = await _userManager.FindByEmailAsync(emailClaim.Value);
                    var userDto = _mappingProfile.Map<UserDTO>(user);
                    var roles = await GetUserRoles(user.Id);
                    if (roles != null)
                    {
                        userDto.Role = roles.FirstOrDefault();
                    }
                    return userDto;
                }
            }

            return null;
        }



        //public async Task<ApplicationUser> GetLoggedUser()
        //{
        //    try
        //    {
        //        var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        //        if (email == null)
        //        {
        //            return null;
        //        }

        //        return await _userManager.FindByEmailAsync(email);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Ocurrió un error específico: " + ex.Message, ex);
        //    }
        //}



        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<int?> GetUserTenantId()
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var authHeader = httpContext.Request.Headers["Authorization"].ToString();
                if (authHeader.StartsWith("Bearer "))
                {
                    var token = authHeader.Substring("Bearer ".Length);
                    var user = await GetLoggedUser(token);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el tenantId del usuario: {ex.Message}");
            }

            return null;
        }


        public async Task<IEnumerable<string>> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            return await _userManager.GetRolesAsync(user);
        }




        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<List<UserDTO>> GetUsersWithRoles()
        {
            var usersWithRoles = new List<UserDTO>();

            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                UserDTO newUser = _mappingProfile.Map<UserDTO>(user);
                newUser.Role = userRoles[0];
                usersWithRoles.Add(newUser);
            }

            return usersWithRoles;
        }




        public async Task<IdentityResult> Register(RegisterRequest model)
        {
            var user = new ApplicationUser
            {
                Nombre = model.Nombre,
                Apellido    = model.Apellido,
                Dni = model.Dni,
                Email = model.Email,
                Direcion = model.Direcion,
                Telefono = model.Telefono,
                Active = true,
                UserName =model.Email,
            };

            // Crear el usuario
            var createUserResult = await _userManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
            {
                return createUserResult;
            }

            // Asignar el rol al usuario
            var roleName = model.Role; // Suponiendo que el nombre del rol está en el objeto RegisterRequest
            var assignRoleResult = await _userManager.AddToRoleAsync(user, roleName);
            if (!assignRoleResult.Succeeded)
            {
                // Si no se pudo asignar el rol, eliminar el usuario recién creado
                await _userManager.DeleteAsync(user);
                return assignRoleResult;
            }
            //await SendEmailAsyncWelcome(model.Email);
            return IdentityResult.Success;
        }

        public async Task<bool> ValidateCredentials(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password) && user.Active)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> ActivateUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user.Active)
            {
                return false;
            }
            user.Active = true;
            await _userManager.UpdateAsync(user);
            return true;


        }
        public async Task<bool> DesactivateUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (!user.Active)
            {
                return false;
            }
            user.Active = false;
            await _userManager.UpdateAsync(user);
            return true;


        }
        public async Task<bool> Update(UserDTO user)
        {
            var userExists = await _userManager.FindByIdAsync(user.Id);
            if (userExists == null)
            {
                return false;
            }
            await AssignRoleToUser(user.Id, user.Role);

            userExists.Telefono = user.Telefono;
            userExists.Nombre = user.Nombre;
            userExists.Apellido = user.Apellido;
            userExists.Dni = user.Dni;
            userExists.Email = user.Email;
            
            userExists.Active = user.Active;

            await _userManager.UpdateAsync(userExists);
            return true;


        }


        public IEnumerable<string> GetRoles()
        {
            var roles = _roleManager.Roles.Select(r => r.Name).ToList();
            return roles;
        }

        public async Task<IdentityResult> AssignRoleToUser(string userId, string roleName)
        {
            // Verificar si el rol existe
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                // El rol especificado no existe
                // Puedes manejar este caso de acuerdo a tus requerimientos
                return IdentityResult.Failed(new IdentityError { Description = $"El rol '{roleName}' no existe." });
            }

            // Obtener el usuario por su ID
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                // El usuario no existe
                // Puedes manejar este caso de acuerdo a tus requerimientos
                return IdentityResult.Failed(new IdentityError { Description = $"El usuario con ID '{userId}' no existe." });
            }

            // Remover todos los roles actuales del usuario
            var resultRemove = await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));

            // Verificar si se pudo remover los roles existentes correctamente
            if (!resultRemove.Succeeded)
            {
                return resultRemove;
            }

            // Asignar el nuevo rol al usuario
            var resultAdd = await _userManager.AddToRoleAsync(user, roleName);
            return resultAdd;
        }






    }
}
