using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace WebStatementViewerC
{
    public partial class _default : System.Web.UI.Page
    {
        SqlConnection ImpdbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ImpdbConn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            DateTime current;
            string result;
            DropDownList1.DataTextFormatString = "{0:dd/MM/yyyy}";
            if (IsPostBack == false)
            {
                dateoffTrade();
                current = Convert.ToDateTime(DropDownList1.SelectedValue);
                result = current.ToString("yyyyMMdd");
                uptolist(result);
                Label1.Text = current.ToString("yyyy/MM/dd");
            }
        }

        private void dateoffTrade()
        {
          //  SqlConnection ImpdbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ImpdbConn"].ConnectionString);
            string buildSQL = "SELECT (CONVERT(datetime,( CONVERT(varchar(8), UploadTime, 112)),106 ) ) as UploadTime  FROM ProcessQry where datediff(day , getdate() , uploadtime ) > -10 group by CONVERT(varchar(8), UploadTime, 112) Order By CONVERT(varchar(8), UploadTime, 112) DESC";
            SqlCommand cmd = new SqlCommand(buildSQL, ImpdbConn);
            cmd.Connection.Open();
            SqlDataReader ddlValues;
            ddlValues = cmd.ExecuteReader();
            DropDownList1.DataSource = ddlValues;
            DropDownList1.DataValueField = "UploadTime";
            DropDownList1.DataTextField = "UploadTime";
            DropDownList1.DataBind();
            cmd.Connection.Close();
          //  cmd.Connection.Dispose();




        }
        private void uptolist(string getdate)
        {
         //   SqlConnection ImpdbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ImpdbConn"].ConnectionString);
            getdate = getdate.Substring(2, 6);
          //  DateTime current;
            string buildSQL = "SELECT UploadTime,ClientCode,Status,StartTime,EndTime FROM ProcessQry   where UploadFileDate ='" + (getdate) + "' and UploadTime > '16:00' Order By UploadTime";
            SqlCommand cmd = new SqlCommand(buildSQL, ImpdbConn);
            cmd.Connection.Open();
            SqlDataReader ddlValues;
            ddlValues = cmd.ExecuteReader();
            GridView1.DataSource = ddlValues;
            GridView1.DataBind();
            cmd.Connection.Close();
           // cmd.Connection.Dispose();


        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime current;
            string result;

            current = Convert.ToDateTime(DropDownList1.SelectedValue);
            result = current.ToString("yyyyMMdd");
            uptolist(result);
        }

        protected void RowDatebound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string Cell = e.Row.Cells[2].Text;
                if (Cell == "S")
                {
                    e.Row.Cells[2].Text = "Success";
                }
                else if (Cell == "F")
                {
                    e.Row.Cells[2].Text = "Fail";
                }
                else if (Cell == "P")
                {
                    e.Row.Cells[2].Text = "Pending";
                }
                else if (string.IsNullOrEmpty(Cell)== true)
                {
                    e.Row.Cells[2].Text = "Processing";
                }
            }
        }

    }


}
