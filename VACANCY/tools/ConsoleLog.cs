/**==========================================================================
 * System: TS Vacancy
 * Module: Administration Website
 * Author: Lucas Porcelli, Edward Centeno
 * Company: @r-Tech SRL Costa Rica
 * Date: Sep, 2018
 *==========================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PG.LST.PSC.TSVacancy.App_Code
{
    public class ConsoleLog
    {
        public static void Error(string Message)
        {
            System.Diagnostics.Debug.WriteLine("[ERROR] --> " + Message);
        }

        public static void Debug(string Message)
        {
            System.Diagnostics.Debug.WriteLine("[DEBUG] --> " + Message);
        }

        public static void Warning(string Message)
        {
            System.Diagnostics.Debug.WriteLine("[WARNING] --> " + Message);
        }
    }
}