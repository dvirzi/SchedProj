using System.Web.UI.WebControls;
using SWE346.Module5.DomainObjects;
using SWE346.Module5.Problem1.DomainObjects;

namespace SWE346.Module5.Problem1.Forms
{
    /// <summary>
    /// Backing class of the Account Manager web form
    /// </summary>
    public partial class AccountManager : System.Web.UI.Page {
        protected AccountCollection Accounts { get; set;}

        protected void Page_Load(object sender, System.EventArgs e) {
            TextBoxLoginUser.Text = "Logged in as: " + (string)Session["LoginUser"];
            Accounts = GetAccounts();
            if (Accounts == null) {
                Accounts = new MockAccounts();
                Session["Accounts"] = Accounts;
                Accounts.SortByName();
            }

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
        {
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
            DataBind();
        }

        /// <summary>
        /// Event handler for the delete command
        /// </summary>
        protected void accountList_DeleteCommand(object source, ListViewDeleteEventArgs e)
        {
            GetAccounts().RemoveAt(e.ItemIndex);
            DataBind();
        }

        /// <summary>
        /// Event handler for the edit command
        /// </summary>
        protected void accountList_EditCommand(object source, ListViewEditEventArgs e) {
            Context.Items["Account"] = Accounts[e.NewEditIndex];
            Server.Transfer("AccountEditor.aspx");
        }

        /// <summary>
        /// Helper method to get the accounts collection
        /// </summary>
        /// <returns></returns>
        protected AccountCollection GetAccounts(){
            return Session["Accounts"] == null ? null : (AccountCollection) Session["Accounts"];    
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
            string loginuser = (string)Session["LoginUser"];
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
            //string Session["LoginUser"]
            //CheckBoxList1.DataBind();
            /*GetAccounts().Add(new Account());
            Context.Items["Account"] = Accounts[GetAccounts().Count - 1];
            Server.Transfer("AccountEditor.aspx");  */
            string msg = "Request from " + loginuser + " to " + Invitee + " to meet in " + Resource;
            msg = msg + " at " + SelTime + " on " + SelDate + ".";
            string script = "alert('" + msg + "');";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", script, true);
        }

    }
}


