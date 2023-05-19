using Dyno.Platform.ReferentialData.Business.IServices;
using Dyno.Platform.ReferentialData.Business.Services;
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
builder.Services.AddIdentity<UserEntity, RoleEntity>()
    
    .AddHibernateStores();
 






builder.Services.AddControllersWithViews();
#endregion

#region Auto Mapper
builder.Services.AddAutoMapper(typeof(MappingBMtoDM));
builder.Services.AddAutoMapper(typeof(MappingDTOtoBM));
#endregion


#region Business Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployerService, EmployerService>();
builder.Services.AddScoped<IShopOwnerService, ShopOwnerService>();
builder.Services.AddScoped<ICasierService, CasierService>();
builder.Services.AddScoped<ITicketService, TicketService>();


#endregion

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

   
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
