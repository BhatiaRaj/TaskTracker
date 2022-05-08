using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
public partial class forgot : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void forgotsubmit_Click(object sender, EventArgs e)
    {
        cn.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from employee where mobileno= '" + username.Text + "' ",cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string password = ds.Tables[0].Rows[0]["password"].ToString();
            string email = ds.Tables[0].Rows[0]["email"].ToString();
            SmtpClient mClient = new System.Net.Mail.SmtpClient();
            mClient.Port = 587;

            mClient.Host = "smtp.gmail.com";
            mClient.EnableSsl = true;
            mClient.UseDefaultCredentials = false;
            mClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            mClient.Credentials = new System.Net.NetworkCredential("Email-Id", "Password");


            System.Net.Mail.MailAddress toAddress1 = new System.Net.Mail.MailAddress(email);
            System.Net.Mail.MailAddress fromAddress1 = new System.Net.Mail.MailAddress("Email-Id");
            System.Net.Mail.MailMessage MyMail1 = new System.Net.Mail.MailMessage(fromAddress1, toAddress1);
            MyMail1.Subject = "Recover Password";


            MyMail1.Body = "Hello, Your Password is " + password ;
            MyMail1.IsBodyHtml = true;

            mClient.Send(MyMail1);
            Response.Write("<script Language='Javascript'>alert('Password has been sent to your registered mail id')</script>");
            clear();
        }
        else
        {
              Response.Write("<script Language='Javascript'>alert('Username Incorrect ')</script>");
              clear();
        }
        cn.Close();
    }
    public void clear()
    {
        
        username.Text = "";
        

    }
  
}