using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
namespace PjFreindBookSeungyeonKim
{
    public partial class WebDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int refM = Convert.ToInt32(Request.QueryString["refM"]);
            OleDbConnection myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\scami\\source\\repos\\PjFreindBookSeungyeonKim\\PjFreindBookSeungyeonKim\\App_Data\\dbFriendBook.mdb");
            myCon.Open();

            OleDbCommand myCmd = new OleDbCommand("Delete from Messages Where RefMessage=" + refM, myCon);
            myCmd.ExecuteNonQuery();
            Response.Redirect("WebHome.aspx");
        }
    }
}