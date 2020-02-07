using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group5_CPRG214_Lab2
{
    public partial class LeaseSlip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetSession();
        }

        private void SetSession()
        {
            string test = Context.User.Identity.GetUserName();
            Session["UserName"] = test;
        }

        protected void gvLeaseSlips_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}