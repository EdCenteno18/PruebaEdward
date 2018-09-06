/**==========================================================================
 * System: TS Vacancy
 * Module: Administration Website
 * Author: Lucas Porcelli, Edward Centeno
 * Company: @r-Tech SRL Costa Rica
 * Date: Sep, 2018
 *==========================================================================*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PG.LST.PSC.App_Code
{
    public static class Validation
    {
        public static bool IsDouble(object value)
        {
            try 
            {
                Convert.ToDouble(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsInteger(object value)
        {
            try
            {
                Convert.ToInt32(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static bool IsComplete(string field)
        {
            return field != null && !field.Trim().Equals("");
        }

        public static bool IsValidID(int? field)
        {
            return field != null && field != 0;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidDateTime(string strDate, string format = "yyyy-MM-dd HH:mm:ss")
        {
            DateTime result;
            return strDate != null && DateTime.TryParseExact(strDate, format,
                 CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }


    }
}