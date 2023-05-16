using Dyno.Platform.ReferntialData.DataModel.UserData;
using FluentNHibernate.Automapping.Steps;
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
    public class EmployerMap:ClassMapping<EmployerEntity>
    {
        public EmployerMap()
        {

            


            Id(user => user.Id, x => {
                x.Column("id");
                x.Type(NHibernateUtil.Guid);
                x.Generator(Generators.GuidComb);

            });





            Property(user => user.CodeTVA, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("CodeTVA");
                x.NotNullable(true);
            });



            Property(user => user.EntrepriseAdress, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("Adress");
                x.NotNullable(true);
            });

            Property(user => user.EmailRH, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("EmailRH");
                x.NotNullable(true);
            });

            Property(user => user.NumTelRH, x =>
            {

                x.Type(NHibernateUtil.Int32);
                x.Column("NumRH");
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

            Bag(user => user.Employees, X =>
            {

                X.Table("Employement");

                X.Key(k => k.Column("employer_id"));
                X.Cascade(Cascade.All);
            }, r => r.ManyToMany(m => m.Column("Employee_id")));

            Property(user => user.Balance, x =>
            {

                x.Type(NHibernateUtil.Double);
                x.Column("Balance");

            });
            ManyToOne(x => x.User, m
                =>
            {
                m.Column("user_id");
                m.NotNullable(true);
                m.ForeignKey("fk_order_user");
            });


            Table("Employers");
            Schema("public");
        }
    }
}
