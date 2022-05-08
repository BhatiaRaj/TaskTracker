using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
public partial class Completetask : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Datetxt.Text = Convert.ToString(System.DateTime.Now.ToShortDateString());
            Timetxt.Text = Convert.ToString(System.DateTime.Now.ToShortTimeString());
            TextBox1.Text = Session["id"].ToString();
            SqlDataAdapter da = new SqlDataAdapter("select allocatedtask.ID,allocatedtask.employeeid,allocatedtask.typeofwork,allocatedtask.customerid,allocatedtask.targetdate,allocatedtask.targettime,allocatedtask.description,employee.employeename, typeofwork.typeofwork  as tow,customer.customername from allocatedtask inner join employee on allocatedtask.employeeid = employee.Id inner join typeofwork on allocatedtask.typeofwork=typeofwork.Id inner join customer on allocatedtask.customerid=customer.Id where allocatedtask.Id='" + TextBox1.Text + "'", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            TextBox3.Text = ds.Tables[0].Rows[0]["Customername"].ToString();
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Filename;
        if (Textarea.Text != "" && FileUpload1.FileName != "")
        {


            if (FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 3, 3) != "jpg" && FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 4, 4) != "jpeg" && FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 3, 3) != "gif" && FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 3, 3) != "png" && FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 3, 3) != "bmp" && FileUpload1.FileName.Substring(FileUpload1.FileName.Length - 3, 3) != "pdf")
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('Select valid file')</script>");
            }
            else
            {

                Filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("image/" + Filename));
                string img = "image/" + Filename;
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into completetask values('" + TextBox1.Text + "','" + TextBox3.Text + "','" + Datetxt.Text + "','" + Timetxt.Text + "','" + Textarea.Text + "','" + img + "')", cn);
                int i = cmd.ExecuteNonQuery();
                cn.Close();
                if (i > 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript'>alert('Data Inserted Successfully')</script>");
                  
                }
            }
        }
        else
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('Please add description and Select file')</script>");         

        }
    }
    public void clear()
    {
        TextBox1.Text = "";
        TextBox3.Text = "";
        Timetxt.Text = "";
        Datetxt.Text = "";
        Textarea.Text = "";
    }
}