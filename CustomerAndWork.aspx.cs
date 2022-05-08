using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
public partial class CustomerAndWork : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
    static int editid = 0;
    String custid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            date1.Text= Convert.ToString(System.DateTime.Now.ToShortDateString());
           
            getwork();
            //data();
            date1.Text = System.DateTime.UtcNow.ToShortDateString();
            customername.Text = Session["CustomerName"].ToString();
            custid = Session["CustomerId"].ToString();
        }
    }
    protected void custandworksubmit_Click(object sender, EventArgs e)
    {
        string Filename;
        if (editid == 0)
        {
            if (FileUpload1.FileName != "")
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
                    custid = Session["CustomerId"].ToString();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("insert into customerandwork values('" + custid + "','" + date1.Text + "','" + Calendar1.SelectedDate.ToShortDateString() + "','" + mobno.Text + "','" + ddlwork.SelectedValue + "','" + img + "','Pending')", cn);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Write("<script LANGUAGE='JavaScript'>alert('Inserted Successfully')</script>");
                    }
                    cn.Close();
                    clear();
                    //data();
                }
            }
            else
            {
                string img = "";
                custid = Session["CustomerId"].ToString();
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into customerandwork values('" + custid + "','" + date1.Text + "','" + Calendar1.SelectedDate.ToShortDateString() + "','" + mobno.Text + "','" + ddlwork.SelectedValue + "','" + img + "','Pending')", cn);
                
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript'>alert('Inserted Successfully')</script>");
                }
                cn.Close();
                clear();
                //data();
               
            }
        }
        else
        {

        }
    }
    //public void data()
    //{
    //    cn.Open();
    //    custid = Session["CustomerId"].ToString();
    //    SqlDataAdapter da = new SqlDataAdapter("select customerandwork.Id,customerandwork.date,customerandwork.target,customerandwork.description,customerandwork.work,customerandwork.status,typeofwork.typeofwork from customerandwork inner join typeofwork on customerandwork.work=typeofwork.Id where customerandwork.customerid='" + custid + "'", cn);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        GridView1.DataSource = ds;
    //        GridView1.DataBind();
    //    }
    //    cn.Close();
    //}
  
    public void getwork()
    {
        cn.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from  typeofwork", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlwork.DataSource = ds;
        ddlwork.DataTextField = ds.Tables[0].Columns["typeofwork"].ToString();
        ddlwork.DataValueField = ds.Tables[0].Columns["Id"].ToString();
        ddlwork.DataBind();
        cn.Close();
    }
    public void clear()
    {
        custid = "";
        date1.Text = "";
        mobno.Text = ""; 
        ddlwork.SelectedIndex = 0; 
        
    }
}