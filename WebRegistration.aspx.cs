using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Collections;

namespace PjFreindBookSeungyeonKim
{
    public partial class WebRegistration : System.Web.UI.Page
    {
        OleDbConnection myCon;
        string username, password,retypePassword, firstName, lastName, gender, race, city;
        ArrayList listOfLangues;
        protected void cboRace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ckboxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Initialize();
            }
           
        }
        private void Initialize()
        {
            rbtnGender.Items.Add("Male");
            rbtnGender.Items.Add("Female");

            cboRace.Items.Add("Select a race from the list");
            cboRace.Items.Add("Asian");
            cboRace.Items.Add("Black");
            cboRace.Items.Add("Hispanic");
            cboRace.Items.Add("White");
            cboRace.Items.Add("Native Americans");

            ckboxLanguages.Items.Add("French");
            ckboxLanguages.Items.Add("English");
            ckboxLanguages.Items.Add("Korean");
            ckboxLanguages.Items.Add("Spanish");
            ckboxLanguages.Items.Add("German");
            ckboxLanguages.Items.Add("Japanese");
            ckboxLanguages.Items.Add("Chinese");



        }
        private bool IscheckboxChecked()
        {
            bool  atLeastOneChecked = false;

            for (int i = 0; i < ckboxLanguages.Items.Count; i++)
            {
                if (ckboxLanguages.Items[i].Selected)
                {
                    atLeastOneChecked = true;
                }
                
            }
            
            
            return atLeastOneChecked;
        }
        private ArrayList AddLanguagestoArray()
        {

            listOfLangues = new ArrayList();

            for (int i = 0; i < ckboxLanguages.Items.Count; i++)
            {
                if (ckboxLanguages.Items[i].Selected)
                {
                    listOfLangues.Add(ckboxLanguages.Items[i].Text);
                }

            }

            return listOfLangues;
        }
        private void InsertLanguages(int refNum)
        {
            ArrayList languages = AddLanguagestoArray();
            foreach (var lang in languages)
            {
                string desc = lang.ToString();
                OleDbCommand myCmd = new OleDbCommand("INSERT INTO Languages (Description, RefMember) VALUES(=@desc, =@refNum)", myCon);
                myCmd.Parameters.Add("@desc", desc);
                myCmd.Parameters.Add("@refNum", refNum);
                myCmd.ExecuteNonQuery();
            }
            

        }
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;
            retypePassword = txtRetypePassword.Text;
            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            city = txtCity.Text;

            if (VerifyLogin())
            {
                gender = rbtnGender.SelectedItem.Text;
                race = cboRace.SelectedItem.Text;

                myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\scami\\source\\repos\\PjFreindBookSeungyeonKim\\PjFreindBookSeungyeonKim\\App_Data\\dbFriendBook.mdb");
                myCon.Open();

                OleDbCommand myCmdDuplicateID = new OleDbCommand("Select * from Members where Username =@username", myCon);
                myCmdDuplicateID.Parameters.Add("@username",username);
                OleDbDataReader myRd = myCmdDuplicateID.ExecuteReader();

                if (!myRd.Read())
                {
                    OleDbCommand myCmd = new OleDbCommand("INSERT INTO Members (Username, [Password], FirstName, LastName, Gender, Race, City) VALUES(=@username, =@password, =@firstName, =@lastName, =@gender, =@race, =@city)", myCon);
                    myCmd.Parameters.Add("@username", username);
                    myCmd.Parameters.Add("@password", password);
                    myCmd.Parameters.Add("@firstName", firstName);
                    myCmd.Parameters.Add("@lastName", lastName);
                    myCmd.Parameters.Add("@gender", gender);
                    myCmd.Parameters.Add("@race", race);
                    myCmd.Parameters.Add("@city", city);

                    myRd.Close();

                    int a = myCmd.ExecuteNonQuery();
                    int refMember;
                    //OleDbCommand cmdSelectRefMember = new OleDbCommand("Select * from Members where Username =@username", myCon);
                    //cmdSelectRefMember.Parameters.Add("@username", username);
                    //OleDbDataReader myRd2 = cmdSelectRefMember.ExecuteReader();
                
                    if (a == 0)
                    {

                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error occurred please try again.')", true);
                        // Response.Write(@"<script language='javascript'>alert('Error occurred please try again.');</script>");

                        Response.Redirect("WebRegistration.aspx");
                    }
                    else
                    {
                        // Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registered successfully!')", true);
                        // Response.Write(@"<script language='javascript'>alert('Registered successfully!');</script>");
                        OleDbDataReader myRd2 = myCmdDuplicateID.ExecuteReader();
                        if (myRd2.Read())
                        {
                            refMember = Convert.ToInt32(myRd2["RefMember"]);
                            InsertLanguages(refMember);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Registered successfully!')", true);
                        }
                        myRd2.Close();

                       




                        Response.Redirect("WebLogin.aspx");
                    }

                }
                else
                {
                    lblMessage.Text = "Username exists. Please enter another username";
                }

                
                
            }

        }
      
        private bool VerifyLogin()
        {
            if (username == "" || username.Length < 5)
            {
                lblMessage.Text = "Username must be more than 5 characters";
                txtUsername.Text = "";
                txtUsername.Focus();
                return false;
            }
            if (password == "" || password.Length < 4)
            {
                lblMessage.Text = "Password must be more than 4 characters";
                txtPassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            if (password!=retypePassword)
            {
                lblMessage.Text = "Enter the same password twice";
                txtPassword.Text = "";
                txtRetypePassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            if (firstName == "" || firstName.Length < 2)
            {
                txtFirstName.Text = "";
                txtFirstName.Focus();
                lblMessage.Text = "First Name must be more than 2 characters";
                return false;
            }
            if (lastName == "" || lastName.Length < 2)
            {
                txtLastName.Text = "";
                txtLastName.Focus();
                lblMessage.Text = "Last Name must be more than 2 characters";
                return false;
            }
            if (rbtnGender.SelectedIndex == -1)
            {
                lblMessage.Text = "Please select a gender";
                return false;
            }
            if (!IscheckboxChecked())
            {
                lblMessage.Text = "Please select at least one language";
                return false;
            }
            if (cboRace.SelectedIndex == 0)
            {
                lblMessage.Text = "Please select a race";
                return false;
            }
            if (city == "")
            {
                lblMessage.Text = "Please enter the name of city";
                return false;
            }
            else
            {
                lblMessage.Text = "User account created!";
                return true;
            }
        }

    }
}