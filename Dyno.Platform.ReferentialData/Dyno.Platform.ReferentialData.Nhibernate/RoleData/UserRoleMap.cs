using Dyno.Platform.ReferentialData.BusinessModel.RoleData;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate.RoleData
{
    public class UserRoleMap: ClassMapping<UserRole>
    {
        public UserRoleMap()
        {
            Schema("public");
            Table("user_role");
            Id(e => e.UserId, id =>
            {
                id.Column("user_id");
                id.Type(NHibernateUtil.String);
                id.Length(64);

            });

            Id(e => e.RoleId, id =>
            {
                id.Column("role_id");
                id.Type(NHibernateUtil.String);
                id.Length(64);

            });
        }
    }
}
