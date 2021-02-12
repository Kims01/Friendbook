<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebRead.aspx.cs" Inherits="PjFreindBookSeungyeonKim.WebRead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @import url('https://fonts.googleapis.com/css?family=Raleway:300,400,700,900');
        .auto-style1 {
            width: 401px;
             background-color:beige;
             font-family:Arial;
            
             background-color:beige;
             position:fixed;
             margin-left:-150px; 
             margin-top:-170px;  
             top:50%;
             left:50%;
        }
        .auto-style2 {
            width: 80px;
        }
    
        header 
        {
	        position: absolute;
	        left: 0;
	        right: 0;
	        margin: 1em;  
        }
        nav ul
        {
	        margin: 0;
	        padding: 0;
	        list-style: none;
        }

        nav li {
	        display: inline-block;
	        margin: 1em;
        }

        nav a {
	        font-weight: 900;
	        text-decoration: none;
	        padding: .5em;
	        text-transform: uppercase;
	        color: black;
	        font-size: .8rem;
        }

        nav a:hover,
        nav a:focus {
	        color: #ddd;
        }

        @media (min-width:60rem)
        {
	        nav {
		        float: right;
	        }
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
     <header>
      <nav>
      <ul>
        <li><a href="WebHome.aspx">HOME</a></li>
        <li><a href="WebSearchMessage.aspx">SEND A MESSAGE</a></li>
       </ul>
    </nav>
  </header>
    <form id="form1" runat="server">
        <div>
            
            <br />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Title </td>
                    <td>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Message </td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Date</td>
                    <td>
                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return" Width="134px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
        </div>
</body>
</html>
