using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferntialData.DataModel.UserData
{
    public class UserOtpEntity
    {
        
        public virtual int Id {  get; set; }
        //public virtual string? UserName { get; set; }
        public virtual string? PhoneNumber{ get; set; }
        public virtual string? Code { get; set; }

        public UserOtpEntity( string phoneNumber, string code) 
        {
            PhoneNumber = phoneNumber;
            Code = code;
        }


       
    }
}
