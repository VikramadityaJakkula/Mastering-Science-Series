﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
     protected void Page_Load(object sender, EventArgs e)
    {
        /* if(Request.Cookies["ExamIdTemp"]!=null)
         {
             if(Request.Cookies["ExamIdTemp"].Value!="fdec440f-5296-46b3-8e82-c793faf1a205")
                Response.Cookies["ExamIdTemp"].Value="fdec440f-5296-46b3-8e82-c793faf1a205";
         }
         else
             Response.Redirect("EnableCookie.aspx");
         */
    }
}
