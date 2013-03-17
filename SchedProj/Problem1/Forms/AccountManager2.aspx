<%@ Page Language="c#" Inherits="SWE346.Module5.Problem1.Forms.AccountManager2" Codebehind="AccountManager2.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>AccountManager</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div style="text-align: center">
            <h1>
                Account Management</h1>
            <asp:Button ID="btnCreate" runat="server" Text="Create New" OnClick="btnCreate_Click"></asp:Button>
            <asp:ListView ID="accountList" runat="server" ItemPlaceholderID="itemPlaceHolder" DataSource="<%#Accounts%>" 
                OnItemDeleting="accountList_DeleteCommand" OnItemEditing="accountList_EditCommand" 
                OnItemCommand="accountList_ItemCommand" onitemcanceling="accountList_ItemCanceling" OnItemDataBound="accountList_OnItemDataBound"
                onitemupdating="accountList_ItemUpdating">
                <LayoutTemplate>
                    <table style="width:100%;border:1">
                    <tr>
                    <td></td>
                    <td><asp:LinkButton ID="SortName" CommandName="SortName" runat="server">Name</asp:LinkButton></td>
                    <td><asp:LinkButton ID="SortBalance" CommandName="SortBalance" runat="server">Balance</asp:LinkButton></td>
                    <td>Account Type</td>
                    <td></td>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"/>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                    <td><asp:Button runat="server" Text="Select" CommandName="Edit"></asp:Button></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Balance") %></td>
                    <td><%# Eval("Type") %></td>
                    <td><asp:Button CommandName="Delete" runat="server" Text="Delete"></asp:Button></td>
                    </tr>
                </ItemTemplate>
                
                <EditItemTemplate>
                    <tr>
                    <td><asp:Button runat="server" Text="Update" CommandName="Update"/></td>
                    <td><asp:TextBox ID="nameTextBox" runat="server" Text='<%# Eval("Name") %>'/></td>
                    <td><asp:TextBox ID="balanceTextBox" runat="server" Text='<%# Eval("Balance") %>'/></td>
                    <td><asp:DropDownList ID="accountTypeList" runat="server"/></td>
                    <td><asp:Button CommandName="Cancel" runat="server" Text="Cancel"/></td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
