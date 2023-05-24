using Dyno.Platform.ReferntialData.DataModel.UserData;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate.UserData
{
    public class CasierMap:ClassMapping<CasierEntity>
    {
        public CasierMap()
        {

            Id(user => user.Id, x => {
                x.Column("id");
                x.Type(NHibernateUtil.Guid);
                x.Generator(Generators.GuidComb);
            });




            ManyToOne(x => x.User, m
                =>
            {
                m.Column("user_id");
                m.NotNullable(true);
                m.ForeignKey("fk_order_user");
            });

            


           

            ManyToOne(user => user.ShopOwnerEntity, x =>
            {
                x.Column("id_Shopowner");
                x.Class(typeof(ShopOwnerEntity));

            });

            Table("Casiers");
            Schema("public");
        }
    }
}
