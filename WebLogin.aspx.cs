using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace PjFreindBookSeungyeonKim
{
    public partial class WebLogin : System.Web.UI.Page
    {
        OleDbConnection myCon;
        string username;
        string password;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\scami\\source\\repos\\PjFreindBookSeungyeonKim\\PjFreindBookSeungyeonKim\\App_Data\\dbFriendBook.mdb");
            myCon.Open();


        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;
            if (verifyLogin())
            {
               OleDbCommand myCmd = new OleDbCommand("Select * from Members where Username =@username AND Password =@password", myCon);
                myCmd.Parameters.Add("@username", username);
                myCmd.Parameters.Add("@password", password);
                OleDbDataReader myRd = myCmd.ExecuteReader();


                if (myRd.Read())
                {
                    Session["User"] = myRd;
                    
                    Response.Redirect("WebHome.aspx");
                }
                else
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();

                    lblMessage.Text = "The username or password is incorrect";
                }
                myRd.Close();
            }
           
        }

        private bool verifyLogin()
        {
            if (username == "" || username.Length < 5)
            {
                lblMessage.Text = "Username must be more than 5 characters";
                txtUsername.Text = "";
                txtUsername.Focus();
                return false;
            }if (password == "" || password.Length < 4)
            {
                lblMessage.Text = "Password must be more than 4 characters";
                txtPassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected System.Void btnSignin_Click(System.Object sender, System.EventArgs e)
        {

        }
    }
}