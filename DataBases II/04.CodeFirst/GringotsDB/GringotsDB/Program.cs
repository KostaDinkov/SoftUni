using System;
using GringotsDB.Core.Models;
using GringotsDB.Persistance;

namespace GringotsDB
{
    class Program
    {
        static void Main(string[] args)
        {
            WizardDeposit wizz = new WizardDeposit()
                                 {
                                     FirstName = "Keanu",
                                     LastName = "Reaves",
                                     Age = 200,
                                     MagicWandCreator = "Antioch Prverell",
                                     MagicWandSize = 15,
                                     DepositTime = new DateTime(2016, 10, 20),
                                     DepositExpirationDate = new DateTime(2020, 10, 20),
                                     DepositAmount = 20000.24m,
                                     DepositCharge = 0.2m,
                                     IsDepositExpired = false,

                                 };
            User user = new User()
                        {
                            UserName = "Kostadin",
                            Password = "sunshine", //throws exception
                            Age = 20,
                            Email = "kosta@dinkov.com",
                            IsDeleted = false,
                            LastTimeLoggedIn = DateTime.Now,
                            RegisteredOn = DateTime.Now,
                            ProfilePicture = new byte[0]

                        };

            using (var unitOfWork = new UnitOfWork(new Persistance.GringotsDB()))
            {

                unitOfWork.WizardDeposits.Add(wizz);
                unitOfWork.Users.Add(user);
                unitOfWork.Complete();
            }
        }
    }
}