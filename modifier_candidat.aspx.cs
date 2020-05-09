using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class modifier_candidat : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    int x = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
      protected bool afficher_formulaire_rempli()
    {
        con.Open();

        int ch = System.Convert.ToInt32(Request.QueryString["id1"]);
        //int x = int.Parse(ch);
        SqlCommand cmd = con.CreateCommand();
        cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from [user] where idUser ='" + ch + "'";

        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                nom_s.Text = dr["nom"].ToString();
                prenom_s.Text = dr["prenom"].ToString();
                mail_s.Text = dr["email"].ToString();
                matricule_s.Text = dr["matricule"].ToString();
                tel_s.Text = dr["numTel"].ToString();
                
            }
            return true;
        }
        else { return false; }
        
        
        
        con.Close();


    }
      protected void modifier_candidats()
      {
          int ch = System.Convert.ToInt32(Request.QueryString["id1"]);

          SqlCommand cmd = con.CreateCommand();
          cmd.CommandType = CommandType.Text;

          string ch1 = "";


          cmd.CommandText = "UPDATE [user] SET nom=@n,prenom=@p,email=@mail,matricule=@mat,numTel=@tel,etat=@e,dateEtat=getDate() WHERE idUser =@ch3";
          cmd.Parameters.AddWithValue("@ch3", ch);
          erreur.Text = mail_s.Text;

          cmd.Parameters.AddWithValue("@n", nom_s.Text);
          cmd.Parameters.AddWithValue("@p", prenom_s.Text);
          cmd.Parameters.AddWithValue("@mail", mail_s.Text);
          cmd.Parameters.AddWithValue("@mat", matricule_s.Text);
          cmd.Parameters.AddWithValue("@tel", tel_s.Text);

          cmd.Parameters.AddWithValue("@e", ch1);

          var v = cmd.ExecuteNonQuery();
          if (v != 0)
          { Response.Redirect("consulter.aspx"); }
          else { erreur.Text = "erreur"; }



      }
    protected void modifierCandidat_Click(object sender, EventArgs e)
    {

        con.Open();
        modifier_candidats();

        con.Close();

    }

    protected void afficherCandidatForm_Click(object sender, EventArgs e)
    {
        
       bool z=afficher_formulaire_rempli();
    }
}
