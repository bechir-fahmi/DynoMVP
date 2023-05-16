using Dyno.Platform.ReferntialData.DataModel.PayementData;
using FluentNHibernate.MappingModel.ClassBased;
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
    public class CategoryMap :ClassMapping<CategoryEntity>
    {
        public CategoryMap() {

            Schema("public");
            Table("category");


            Id(category => category.Id, x => {
                x.Column("id");
                x.Type(NHibernateUtil.Int32);
                x.Generator(Generators.Increment);


            });



            Property(category => category.Name, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("category_name");
                x.NotNullable(true);
            });

            ManyToOne(x => x.Ticket, m =>
            {
                m.Column("ticket_id");

                m.NotNullable(true);
                m.ForeignKey("fk_order_ticket");
            });

        }
    }
}
