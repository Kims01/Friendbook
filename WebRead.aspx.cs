using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace PjFreindBookSeungyeonKim
{
    public partial class WebRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int refM = Convert.ToInt32(Request.QueryString["refM"]);
           OleDbConnection myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\scami\\source\\repos\\PjFreindBookSeungyeonKim\\PjFreindBookSeungyeonKim\\App_Data\\dbFriendBook.mdb");
            myCon.Open();
            
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Messages WHERE RefMessage =" + refM, myCon);
            OleDbDataReader myRd = myCmd.ExecuteReader();

            if (myRd.Read())
            {
                lblTitle.Text = myRd["Title"].ToString();
                lblMessage.Text = myRd["Message"].ToString();
                lblDate.Text = myRd["CreateDate"].ToString();
            }
            myRd.Close();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebHome.aspx");
        }

        protected System.Void Page_Load(System.Object sender, System.EventArgs e)
        {

        }
    }
}