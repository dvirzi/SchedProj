namespace work.SchedProj.Sched
{
    /// <summary>
    /// Summary description for _Default.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //Response.Redirect("Forms/AccountManager.aspx");
            Response.Redirect("Forms/Scheduler.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}


