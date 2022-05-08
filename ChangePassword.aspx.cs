using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class ChangePassword : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Text = Convert.ToString(Session["Emp"]);
        Label4.Text = Convert.ToString(Session["CustomerEmail"]);
        Label5.Text = Convert.ToString(Session["Admin"]);
    }
    protected void changepasswordsubmit_Click(object sender, EventArgs e)
    {
        cn.Open();
        if (newpassword.Text==conformpassword.Text)
        {
            SqlCommand cmd = new SqlCommand("update employee set password='"+newpassword.Text+"' where mobileno='"+Label3.Text+"'",cn);
            int i = cmd.ExecuteNonQuery();
            if(i>0)
            {
                Response.Write("<script Language='Javascript'>alert('Password Changed')</script>");
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("update customer set customerpassword='" + newpassword.Text + "' where customeremail='" + Label4.Text + "'", cn);
                int i1 = cmd1.ExecuteNonQuery();
                if (i1 > 0)
                {
                    Response.Write("<script Language='Javascript'>alert('Password Changed')</script>");
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("update adminlogin set password='" + newpassword.Text + "'", cn);
                    int i2 = cmd2.ExecuteNonQuery();
                    if (i2 > 0)
                    {
                        Response.Write("<script Language='Javascript'>alert('Password Changed')</script>");
                    }
                }
            }
        }
        else
        {
            Response.Write("<script Language='Javascript'>alert('Password doesnot match')</script>"); 
        }
        cn.Close();
    }
}