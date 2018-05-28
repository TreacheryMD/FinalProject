using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL.Services
{
    public class CursManagerService : ICursManagerService
    {
        public decimal CurrencyConvert(CurrencyTypes currency1, CurrencyTypes currency2, decimal ammount)
        {
            ExchangeService exchange = new ExchangeService();
            exchange.LoadExchange();

            if (!exchange.ExchangeToMdl.Any()) throw new Exception("Exchange rate was not loaded");
            if (currency1 == currency2) return ammount;

            return exchange.ExchangeToMdl[currency1.ToString()] * ammount / exchange.ExchangeToMdl[currency2.ToString()];
        }
    }
}
