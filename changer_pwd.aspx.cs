using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;



public partial class changer_pwd : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        Page previousPage=Page.PreviousPage;
       
    

        //string previousPagee = HttpContext.Current.Request.UrlReferrer.AbsolutePath;
      //  Erreur.Text = previousPagee;
        /*
        if (previousPage != null && previousPage.IsCrossPagePostBack)
        {
            mail = ((TextBox)previousPage.FindControl("inputEmail")).Text;
            Erreur.Text = mail;

        }
        else
        {
            Erreur.Text = "Vous pouvez pas changer votre mot de passe";
        }
   
       */
    }
    protected string chercher_mail(int id)
    {
        
        SqlCommand cmd = con.CreateCommand();
        cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select email from [user] where idUser= @id";
        cmd.Parameters.AddWithValue("@id",id);
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        string mail="";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

              mail = dr["email"].ToString();

            }

        }
        return mail;
    }


    protected void Button1_Click(object sender, EventArgs e)
    { string  ch =Request.QueryString["id"];
        if (pwd.Text == pwd1.Text)
        {  string m=chercher_mail(int.Parse(ch));
            bool pwdi = modifier_pwd(pwd.Text,m);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Mot de passe modifié.');</script>");

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Veuillez saisir le même mot de passe.');</script>");
        }
    }


    protected bool modifier_pwd(string pwd,string mail)
    {
        string idUser = recherche_pwd(mail);
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "UPDATE [ProfilUser] SET mot_passe=@pwd WHERE id_user =@idUser";
        cmd.Parameters.AddWithValue("@idUser",idUser);
        cmd.Parameters.AddWithValue("@pwd", pwd);
        var v = cmd.ExecuteNonQuery();
        if (v != 0)
         return true; 
        else  return false; 


    }

    protected string recherche_pwd(string maile)
    {
       
        SqlCommand cmd = con.CreateCommand();
        cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select idUser from [user] where email= @mail";
        cmd.Parameters.AddWithValue("@mail",maile);
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        string id="";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

               id = dr["idUser"].ToString();

            }

        }
        return id;
    }

}