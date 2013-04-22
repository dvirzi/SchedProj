using System;
using System.Web.UI.WebControls;
using SWE346.Module5.DomainObjects;
using SWE346.Module5.Problem1.DomainObjects;

namespace SWE346.Module5.Problem1.Forms
{
    /// <summary>
    /// Backing class of the Account Manager web form
    /// </summary>
    public partial class AccountManager2 : System.Web.UI.Page {
        protected AccountCollection Accounts { get; set;}

        protected void Page_Load(object sender, EventArgs e) {
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
                    DataBind();
                    break;
                case "SortBalance" :
                    GetAccounts().SortByBalance();
                    DataBind();
                    break;
                default  :
                    GetAccounts().SortByName(false);
                    //DataBind();
                    break;
            }
            //DataBind();
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
        /// Event handler for the create button
        /// </summary>
        protected void btnCreate_Click(object sender, EventArgs e) {
            Accounts.Add(new Account());
            accountList.EditIndex = GetAccounts().Count - 1;
            DataBind();
        }

        /// <summary>
        /// Event handler for the edit command
        /// </summary>
        protected void accountList_EditCommand(object source, ListViewEditEventArgs e) {
            accountList.EditIndex = e.NewEditIndex;
            DataBind();
        }

        /// <summary>
        /// Helper method to get the accounts collection
        /// </summary>
        /// <returns></returns>
        protected AccountCollection GetAccounts(){
            return Session["Accounts"] == null ? null : (AccountCollection) Session["Accounts"];    
        }

        protected void accountList_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            accountList.EditIndex = -1;
            DataBind();
        }

        protected void accountList_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            string name = ((TextBox) accountList.EditItem.FindControl("nameTextBox")).Text;
            string balance = ((TextBox) accountList.EditItem.FindControl("balanceTextBox")).Text;
            Account.AccountType type = (Account.AccountType) int.Parse(((DropDownList) accountList.EditItem.FindControl("accountTypeList")).SelectedValue);

            Account account = Accounts[e.ItemIndex];
            account.Name = name;
            float convertedBalance;
            if(float.TryParse(balance, out convertedBalance))
                account.Balance = convertedBalance;
            account.Type = type;

            accountList.EditIndex = -1;
            DataBind();
        }

        protected void accountList_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            // This stmt is used to execute the code only in case of edit 
            if (((ListView)(sender)).EditIndex != -1 && ((ListViewDataItem)(e.Item)).DisplayIndex == ((ListView)(sender)).EditIndex)
            {
                DropDownList list = (DropDownList)e.Item.FindControl("accountTypeList");
                list.Items.Add(new ListItem("Checking", ((int)Account.AccountType.Checking).ToString()));
                list.Items.Add(new ListItem("Savings", ((int)Account.AccountType.Savings).ToString()));
                list.Items.Add(new ListItem("Money Market", ((int)Account.AccountType.MoneyMarket).ToString()));
                list.SelectedValue = ((int) ((Account) ((ListViewDataItem) e.Item).DataItem).Type).ToString();
            }
        }
    }
}


