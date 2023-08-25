using Dyno.Platform.ReferntialData.DataModel.UserData;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate.UserData
{
    public class UserOtpMap : ClassMapping<UserOtpEntity>
    {
        public UserOtpMap() 
        {
            Schema("public");
            Table("userOtps");
            Id(e => e.Id, id => {
                id.Column("id");
                id.Type(NHibernateUtil.Int32);
            });

            //Property(e => e.UserName, prop => {
            //    prop.Column("user_name");
            //    prop.Type(NHibernateUtil.String);
            //    prop.Length(64);
            //    prop.NotNullable(true);
            //});

            Property(e => e.PhoneNumber, prop => {
                prop.Column("phone_number");
                prop.Type(NHibernateUtil.String);
                prop.NotNullable(true);
            });
            
            Property(e => e.Code, prop => {
                prop.Column("code");
                prop.Type(NHibernateUtil.String);
                prop.NotNullable(true);
                prop.Unique(true);
            });






        }
    }
}
