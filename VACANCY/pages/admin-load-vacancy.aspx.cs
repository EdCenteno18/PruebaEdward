using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PG.LST.PSC.TSVACANCY.Models;
using PG.LST.PSC.TSVACANCY.entities;
using System.Collections;
using System.Text;

namespace PG.LST.PSC.TSVACANCY.pages
{
    public partial class admin_load_vacancy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Log.Save(Session["UserName"].ToString(), "W", "MENSAJE DE PRUEBA");
                string s = Session["UserName"].ToString();
            }


            List<Vacancy> list = new List<Vacancy>();
            list = VacancyModel.GetAllVacancy();

            string htmlTable = GetMyTable(list);
            //Al div de la tabla le asigno la construcción del table en html
            divTabla.InnerHtml = htmlTable;
        }


        //Este methodo recibe un listado de vacantes despues construye un table para ser visto en la vista
        public static string GetMyTable(List<Vacancy> lst)
        {

            var sb = new StringBuilder();
            sb.Append("<TABLE id='load-vacancy'class='table' data-filtering='true' data-paging='true' data-paging-position='right' data-paging-size='10'>\n");
            sb.Append("<thead>\n");
            sb.Append("<tr>\n");
            sb.Append("<th>Position Title</th>\n");
            sb.Append("<th>Department</th>\n");
            sb.Append("<th data-breakpoints='s sm'>Hiring Manager</th>\n");
            sb.Append("<th data-breakpoints='xs sm'>Status</th>\n");
            sb.Append("</thead>\n");
            sb.Append("<tbody>\n");
            foreach (var item in lst)
            {
                sb.Append("<tr>\n");

                sb.Append("<td>\n");
                sb.Append(item.PositionTitle);
                sb.Append("</td>\n");

                sb.Append("<td>\n");
                sb.Append(item.Department);
                sb.Append("</td>\n");

                sb.Append("<td>\n");
                sb.Append(item.HiringManager);
                sb.Append("</td>\n");

                sb.Append("<td>\n");
                sb.Append(item.IDStatus);
                sb.Append("</td>\n");

                sb.Append("</tr>\n");

            }
            sb.Append("</tbody>\n");
            sb.Append("</table>\n");
            return sb.ToString();

        }
    }
}