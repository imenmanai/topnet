using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;


public partial class liste_ques : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        string ch = Request.QueryString["ID"];
        //afficher_liste(int.Parse(ch));
       // imeni.Text = ch;
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select question from [question] inner join Question_Examen on question.idQuestion=Question_Examen.idQuestion inner join examen on examen.refExamen = Question_Examen.refExamen where examen.refExamen=@ref";
        cmd.Parameters.AddWithValue("@ref",int.Parse(ch));
        cmd.ExecuteNonQuery();
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);
        GV.DataSource = dtb1;
        GV.DataBind();
    }

    protected void afficher_liste(int refe_examen)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select question from [question] inner join Question_Examen on question.idQuestion=Question_Examen.idQuestion inner join examen on examen.refExamen = Question_Examen.refExamen where examen.refExamen=@ref";
        cmd.Parameters.AddWithValue("@ref",refe_examen);
        cmd.ExecuteNonQuery();
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);
        if (dtb1 != null)
        {
            GV.DataSource = dtb1;
            GV.DataBind();
        }
      
    }
    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV.PageIndex = e.NewPageIndex;

        afficher_liste(int.Parse(Request.QueryString["ID"]));
    }
  

    protected void GV_PageIndexChanged1(object sender, EventArgs e)
    {
        GV.SelectedIndex = 0;
    }
    
}