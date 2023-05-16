using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.UserData
{
    public class ShopOwner 
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public String? CodeTVA { get; set; }
        public String? Adress { get; set;  }
        public String? PayementMethod { get; set; }
        public String? AdressFacturation { get; set; }
        public float Balance { get; set; }
        public List<Casier>? casiers { get; set; }

    }
}
