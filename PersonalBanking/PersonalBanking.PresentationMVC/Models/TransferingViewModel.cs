using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.PresentationMVC.Models
{
    public class TransferingViewModel
    {
        [Required]
        public string SourceBankAccountNumber { get; set; }
        [Required]
        public string TargetBankAccountNumber { get; set; }
        [Required]
        public decimal Ammount { get; set; }
        public int Id { get; set; }
    }
}