/**==========================================================================
 * System: TS Vacancy
 * Module: Administration Website
 * Author: Lucas Porcelli, Edward Centeno
 * Company: @r-Tech SRL Costa Rica
 * Date: Sep, 2018
 *==========================================================================*/

using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace PG.LST.PSC.App_Code
{
    public class ExcelWriter
    {
        public static void DownloadFile(DataTable dt, string fileName)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, dt.TableName);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".xlsx");
                
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms, false);
                    ms.WriteTo(HttpContext.Current.Response.OutputStream);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                }
            }
        }

    }
}