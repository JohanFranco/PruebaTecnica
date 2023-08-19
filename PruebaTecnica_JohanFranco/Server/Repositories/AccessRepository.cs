using Dapper;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica_JohanFranco.Shared;
using PruebaTecnica_JohanFranco.Shared.Access;
using System.Data.Common;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnica_JohanFranco.Server.Repositories
{
    public class AccessRepository:IAccesRepository
    {
        private readonly IConfiguration configuration;
        private SqlConnection _context;
        public AccessRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this._context = new SqlConnection(configuration.GetConnectionString("Contactos"));
        }

        public async Task<bool>RegisterUser(UserDTO userDTO)
        {
            string ssql = $@"INSERT INTO [dbo].[Usuario] (nickName, email, password)
                                VALUES (@NickName, @Email, @Pass)";

            await _context.QueryAsync(ssql, new
            {
                NickName = userDTO.NickName,
                Email = userDTO.Email,
                Pass = userDTO.Password
            });

            return true;
        }

        public async Task<UserToken> GetUserToken(UserCredentials credentials)
        {
            string ssql = $@"SELECT * FROM [dbo].[Usuario] WHERE email = @Email AND password = @Pass";
            var usuario = await _context.QueryFirstOrDefaultAsync<UserDTO>(ssql, new
            {
                Email = credentials.User,
                Pass = credentials.Password
            });

            if (usuario == null) 
                return null;

            return BuildToken(usuario);
        }

        private UserToken BuildToken(UserDTO usertInfo)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, usertInfo.NickName),
                new Claim(JwtRegisteredClaimNames.UniqueName, usertInfo.IdUser.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usertInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

        }
    }
}
