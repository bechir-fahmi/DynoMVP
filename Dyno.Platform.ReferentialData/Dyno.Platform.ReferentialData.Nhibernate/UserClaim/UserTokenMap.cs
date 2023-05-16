using Dyno.Platform.ReferntialData.DataModel.UserClaim;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate.UserClaim
{
    public class UserTokenMap:ClassMapping<UserTokenEntity>
    {
        public UserTokenMap()
        {

            Schema("public");
            Table("user_token");
            Property(e => e.UserId, prop => {
                prop.Column("user_id");
                prop.Type(NHibernateUtil.String);
                prop.Length(32);
                prop.NotNullable(true);
                prop.Unique(true);
            });
            Property(e => e.LoginProvider, prop => {
                prop.Column("login_provider");
                prop.Type(NHibernateUtil.String);
                prop.Length(256);
                prop.NotNullable(true);

            });
            Property(e => e.Name, prop => {
                prop.Column("name");
                prop.Type(NHibernateUtil.String);
                prop.Length(64);
                prop.NotNullable(true);
            });
            Property(e => e.Value, prop => {
                prop.Column("value");
                prop.Type(NHibernateUtil.String);
                prop.Length(256);
                prop.NotNullable(true);
            });
        }
    }
}
