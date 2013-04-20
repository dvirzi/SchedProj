using System;
using SWE346.Module5.Problem1.DomainObjects;

namespace SWE346.Module5.Problem1.Forms
{
    /// <summary>
    /// Form to create accounts.
    /// </summary>
    public partial class Create : System.Web.UI.Page
    {
        protected Account Account { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Check for passed in account to work with
                if (Context.Items["Account"] != null)
                    Session["AccountInEdit"] = Context.Items["Account"];
                else
                    throw new ArgumentNullException("An Account must be passed to the Account Editor in Context.Items\"Account\"]");
            }

            Account = (Account)Session["AccountInEdit"];

            if (!IsPostBack)
                ModelToView(Account);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ViewToModel(Account);
            Server.Transfer("AccountManager.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ModelToView(Account);
        }

        protected void ViewToModel(Account account)
        {
            account.Name = txtName.Text;
            account.Balance = Convert.ToSingle(txtBalance.Text);
            account.Type = (Account.AccountType)Enum.Parse(typeof(Account.AccountType), rbtnAccountType.SelectedValue, false);
        }

        protected void ModelToView(Account account)
        {
            txtName.Text = account.Name;
            txtBalance.Text = account.Balance.ToString();
            rbtnAccountType.SelectedValue = account.Type.ToString();
        }
    }
}


