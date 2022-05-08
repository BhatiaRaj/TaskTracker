using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Department : System.Web.UI.Page
{

    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
    static int editid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        data();
    }
    protected void departmentsubmit_Click(object sender, EventArgs e)
    {

        if (editid == 0)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("if not exists(select * from department where departmentname='"+ dprname.Text +"') insert into department values('" + dprname.Text + "')", cn);
            int i = cmd.ExecuteNonQuery();
            if(i>0)
            {
                Response.Write("<script Language='Javascript'>alert('Insert')</script>");
            }
            else
            {
                Response.Write("<script Language='Javascript'>alert('Already Exists')</script>");
            }
            cn.Close();
            clear();
            data();
        }
        else
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("if not exists(select * from department where departmentname='" + dprname.Text + "' and Id!="+ editid +") update department set departmentname='" + dprname.Text + "' where Id = " + editid + "", cn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                //update message
                Response.Write("<script Language='Javascript'>alert('Update Successfully')</script>");
            }
            else
            {
                //already exists
                Response.Write("<script Language='Javascript'>alert('Already Exists')</script>");
            }
            cn.Close();
            clear();
            editid = 0;
            data();
        }
    }
    
    public void data()
    {
        cn.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from department", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        cn.Close();
    }

    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        cn.Open();
        LinkButton del = sender as LinkButton;
        GridViewRow delrow = del.NamingContainer as GridViewRow;
        int a = Convert.ToInt32(GridView1.DataKeys[delrow.RowIndex].Value.ToString());
        SqlCommand cmd = new SqlCommand("delete from department where Id=" + a + "", cn);
        int i = cmd.ExecuteNonQuery();
        cn.Close();
        data();
    }
    protected void lnkedit_Click(object sender, EventArgs e)
    {
        cn.Open();
        LinkButton ed = sender as LinkButton;
        GridViewRow edrow = ed.NamingContainer as GridViewRow;
        string b = GridView1.DataKeys[edrow.RowIndex].Value.ToString();
        SqlDataAdapter da = new SqlDataAdapter("select * from department where Id='" + b + "'", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        editid = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"].ToString());
        dprname.Text = ds.Tables[0].Rows[0]["departmentname"].ToString();
        cn.Close();
    }
    public void clear()
    {
        dprname.Text="";
    }

}