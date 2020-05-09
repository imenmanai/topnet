using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class ajout_candidat : System.Web.UI.Page
{//Get connection string from web.config file  
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
    }


    protected void ajout_Click(object sender, EventArgs e)
    {
        ajout_candidats();
        con.Close();

    }


    /******************Fonctionnalité********************************/
    protected int rechercher_idInsertion(string login, string pwd)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select id_user from [ProfilUser] where login ='" + login + "' and mot_passe ='" + pwd + "'";

        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        string id_insertion = "";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                id_insertion = dr["id_user"].ToString();

            }
        }

        return (int.Parse(id_insertion));
    }
    protected void ajout_candidats()
    {
         int id_insert = rechercher_idInsertion((string)Session["login"], (string)Session["mot_passe"]);


        if ((string.IsNullOrEmpty(nom_s.Text) == false) && (string.IsNullOrEmpty(prenom_s.Text) == false) && (string.IsNullOrEmpty(mail_s.Text) == false) && (string.IsNullOrEmpty(tel_s.Text) == false))
        {
            
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO [user] (nom,prenom,email,matricule,numTel,type,dateInsertion,idInsertion,dateEtat) VALUES (@nom,@prenom,@email,@matricule,@numTel,'candidat',getDate(),@idInsertion,getDate())";
                cmd.Parameters.AddWithValue("@nom", nom_s.Text);
                cmd.Parameters.AddWithValue("@prenom", prenom_s.Text);
                cmd.Parameters.AddWithValue("@email", mail_s.Text);
                cmd.Parameters.AddWithValue("@matricule", matricule_s.Text);
                cmd.Parameters.AddWithValue("@numTel", int.Parse(tel_s.Text));
                cmd.Parameters.AddWithValue("@idInsertion", id_insert);


                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                try
                {
                    int var = cmd.ExecuteNonQuery();
                    if (var != 0)
                    {
                        Response.Redirect("consulter.aspx");

                    }
                }
                catch (Exception exp)
                {

                    verif.Text = "ajout non fait";
                }

                cmd.Parameters.Clear();

            }}
    /*  
        else if ((recherche_matricule(matricule_s.Text) == true) && (rechercher_mail(mail_s.Text) == false))
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Veuillez saisir une autre matricule.');</script>");
        }
        else if ((rechercher_mail(mail_s.Text) == true) && (recherche_matricule(matricule_s.Text) == false))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Veuillez saisir une autre adresse mail.');</script>");

        }

        }
    */

    protected bool rechercher_mail(string mail)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select idUser from [user] where email =@m";
        cmd.Parameters.AddWithValue("@m", mail);


        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        if (dt.Rows.Count != 0)
        {
            cmd.Parameters.Clear();

            return (true);

        }
        else
        {
            cmd.Parameters.Clear();

            return (false);
        }

    }

    protected bool recherche_matricule(string matricule)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select idUser from [user] where matricule =@mat";
        cmd.Parameters.AddWithValue("@mat", matricule);


        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        if (dt.Rows.Count != 0)
        {
            cmd.Parameters.Clear();

            return (true);

        }
        else
        {
            cmd.Parameters.Clear();

            return (false);
        }

    }


}