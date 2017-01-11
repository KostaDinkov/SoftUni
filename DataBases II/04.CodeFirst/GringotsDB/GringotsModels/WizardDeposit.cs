using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GringotsModels
{
    public class WizardDeposit : IValidatableObject
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public int Age { get; set; }
        public string MagicWandCreator { get; set; }
        public int MagicWandSize { get; set; }
        public string DepositGroup { get; set; }
        public DateTime DepositTime { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal DepositInterest { get; set; }
        public decimal DepositCharge { get; set; }
        public DateTime DepositExpirationDate { get; set; }
        public bool IsDepositExpired { get; set; }

        //Custom validations
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Age < 0)
            {
                yield return  new ValidationResult("Age cannot be  a negative number!");
            }
            if (this.MagicWandSize <1 || this.MagicWandSize >32767)
            {
                yield return new ValidationResult("MagicWandSize must be between 1 and 32767");
            }
        }
    }
}