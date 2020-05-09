using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class login : System.Web.UI.Page
{ //Get connection string from web.config file  
   
    string ch = string.Empty; 
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
  
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    { con.Open();

    
            
 
    }
    protected string select_typeuser()
    {
        cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select type from [user] inner join ProfilUser on [user].idUser = ProfilUser.id_user where login ='" + inputEmail.Text + "' and mot_passe ='" + inputPasswordee.Text + "'";

        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ch = dr["type"].ToString();

                
            }
        } return (ch);
    }
    protected bool verifier()
    {
        cmd= con.CreateCommand();
      
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from ProfilUser where login ='" + inputEmail.Text + "' and mot_passe ='" + inputPasswordee.Text + "'";
        
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Session["login"] = dr["login"].ToString();
               Session["mot_passe"] = dr["mot_passe"].ToString();
            }
            return true;
        }
        else {

            //Label1.Text = "erreur";
            
            return false; }
    }
    /**********************/
  private int i = 0;
    protected void Button1_Click(object sender, EventArgs e)
  {
     
        i++;
        Label1.Text = i.ToString();
        string chi = select_typeuser();
        bool test;
        
       test = verifier();
        if((test) && (chi=="Super user"))
        { //acceuil superuser
            Response.Redirect("acceuilaspx.aspx");

        } else  if((test) && (chi=="Admin"))
        {
         
               Response.Redirect("accueil_admin.aspx");

        }
        else if (test==false)
        {
           
            i++;
            Label1.Text = i.ToString();  

        }

            con.Close(); 
    }
   
    ///deuxieme fct
  
}

 