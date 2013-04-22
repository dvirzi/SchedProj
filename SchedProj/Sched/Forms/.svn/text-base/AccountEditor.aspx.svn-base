<%@ Page Language="c#" Inherits="SWE346.Module5.Problem1.Forms.Create" Codebehind="AccountEditor.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Account Editor</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
       <div style="width:100%"> 
       <h1>Account Creation</h1>
        <table >
        <tr>
            <td><asp:Label ID="lnlName" runat="server">Name:</asp:Label></td>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
       </tr>
       <tr>
            <td><asp:Label ID="lnlBalance" runat="server">Opening Balance</asp:Label></td>
            <td><asp:TextBox ID="txtBalance" runat="server"></asp:TextBox></td>
       </tr>
       <tr>
            <td><asp:Label ID="lblAccountType" runat="server">Account Type</asp:Label></td>
            <td style="text-align:left">  
                <asp:RadioButtonList ID="rbtnAccountType" runat="server" >
                    <asp:ListItem Value="Checking" Selected="True">Checking</asp:ListItem>
                    <asp:ListItem Value="Savings">Savings</asp:ListItem>
                    <asp:ListItem Value="MoneyMarket">Money Market</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>       
       <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btnCancel" runat="server" Text="Reset" OnClick="btnReset_Click"></asp:Button>
                <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click"></asp:Button> 
            </td>
        </tr>
       </table>     
       </div> 
    </form>
</body>
</html>
