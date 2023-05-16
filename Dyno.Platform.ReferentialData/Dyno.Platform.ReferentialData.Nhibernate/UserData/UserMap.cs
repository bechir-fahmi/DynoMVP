using Dyno.Platform.ReferntialData.DataModel.UserData;
using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate;
using Remotion.Linq;
using NHIdentityUser = NHibernate.AspNetCore.Identity.IdentityUser;
using NHibernate.Type;
using NHibernate.SqlTypes;

namespace Dyno.Platform.ReferentialData.Nhibernate.UserData
{
    public class UserMap: ClassMapping<UserEntity>
    {
        public UserMap()
        {


            Schema("public");
            Table("users");
            Id(e => e.Id, id => {
                id.Column("id");
                id.Type(NHibernateUtil.StringClob);
                id.Length(32);
                id.Generator(Generators.TriggerIdentity);
            });
            Property(e => e.UserName, prop => {
                prop.Column("user_name");
                prop.Type(NHibernateUtil.String);
                prop.Length(64);
                prop.NotNullable(true);
                prop.Unique(true);
            });
            Property(e => e.NormalizedUserName, prop => {
                prop.Column("normalized_user_name");
                prop.Type(NHibernateUtil.String);
                prop.Length(64);
                prop.NotNullable(true);
                prop.Unique(true);
            });
            Property(e => e.Email, prop => {
                prop.Column("email");
                prop.Type(NHibernateUtil.String);
                prop.Length(256);
                prop.NotNullable(true);
            });
            Property(e => e.NormalizedEmail, prop => {
                prop.Column("normalized_email");
                prop.Type(NHibernateUtil.String);
                prop.Length(256);
                prop.NotNullable(true);
            });
            Property(e => e.EmailConfirmed, prop => {
                prop.Column("email_confirmed");
                prop.Type(NHibernateUtil.Boolean);
                prop.NotNullable(true);
            });
            Property(e => e.PhoneNumber, prop => {
                prop.Column("phone_number");
                prop.Type(NHibernateUtil.String);
                prop.Length(128);
                prop.NotNullable(false);
            });
            Property(e => e.PhoneNumberConfirmed, prop => {
                prop.Column("phone_number_confirmed");
                prop.Type(NHibernateUtil.Boolean);
                prop.NotNullable(true);
            });
            Property(e => e.LockoutEnabled, prop => {
                prop.Column("lockout_enabled");
                prop.Type(NHibernateUtil.Boolean);
                prop.NotNullable(true);
            });
            //Property(e => e.LockoutEnd, prop =>
            //{
            //    prop.Column(col =>
            //    {
            //        col.Name("lockout_end");
            //        col.SqlType("timestamp with time zone");
            //    });
            //    prop.Type(NHibernateUtil.DateTimeOffset);



            //});
            Property(e => e.AccessFailedCount, prop => {
                prop.Column("access_failed_count");
                prop.Type(NHibernateUtil.Int32);
                prop.NotNullable(true);
            });
            Property(e => e.ConcurrencyStamp, prop => {
                prop.Column("concurrency_stamp");
                prop.Type(NHibernateUtil.String);
                prop.Length(36);
                prop.NotNullable(false);
            });
            Property(e => e.PasswordHash, prop => {
                prop.Column("password_hash");
                prop.Type(NHibernateUtil.String);
                prop.Length(256);
                prop.NotNullable(false);
            });
            Property(e => e.TwoFactorEnabled, prop => {
                prop.Column("two_factor_enabled");
                prop.Type(NHibernateUtil.Boolean);
                prop.NotNullable(true);
            });
            Property(e => e.SecurityStamp, prop => {
                prop.Column("security_stamp");
                prop.Type(NHibernateUtil.String);
                prop.Length(64);
                prop.NotNullable(false);
            });

           
        }

    }
}
