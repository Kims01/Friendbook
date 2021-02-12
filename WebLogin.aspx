<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLogin.aspx.cs" Inherits="PjFreindBookSeungyeonKim.WebLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 
        {
            font-family:Arial;
             width:300px;
             height:300px;
             background-color:beige;
             position:fixed;
             margin-left:-150px; 
             margin-top:-170px;  
             top:50%;
             left:50%;
            
        }
        .auto-style3 
        {
            font-family:Arial;
            text-align: center;
        }
        body, html 
        {
          height: 100%;
          margin: 0;
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
            <table class="auto-style1" align="center" >
                <tr>
                    <td colspan="2">
                        <h1 class="auto-style3">Friendbook</h1>
                    </td>
                </tr>
                <tr>
                    <td><strong>Username</strong></td>
                    <td>
            <asp:TextBox ID="txtUsername" runat="server" Width="223px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><strong>Password</strong></td>
                    <td>
            <asp:TextBox ID="txtPassword" runat="server" OnTextChanged="txtPassword_TextChanged" TextMode="Password" Width="223px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><asp:Button ID="btnSignin" runat="server" Text="Sign in" OnClick="btnSignin_Click" Width="229px" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">&nbsp;<strong><a href="WebRegistration.aspx">Don&#39;t have a Friendbook account? </a>
                        <br />
                        <a href="WebRegistration.aspx">Sign up!</a></strong></td>
                </tr>
            </table>
        </div>
                  </form>
        </div>
 
</body>
</html>
