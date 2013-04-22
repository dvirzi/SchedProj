using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SWE346.Module5.Problem1.Forms
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
            LabelMyInvites.Text = (string)Session["LoginUser"] + "'s Invites";
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
    }
}