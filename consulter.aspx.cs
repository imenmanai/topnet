﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class consulter : System.Web.UI.Page
{

    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        afficher_candidat();
      
    }

    protected void afficher_candidat()
    {
        SqlCommand cmd = con.CreateCommand();


        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from [user] where type = 'candidat'";
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);
        // cmd.ExecuteNonQuery();
      
            dataTables.DataSource = dtb1;
            dataTables.DataBind();
       

    }
    protected void dataTables_PageIndexChanged(object sender, EventArgs e)
    {
        dataTables.SelectedIndex = 0;

    }
    protected void datables_rowCommand(object sender, GridViewCommandEventArgs e)
    {
        for (int i = 0; i < dataTables.Rows.Count; i++)
        {
            string val = dataTables.Rows[i].Cells[0].Text;

            if (e.CommandName == "modifier")
            { Response.Redirect("modifier_candidat.aspx?id1=" + val); }
        }
    }
    protected void recherche()
    {
        SqlCommand cmd = con.CreateCommand();


        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from [user] where (nom=@n OR prenom=@p OR email=@e OR matricule=@m) and type='candidat' ";
        cmd.Parameters.AddWithValue("@n", myInput.Text);
        cmd.Parameters.AddWithValue("@p", myInput.Text);
        cmd.Parameters.AddWithValue("@e", myInput.Text);
        cmd.Parameters.AddWithValue("@m", myInput.Text);

        cmd.ExecuteNonQuery();
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);
        // cmd.ExecuteNonQuery();
        dataTables.DataSource = dtb1;
        dataTables.DataBind();
        cmd.Parameters.Clear();

    }
    protected void search_Click(object sender, EventArgs e)
    {
        recherche();
    }

    protected void dataTables_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dataTables.PageIndex = e.NewPageIndex;
        afficher_candidat();

    }

}