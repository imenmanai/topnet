using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class ajout_login : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected int ajout_id()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        int id_insert = rechercher_idInsertion((string)Session["login"], (string)Session["mot_passe"]);
        cmd.CommandText = "INSERT INTO [user] (nom,prenom,email,matricule,numTel,type,dateInsertion,idInsertion,dateEtat) VALUES (@nom,@prenom,@email,@matricule,@numTel,@type, getDate(),@idInsertion,getDate()) SELECT SCOPE_IDENTITY() SELECT SCOPE_IDENTITY()";
        cmd.Parameters.AddWithValue("@nom", "");
        cmd.Parameters.AddWithValue("@prenom", "");
        cmd.Parameters.AddWithValue("@email", "");
        cmd.Parameters.AddWithValue("@matricule", "");
        cmd.Parameters.AddWithValue("@type", "");
        cmd.Parameters.AddWithValue("@numTel", 0);
        cmd.Parameters.AddWithValue("@idInsertion", id_insert);

        cmd.ExecuteNonQuery();

        int userID=0;
        object obj = cmd.ExecuteScalar();
        if (obj != null)
        {
            userID = int.Parse(obj.ToString());
        } 
        return (userID);
    }
    protected bool ajout_log()
    {
        int id_aj = ajout_id();
      
        bool x = false;
        if (logi.Text!="" || pwd.Text!="")
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO ProfilUser (id_user,login,mot_passe) VALUES (@id_user,@login,@pwd)";
            cmd.Parameters.AddWithValue("@id_user",id_aj);
            cmd.Parameters.AddWithValue("@login", logi.Text);
            cmd.Parameters.AddWithValue("@pwd", pwd.Text);
          
            try
            {
                int var = cmd.ExecuteNonQuery();
                if (var != 0)
                {
                    x = true;
                }

            }
            catch (Exception e)
            {
                x = false;
              
            }

            cmd.Parameters.Clear();

        }
        return (x);
    }
    protected void Button_log_Click(object sender, EventArgs e)
    {
        con.Open();
        bool test=ajout_log();
        if(test)
        {
            int  id = rechercher_idInsertion(logi.Text, pwd.Text);
         Response.Redirect("Ajouter_admin.aspx?id="+id);
            //Response.Write("ajout sar");
        }
   

 con.Close();   

        }


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
    }
