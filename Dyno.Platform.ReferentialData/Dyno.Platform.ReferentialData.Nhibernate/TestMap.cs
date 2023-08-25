using Dyno.Platform.ReferntialData.DataModel;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate
{
    public class TestMap : ClassMapping<TestData>
    {
        public TestMap()
        {
            Schema("public");
            Table("Test");
            Id(e => e.Id, id =>
                {
                    id.Column("id");
                    id.Type(NHibernateUtil.String);
                    id.Length(64);
                    

                });
            Property(e => e.Name, prop =>
            {
                prop.Column("name");
                prop.Type(NHibernateUtil.String);
                prop.Length(64);
                prop.NotNullable(true);
                prop.Unique(true);
            });
            
        }
    }
}
