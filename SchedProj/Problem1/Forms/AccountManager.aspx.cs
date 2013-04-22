using System;
using System.Web.UI.WebControls;
using SWE346.Module5.DomainObjects;
using SWE346.Module5.Problem1.DomainObjects;
using System.Data;
using System.Data.OleDb;

namespace SWE346.Module5.Problem1.Forms
{
    /// <summary>
    /// Backing class of the Account Manager web form
    /// </summary>
    public partial class AccountManager : System.Web.UI.Page {
        //protected AccountCollection Accounts { get; set;}
        protected string loginuser;

        protected void Page_Load(object sender, System.EventArgs e) {
            // Check if login user has messages waiting.
            loginuser = (string)Session["LoginUser"];
            TextBoxLoginUser.Text = "Logged in as: " + (string)Session["LoginUser"];
            bool chkUserMsg = UserMsgWaiting(loginuser);
            if (chkUserMsg)
            {
                TextBoxMsg.Attributes["style"] = "color:red; font-weight:bold;";
                TextBoxMsg.Text = "You have unread Invites.  ";
            }
            else
            {
                TextBoxMsg.Text = "                          ";
            }
            /*Accounts = GetAccounts();
            if (Accounts == null) {
                Accounts = new MockAccounts();
                Session["Accounts"] = Accounts;
                Accounts.SortByName();
            }*/

            if(!IsPostBack)
                DataBind();
        }

        /// <summary>
        /// Event handler for the Item Command
        /// </summary>
        ///<remarks>
        /// This command is used to drive sorting
        ///</remarks>
        protected void accountList_ItemCommand(object source, ListViewCommandEventArgs e)
        {/*
            switch(e.CommandName){
                case "SortName" :
                    GetAccounts().SortByName();
                    break;
                case "SortBalance" :
                    GetAccounts().SortByBalance();
                    break;
                default  :
                    GetAccounts().SortByName(false);
                    break;
            }
            DataBind();*/
        }

        /// <summary>
        /// Event handler for the delete command
        /// </summary>
        protected void accountList_DeleteCommand(object source, ListViewDeleteEventArgs e)
        {
            //GetAccounts().RemoveAt(e.ItemIndex);
            //DataBind();
        }

        /// <summary>
        /// Event handler for the edit command
        /// </summary>
        protected void accountList_EditCommand(object source, ListViewEditEventArgs e) {
            //Context.Items["Account"] = Accounts[e.NewEditIndex];
            //Server.Transfer("AccountEditor.aspx");
        }

        /// <summary>
        /// Helper method to get the accounts collection
        /// </summary>
        /// <returns></returns>
        protected void GetAccounts(){
            //return Session["Accounts"] == null ? null : (AccountCollection) Session["Accounts"];    
        }

        protected void DropDownList_RoomName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
           // CheckBoxList1.DataBind();
        }

        protected void DropDownList_RoomName_TextChanged(object sender, System.EventArgs e)
        {
            //CheckBoxList1.DataBind();
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        protected void DropDownList_Date_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //string ss = DropDownList_Date.Text;
            //AccessDataSource3.DataBind();
            //GridView1.DataBind();
            //TextBox1.Text = DropDownList_Date.SelectedValue;
        }

