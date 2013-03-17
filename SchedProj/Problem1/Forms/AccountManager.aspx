<%@ Page Language="c#" Inherits="SWE346.Module5.Problem1.Forms.AccountManager" Codebehind="AccountManager.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>AccountManager</title>
    </head>
<body>
    <p align="center" style="font-size: x-large; color: #0000FF; font-weight: bold;">
        Schedule an Appointment<br />
    </p>
    <form id="Form1" method="post" runat="server">
      <div style="text-align: center">
          <p style="font-size: medium; font-weight: bold;">
               Choose Attendee&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server"
                 DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserName"
                 style=" 45px">
            </asp:DropDownList>
          </p>
            <p style="font-size: medium; font-weight: bold;">
                Choose A Room / Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="AccessDataSource1" DataTextField="RoomName" DataValueField="RoomName" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" OnTextChanged="DropDownList2_TextChanged">
                </asp:DropDownList>
                <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="C:\Users\Dave\Documents\SDEV-435\SchedProj\Problem1\Users.mdb" SelectCommand="SELECT [RoomName] FROM [Rooms]"></asp:AccessDataSource>
            </p>
            <p style="font-size: medium">
                Day&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" BorderStyle="None">3/10/2013</asp:TextBox>
            </p>
        </div>
        <div style="text-align: center">
        <p style="font-size: 10.5px; font-family: 'Courier New', Courier, monospace;">
            Time: 8 &nbsp;9&nbsp;10&nbsp;11&nbsp;12&nbsp;1 &nbsp;2 &nbsp;3 &nbsp;4 &nbsp;5 PM</p>
        </div>
        <div style="text-align: center">
            <p style="font-size: medium; height: 43px; margin-top: -10px; font-family: 'Courier New', Courier, monospace;">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="AccessDataSource2" DataTextField="AvailArray" DataValueField="AvailDate" RepeatDirection="Horizontal" Font-Names="Courier New" Font-Size="XX-Large" RepeatColumns="10" RepeatLayout="Flow" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                </asp:CheckBoxList>
                <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="C:\Users\Dave\Documents\SDEV-435\SchedProj\Problem1\users.mdb" SelectCommand="SELECT [AvailArray], [AvailDate] FROM [RoomAvail] WHERE (([AvailDate] = ?) AND ([Room] = ?))">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="3/10/2013" Name="AvailDate" Type="DateTime" />
                        <asp:ControlParameter ControlID="DropDownList2" Name="Room" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:AccessDataSource>
            </p>
        </div>
        <div style="text-align: center">
            <p style="font-size: medium">
                &nbsp;</p>
            <p>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UsersConnectionString %>" ProviderName="<%$ ConnectionStrings:UsersConnectionString.ProviderName %>" SelectCommand="SELECT [UserName] FROM [UserInfo]"></asp:SqlDataSource>
            </p>
            <asp:Button ID="btnCreate" runat="server" Text="Confirm" OnClick="btnCreate_Click"></asp:Button>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
