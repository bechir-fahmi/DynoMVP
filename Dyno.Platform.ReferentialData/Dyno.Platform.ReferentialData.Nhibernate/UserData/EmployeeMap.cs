using Dyno.Platform.ReferntialData.DataModel.UserData;
using FluentNHibernate.Automapping.Steps;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cascade = NHibernate.Mapping.ByCode.Cascade;

namespace Dyno.Platform.ReferentialData.Nhibernate.UserData
{
    public class EmployeeMap : ClassMapping<EmployeeEntity>
    {
        public EmployeeMap()

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

            Property(user => user.Balance, x =>
            {

                x.Type(NHibernateUtil.Double);
                x.Column("Balance");

            });
            Bag(user => user.Employers, X =>
            {

                X.Table("Employement");
                
                X.Key(k => k.Column("employee_id"));
                X.Lazy(CollectionLazy.Lazy);
                X.Cascade(Cascade.All);
            }, r => r.ManyToMany(m => m.Column("Employer_id"))); 
    
            ManyToOne(x => x.User, m
                =>
            {
                m.Column("user_id");
               
                m.NotNullable(true);
                m.ForeignKey("fk_order_user");
            });


            Table("Employees");
            Schema("public");

        }

        
    }
}
