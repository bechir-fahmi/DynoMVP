using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferntialData.DataModel.UserData
{
    public class ShopOwnerEntity 
    {
        public virtual Guid Id { get; set; }
        public virtual UserEntity User { get; set; }
        [Required]
        public virtual String? CodeTVA { get; set; }
        [Required]
        public virtual String? Adress { get; set; }
        [Required]
        public virtual String? PayementMethod { get; set; }
        [Required]
        public virtual String? AdressFacturation { get; set; }
        public virtual IList<CasierEntity>? casierEntities { get; set; }
        public virtual double Balance { get; set; }

    }
}
