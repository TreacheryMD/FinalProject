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
        public static DateTime MinDateTime = DateTime.Now.AddYears(-120);
        public static DateTime MaxDateTime = DateTime.Now.AddYears(-18);

        private readonly string _errMessage =
            $"Date is not in given range {MinDateTime.ToShortDateString()}-{MaxDateTime.ToShortDateString()}";

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
             var mvr = new ModelClientValidationRule
            {
                ErrorMessage = "clientSide",
                ValidationType = "validatedaterange"
            };
            return new[] { mvr };
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value) >= MinDateTime && Convert.ToDateTime(value) <= MaxDateTime)
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