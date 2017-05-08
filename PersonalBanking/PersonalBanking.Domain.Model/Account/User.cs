using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.Domain.Model.Account
{
    public class User : EntityBase
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual bool IsAdmin { get; set; }        
        public virtual Person Person { get; set; }

        public User()
        {
        }

    }
}
