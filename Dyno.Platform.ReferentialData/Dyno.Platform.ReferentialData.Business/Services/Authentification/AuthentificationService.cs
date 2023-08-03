using AutoMapper;
using AutoMapper.Execution;
using CoreSharp.NHibernate.PostgreSQL.Types;
using Dyno.Platform.ReferentialData.Business.IServices.IAuthentification;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.DTO.AuthDTO;
using Dyno.Platform.ReferentialData.DTO.UserClaimData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Org.BouncyCastle.Asn1.Crmf;
using Platform.Shared.Enum;
using Platform.Shared.EnvironmentVariable;
using Platform.Shared.Result;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Dyno.Platform.ReferentialData.Business.Services.Authentification
{
    public class AuthentificationService : IAuthentificationService
    {
        public readonly SignInManager<UserEntity> _signInManager;
        public readonly UserManager<UserEntity> _userManager;
        public readonly IMapper _mapper;
        public readonly IMapperSession<UserEntity> _mapperSession;
        public readonly RoleManager<RoleEntity> _roleManager;



        public AuthentificationService(SignInManager<UserEntity> signInManager, 
            UserManager<UserEntity> userManager,
            IMapper mapper, IMapperSession<UserEntity> mapperSession, RoleManager<RoleEntity> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _mapperSession = mapperSession;
            _roleManager = roleManager;
        }

        //public async Task<bool> ForgetPassword(string email)
        //{
        //    UserEntity userEntity = await _userManager.FindByEmailAsync(email);
        //    if (userEntity != null)
        //    {

        //    }
        //}


        public async Task<OperationResult> Login(LoginModelDTO loginModelDTO)
        {
            UserEntity userEntity = await _userManager.FindByEmailAsync(loginModelDTO.Email);
            if (userEntity != null)
            {

                IList<string> userRole = await _userManager.GetRolesAsync(userEntity);
                foreach (var role in userRole)
                {
                    RoleEntity roleEntity = (RoleEntity)Convert.ChangeType(role, typeof(RoleEntity));
                    userEntity.Roles.Add(roleEntity);
                }

                var accessToken = GenerateToken(userEntity);
                var refreshToken = GenerateRefreshToken();

                return new OperationResult
                {
                    Result = QueryResult.IsSucceded,
                    ExceptionMessage = "No error",
                    ExtendedProperties = new Dictionary<string, object>()
                    {
                        {"AccessToken", accessToken},
                        {"RefreshToken", refreshToken},
                        {"RefreshTokenExpired", DateTime.Now.AddDays(Convert.ToDouble(JWTVariable.RefreshTokenExpired))},
                    }
                };
            }
            else
            {
                return new OperationResult
                {
                    Result = QueryResult.IsFailed,
                    ExceptionMessage = "user n'existe pas"
                };
            }

        }


        private string GenerateToken(UserEntity userEntity)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTVariable.key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("Id", userEntity.Id)
            };
            foreach (var role in userEntity.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Id));
            }

            var token = new JwtSecurityToken(
                issuer: JWTVariable.Issuer,
                audience: JWTVariable.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(JWTVariable.AccesTokenExpired)),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        }
        
        public async Task<OperationResult> Register(RegisterModelDTO register)
        {
            List<UserEntity> userEntities= _mapperSession.GetAllByExpression(User => User.PhoneNumber == register.PhoneNumber);
            RoleEntity roleEntity = await _roleManager.FindByNameAsync(RoleName.Client.ToString());

            foreach (var entity in userEntities) 
            {
                if(entity.Roles.Contains(roleEntity))
                {
                    return new OperationResult
                    {
                        Result = QueryResult.IsFailed,
                        ExceptionMessage = "This phone number exist"
                    };
                }
            }
            User user = _mapper.Map<User>(register);
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            userEntity.Id = Guid.NewGuid().ToString();
            userEntity.Roles.Add(roleEntity);
            var result = await _userManager.CreateAsync(userEntity, register.Password);

            return new OperationResult
            {
                Result = result.Succeeded ? QueryResult.IsSucceded : QueryResult.IsFailed,
                ExceptionMessage = !result.Succeeded ? result.Errors.ToList()[0].Description : null
            };
                  
        }
        private string GenerateOTP() 
        {
            Random random = new Random();
            int otps=random.Next(100000,999999);
            return otps.ToString("D6");
        }

        public MessageResource GetOtpVerificationCode(string phoneNumber)
        {
            TwilioClient.Init(TwilioVariable.AccountSID, TwilioVariable.AuthToken);
            
            var result = MessageResource.Create(
                body: this.GenerateOTP(),
                from: new Twilio.Types.PhoneNumber(TwilioVariable.TwilioPhone),
                to: phoneNumber
                );
            return result;
        }
         
        public Task GetPassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}
