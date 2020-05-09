using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Ajouter_admin : System.Web.UI.Page
{//Get connection string from web.config file  
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
    }
     protected int select_id(string mail)
    {  SqlCommand cmd = con.CreateCommand();
        cmd= con.CreateCommand();
      
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select idUser from [user] where email ='" + mail + "'";
        
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        string x="";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                x = dr["idUser"].ToString();
                
            }
           
        }


        return (int.Parse(x));
        
    }
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
            
            return (false); }

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

            return (false); }

    }
    protected int rechercher_idInsertion(string login, string pwd)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select id_user from [ProfilUser] where login ='" + login + "' and mot_passe ='"+pwd+"'";

        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        string id_insertion="";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                id_insertion = dr["id_user"].ToString();
                
            }
           
        }


        return (int.Parse(id_insertion));
     
    }

    protected bool verifier_num(string numTel)
    { int x=0;
        for(int i =0 ;i<numTel.Length;i++)
        {
            if ((numTel[i] >= '0') && (numTel[i] <= '9'))
            {
                x = 1;
                break;
            }
        }

        if (x == 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    protected bool verif_nom(string nom)
    {
        int x = 0;
        for (int i = 0; i < nom.Length; i++)
        {
            if ((nom[i] < 'a') && (nom[i] > 'z') && (nom[i] < 'A') && (nom[i] > 'Z'))
            {
                x = 1;
                break;
            }
        }

        if (x == 1)
        {
            return true;
        }
        else return false;
    }
    protected void ajout_userAdmin()
    {
        int idi = System.Convert.ToInt32(Request.QueryString["id"]);
        bool test = recherche_matricule(matricule_s.Text);
        verif.Text = test.ToString();
        if ((string.IsNullOrEmpty(nom_s.Text) == false) && (string.IsNullOrEmpty(prenom_s.Text) == false) && (string.IsNullOrEmpty(mail_s.Text) == false) && (string.IsNullOrEmpty(tel_s.Text) == false))
        {
            if ((recherche_matricule(matricule_s.Text) == false) && (rechercher_mail(mail_s.Text) == false))
            {
              
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

               cmd .CommandText = "UPDATE [user] SET nom=@n,prenom=@p,email=@mail,matricule=@mat,numTel=@tel,dateEtat=getDate(),type=@type WHERE idUser=@id";
                cmd.Parameters.AddWithValue("@n", nom_s.Text);
                cmd.Parameters.AddWithValue("@p", prenom_s.Text);
                cmd.Parameters.AddWithValue("@mail", mail_s.Text);
                cmd.Parameters.AddWithValue("@mat", matricule_s.Text);
                cmd.Parameters.AddWithValue("@tel", int.Parse(tel_s.Text));
                cmd.Parameters.AddWithValue("@id", idi);
                string c = a.SelectedItem.Value;
                cmd.Parameters.AddWithValue("@type", c);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                int x = select_id(mail_s.Text);

                    int var = cmd.ExecuteNonQuery();
                    if (var != 0)
                    {
                        Response.Redirect("consulter_admin.aspx");

                    }

                cmd.Parameters.Clear();

            } else if((recherche_matricule(matricule_s.Text) == true)&&(rechercher_mail(mail_s.Text) == false))
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Veuillez saisir une autre matricule.');</script>");
            }
            else if ((rechercher_mail(mail_s.Text) == true) && (recherche_matricule(matricule_s.Text) == false))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Veuillez saisir une autre adresse mail.');</script>");

            }
            else if (verifier_num(tel_s.Text))
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Veuillez saisir un numéro de téléphone correcte.');</script>");
            }
            else if ((verif_nom(nom_s.Text)) || (verif_nom(prenom_s.Text)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Veuillez ne pas saisir des caractères spéciaux.');</script>"); 
            }

        }
    }

    protected void submit_Click(object sender, EventArgs e)
    {


        ajout_userAdmin();
 con.Close();   

        }      

    }

