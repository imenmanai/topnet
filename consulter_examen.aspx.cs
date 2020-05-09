using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
public partial class consulter_examen : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    { con.Open();
    afficher();


    }
    protected void afficher()
    {
        SqlCommand cmd = con.CreateCommand();


        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from examen";
        cmd.ExecuteNonQuery();
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);
       
        if (!IsPostBack)
        {
          GV.DataSource = dtb1;
            GV.DataBind();
        }

    }
  
    protected void GV_PageIndexChanged(object sender, EventArgs e)
    {
        GV.SelectedIndex = 0;
    }
    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV.PageIndex = e.NewPageIndex;

        SqlCommand cmd = con.CreateCommand();


        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from examen";
        cmd.ExecuteNonQuery();
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);

       
            GV.DataSource = dtb1;
            GV.DataBind();


    }

    protected int select_refExamen(string titre)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select refExamen from examen where titreExamen=@titre";
        cmd.Parameters.AddWithValue("@titre", titre);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        string refe = "";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                refe = dr["refExamen"].ToString();

            }
        }
        return (int.Parse(refe));

    }
    
    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    { if (e.CommandName == "consulter")
        {
           // Response.Write(select_refExamen(imeni.Text));
            Response.Redirect("liste_ques.aspx?ID=" + select_refExamen(imeni.Text));
        }}
    protected void GV_SelectedIndexChanged(object sender, EventArgs e)
    {  foreach (GridViewRow row in GV.Rows)
    {
 if (row.RowIndex == GV.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                row.ToolTip = string.Empty;
                String pid;
                pid = row.Cells[0].Text;


                imeni.Text = pid;


            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                row.ToolTip = "Click to select this row.";
            }
        }
     
    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GV, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Click to select this row.";
        }
    }
}