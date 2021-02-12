using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace PjFreindBookSeungyeonKim
{
    public partial class WebSearchMessage : System.Web.UI.Page
    {

        OleDbConnection myCon;

        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                Initialize();
                
            }
        
        }
        private bool VerifySearchTextBox()
        {
            if (txtUserEntered.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        private bool VerifyMessagePanel()
        {
            if (txtTitle.Text == "")
            {
                lblMessageState.Text = "Please enter the title";
                txtTitle.Focus();
                return false;
            }
            if (txtMessage.Text == "")
            {
                lblMessageState.Text = "Enter a message";
                txtMessage.Focus();
                return false;
            }
            else
            {
                return true;
            }

        }
        private void Initialize()
        {

            OleDbDataReader greet = (OleDbDataReader)Session["User"];
            lblGreet.Text = "Welcome " + greet["FirstName"].ToString() + " " + greet["LastName"].ToString();
            cboSearch.Items.Add("Select an option from the list");
            cboSearch.Items.Add("Gender");
            cboSearch.Items.Add("Race");
            cboSearch.Items.Add("City");
            cboSearch.Items.Add("Language spoken");

            PanelMessage.Visible = false;

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelMessage.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (VerifySearchTextBox())
            {
                myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\scami\\source\\repos\\PjFreindBookSeungyeonKim\\PjFreindBookSeungyeonKim\\App_Data\\dbFriendBook.mdb");
                myCon.Open();

                string selected = cboSearch.SelectedItem.Text;
                string userEntered = txtUserEntered.Text;
                OleDbDataReader myRd;

                if (selected == "Language spoken")
                {
                    OleDbCommand myCmd = new OleDbCommand("SELECT m.Refmember, m.FirstName + ' ' + m.LastName AS Fullname FROM Members m, Languages l WHERE m.RefMember = l.RefMember AND l.Description = @userEntered; ", myCon);
                    myCmd.Parameters.Add("@userEntered", userEntered);
                    myRd = myCmd.ExecuteReader();

                    cboRecipient.DataTextField = "FullName";
                    cboRecipient.DataValueField = "RefMember";
                    cboRecipient.DataSource = myRd;
                    cboRecipient.DataBind();
                    myRd.Close();
                }
                else
                {

                    //OleDbCommand myCmd = new OleDbCommand("Select * from Members where "+ selected +" =@userEntered ", myCon);
                    OleDbCommand myCmd = new OleDbCommand("Select RefMember,FirstName  + ' ' + LastName AS FullName from Members where " + selected + " =@userEntered", myCon);
                    myCmd.Parameters.Add("@userEntered", userEntered);

                    myRd = myCmd.ExecuteReader();

                    cboRecipient.DataTextField = "FullName";
                    cboRecipient.DataValueField = "RefMember";
                    cboRecipient.DataSource = myRd;
                    cboRecipient.DataBind();
                    myRd.Close();

                }


                cboSearch.SelectedIndex = 0;
                txtUserEntered.Text = "";

                if (string.IsNullOrEmpty(cboRecipient.Text))
                {

                    lblResult.Text = "No Data Found";

                }
                else
                {
                    PanelMessage.Visible = true;
                    lblResult.Text = "";
                }


            }
            else
            {
                lblResult.Text = "Please enter a word to search";
            }



        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            cboRecipient.SelectedIndex=0;
            txtTitle.Text = "";
            txtMessage.Text = "";
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (VerifyMessagePanel())
            { 
                string recipient = cboRecipient.SelectedItem.Text;
                string title = txtTitle.Text;
                string message = txtMessage.Text;

                int selectedIndex = cboRecipient.SelectedIndex;
                int selectedValue = Convert.ToInt32(cboRecipient.SelectedValue);
                int receiver = selectedValue;

                myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\scami\\source\\repos\\PjFreindBookSeungyeonKim\\PjFreindBookSeungyeonKim\\App_Data\\dbFriendBook.mdb");
                myCon.Open();
                OleDbDataReader greet = (OleDbDataReader)Session["User"];
                sender = Convert.ToInt32(greet["RefMember"]);

            

                OleDbCommand myCmd = new OleDbCommand("INSERT INTO Messages (Title,Message,Sender,Receiver) VALUES ('" + title + "','" + message + "'," + sender + "," + receiver + ")", myCon);


                //OleDbCommand myCmd = new OleDbCommand("Insert into Messages (Title,Message,Sender,Receiver) Values(@title, @message,@sender,@receiver)", myCon);
                //myCmd.Parameters.Add("@title", title);
                //myCmd.Parameters.Add("@message", message);
                //myCmd.Parameters.Add("@sender", sender);
                //myCmd.Parameters.Add("@receiver", receiver);

                int a = myCmd.ExecuteNonQuery();

                if (a == 0)
                {


                }
                else
                {

                    lblMessageState.Text = "Inserted!!";
                    Response.Redirect("WebHome.aspx");

                }

            }

        }

        protected void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}