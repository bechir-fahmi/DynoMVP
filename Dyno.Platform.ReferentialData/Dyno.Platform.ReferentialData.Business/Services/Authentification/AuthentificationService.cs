using AutoMapper;
using AutoMapper.Execution;
using CoreSharp.NHibernate.PostgreSQL.Types;
using Dyno.Platform.ReferentialData.Business.IServices.IAuthentification;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.DTO.AuthDTO;
using Dyno.Platform.ReferentialData.DTO.UserClaimData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferntialData.DataModel.UserClaim;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        public readonly RoleManager<RoleEntity> _roleManager;

        private readonly IMapperSession<UserEntity> _mapperSession;
        private readonly IMapperSession<UserOtpEntity> _mapperSessionOtp;
        private readonly IMapperSession<UserRoleEntity> _mapperSessionUserRole;
        
        private readonly IMapper _mapper;
        private readonly ILogger<AuthentificationService> _logger;


        public AuthentificationService(SignInManager<UserEntity> signInManager, 
            UserManager<UserEntity> userManager,
            RoleManager<RoleEntity> roleManager,                        
            IMapperSession<UserEntity> mapperSession,             
            IMapperSession<UserOtpEntity> mapperSessionOtp,
            IMapperSession<UserRoleEntity> mapperSessionUserRole,
            IMapper mapper,
            ILogger<AuthentificationService> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;

            _mapperSession = mapperSession;
            _mapperSessionOtp = mapperSessionOtp;
            _mapperSessionUserRole = mapperSessionUserRole;

            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OperationResult> Login(LoginModelDTO loginModelDTO)
        {
            UserEntity userEntity = await _userManager.FindByNameAsync(loginModelDTO.UserName);
            if (userEntity != null)
            {

                //IList<string> userRole = await _userManager.GetRolesAsync(userEntity);
                //foreach (var role in userRole)
                //{
                //    RoleEntity roleEntity = (RoleEntity)Convert.ChangeType(role, typeof(RoleEntity));
                //    userEntity.Roles.Add(roleEntity);
                //}

                var accessToken = GenerateToken(userEntity);
                var refreshToken = GenerateRefreshToken();

                return new OperationResult
                {
                    Result = QueryResult.IsSucced,
                    ExceptionMessage = "No error",
                    ExtendedProperties = new Dictionary<string, object>()
                    {
                        {"AccessToken", accessToken},
                        {"RefreshToken", refreshToken},
                        {"RefreshTokenExpired", DateTime.Now.AddDays(Convert.ToDouble(JWTVariable.RefreshTokenExpired)) },
                        {"id",userEntity.Id},{"firstname",userEntity.FirstName},{"lastname",userEntity.LastName},{"username",userEntity.UserName},{"email",userEntity.Email},
                        {"picture",userEntity.Picture},{"balance",userEntity.Balances},
                        {"adresse",userEntity.Addresses}


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

        public async Task<OperationResult> Register(RegisterModelDTO register)
        {
            RoleEntity? roleEntity = await _roleManager.FindByNameAsync(RoleName.Client.ToString());
            if (roleEntity == null)
            {
                return new OperationResult
                {
                    Result = QueryResult.IsFailed,
                    ExceptionMessage = "The Role Client not exist"
                };
            }
            List<UserEntity> userEntities = _mapperSession.GetAllByExpression(User => User.PhoneNumber == register.PhoneNumber);
            if (userEntities.Count != 0)
            {
                foreach (var entity in userEntities)
                {
                    UserRoleEntity? userRoleEnity = _mapperSessionUserRole.GetByExpression(UserRole => UserRole.UserId == entity.Id && UserRole.RoleId == roleEntity.Id);
                    if (userRoleEnity != null)
                    {
                        return new OperationResult
                        {
                            Result = QueryResult.IsFailed,
                            ExceptionMessage = "This phone number exist"
                        };
                    }
                }
            }
            User user = _mapper.Map<User>(register);
            UserEntity userEntity = _mapper.Map<UserEntity>(user);
            userEntity.Id = Guid.NewGuid().ToString();
            var result = await _userManager.CreateAsync(userEntity, register.Password);
            if (result.Succeeded)
            {
                _mapperSessionUserRole.Add(new UserRoleEntity { UserId = userEntity.Id, RoleId = roleEntity.Id });
            }
            return new OperationResult
            {
                Result = result.Succeeded ? QueryResult.IsSucced : QueryResult.IsFailed,
                ExceptionMessage = !result.Succeeded ? result.Errors.ToList()[0].Description : null
            };
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
        
        
        private string GenerateOTP() 
        {
            //Random random = new Random();
            //int otps=random.Next(100000,999999);
            //return otps.ToString("D6");
            return "5656";
        }

        public MessageResource GetOtpVerificationCode(string phoneNumber)
        {
            TwilioClient.Init(TwilioVariable.AccountSID, TwilioVariable.AuthToken);
            string Code = this.GenerateOTP();
            UserOtpEntity userOtpEntity = new UserOtpEntity(phoneNumber, Code);
            _mapperSessionOtp.Add(userOtpEntity);
            var result = MessageResource.Create(
                body: Code,
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
