using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADMIN_Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            //UDT = UAdapter.SELECT();
            //drpemail.DataSource = UDT;
            drpemail.DataTextField = "email";
            drpemail.DataValueField = "uid";
            drpemail.DataBind();
            drpemail.Items.Insert(0, "SELECT");
        }
        lbl.Text = "";
    }
    protected void btnselect_Click(object sender, EventArgs e)
    {
        if (drpemail.SelectedIndex == 0)
        {
            lbl.Text = "Select Email";
        }
        else
        {
           
          //  PDT = PAdapter.Select_By_PID(Convert.ToInt32( drpemail.SelectedValue));
            //PDT = PAdapter.Select_B_EMAIL(drpemail.SelectedItem.Text);
            
            //gvgrid.DataSource = PDT;
            gvgrid.DataBind();

            
            lbl.Text = "Total Record = " + gvgrid.Rows.Count.ToString();
        }
    }
    protected void gvgrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}