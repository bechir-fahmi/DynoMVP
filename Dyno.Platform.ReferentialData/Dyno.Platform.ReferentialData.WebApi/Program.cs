using Dyno.Platform.ReferentialData.BusinessModel.Mapping;
using Dyno.Platform.ReferentialData.Nhibernate;
using Dyno.Platform.ReferentialData.WebApi;
using MicroserviceBase;
using Server.Kafka;
using WatchDog;
using Dyno.Platform.ReferentialData.DTO.Mapping;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserRole;
using NHibernate.AspNetCore.Identity;
using Dyno.Platform.ReferentialData.Business.IServices.IUserDataService;
using Dyno.Platform.ReferentialData.Business.Services.UserDataService;
using Dyno.Platform.ReferentialData.Business.IServices.IRoleDataService;
using Dyno.Platform.ReferentialData.Business.Services.RoleDataService;
using Dyno.Platform.ReferentialData.Business.IServices.IUserClaimService;
using Dyno.Platform.ReferentialData.Business.Services.ClaimService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Platform.Shared.EnvironmentVariable;
using Dyno.Platform.ReferentialData.Business.Services.Authentification;
using Dyno.Platform.ReferentialData.Business.IServices.IAuthentification;
using Dyno.Platform.ReferentialData.Business.IServices.IAddressDataService;
using Dyno.Platform.ReferentialData.Business.Services.AddressDataService;
using Dyno.Platform.ReferentialData.Business.IServices.IBalanceDataService;
using Dyno.Platform.ReferentialData.Business.Services.BalanceDataService;

var builder = WebApplication.CreateBuilder(args);

#region Kafka Config
KafkaConfig config = builder.Configuration.GetSection("Kafka_BootstrapServer").Get<KafkaConfig>();

builder.Services.AddSingleton(config);


builder.Services.AddSingleton<IProducer<HeartBeatMessage>>(producer => new Producer<HeartBeatMessage>(Topic.TOPIC_WATCHDOG_SEND_MESSAGE, config));
builder.Services.AddSingleton<IConsumer<HeartBeatMessage>>(consumer => new Consumer<HeartBeatMessage>(Topic.TOPIC_WATCHDOG_RECEIVE_MESSAGE, config));
builder.Services.AddHostedService<MicroserviceBaseWorker>();

#endregion




#region DataBase Config
DatabaseConfig configdata = builder.Configuration.GetSection("ConnectionStrings").Get<DatabaseConfig>();
builder.Services.AddNHibernate(configdata.Pgsqlconnection);
builder.Services.AddDefaultIdentity<UserEntity>()
    .AddRoles<RoleEntity>()
    .AddHibernateStores();
    
 






builder.Services.AddControllersWithViews();
#endregion

#region Auto Mapper
builder.Services.AddAutoMapper(typeof(MappingBMtoDM));
builder.Services.AddAutoMapper(typeof(MappingDTOtoBM));
#endregion


#region Business Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IUserClaimService, UserClaimService>();
builder.Services.AddScoped<IRoleClaimService, RoleClaimService>();
builder.Services.AddScoped<IAuthentificationService, AuthentificationService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IBalanceService, BalanceService>();


builder.Services.AddScoped<IUrlHelper>(x =>
{
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);

});

#endregion

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = JWTVariable.Issuer,
        ValidAudience = JWTVariable.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTVariable.key))
    };
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
