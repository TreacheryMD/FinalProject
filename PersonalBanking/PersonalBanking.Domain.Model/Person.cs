using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.Domain.Model
{
    public enum GenderType { Male = 1, Female, Unckown }
    public class Person : EntityBase
    {
        public virtual string FirstName { get; protected internal set; }
        public virtual string LastName { get; protected internal set; }
        public virtual DateTime BirthDate { get; protected internal set; }
        public virtual string FiscalCode { get; protected internal set; }
        public virtual GenderType Gender { get; protected internal set; }

        public Person(string firstName, string lastName, DateTime birthDate, string fiscalCode, GenderType gender)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));
            if (string.IsNullOrWhiteSpace(fiscalCode)) throw new ArgumentNullException(nameof(fiscalCode));
            if (birthDate < DateTime.Now.AddYears(-125)) throw new Exception($"Invalid field:{nameof(birthDate)}");

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            FiscalCode = fiscalCode;
            Gender = gender;
        }

        public Person()
        {
            FirstName = "NoFirstName";
            LastName = "NoLastName";
            BirthDate = DateTime.Now;
            FiscalCode = "0000000000000";
            Gender = GenderType.Male;
        }

        public override string ToString()
        {
            return $"{FirstName};{LastName};{BirthDate.ToShortDateString()};{FiscalCode};{Gender}";
        }

        public virtual string GetPersonFiscalCode()
        {
            return FiscalCode;
        }
    }
}
