<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebHome.aspx.cs" Inherits="PjFreindBookSeungyeonKim.WebHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        @import url('https://fonts.googleapis.com/css?family=Raleway:300,400,700,900');
        header 
        {
	        position: absolute;
	        left: 0;
	        right: 0;
	        margin: 1em;  
        }
        nav ul {
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
    .PanelMessage
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
        </div>
        <asp:Label ID="lblGreet" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Panel class="PanelMessage" runat="server" Height="100px" Width="319px">
            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
        </asp:Panel>
        <br />
        <p>
            &nbsp;</p>
    </form>
  </div>
</body>
</html>
