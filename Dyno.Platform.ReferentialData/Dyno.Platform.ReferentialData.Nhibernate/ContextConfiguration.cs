using Dyno.Platform.ReferentialData.Nhibernate.RoleData;
using Dyno.Platform.ReferentialData.Nhibernate.TicketData;
using Dyno.Platform.ReferentialData.Nhibernate.UserClaim;
using Dyno.Platform.ReferentialData.Nhibernate.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.AspNetCore.Identity;
using NHibernate.AspNetCore.Identity.Mappings;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Tool.hbm2ddl;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace Dyno.Platform.ReferentialData.Nhibernate
{
    public static class ContextConfiguration
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            

           var configuration = new Configuration();

            var mapper = new ModelMapper();
            mapper.AddMapping<UserMap>();
            mapper.AddMapping<RoleMap>();
            mapper.AddMapping<RoleClaimMap>();
            mapper.AddMapping<UserTokenMap>();
            mapper.AddMapping<UserLoginMap>();
            mapper.AddMapping<UserRoleMap>();
            mapper.AddMapping<UserClaimMap>();
            mapper.AddMapping<ShopOwnerMap>();
            mapper.AddMapping<SuperUserMap>();
            mapper.AddMapping<EmployeeMap>();
            mapper.AddMapping<EmployerMap>();
            mapper.AddMapping<CasierMap>();
            mapper.AddMapping<TicketMap>();
            mapper.AddMapping<PayementMap>();
            mapper.AddMapping<CategoryMap>();




            configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

           
           

            configuration.DataBaseIntegration(c =>
            {

                c.Driver<NpgsqlDriver>();
                c.Dialect<PostgreSQL83Dialect>();
                c.ConnectionProvider<DriverConnectionProvider>();
               c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Validate;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
                
            });

           



            var export = new SchemaUpdate(configuration);
            export.Execute(false, true);

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped(typeof(IMapperSession<>), typeof(MapperSession<>));
          
                
                

            return services;
        }
    }
}
