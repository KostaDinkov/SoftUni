using System;
using System.Net.Mail;

namespace GringotsDB.Core
{
    public static class Utility
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}