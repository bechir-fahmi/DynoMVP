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
    public class ShopOwnerMap : ClassMapping<ShopOwnerEntity>
    {
        public ShopOwnerMap()
        {
            Id(user => user.Id, x => {
                x.Column("id");
                x.Type(NHibernateUtil.Guid);
                x.Generator(Generators.GuidComb);
            });



            Property(user => user.Adress, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("Adress");
                x.NotNullable(true);
            });

            Property(user => user.CodeTVA, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("CodeTVA");
                x.NotNullable(true);
            });

            Property(user => user.PayementMethod, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("PayementMethod");
                x.NotNullable(true);
            });

            Property(user => user.AdressFacturation, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("AdressFacturation");
                x.NotNullable(true);
            });

            Property(user => user.Balance, x =>
            {

                x.Type(NHibernateUtil.Int64);
                x.Column("Balance");

            });

            ManyToOne(x => x.User, m
                =>
            {
                m.Column("user_id");
                m.NotNullable(true);
                m.ForeignKey("fk_order_user");
            });



            Table("Shopowners");
            Schema("public");
        }


    }


}
