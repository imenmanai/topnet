using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class reponse : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    { con.Open();


    string ch = Request.QueryString["ID"];
    int id =System.Convert.ToInt32(ch.Substring(0, ch.IndexOf(":")));

               string type =ch.Substring(ch.IndexOf(":") + 1,5);
               
          afficher_question(id,type);
 
    }

    protected void afficher_question(int id,string type)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "select question from [question] where idQuestion ='" + id + "'";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
          string ques = "";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
               ques = dr["question"].ToString();

            }}
        if (type == "texte")
        { Question1.Text = ques; }
        else if (type == "image")
        {
            Question1.Visible = false;
            questions.Visible = true;
            questions.ImageUrl = "téléchargement/" + ques;
        } else if(type=="imtxt")
        {


            string image = ques.Substring(0, ques.IndexOf(":"));
            int idi=ques.IndexOf(":") + 1;
            int idii=ques.IndexOf("?");
            string texte = ques.Substring(idi,idii-idi);
            Question1.Text = texte;
            questions.Visible = true;
            questions.ImageUrl = "téléchargement/" + image;
        
        }
    }

    protected string type_question(int id)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "select [type] from question where idQuestion ='"+id+"'";
   
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        string type = "";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                type = dr["type"].ToString();

            }

        }
        return type;
    }




    protected void rep_Click(object sender, EventArgs e)
    {
        if (ami.SelectedItem.Value == "texte")
        {
            reponse1.Visible = true;
            reponse11.Visible = true;
            reponse12.Visible = true;
            reponse13.Visible = true;
        }
        else if (ami.SelectedItem.Value == "image")
        {
            images.Visible = true;
            reponse11.Visible = true;
            reponse12.Visible =true;
            reponse13.Visible = true;
           

        }
    }


    protected bool ajout_reponse(int idReponse, string type)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "INSERT INTO reponse (idQuestion,reponse,dateInsertion,type) VALUES (@idQuestion,@reponse,getDate(),@type)";
        cmd.Parameters.AddWithValue("@idQuestion", idReponse);
        cmd.Parameters.AddWithValue("@reponse",reponse1.Text);
        cmd.Parameters.AddWithValue("@type", type);
        int var = cmd.ExecuteNonQuery();
        if (var != 0)
        {
            cmd.Parameters.Clear();
            return true;
        }
        else
        {
            cmd.Parameters.Clear();
            return false;
        }
    }
    protected bool ajout_reponse1(int idReponse, int bonne,string type)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "INSERT INTO reponse (idQuestion,reponse,bonneReponse,dateInsertion,type) VALUES (@idQuestion,@reponse,@bonneReponse,getDate(),@type)";
        cmd.Parameters.AddWithValue("@idQuestion", idReponse);
        cmd.Parameters.AddWithValue("@reponse","téléchargement/"+images.FileName.ToString());
   cmd.Parameters.AddWithValue("@type", type);
   cmd.Parameters.AddWithValue("@bonneReponse",bonne);
        int var = cmd.ExecuteNonQuery();
        if (var != 0)
        {
            cmd.Parameters.Clear();
            return true;
        }
        else
        {
            cmd.Parameters.Clear();
            return false;
        }
    }
    protected bool bonneReponse(int idQuestion,int bonne,string reponse)
    {
       
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "UPDATE reponse SET bonneReponse=@bonneReponse WHERE idQuestion=@idQuestion and reponse=@reponse";
        cmd.Parameters.AddWithValue("@idQuestion",idQuestion);

        cmd.Parameters.AddWithValue("@bonneReponse",bonne);
        cmd.Parameters.AddWithValue("@reponse",reponse);
        var v = cmd.ExecuteNonQuery();
        if (v != 0)
        { return true; }
        else { return false; }
    }

    protected bool bonneReponse1(int idQuestion, int bonne)
    {
        images.SaveAs(Server.MapPath("téléchargement/" + images.FileName));

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "UPDATE reponse SET bonneReponse=@bonneReponse WHERE idQuestion=@idQuestion and reponse=@reponse";
        cmd.Parameters.AddWithValue("@idQuestion", idQuestion);

        cmd.Parameters.AddWithValue("@bonneReponse", bonne);
        cmd.Parameters.AddWithValue("@reponse","téléchargement"+images.FileName.ToString());
     
       
        var v = cmd.ExecuteNonQuery();
        if (v != 0)
        { return true; }
        else { return false; }
    }

    protected void afficher_reponses(int id)
    {
        SqlCommand cmd = con.CreateCommand();


        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from reponse where idQuestion='"+id+"'";
    cmd.ExecuteNonQuery();
       
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);

            DataTable dtb1 = new DataTable();
            sqlDa.Fill(dtb1);
         string image = "";
        if (dtb1.Rows.Count != 0)
        {
            foreach (DataRow dr in dtb1.Rows)
            {
                image = dr["reponse"].ToString();

            }

        }

            if (ami.SelectedItem.Value == "texte")
            {
                tables_rep.DataSource = dtb1;
                tables_rep.DataBind();
            }
            else if (ami.SelectedItem.Value == "image")
            {

                GridView1.DataSource = dtb1;
                GridView1.DataBind();


            }
       
    }

    protected void reponse11_Click(object sender, ImageClickEventArgs e)
    {
     
        if (ami.SelectedItem.Value == "texte")
        {
            string ch = Request.QueryString["ID"];
            int id = System.Convert.ToInt32(ch.Substring(0, ch.IndexOf(":")));
            bool test = vrai(id);
           
            if (test == false)
            {
                bool rep = ajout_reponse(id, "texte");
                bool bonne = bonneReponse(id, 1, reponse1.Text); 
            }
            else Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('une seule réponse correcte.');</script>");
        }
        else if (ami.SelectedItem.Value == "image")
        {
            string ch = Request.QueryString["ID"];
            int id = System.Convert.ToInt32(ch.Substring(0, ch.IndexOf(":")));
            bool test = vrai(id);
            if (test == false)
            { bool rep = ajout_reponse1(id, 1, "image"); }
            else Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('une seule réponse correcte.');</script>");
          
        }
      
        
    }

   

    protected void reponse13_Click(object sender, ImageClickEventArgs e)
    {
        string ch = Request.QueryString["ID"];
        int id = System.Convert.ToInt32(ch.Substring(0, ch.IndexOf(":")));
    afficher_reponses(id);
         reponse1.Text = "";
    
    
    }


    protected void reponse12_Click(object sender, ImageClickEventArgs e)
    {

        if (ami.SelectedItem.Value == "texte")
        {
            string ch = Request.QueryString["ID"];
            int id = System.Convert.ToInt32(ch.Substring(0, ch.IndexOf(":")));
            bool rep = ajout_reponse(id, "texte");
            bool bonne = bonneReponse(id, 0, reponse1.Text);
        }
        else if (ami.SelectedItem.Value == "image")
        {
            string ch = Request.QueryString["ID"];
            int id = System.Convert.ToInt32(ch.Substring(0, ch.IndexOf(":")));
            bool rep = ajout_reponse1(id,0, "image");
          
      
        }
    }


    protected bool vrai(int id)
    {
        
        
     
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "select [bonneReponse] from reponse where idQuestion ='" + id + "'and bonneReponse=1";

        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
      
        if (dt.Rows.Count > 0)
        {
            return true;

        }
        else return false;
        

    }
    protected void valider_Click(object sender, EventArgs e)
    {
        Response.Redirect("examen1.aspx");
    }
    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("preparer_question.aspx");

    }
}