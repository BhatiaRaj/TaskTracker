using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class TypeOfWork : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
    static int editid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        data();
    }
    protected void typeofworksubmit_Click(object sender, EventArgs e)
    {
       
        if (editid == 0)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("if not exists(select * from typeofwork where typeofwork='" + typeofwork.Text + "') insert into typeofwork values('" + typeofwork.Text + "')", cn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("<script Language='Javascript'>alert('Insert')</script>");
            }
            else
            {
                Response.Write("<script Language='Javascript'>alert('Already Exists')</script>");
            }
            cn.Close();
            typeofwork.Text = "";
            data();
        }
        else
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("if not exists(select * from typeofwork where typeofwork='" + typeofwork.Text + "' and Id!="+ editid +") update typeofwork set typeofwork='" + typeofwork.Text + "' where Id = " + editid + "", cn);
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

            typeofwork.Text = "";
            editid = 0;
            data();
        }
    }
    public void data()
    {
        cn.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from typeofwork", cn);
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
        string a = GridView1.DataKeys[delrow.RowIndex].Value.ToString();
        SqlCommand cmd = new SqlCommand("delete from typeofwork where Id='" + a + "'", cn);
        cmd.ExecuteNonQuery();
        cn.Close();
        data();
    }
    protected void lnkedit_Click(object sender, EventArgs e)
    {
        cn.Open();
        LinkButton ed = sender as LinkButton;
        GridViewRow edrow = ed.NamingContainer as GridViewRow;
        string b = GridView1.DataKeys[edrow.RowIndex].Value.ToString();
        SqlDataAdapter da = new SqlDataAdapter("select * from typeofwork where Id='" + b + "'", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        editid = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"].ToString());
        typeofwork.Text = ds.Tables[0].Rows[0]["typeofwork"].ToString();
        cn.Close();
    }
}