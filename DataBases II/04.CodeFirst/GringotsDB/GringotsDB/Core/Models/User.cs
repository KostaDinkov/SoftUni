using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GringotsDB.Core.Models
{
    public class User : IValidatableObject
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        public int Age { get; set; }
        public bool IsDeleted { get; set; }

        //complex validations
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //todo create strings class
            //validate password
            if (!Regex.IsMatch(this.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
            {
                yield return new ValidationResult("Invalid Password: must contain...");
            }
            if (Password.Length < 6 || Password.Length>50)
            {
                yield return new ValidationResult("Invalid Password: length must be between 6 and 50 symbols");
            }

            //validate email
            if (!Utility.IsValidEmail(this.Email))
            {
                yield return new ValidationResult("Invalid Email");
            }

            //validate profile picture
            if (this.ProfilePicture.Length > 1024)
            {
                yield return new ValidationResult("Image size too big!");
            }

            //validate age
            if ((this.Age < 4) || (this.Age > 120))
            {
                yield return new ValidationResult("Invalid age!");
            }
        }
    }
}