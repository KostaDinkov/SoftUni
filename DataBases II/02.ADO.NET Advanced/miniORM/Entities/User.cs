using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniORM.Attributes;

namespace miniORM.Entities
{
    [Entity(TableName = "Users")]
    class User
    {
        [Id]
        private int id;
        [Column(ColumnName = "Username")]
        private string username;
        [Column(ColumnName = "Password")]
        private string password;
        [Column(ColumnName = "Age")]
        private int age;
        [Column(ColumnName = "RegistrationDate")]
        private DateTime registrationDate;

        private string email;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                this.id = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                this.password = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                this.age = value;
            }
        }

        public DateTime RegistrationDate
        {
            get
            {
                return registrationDate;
            }

            set
            {
                this.registrationDate = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                this.email = value;
            }
        }

        public User(string username, string password, int age, DateTime registrationDate)
        {
            this.Username = username;
            this.Password = password;
            this.Age = age;
            this.RegistrationDate = registrationDate;
        }

        
    }
}
