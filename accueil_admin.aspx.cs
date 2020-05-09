using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class accueil_admin : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        afficher_nomuser((string)Session["login"], (string)Session["mot_passe"]);

    }
    protected void afficher_nomuser(string login, string pwd)
    {
        SqlCommand cmd = con.CreateCommand();


        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select [user].nom,[user].prenom from [user] inner join ProfilUser on  [user].idUser=ProfilUser.id_user  where  [ProfilUser].login=@login and [ProfilUser].mot_passe=@pwd ";
        cmd.Parameters.AddWithValue("@login", login);
        cmd.Parameters.AddWithValue("@pwd", pwd);
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);

        string nom = "";
        string prenom = "";
        if (dtb1.Rows.Count != 0)
        {
            foreach (DataRow dr in dtb1.Rows)
            {
                nom = dr["nom"].ToString();
                prenom = dr["prenom"].ToString();
            }
        }
        user.Text = nom + " " + prenom;

    }
    protected void logout_Click(object sender, EventArgs e)
    {
        Session["login"] = "";
        Session["mot_passe"] = "";
        Response.Redirect("login.aspx");
    }

    protected void logout_Click1(object sender, EventArgs e)
    {
        Session["login"] = "";
        Session["mot_passe"] = "";
        Response.Redirect("login.aspx");
    }
}