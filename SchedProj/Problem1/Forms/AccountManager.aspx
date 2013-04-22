<%@ Page Language="c#" Inherits="SWE346.Module5.Problem1.Forms.AccountManager" Codebehind="AccountManager.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>AccountManager</title>
    </head>
<body>
    <form id="Form1" method="post" runat="server">
        <p align="center" style="font-size: x-large; color: #0000FF; font-weight: bold;">
            Schedule a Meeting<br />
        </p>
        <p align="center" style="font-size: x-large; color: #0000FF; font-weight: bold; margin-left: 40px;">
            <asp:TextBox ID="TextBoxLoginUser" runat="server" BorderStyle="None" Font-Size="Large" style="font-weight:bold;"
                 Font-Name="Times New Roman" Font-Names="Times New Roman" Width="182px" ReadOnly="True"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonLogout_Click" />
        </p>
            <p align="center" style="font-size: x-large; color: #0000FF; font-weight: bold; margin-left: 40px;">
                <asp:TextBox ID="TextBoxMsg" runat="server" BorderStyle="None" Font-Names="Times New Roman" Font-Size="Large" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="ButtonMyInvites" runat="server" Text="My Invites" OnClick="ButtonMyInvites_Click" />
        </p>
      <div style="text-align: center">
          <p style="font-size: medium; font-weight: bold;">
               Choose Attendee&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList_UserName" runat="server"
                 DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField=""
                 style=" 45px" OnSelectedIndexChanged="DropDownList_UserName_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
          </p>
            <p style="font-size: medium; font-weight: bold;">
                Choose A Room&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList_RoomName"
                     runat="server" DataSourceID="AccessDataSource1"
                     DataTextField="RoomName" DataValueField="RoomName" AutoPostBack="True"
                     OnSelectedIndexChanged="DropDownList_RoomName_SelectedIndexChanged"
                     OnTextChanged="DropDownList_RoomName_TextChanged">
                </asp:DropDownList>
            </p>
            <p style="font-size: medium; font-weight: bold;">
                Choose a Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:DropDownList ID="DropDownList_Date" runat="server" DataSourceID="AccessDataSource_UAvailDate"
                     AutoPostBack="True" DataTextField="DateAvail" DataValueField="AvailDate_"
                     OnSelectedIndexChanged="DropDownList_Date_SelectedIndexChanged">
                </asp:DropDownList>
            </p>
            <asp:Button ID="Button1" runat="server" Text="Send Invite" OnClick="btnCreate_Click"></asp:Button>
        </div>
        <div style="text-align: center">
            <p style="font-size: medium; height: 43px; margin-top: -10px;
                 font-family: 'Courier New', Courier, monospace;">
                <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" 
                    HorizontalAlign="Center"
                    cellpadding="6"
                    cellspacing="5"
                    Width="1050px"
                    emptydatatext="          There is no availability for the Attendee on the Date selected.      "
                    DataKeyNames="User_,DateAvail"
                    DataSourceID="AccessDataSource3" EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="User_" 
                            HeaderText="" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="User_" />
                        <asp:BoundField DataField="DateAvail" 
                            HeaderText="" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="DateAvail" />
                        <asp:BoundField DataField="A08" 
                            ItemStyle-Width="100px"
                            HeaderText="8 AM" ReadOnly="True"
                            SortExpression="A08" />
                        <asp:BoundField DataField="A09" 
                            ItemStyle-Width="100px"
                            HeaderText="9 AM" ReadOnly="True"
                            SortExpression="A09" />
                        <asp:BoundField DataField="A10" 
                            HeaderText="10 AM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="A10" />
                        <asp:BoundField DataField="A11" 
                            HeaderText="11 AM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="A11" />
                        <asp:BoundField DataField="A12" 
                            HeaderText="12 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="A12" />
                        <asp:BoundField DataField="A13" 
                            HeaderText="1 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="A13" />
                        <asp:BoundField DataField="A14" 
                            HeaderText="2 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="A14" />
                        <asp:BoundField DataField="A15" 
                            HeaderText="3 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="A15" />
                        <asp:BoundField DataField="A16" 
                            HeaderText="4 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="A16" />
                        <asp:BoundField DataField="A17" 
                            HeaderText="5 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="A15" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridViewRoom" runat="server" 
                    AutoGenerateColumns="False" 
                    HorizontalAlign="Center"
                    cellpadding="6"
                    cellspacing="5"
                    Width="1050px"
                    ShowHeader="false"
                    emptydatatext="          There is no availability for the Room on the Date selected.      "
                    DataKeyNames="AvailDate,Room"
                    DataSourceID="AccessDataSource2" EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="Room" 
                            HeaderText="" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="Room" />
                        <asp:BoundField DataField="DateAvail1" 
                            HeaderText="" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="AvailDate" />
                        <asp:BoundField DataField="R08" 
                            HeaderText="8 AM" ReadOnly="True"                            
                            ItemStyle-Width="100px"
                            SortExpression="R08" />
                        <asp:BoundField DataField="R09" 
                            HeaderText="9 AM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="R09" />
                        <asp:BoundField DataField="R10" 
                            HeaderText="10 AM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="R10" />
                        <asp:BoundField DataField="R11" 
                            HeaderText="11 AM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="R11" />
                        <asp:BoundField DataField="R12" 
                            HeaderText="12 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="R12" />
                        <asp:BoundField DataField="R13" 
                            HeaderText="1 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="R13" />
                        <asp:BoundField DataField="R14" 
                            HeaderText="2 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="R14" />
                        <asp:BoundField DataField="R15" 
                            HeaderText="3 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="R15" />
                        <asp:BoundField DataField="R16" 
                            HeaderText="4 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="R16" />
                        <asp:BoundField DataField="R17" 
                            HeaderText="5 PM" ReadOnly="True"
                            ItemStyle-Width="100px"
                            SortExpression="R15" />
                    </Columns>
                </asp:GridView>
        </div>
        <div style="text-align: center; vertical-align: bottom">                
            <asp:Label runat="server" ID="lbl"
                Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Choose A Time:&nbsp;&nbsp;&nbsp;" />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatLayout="Flow" align="center"
                RepeatDirection="Horizontal" CellSpacing="80" Height="6px" Width="863px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="08"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="09"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="10"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="11"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="12"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="13"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="14"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="15"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="16"></asp:ListItem>
                <asp:ListItem Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="17"></asp:ListItem>
            </asp:RadioButtonList>
            </p>
        </div>
        <div style="text-align: center">
            <p style="font-size: medium">
                &nbsp;</p>
            <p>
                &nbsp;</p>
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
            <br />
            <asp:Button ID="btnCreate" runat="server" Text="Confirm" OnClick="btnCreate_Click"></asp:Button>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                    SelectCommand="SELECT UserName FROM UserInfo WHERE (UserName &lt;&gt; LoginUser)">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="Dave" Name="LoginUser" SessionField="LoginUser" />
                </SelectParameters>
        </asp:SqlDataSource>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server"
                    DataFile="~\App_Data\users.mdb" SelectCommand="SELECT [RoomName] FROM [Rooms]"></asp:AccessDataSource>
            <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~\App_Data\users.mdb"
                    SelectCommand="SELECT Room, AvailDate, R08, R09, R10, R11, R12, R13, R14, R15, R16, R17, Format(AvailDate, 'dd-mmm-yyyy') AS DateAvail1 FROM RoomAvail WHERE (Room = RoomChosen) AND (AvailDate = CDate(DateChosen))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList_RoomName" DefaultValue="" Name="RoomChosen" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="DropDownList_Date" DefaultValue="4-18-13" Name="DateChosen" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:AccessDataSource>
            <asp:AccessDataSource ID="AccessDataSource3" runat="server" DataFile="~\App_Data\users.mdb"
                 SelectCommand="SELECT User_, AvailDate_, A08, A09, A10, A11, A12, A13, A14, A15, A16, A17, Format(AvailDate_, 'dd-mmm-yyyy') AS DateAvail FROM UserAvail WHERE (User_ = UName) AND (AvailDate_ = CDate(SearchDate))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList_UserName" Name="UName" PropertyName="SelectedValue" DefaultValue="" />
                    <asp:ControlParameter ControlID="DropDownList_Date" DefaultValue="" Name="SearchDate" PropertyName="SelectedValue" />
               </SelectParameters>
            </asp:AccessDataSource>
            <asp:AccessDataSource ID="AccessDataSource_UAvailDate" runat="server" DataFile="~\App_Data\users.mdb"
                 SelectCommand="SELECT User_, AvailDate_, Format(AvailDate_, 'dd-mmm-yyyy') AS DateAvail FROM UserAvail WHERE (User_ = UName)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList_UserName" Name="UName" PropertyName="SelectedValue" DefaultValue="user6" />
               </SelectParameters>
            </asp:AccessDataSource>
        

    </form>
</body>
</html>
