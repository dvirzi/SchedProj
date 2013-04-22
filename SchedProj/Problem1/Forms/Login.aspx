<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SWE346.Module5.Problem1.Forms.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            margin-left: 80px;
        }
        .style2
        {
            margin-left: 80px;
        }
        .style3
        {
            margin-left: 80px;
        }
        .style4
        {
            margin-left: 160px;
        }
        .style5
        {
            margin-left: 240px;
        }
        .style6
        {
            margin-left: 240px;
        }
        .style7
        {
            margin-left: 240px;
        }
        .style8
        {
            margin-left: 160px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageURL="images/clip-art-meeting-466232.jpg"></asp:Image>
    </div>
    <p class="style1">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" 
            Text="Meeting Scheduling: Login"></asp:Label>
    </p>        
    <p class="style2">
        <asp:Label ID="Label2" runat="server" Text="User Name"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUserName" runat="server" Width="166px"></asp:TextBox>
        </p>
    <div class="style3">
        <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPassword" runat="server" Width="170px" TextMode="Password"></asp:TextBox>
    </div>
&nbsp;&nbsp;&nbsp;
    <div class="style4">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Enabled="False" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Visible="False">
            <asp:ListItem>UnSecure XML</asp:ListItem>
            <asp:ListItem>Secure XML</asp:ListItem>
            <asp:ListItem Selected="True">Secure SQL DB</asp:ListItem>
        </asp:RadioButtonList>
        <br />
    </div>
    <div class="style5">
    </div>
    <p class="style6">
        <asp:Button ID="btnLogin" runat="server" Font-Bold="True" 
            onclick="btnLogin_Click" Text="Login" />
    </p>
    <p class="style6">
        &nbsp;</p>
    <div class="style8">
    </div>
    <p class="style6">
        &nbsp;</p>
    <p class="style6">
        &nbsp;</p>
    <p class="style6">
        &nbsp;</p>
    <p class="style6">
        &nbsp;</p>
    <p class="style6">
        &nbsp;</p>
    <p class="style6">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
    <p class="style6" style="font-weight: bold" align="left" dir="ltr">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Test Password" 
            Visible="False"></asp:Label>
    </p>
    <p class="style6">
        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="MD5" 
            Visible="False" />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="SHA1" 
            Visible="False" />
    </p>
    <p class="style7">
        <asp:TextBox ID="TextBox1" runat="server" Width="530px" Visible="False"></asp:TextBox>
    </p>
    </form>
</body>
</html>
