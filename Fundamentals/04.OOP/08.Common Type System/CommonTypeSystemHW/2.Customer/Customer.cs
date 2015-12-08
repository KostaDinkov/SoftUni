namespace _2.Customer
{
    using System;
    using System.Collections.Generic;

    internal class Customer : ICloneable, IComparable
    {
        public Customer(string fName, string mName, string lName, ulong id)
        {
            this.FirstName = fName;
            this.MiddleName = mName;
            this.LastName = lName;
            this.ID = id;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public ulong ID { get; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string EMail { get; set; }
        public List<Payment> Payments { get; set; } = new List<Payment>();
        public CustomerType CustomerType { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.MiddleName} {this.LastName}, ID: {this.ID}";
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Customer return false.
            var p = obj as Customer;
            if (p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (
                this.ID == p.ID &&
                this.FirstName == p.FirstName &&
                this.MiddleName == p.MiddleName &&
                this.LastName == p.LastName);
        }

        public static bool operator ==(Customer a, Customer b)
        {
            if (Object.ReferenceEquals(a, b))
            {
                return true;
            }
            return false;
            // NOTE: After some testing I preferred to leave the == comparison for the reference to the object
            // instead of comparing particular fields of the objects.
            // Therefore i commented the next lines
            
            //if (((object) a == null) || ((object) b == null))
            //{
            //    return false;
            //}
            //return (
            //    a.ID == b.ID &&
            //    a.FirstName == b.FirstName &&
            //    a.MiddleName == b.MiddleName &&
            //    a.LastName == b.LastName);

        }

        public static bool operator !=(Customer a, Customer b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            // ID should be unique anyways so...
            return  base.GetHashCode() ^ this.ID.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var c = obj as Customer;
            if (c != null)
            {
                string fullname = this.FirstName + this.MiddleName + this.LastName;
                string objFullname = c.FirstName + c.MiddleName + c.LastName;
                if (fullname.Equals(objFullname))
                {
                    return this.ID.CompareTo(c.ID);
                }
                return fullname.CompareTo(objFullname);
            }
            return 1;
        }

        public object Clone()
        {
            //TODO Implement Clone
            //cloning all the value types by the provided clone functionality
            var clone = (Customer)this.MemberwiseClone();
            //copying the contetnts of the 
            clone.Payments = new List<Payment>();
            foreach (var payment in this.Payments)
            {
                clone.Payments.Add((Payment)payment.Clone());
            }

            return clone;
        }
    }
}