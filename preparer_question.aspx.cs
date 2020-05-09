using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class preparer_question : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    {
        Image11.ImageUrl = "";
    }

    protected void Button111_Click(object sender, EventArgs e)
    {
        if (am.SelectedItem.Value == "texte")
        {
            saisie.Visible = true;
            saisie_s.Visible = true;

            FileUpload1.Visible = false;
            
            Image11.Visible = false;
            confirmer.Visible = true;
          
        }
        else if (am.SelectedItem.Value == "image")
        {
            
            FileUpload1.Visible = true;
           
            Image11.Visible = true;
            saisie.Visible = false;
            saisie_s.Visible = false;
            confirmer.Visible = true;

        }
        else if (am.SelectedItem.Value == "texte et image")
        {
            saisie.Visible = true;
            saisie_s.Visible = true;
            
            FileUpload1.Visible = true;
           
            Image11.Visible = true;
            confirmer.Visible = true;

        }
    }
    


    protected bool ajout_question(string question,string type)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        
        cmd.CommandText = "INSERT INTO question (question,dateInsertion,type) VALUES (@question,getDate(),@type)";
        cmd.Parameters.AddWithValue("@question", question);
        cmd.Parameters.AddWithValue("@type",type);
    
           
                    int var = cmd.ExecuteNonQuery();
                    if (var != 0)
                    {
                cmd.Parameters.Clear();
                      return true;
                    }
                    else{
                cmd.Parameters.Clear();
                    return false;}
  
    }


    protected int id_question(string question)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select idQuestion from question where question ='"+question+"'";
        cmd.Parameters.AddWithValue("@question", question);
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        string id = "";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                id= dr["idQuestion"].ToString();

            }

        }


        return (int.Parse(id));
    }

    protected void confirmer_Click(object sender, EventArgs e)
    {
     
        if (am.SelectedItem.Value == "texte")
        {
            bool test = ajout_question(saisie_s.Text, am.SelectedItem.Value);
            if (test)
            {
                Response.Redirect("reponse.aspx?ID=" + id_question(saisie_s.Text).ToString() + ":texte");
               
            }            else
            {
                erreur.Text = "ourourou";
            }
        }
        else if (am.SelectedItem.Value == "image")
        {
            bool test = ajout_question(FileUpload1.FileName.ToString(),am.SelectedItem.Value);
            if (test)
            {
                FileUpload1.SaveAs(Server.MapPath("téléchargement/" + FileUpload1.FileName));

                string strFilename = FileUpload1.FileName.ToString();
                Image11.ImageUrl = "téléchargement/" + strFilename;

                

                Response.Redirect("reponse.aspx?ID="+id_question(strFilename)+":image");
               
            }
            else
            {
                erreur.Text = "ourourou";
            }
        }
        else if (am.SelectedItem.Value == "texte et image")
        {
            bool test = ajout_question(FileUpload1.FileName.ToString() + ":" + saisie_s.Text+"?", am.SelectedItem.Value);
            if (test)
            { 
                FileUpload1.SaveAs(Server.MapPath("téléchargement/" + FileUpload1.FileName));

                string strFilename = FileUpload1.FileName.ToString();
                Image11.ImageUrl = "téléchargement/" + strFilename;

                Response.Redirect("reponse.aspx?ID=" + id_question(FileUpload1.FileName.ToString() + ":" + saisie_s.Text+"?") + ":imtxt");
              
            }
            else
            {
                erreur.Text = "ourourou";
            }
        }

    }
    }
