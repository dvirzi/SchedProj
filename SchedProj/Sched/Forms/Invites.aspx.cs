using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace work.SchedProj.Sched.Forms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
            }
            LabelMyInvites.Text = (string)Session["LoginUser"] + "'s New Invites";
            LabelMyReturns.Text = (string)Session["LoginUser"] + "'s Accepted / Declined";
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Action = e.CommandName;
            int InvNum = Convert.ToInt32(e.CommandArgument);
            // do something
        }

        protected void GridView2_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Action = e.CommandName;
            int InvNum = Convert.ToInt32(e.CommandArgument);
            // purge Invites table
            if (Action.Equals("Purge"))
            {
                purgeInvite(InvNum);
            }
        }

        protected void purgeInvite(int invnum)
        {
            // Delete row indexed by invnum in table Invites.
        }

        protected void AcceptInvite(int invnum)
        {
            // sets Invites.Status to Accepted for row InvNum. 
        }

        protected void DeclineInvite(int invnum)
        {
            // sets Invites.Status to Declined for row InvNum.
            // Sets Availability to True for the Room and User.
        }
    }
}