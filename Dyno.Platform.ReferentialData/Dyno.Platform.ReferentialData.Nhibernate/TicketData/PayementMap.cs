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
    public class PayementMap : ClassMapping<PayementEntity>
    {
        public PayementMap()
        {
            Schema("public");
            Table("payement");


            Id(payement => payement.Id, x => {
                x.Column("id");
                x.Type(NHibernateUtil.Guid);
                x.Generator(Generators.GuidComb);


            });



            Property(payement => payement.Date, x =>
            {

                x.Type(NHibernateUtil.DateTime);
                x.Column("date");
                x.NotNullable(true);
            });

            Property(payement => payement.DayOfWork, x =>
            {

                x.Type(NHibernateUtil.Int32);
                x.Column("day_of_work");
                x.NotNullable(true);
            });

            ManyToOne(x => x.Employer, m =>
            {
                m.Column("employer_id");

                m.NotNullable(true);
                m.ForeignKey("fk_order_employer");
            });

            ManyToOne(x => x.Employee, m =>
            {
                m.Column("employee_id");

                m.NotNullable(true);
                m.ForeignKey("fk_order_employee");
            });

        }
    }
}