        protected void DropDownList_UserName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //AccessDataSource3.DataBind();
            //DropDownList_Date.DataBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Event handler for the create button
        /// </summary>
        protected void btnCreate_Click(object sender, System.EventArgs e)
        {
            //string SelDate = (string) DropDownList_Date.SelectedItem.Text;
            if ((GridViewRoom.Rows.Count == 0) || (GridView1.Rows.Count == 0))
            {
                string gvMsg = "alert('Please choose a Room and Guest with an available open Date.');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", gvMsg, true);
                return;
            }
            int RadioChoice = RadioButtonList1.SelectedIndex;  // index -1 if no button selected
            if (RadioChoice < 0)
            {
                string rcMsg = "alert('Please choose a Time for the meeting.');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", rcMsg, true);
                return;
            }
            if (loginuser == null) loginuser = "Default User";
            string Invitee = GridView1.Rows[0].Cells[0].Text;
            string SelDate = GridView1.Rows[0].Cells[1].Text;
            string SelTime = GridView1.HeaderRow.Cells[RadioChoice + 2].Text;
            string Resource = GridViewRoom.Rows[0].Cells[0].Text;  // need to make sure room grid is populated.
            string UserAvail = GridView1.Rows[0].Cells[RadioChoice + 2].Text;
            string RoomAvail = GridViewRoom.Rows[0].Cells[RadioChoice + 2].Text;
            if ((UserAvail.Equals( "False")) || (RoomAvail.Equals( "False")))
            {
                string TmMsg = "alert('Please choose a Room and Guest with an available Time.');";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", TmMsg, true);
                return;
            }
            insertNewRequest(Invitee, loginuser, SelDate + " " + SelTime, Resource, "New");
            string msg = "Request from " + loginuser + " to " + Invitee + " to meet in " + Resource;
            msg = msg + " at " + SelTime + " on " + SelDate + ".";
            string script = "alert('" + msg + "');";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", script, true);
        } // btnCreate_Click

        protected void insertNewRequest(
              string Attendee,
              string Requestor,
              string TimeDate,
              string Resource,
              string Status)
        {
            // Add a new row to the Invites table.
            // Create a new index and populate fields with the parameters passed in.
            // Seems to figure out the data vallue for TimeDate OK by passing in my concat string.
            string mySQLDB = Server.MapPath(@"~\App_Data\Users.mdb");
            string CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mySQLDB + ";User Id=;Password=;";
            DataSet ds = new DataSet();
            using (OleDbConnection oConnection = new OleDbConnection(CONNECTION_STRING))
            {
                OleDbDataAdapter oDataAdapter = new OleDbDataAdapter
                    ("Select Max(InvNum) as CurInvite from Invites", oConnection);
                OleDbCommandBuilder oCommandBuilder =
                    new OleDbCommandBuilder(oDataAdapter);
                oCommandBuilder.QuotePrefix = "[";
                oCommandBuilder.QuoteSuffix = "]";
                string CurInvite;
                int newIndex;
                try
                {
                    // First get the current index, or zero if no rows.
                    oConnection.Open();
                    oDataAdapter.Fill(ds, "Invites");
                    //if (ds.Tables["Invites"].Rows.Count > 0) {
                    DataRow row = ds.Tables["Invites"].Rows[0];
                    CurInvite = row.ItemArray[0].ToString();
                    Int32.TryParse(CurInvite, out newIndex);

                    // Create new row with next index number and passed in data.
                    newIndex = newIndex + 1;
                    string insquery = @"INSERT INTO Invites (InvNum, Attendee, Requestor, TimeDate, Resource, Status)" +
                        " VALUES ('" + newIndex + "', '" + Attendee + "', '" + Requestor + "', '" + TimeDate +
                            "', '" + Resource + "', '" + Status + "');";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = insquery;
                    cmd.Connection = oConnection;
                    cmd.ExecuteNonQuery();

                    // Notify Invitee of request by setting the NewMsgFlag field in UserInfo.
                    setNewMsgFlag (Attendee, true);
                    /*string updquery = @"UPDATE [UserInfo] SET [NewMsgFlag] = True WHERE UserName = '" +
                        Attendee + "';";
                    cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = updquery;
                    cmd.Connection = oConnection;
                    cmd.ExecuteNonQuery();*/


                }
                catch (OleDbException e)
                {
                    Response.Write(e.ToString());
                }
                finally
                {
                    oConnection.Close();
                }
            } // end using clause
        } // End InsertNewRequest

        protected void setNewMsgFlag(
              string User,
              bool Status)
        {
            // Add a new row to the Invites table.
            // Create a new index and populate fields with the parameters passed in.
            // Seems to figure out the data vallue for TimeDate OK by passing in my concat string.
            string mySQLDB = Server.MapPath(@"~\App_Data\Users.mdb");
            string CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mySQLDB + ";User Id=;Password=;";
            DataSet ds = new DataSet();
            using (OleDbConnection oConnection = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    // First get the current index, or zero if no rows.
                    oConnection.Open();

                    // Notify Invitee of request / cancel message by setting the NewMsgFlag field in UserInfo.
                    string updquery = @"UPDATE [UserInfo] SET [NewMsgFlag] = " + Status + " WHERE UserName = '" +
                        User + "';";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = updquery;
                    cmd.Connection = oConnection;
                    cmd.ExecuteNonQuery();
                }
                catch (OleDbException e)
                {
                    Response.Write(e.ToString());
                }
                finally
                {
                    oConnection.Close();
                }
            } // end using clause
        } // End setNewMsgFlag

        protected bool UserMsgWaiting(string user)
        {
            // Query table UserInfo for NewMsgFlag for a given UserName
            // Return True/False
            //if (user == null) return false;
            string mySQLDB = Server.MapPath(@"~\App_Data\Users.mdb");
            String CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mySQLDB + ";User Id=;Password=;";
            DataSet ds = new DataSet();
            using (OleDbConnection oConnection = new OleDbConnection(CONNECTION_STRING))
            {
                OleDbDataAdapter oDataAdapter = new OleDbDataAdapter
                    ("Select [UserName], [NewMsgFlag] from UserInfo where username='" + user + "'", oConnection);
                OleDbCommandBuilder oCommandBuilder =
                    new OleDbCommandBuilder(oDataAdapter);
                oCommandBuilder.QuotePrefix = "[";
                oCommandBuilder.QuoteSuffix = "]";
                try
                {
                    oConnection.Open();
                    oDataAdapter.Fill(ds, "UserInfo");
                    if (ds.Tables["UserInfo"].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables["UserInfo"].Rows[0];
                        if (row.ItemArray[0].ToString().Equals(user) &&
                        ((bool)row.ItemArray[1] == true))
                            return true;
                    }
                }
                catch (OleDbException e)
                {
                    Response.Write(e.ToString());
                }
                finally
                {
                    oConnection.Close();
                }
                return false;
            } // end using clause
        } // End UserMsgWaiting

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Server.Execute("Login.aspx");
        }

        protected void ButtonMyInvites_Click(object sender, EventArgs e)
        {
            // for now just reset the new message flag in UserInfo
            setNewMsgFlag(loginuser, false);
            //Server.Execute("Invites.aspx");
            Server.Transfer("Invites.aspx");
        }
    }  // end class AccountManager
}


