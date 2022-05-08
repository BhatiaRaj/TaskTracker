using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Customer_sWork : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            data();
        }
    }
    public void data()
    {
        cn.Open();
        string eid = Session["Admin"].ToString();
        SqlDataAdapter da = new SqlDataAdapter("select customerandwork.Id,customerandwork.date,customerandwork.target,customerandwork.description,customerandwork.status,customer.customername,typeofwork.typeofwork from customerandwork inner join customer on customerandwork.customerid=customer.Id inner join typeofwork on customerandwork.work=typeofwork.Id", cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        cn.Close();
    }
    protected void lnkupdate_Click(object sender, EventArgs e)
    {

        LinkButton ed = sender as LinkButton;
        GridViewRow edrow = ed.NamingContainer as GridViewRow;
        string b = GridView1.DataKeys[edrow.RowIndex].Value.ToString();
        cn.Open();
        SqlCommand cmdupdate = new SqlCommand("update customerandwork set status='Completed' where Id="+ Convert.ToInt32(b.ToString()) +" ",cn);
        int i = cmdupdate.ExecuteNonQuery();
        if(i>0)
        {
            cn.Close();
            Response.Write("<script Language='Javascript'>alert('Status Updated Successfully')</script>");
            data();
        }
    }
}