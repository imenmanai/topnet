using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Default2 : System.Web.UI.Page
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

                a.Text = dr["type"].ToString();

                string chi = dr["etat"].ToString();
                if (chi == "active")
                {
                    etat.SelectedIndex = 0;
                }
                else if (chi == "desactive")
                {
                    etat.SelectedIndex = 1;

                }
            }
            return true;
        }
        else { return false; }

       
    }

    protected void modifier_user()
    {
        int ch = System.Convert.ToInt32(Request.QueryString["id1"]);

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        string c = a.SelectedItem.Value;
        string ch1 = "";
        if (etat.SelectedIndex == 0)
        {
            ch1 = "active";
        }
        else if (etat.SelectedIndex == 1)
        {
            ch1 = "desactive";
        }

        cmd.CommandText = "UPDATE [user] SET nom=@n,prenom=@p,email=@mail,matricule=@mat,numTel=@tel,type=@t,etat=@e,dateEtat=getDate() WHERE idUser =@ch3";
        cmd.Parameters.AddWithValue("@ch3", ch);
        erreur.Text = mail_s.Text;

        cmd.Parameters.AddWithValue("@n", nom_s.Text);
        cmd.Parameters.AddWithValue("@p", prenom_s.Text);
        cmd.Parameters.AddWithValue("@mail", mail_s.Text);
        cmd.Parameters.AddWithValue("@mat", matricule_s.Text);
        cmd.Parameters.AddWithValue("@tel", tel_s.Text);
        cmd.Parameters.AddWithValue("@t", c);
        cmd.Parameters.AddWithValue("@e", ch1);

        var v = cmd.ExecuteNonQuery();
        if (v != 0)
        { Response.Redirect("consulter_admin.aspx"); }
        else { erreur.Text = "ourourou"; }




    }
    protected void modiferUser_Click(object sender, EventArgs e)
    {

        con.Open();
        modifier_user();

        con.Close();

    }

    protected void afficherFormulaire_Click(object sender, EventArgs e)
    {
        
       bool z=afficher_formulaire_rempli();
    }
}