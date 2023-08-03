using Dyno.Platform.ReferntialData.DataModel.BalanceData;
using FluentNHibernate.MappingModel.ClassBased;
using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate.BalanceData
{
    public class BalanceMap : ClassMapping<BalanceEntity>
    {
        public BalanceMap() 
        {
            Id(balance => balance.Id, x =>
            {
                x.Column("id");
                x.Type(NHibernateUtil.Int32);
                x.Generator(Generators.Identity);
            });

            Property(balance => balance.Amount, x =>
            {

                x.Type(NHibernateUtil.Double);
                x.Column("amount");

            });

              Property(balance => balance.Key, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("key");

            });

            Property(balance => balance.Status, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("status");

            });

          
            ManyToOne(balance => balance.User, x =>
            {
                x.Column("user_id");
                x.Cascade(Cascade.Persist);
            });
            Table("balance");
        }
    }
}
