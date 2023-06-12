
using Dyno.Platform.ReferntialData.DataModel.UserClaim;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate.UserClaimData
{
    public class UserRoleMap : ClassMapping<UserRoleEntity>
    {
        public UserRoleMap()
        {
            Schema("public");
            Table("user_role");
            Property(e => e.UserId, prop =>
            {
                prop.Column("user_id");
                prop.Type(NHibernateUtil.String);
                prop.Length(32);
                prop.NotNullable(true);
                prop.Unique(true);
            });


            Property(e => e.RoleId, prop =>
            {
                prop.Column("role_id");
                prop.Type(NHibernateUtil.String);
                prop.Length(32);
                prop.NotNullable(true);
                prop.Unique(true);
            });
        }
    }
}
