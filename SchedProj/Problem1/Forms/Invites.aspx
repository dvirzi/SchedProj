<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invites.aspx.cs" Inherits="SWE346.Module5.Problem1.Forms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelMyInvites" runat="server" Text="My Invites" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Back" />
        <br />
        <br />
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource_Invites" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="Requestor" HeaderText="Requestor" SortExpression="Requestor" />
                <asp:BoundField DataField="TimeDate" HeaderText="TimeDate" SortExpression="TimeDate" />
                <asp:BoundField DataField="Resource" HeaderText="Resource" SortExpression="Resource" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>
    
        <asp:AccessDataSource ID="AccessDataSource_Invites" runat="server"
             DataFile="~\App_Data\users.mdb"
                SelectCommand="SELECT [Requestor], [TimeDate], [Resource], [Status] FROM [Invites] WHERE ([Attendee] = ?)">
            <SelectParameters>
                <asp:SessionParameter Name="Attendee" SessionField="LoginUser" Type="String" />
            </SelectParameters>
        </asp:AccessDataSource>
    </form>
</body>
</html>
