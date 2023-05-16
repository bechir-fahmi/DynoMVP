using Dyno.Platform.ReferntialData.DataModel.UserClaim;
using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate.UserClaim
{
    public class UserClaimMap:ClassMapping<UserClaimEntity>
    {

    public UserClaimMap()
        {
            Schema("public");
            Table("user_claim");
            Id(e => e.Id, id => {
                id.Column("id");
                id.Type(NHibernateUtil.String);
                id.Length(32);
                id.Generator(Generators.TriggerIdentity);
            });
            Property(e => e.UserId, prop => {
                prop.Column("user_id");
                prop.Type(NHibernateUtil.String);
                prop.Length(32);
                prop.NotNullable(true);
                
            });
            Property(e => e.ClaimType, prop => {
                prop.Column("claim_type");
                prop.Type(NHibernateUtil.String);
                prop.Length(256);
                prop.NotNullable(true);

            });
            Property(e => e.ClaimValue, prop => {
                prop.Column("claim_value");
                prop.Type(NHibernateUtil.String);
                prop.Length(256);
                prop.NotNullable(true);
            });
        }
    }
}
