<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebRegistration.aspx.cs" Inherits="PjFreindBookSeungyeonKim.WebRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 400px;
            background-color:beige;
        }
        .auto-style2 {
            height: 26px;
            text-align: left;
        }
        .auto-style3 {
            height: 22px;
            text-align: left;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style7 {
            text-align: left;
        }
        .auto-style8 {
            height: 26px;
            text-align: center;
        }
         .bg 
        {
          background-image: url("../img/fbook.jpg");
          height: 100%; 
          background-position: center;
          background-repeat: no-repeat;
          background-size: cover;
        }
    </style>
</head>
<body>
    <div class="bg">
    <form id="form1" runat="server">
        <div>
            <h1>&nbsp;</h1>
        </div>
        <table class="auto-style1" align="center">
            <tr>
                <td class="auto-style2" colspan="2">
                    <h1 class="auto-style5">Registration</h1>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="2">&nbsp;<a href="WebLogin.aspx">Already have an account? Sign in!</a></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;Username</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtUsername" runat="server" Width="177px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Password</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="177px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Retype Password</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtRetypePassword" runat="server" TextMode="Password" Width="177px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">First Name</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtFirstName" runat="server" Width="177px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Last Name</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtLastName" runat="server" Width="177px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Gender</td>
                <td class="auto-style7">
                    <asp:RadioButtonList ID="rbtnGender" runat="server">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Spoken Languages</td>
                <td class="auto-style3">
                    <asp:CheckBoxList ID="ckboxLanguages" runat="server" OnSelectedIndexChanged="ckboxLanguages_SelectedIndexChanged">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Race</td>
                <td class="auto-style7">
                    <asp:DropDownList ID="cboRace" runat="server" Width="182px" OnSelectedIndexChanged="cboRace_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">City</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtCity" runat="server" Width="177px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style5">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style7">
                    <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click" Text="Sign Up" Width="181px" />
                </td>
            </tr>
            </table>
        <p>
            &nbsp;</p>
    </form>
        </div>
</body>
</html>
