using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace PjFreindBookSeungyeonKim
{
    public partial class WebHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbDataReader greet = (OleDbDataReader)Session["User"];
            lblGreet.Text = "Welcome " + greet["FirstName"].ToString() + " " + greet["LastName"].ToString();
            OleDbConnection myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\scami\\source\\repos\\PjFreindBookSeungyeonKim\\PjFreindBookSeungyeonKim\\App_Data\\dbFriendBook.mdb");
            myCon.Open();
            string sql = "SELECT Messages.RefMessage, Messages.Message, Messages.Sender, Messages.Receiver, Messages.Title, Members.FirstName + ' ' + Members.LastName AS Fullname FROM  Messages, Members WHERE Messages.Sender = Members.RefMember AND Messages.Receiver = " + greet["RefMember"];

            OleDbCommand myCmd = new OleDbCommand(sql, myCon);
            OleDbDataReader myRd = myCmd.ExecuteReader();

            //GridView1.DataSource = myRd;
            //GridView1.DataBind();

            while (myRd.Read())
            {
                ltlMessage.Text = "<table><tr><td>Messages</td><td>From</td><td>Actions</td></tr><tr><td>" + myRd["Title"].ToString() + "</td><td>" + myRd["Fullname"].ToString() + "</td><td><a href=" + "WebRead.aspx?refM=" + myRd["RefMessage"].ToString() + ">Read</a><a href=" + "WebDelete.aspx?refM=" + myRd["RefMessage"].ToString() + ">Delete</a></td></tr></table> ";
                myRd.NextResult();
            }
            //if (!myRd.Read())
            //{
            //    ltlMessage.Text = "No messages";
            //}
            myRd.Close();
            //     ltlMessage.Text = "<table>< tr >< td >< strong > Messages </ strong ></ td >< td >< strong > From </ strong ></ td >< td >< strong > Actions </ strong ></ td ></ tr ><tr>< td >" + myRd["Title"].ToString() + "</ td >< td >" + myRd["Fullname"].ToString() + "</ td >< td > < a href = "read.aspx? refM =<%= myRec.Fields["RefMessage"].Value %> " > Read </ a >
            //< a href = "delete.aspx?refM=<%= myRec.Fields["RefMessage"].Value %>" > Delete </ a > </ td ></ tr ></ table > ";

        }

        protected System.Void Page_Load(System.Object sender, System.EventArgs e)
        {

        }
    }
}