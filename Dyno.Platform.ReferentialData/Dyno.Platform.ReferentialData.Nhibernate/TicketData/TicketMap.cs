using Dyno.Platform.ReferntialData.DataModel.PayementData;
using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate.TicketData
{
    public class TicketMap : ClassMapping<TicketEntity>
    {
        public TicketMap() {
            Schema("public");
            Table("ticket");

            Id(ticket => ticket.Id, x => {
                x.Column("id");
                x.Type(NHibernateUtil.Guid);
                x.Generator(Generators.GuidComb);


            });



            Property(ticket => ticket.Name ,x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("ticket_name");
                x.NotNullable(true);
            });

            Property(ticket => ticket.amount, x =>
            {

                x.Type(NHibernateUtil.Double);
                x.Column("amount");

            });

        }
    }
}
