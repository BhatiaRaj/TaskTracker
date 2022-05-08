using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Demo : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Admin"]) != "")
            Label1.Text = Session["Admin"].ToString();
        else if (Convert.ToString(Session["Empname"]) != "")
            Label1.Text = Session["Empname"].ToString();
        else
            Label1.Text = Session["CustomerName"].ToString();

        getallocatedtask();
        getdesignation();
        getdepartment();
        gettypeofwork();
        getcustomer();
        getcompletetask();
        getemployee();
    }
    public void getemployee()
    {
        SqlDataAdapter da = new SqlDataAdapter("select count(Id) from employee",cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Label2.Text = ds.Tables[0].Rows[0][0].ToString();
    }
    public void getallocatedtask()
    {
        SqlDataAdapter da = new SqlDataAdapter("select count(Id) from allocatedtask", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Label3.Text = ds.Tables[0].Rows[0][0].ToString();
    }
    
    public void getcustomer()
    {
        SqlDataAdapter da = new SqlDataAdapter("select count(Id) from customer", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Label4.Text = ds.Tables[0].Rows[0][0].ToString();
    }
    public void getcompletetask()
    {
        SqlDataAdapter da = new SqlDataAdapter("select count(Id) from completetask", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Label005.Text = ds.Tables[0].Rows[0][0].ToString();
    }
    public void getdepartment()
    {
        SqlDataAdapter da = new SqlDataAdapter("select count(Id) from department", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Label6.Text = ds.Tables[0].Rows[0][0].ToString();
    }
    public void getdesignation()
    {
        SqlDataAdapter da = new SqlDataAdapter("select count(Id) from designation", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Label7.Text = ds.Tables[0].Rows[0][0].ToString();
    }
    public void gettypeofwork()
    {
        SqlDataAdapter da = new SqlDataAdapter("select count(Id) from typeofwork", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Label8.Text = ds.Tables[0].Rows[0][0].ToString();
    }
}