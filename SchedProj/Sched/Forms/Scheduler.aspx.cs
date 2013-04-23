using System;
using System.Web.UI.WebControls;
//using SWE346.Module5.DomainObjects;
using SWE346.Module5.Problem1.DomainObjects;
using System.Data;
using System.Data.OleDb;

namespace work.SchedProj.Sched.Forms
{
    /// <summary>
    /// Backing class of the Scheduler web form
    /// </summary>
    public partial class Scheduler : System.Web.UI.Page {
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
        /// Event handler for the Invite button
        /// </summary>
        protected void btnInvite_Click(object sender, System.EventArgs e)
        {
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
            string Comments = TextBoxComments.Text;
            insertNewRequest(Invitee, loginuser, SelDate + " " + SelTime, Resource, "New", Comments);
            reserveRoom(Resource, SelDate + " " + SelTime, false);
            reserveUser(loginuser, SelDate + " " + SelTime, false);
            string msg = "Request from " + loginuser + " to " + Invitee + " to meet in " + Resource;
            msg = msg + " at " + SelTime + " on " + SelDate + ".";
            string script = "alert('" + msg + "');";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", script, true);
        } // btnInvite_Click

        protected void reserveRoom(string resource, string datetime, bool newval)
        {
            // RoomAvail.Room, AvailDate, Rnn field set to newval (True if available, False if reserved).
        }

        protected void reserveUser(string user, string datetime, bool newval)
        {
            // UserAvail.User_, AvailDate_, Ann field set to newval (True if available, False if reserved).
        }

        protected void insertNewRequest(
            string Attendee,
            string Requestor,
            string TimeDate,
            string Resource,
            string Status,
            string Comments)
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
                    string insquery = @"INSERT INTO Invites (InvNum, Attendee, Requestor, TimeDate, Resource, Status, Comments)" +
                        " VALUES ('" + newIndex + "', '" + Attendee + "', '" + Requestor + "', '" + TimeDate +
                            "', '" + Resource + "', '" + Status + "', '" + Comments + "');";
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


