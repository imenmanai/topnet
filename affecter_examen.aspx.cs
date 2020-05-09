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
using System.Net.Mail;

public partial class affecter_examen : System.Web.UI.Page
{

    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        if (!IsPostBack)
        { afficher_candidat(); }
        listeExamen();
        /****************************/
      
    }
  
    protected void listeExamen()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "select titreExamen from examen";

        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                DropDownList12.Items.Add(dr["titreExamen"].ToString());

               
            }

        }
    }
    protected void afficher_candidat()
    {
        SqlCommand cmd = con.CreateCommand();


        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from [user] where type = 'candidat'";
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);
        // cmd.ExecuteNonQuery();
        if (!IsPostBack)
        {
            dataTables.DataSource = dtb1;
            dataTables.DataBind();
        }


    }
    protected void dataTables_PageIndexChanged(object sender, EventArgs e)
    {
        dataTables.SelectedIndex = 0;

    }
    protected void datables_rowCommand(object sender, GridViewCommandEventArgs e)
    { /*
        for(int i=0;i<dataTables.Rows.Count;i++)
        {
          
        //  int x = get_ID(val);
            if (e.CommandName == "affecterr")
            {
                Label l = (Label)dataTables.Rows[i].FindControl("Label1");
                Response.Redirect("affecter_examen.aspx?id=" +l.Text);
               /*
                test.Text = l.Text;

                // ajout_candidatpass_examen(x);

            } */

        if (e.CommandName == "poste")
        {
            nom_poste.Visible = true;
 
        }
       }

    protected bool rechercher_Token(string token)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select token from candidat where token=@token";
        cmd.Parameters.AddWithValue("@token", token);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
      
        if (dt.Rows.Count != 0)
        {
           return true;
        } else {return false;}
    }

    protected void ajout_candidatpass_examen(int idUser)
    {    
        string x = RandomToken();
        Boolean test = rechercher_Token(x);
        if (test == false)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO candidat (token,id_user) VALUES (@token,@id)";
            cmd.Parameters.AddWithValue("@id", idUser);

            cmd.Parameters.AddWithValue("@token", x);
            var xi = cmd.ExecuteNonQuery();
        }
    }

    protected string select_tokenCandidat(int idUser)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select token from candidat where id_user=@id";
        cmd.Parameters.AddWithValue("@id", idUser);
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        string token = "";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                token = dr["token"].ToString();

            }

        }
        return (token);

    }
  

    protected void recherche()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from [user] where (nom=@n OR prenom=@p OR email=@e OR matricule=@m) and type='candidat' ";
        cmd.Parameters.AddWithValue("@n", myInput.Text);
        cmd.Parameters.AddWithValue("@p", myInput.Text);
        cmd.Parameters.AddWithValue("@e", myInput.Text);
        cmd.Parameters.AddWithValue("@m", myInput.Text);

        cmd.ExecuteNonQuery();
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);
        // cmd.ExecuteNonQuery();
        dataTables.DataSource = dtb1;
        dataTables.DataBind();
        cmd.Parameters.Clear();

    }
    protected void search_Click(object sender, EventArgs e)
    {
        recherche();
    }

    protected void dataTables_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        List<int> list = new List<int>();
        if (ViewState["SelectedRecords"] != null)
        {
            list = (List<int>)ViewState["SelectedRecords"];
        }

        foreach (GridViewRow row in dataTables.Rows)
        {
            CheckBox chk = (CheckBox)(row.Cells[0].FindControl("ajout"));
            var selectedKey = int.Parse(dataTables.DataKeys[row.RowIndex].Value.ToString());
            if (chk.Checked == true)
            {
                if (!list.Contains(selectedKey))
                {
                    list.Add(selectedKey);


                }
            }
            else
            {
                if (list.Contains(selectedKey))
                {
                    list.Remove(selectedKey);

                }
            }
        }
        ViewState["SelectedRecords"] = list;
        dataTables.PageIndex = e.NewPageIndex;
       
        SqlCommand cmd = con.CreateCommand();

        cmd.CommandType = CommandType.Text;
        cmd.CommandText = " select * from [user] where type='candidat'";
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();
        sqlDa.Fill(dtb1);

        dataTables.DataSource = dtb1;
        dataTables.DataBind();

       // Response.Redirect("affecter_examen.aspx?ID=" + e.NewPageIndex);
    
    }
    public int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }   
    // Generate a random string with a given size  
    public string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }    
    public string RandomToken()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(RandomString(4, true));
        builder.Append(RandomNumber(1000, 9999));
        builder.Append(RandomString(2, false));
        return builder.ToString();  
    }


    protected string get_mail(int id)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select email from [user] where idUser=@idUser";
        cmd.Parameters.AddWithValue("@idUser",id);
        cmd.ExecuteNonQuery();
         DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        
        string idi="";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                idi = dr["email"].ToString();

            }

        }
        return (idi);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write(RandomToken());
    }
    protected void dataTables_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
    List<int> list = ViewState["SelectedRecords"] as List<int>;
    if (e.Row.RowType == DataControlRowType.DataRow && list != null)
    {
        var idUser = int.Parse(dataTables.DataKeys[e.Row.RowIndex].Value.ToString());
        if (list.Contains(idUser))
        {
            CheckBox chk = (CheckBox)e.Row.Cells[0].FindControl("ajout");
            chk.Checked = true;
        }
    }

}
    protected int ref_examen(string titre)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select refExamen from examen where titreExamen=@titre";
        cmd.Parameters.AddWithValue("@titre",titre);
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        string id = "";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                id = dr["refExamen"].ToString();

            }

        }
        return (int.Parse(id));
    }

    protected int index(string mail)
    {int x=0;
        for (int i = 0; i < dataTables.Rows.Count; i++)
        {
            if (dataTables.Rows[i].Cells[3].Text == mail)
            {
                x = i;
                // break;
            }
            else x = -1;

        } return x;
    }

    protected void affecter_Click(object sender, EventArgs e)
    
    {
        List<int> list = new List<int>();
        if (ViewState["SelectedRecords"] != null)
        {
            list = (List<int>)ViewState["SelectedRecords"];
        }

        foreach (GridViewRow row in dataTables.Rows)
        {
            CheckBox chk = (CheckBox)(row.Cells[0].FindControl("ajout"));
            var selectedKey = int.Parse(dataTables.DataKeys[row.RowIndex].Value.ToString());
            if (chk.Checked == true)
            {
                if (!list.Contains(selectedKey))
                {
                    list.Add(selectedKey);
                }
            }
            else
            {
                if (list.Contains(selectedKey))
                {
                    list.Remove(selectedKey);
                }
            }
        }
      
        ViewState["SelectedRecords"] = list;
        if ((list != null))
        {
            foreach (int id in list)
            {
               
               /* int idi = get_ID(id);
                int y = index(id);
                */
                ajout_candidatpass_examen(id);
                string x = select_tokenCandidat(id);
                string maili=get_mail(id);
                Boolean test = envoi_mail(maili, x);
                ajout_poste(nom_poste.Text, ref_examen(DropDownList12.SelectedItem.Value));
                int refe = ref_examen(DropDownList12.SelectedItem.Value);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO passer_examen (token,idUser,refExamen,dateInsertion) VALUES (@token,@id,@ref,getDate())";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@ref", refe);
                cmd.Parameters.AddWithValue("@token", x);
                var xi = cmd.ExecuteNonQuery();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('examen affecter.');</script>");
            }
        }
    }
    public bool envoi_mail(string email, string token)
    {
          string sendEmail = ConfigurationManager.AppSettings["SendEmail"];
          if (sendEmail.ToLower() == "true")
          {
              MailMessage msg = new MailMessage("imenmanai258@gmail.com",email);


              msg.Subject = "Passer examen";
              msg.Body = "Bonjour , Afin de passer le test psychotechnique , Voici votre token d'examen  "+token;
              SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

              smtp.Credentials = new System.Net.NetworkCredential()
              {
                  UserName = "imenmanai258@gmail.com",
                  Password = "Imenmanaiesprit12"
              };
              smtp.EnableSsl = true;
              smtp.Send(msg);
              return true;
          }
          else { return false; }

    }



    protected void ajout_poste(string nom, int refExamen)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT INTO poste (nomPoste,refExamen) VALUES (@nomP,@refE)";
        cmd.Parameters.AddWithValue("@nomP", nom);

        cmd.Parameters.AddWithValue("@refE", refExamen);
        var xi = cmd.ExecuteNonQuery();
    }


  
}
 




    
