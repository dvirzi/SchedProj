<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invites.aspx.cs" Inherits="work.SchedProj.Sched.Forms.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image2" runat="server" ImageURL="~/Forms/images/clip-art-meeting-999827.jpg"></asp:Image>
    </div>
    <div>
        <br />
        <asp:Label ID="LabelMyInvites" runat="server" Text="My Invites" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="Back" />
        <br />
        <br />
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource_Invites"
             EnableModelValidation="True" OnRowCommand="GridView1_OnRowCommand" >
            <Columns>
                <asp:BoundField DataField="InvNum" HeaderText="InvNum" SortExpression="InvNum" />
                <asp:BoundField DataField="Requestor" HeaderText="Requestor" SortExpression="Requestor" />
                <asp:BoundField DataField="TimeDate" HeaderText="TimeDate" SortExpression="TimeDate" />
                <asp:BoundField DataField="Resource" HeaderText="Resource" SortExpression="Resource" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonAccept" runat="server" CausesValidation="false" CommandName="Accept"
                            Text="Accept" CommandArgument='<%# Eval("InvNum") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonDecline" runat="server" CausesValidation="false" CommandName="Decline"
                            Text="Decline" CommandArgument='<%# Eval("InvNum") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    <div>
        <br />
        <br />
        <br />
        <asp:Label ID="LabelMyReturns" runat="server" Text="View Accepted / Declined" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonBack2" runat="server" OnClick="ButtonBack_Click" Text="Back" />
        <br />
        <br />
    </div>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSourceReturn"
             EnableModelValidation="True" OnRowCommand="GridView2_OnRowCommand" >
            <Columns>
                <asp:BoundField DataField="InvNum" HeaderText="InvNum" SortExpression="InvNum" />
                <asp:BoundField DataField="Attendee" HeaderText="Attendee" SortExpression="Attendee" />
                <asp:BoundField DataField="TimeDate" HeaderText="TimeDate" SortExpression="TimeDate" />
                <asp:BoundField DataField="Resource" HeaderText="Resource" SortExpression="Resource" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="ButtonPurge" runat="server" CausesValidation="false" CommandName="Purge"
                            Text="Purge" CommandArgument='<%# Eval("InvNum") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
        <asp:AccessDataSource ID="AccessDataSource_Invites" runat="server"
             DataFile="~\App_Data\users.mdb"
                SelectCommand="SELECT [InvNum], [Requestor], [TimeDate], [Resource], [Status], [Comments] FROM [Invites] WHERE (Status = 'New') AND ([Attendee] = ?)">
            <SelectParameters>
                <asp:SessionParameter Name="Attendee" SessionField="LoginUser" Type="String" />
            </SelectParameters>
        </asp:AccessDataSource>

        <asp:AccessDataSource ID="AccessDataSourceReturn" runat="server"
             DataFile="~\App_Data\users.mdb"
                SelectCommand="SELECT [InvNum], [Attendee], [TimeDate], [Resource], [Status], [Comments] FROM [Invites] WHERE ((Status = 'Accepted') Or  (Status = 'Declined')) AND ([Requestor] = ?)">
            <SelectParameters>
                <asp:SessionParameter Name="Requestor" SessionField="LoginUser" Type="String" />
            </SelectParameters>
        </asp:AccessDataSource>
    </form>
</body>
</html>
