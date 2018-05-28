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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string FiscalCode { get; set; }
        public GenderType Gender { get; set; }

    }
}
