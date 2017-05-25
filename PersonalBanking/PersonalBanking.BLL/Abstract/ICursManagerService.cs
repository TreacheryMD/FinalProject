using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL.Abstract
{
    public interface ICursManagerService
    {
        decimal CurrencyConvert(CurrencyTypes currency1, CurrencyTypes currency2, decimal ammount);
    }
}
