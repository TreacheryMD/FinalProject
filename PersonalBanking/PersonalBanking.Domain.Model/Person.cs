using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model.Account;

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
        //public virtual IList<BankAccount> BankAccounts { get; protected internal set; }


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
           // BankAccounts = new List<BankAccount>();
        }

        public Person()
        {
            FirstName = "NoFirstName";
            LastName = "NoLastName";
            BirthDate = DateTime.Now;
            FiscalCode = "000000000";                         
            Gender = GenderType.Male;
          //  BankAccounts = new List<BankAccount>();
        }

        //public virtual void AddBankAccount(BankAccount bankAccount)
        //{
        //    BankAccounts.Add(bankAccount); 
        //}
        //public virtual void RemoveBankAccount(BankAccount bankAccount)
        //{
        //    BankAccounts.Remove(bankAccount);
        //}
        public override string ToString()
        {
            return $"{FirstName};{LastName};{BirthDate.ToShortDateString()};{FiscalCode};{Gender}";
        }

        public virtual string GetPersonFiscalCode()
        {
            return FiscalCode;
        }

        //public IList<Person> RandomPersonGenerator(int numberOfPersonToGenerate)
        //{
        //    Random rnd = new Random();
        //    //80
        //    string[] firstNamesFemaleArray = { "Abbie", "Adalyn", "Alaina", "Alani", "Alannah", "Alayna", "Amaris", "Amiah", "Amy", "Anaya", "Annabelle", "Ava", "Barbara", "Braelyn", "Bridget", "Cecelia", "Celia", "Cherish", "Cindy",
        //                                "Crystal", "Dakota", "Dayami", "Delilah", "Diamond", "Elizabeth", "Elliana", "Esperanza", "Evelyn", "Fernanda", "Hadley", "Hillary", "Hope", "Isabel", "Janet", "Jaylene", "Jaylyn", "Jazlyn",
        //                                "Jazlynn", "June", "Kaiya", "Karlee", "Karley", "Kaydence", "Kaylen", "Kenya", "Kristen", "Kylee", "Lauren", "Lauryn", "Leanna", "Lia", "Lilianna", "Livia", "Lucy", "Madelyn", "Madisyn", "Mariam",
        //                                "Marina", "Marisol", "Mckenzie", "Meadow", "Melanie", "Melissa", "Meredith", "Monica", "Naomi", "Paityn", "Perla", "Piper", "Raegan", "Ryleigh", "Sanai", "Sherlyn", "Sienna", "Sloane", "Tessa", "Vivian",
        //                                "Whitney", "Willow", "Yasmine"};
        //    //40
        //    string[] firstNamesMaleArray = { "Patrick", "Jaxson", "Dillan", "Emerson", "Cael", "Rey", "Felix", "Billy", "Shamar", "Jamie", "Marquise", "Steve", "Paxton", "Spencer", "Jay", "Justin", "Jadon", "Elijah", "Johnathan", "William", "Frederick",
        //                                 "Malik", "Aaden", "Adam", "Royce", "Chase", "Jovanni", "Antonio", "Eddie", "Aydin", "Declan", "Brycen", "Brandon", "Alessandro", "Victor", "Ronan", "Arturo", "Quentin", "Bryce", "Dexter" };
        //    //65
        //    string[] lastNameArray = { "Mcgee", "Wagner", "Evans", "Washington", "Horton", "Buck", "Robles", "Flowers", "Bowen", "Maldonado", "Rogers", "Moran", "Crane", "Sexton", "Dawson", "Lloyd", "Villegas", "Holloway", "Wall", "Hale", "Parsons",
        //                           "Leon", "Hart", "Ballard", "Schneider", "Fry", "Fletcher", "Underwood", "David", "Li", "Good", "Hunt", "Butler", "Soto", "Gaines", "Zuniga", "Gould", "Caldwell", "Cowan", "Davis", "Peters",
        //                           "George", "Solis", "Terry", "Wolfe", "Curry", "Mckee", "Benson", "Ray", "Wilkins", "Rocha", "Kemp", "Ibarra", "Cuevas", "Thomas", "Gray", "Brewer", "Santos", "Hoover", "Morse", "Sparks", "Fritz", "Steele", "Hurley", "Gibson" };


        //    IList<Person> pList = new List<Person>();

        //    for (int i = 0; i < numberOfPersonToGenerate; i++)
        //    {
        //        int gN = rnd.Next(1, 2);
        //        GenderType gender = (GenderType)gN;
        //        string firstName = gN == 1 ? firstNamesMaleArray[rnd.Next(0, 39)] : firstNamesFemaleArray[rnd.Next(0, 79)];
        //        string lastName = lastNameArray[rnd.Next(0, 64)];
        //        DateTime birthDate = new DateTime(rnd.Next(1950, 1999), rnd.Next(1, 12), rnd.Next(1, 26));

        //        //List<int> fiscalCodesList = new List<int>();

        //        //pList.Add(new Person(firstName,lastName,birthDate,fiscalCode, gender));
        //    }
        //    return pList;
        //}
    }
}
