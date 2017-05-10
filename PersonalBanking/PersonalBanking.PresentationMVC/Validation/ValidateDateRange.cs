using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace PersonalBanking.PresentationMVC.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateDateRange : ValidationAttribute, IClientValidatable
    {
        //public DateTime MinDate { get; set; }
        //public DateTime MaxDate { get; set; }

        //public ValidateDateRange(DateTime minDateTime,DateTime maxDateTime)
        //{
        //    MinDate = minDateTime;
        //    MaxDate = maxDateTime;
        //}

        private string _errMessage =
            $"Date is not in given range {DateTime.Now.AddYears(-120)}-{DateTime.Now.AddYears(-18)}";

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var mvr = new ModelClientValidationRule
            {
                ErrorMessage = _errMessage,
                ValidationType = "ValidateDateRange"
            };
            return new[] { mvr };
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value) >= DateTime.Now.AddYears(-120) && Convert.ToDateTime(value) <= DateTime.Now.AddYears(-18))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(_errMessage);
            }
        }
    }
}