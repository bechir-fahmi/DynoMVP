using Dyno.Platform.ReferntialData.DataModel.AddressData;
using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Nhibernate.AddressData
{
    public class AddressMap : ClassMapping<AddressEntity>
    {
        public AddressMap()
        {
            Id(address => address.Id, x =>
            {
                x.Column("id");
                x.Type(NHibernateUtil.Int32);
                x.Generator(Generators.Identity);
            });

            Property(address => address.AddressName, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("address_Name");

            });

            Property(address => address.Longitude, x =>
            {

                x.Type(NHibernateUtil.Double);
                x.Column("longitude");

            });

            Property(address => address.Latitude, x =>
            {

                x.Type(NHibernateUtil.Double);
                x.Column("latitude");

            });



            Property(address => address.Street, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("street");

            });

            Property(address => address.City, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("city");

            });

            Property(address => address.PostalCode, x =>
            {

                x.Type(NHibernateUtil.Int32);
                x.Column("postal_code");

            });


            Property(address => address.Country, x =>
            {

                x.Type(NHibernateUtil.StringClob);
                x.Column("country");

            });

            ManyToOne(address => address.User, x =>
            {
                x.Column("user_id");
                x.Cascade(Cascade.Persist);
            });

        }
    }
}
