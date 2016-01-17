using System;

namespace Methods
{
    using System.Globalization;
    using System.Text.RegularExpressions;

    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        /// <summary>
        /// Compare the age of this student with another
        /// </summary>
        /// <param name="other">Another student</param>
        /// <returns>True, if this student is older than the second, False otherwise</returns>
        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = ExtractBirthDate(this.OtherInfo);
            DateTime secondDate = ExtractBirthDate(other.OtherInfo);

            return firstDate > secondDate;
        }

        /// <summary>
        /// Tries to extract a DateTime object representing birth date
        /// </summary>
        /// <param name="str">The string to look for a birth date</param>
        /// <returns></returns>
        private static DateTime ExtractBirthDate(string str)
        {
            //NOTE for Softuni students:
            //search for the 'born' keyword in the string
            //if such a word doesn't exist, then we cannot assume that any 
            //date would mean the birth date and will throw an exception
            //it's not perfect but better than the old variant

            Match born = Regex.Match(str, @"\bborn\W");
            if (born.Success)
            {
                Match bDate = Regex.Match(str.Substring(born.Index), @"\b\d{2}\.\d{2}.\d{4}\b");
                if (bDate.Success)
                {
                    DateTime birthDay;
                    if (DateTime.TryParseExact(bDate.Value, "dd.MM.yyyy", null, DateTimeStyles.None, out birthDay))
                    {
                        return birthDay;
                    }
                }
            }
            throw new ArgumentException("Could not extract a valid birth date from string.", str);
        }
    }
}