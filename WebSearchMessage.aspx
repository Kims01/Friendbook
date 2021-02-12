<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSearchMessage.aspx.cs" Inherits="PjFreindBookSeungyeonKim.WebSearchMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @import url('https://fonts.googleapis.com/css?family=Raleway:300,400,700,900');
       
        .auto-style3 {
            height: 26px;
            text-align: left;
        }
        .auto-style5 {
            width: 212px;
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
       
        .auto-style9 {
            text-align: left;
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
        .auto-style1 {
            width: 400px;
        }
        .auto-style10 {
            width: 331px;
        }
        .auto-style7 {
            text-align: center;
            height: 23px;
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
        <br />
        <br />
        <br />
        <asp:Label ID="lblGreet" runat="server"></asp:Label>
        <br />
        <br />
     
       
           
        <asp:Panel ID="PanelSearch" runat="server" Height="158px" Width="410px" BackColor="Beige">
            <table class="auto-style5" align="center">
                <tr>
                    <td class="auto-style9">
                        <h2>Search a friend</h2>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:DropDownList ID="cboSearch" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="218px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtUserEntered" runat="server" Width="215px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">
                        <asp:Button ID="btnSearch0" runat="server" OnClick="btnSearch_Click" Text="Search" Width="220px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
         <br />
    
        <asp:Panel ID="PanelMessage" runat="server" Height="195px" Width="410px" BackColor="Beige">
            <table class="auto-style1">
                <tr>
                    <td>Recipient&nbsp;&nbsp; </td>
                    <td class="auto-style10">
                        <asp:DropDownList ID="cboRecipient" runat="server" Width="326px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Title </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtTitle" runat="server" Width="323px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Message </td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtMessage" runat="server" Height="73px" TextMode="MultiLine" Width="321px" OnTextChanged="txtMessage_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" Width="59px" />
                    </td>
                    <td class="auto-style10">
                        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" Width="326px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7" colspan="2">
                        <asp:Label ID="lblMessageState" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
      
        <br />
    </form>
         </div>
</body>
</html>
