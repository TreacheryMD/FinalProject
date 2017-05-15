using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model;

namespace PersonalBanking.BLL.DTO
{
    public class PersonDTO : EntityBaseDTO
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string FiscalCode { get; set; }
        public virtual GenderType Gender { get; set; }

    }
}
