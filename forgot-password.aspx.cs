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
using System.IO;


public partial class forgot_password : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    {

        con.Open();
    }

    public bool envoi_mail(string email)
    {
        string sendEmail = ConfigurationManager.AppSettings["SendEmail"];
        if (sendEmail.ToLower() == "true")
        {
            MailMessage msg = new MailMessage("imenmanai258@gmail.com", email);


            msg.Subject = "Réinitialiser votre mot de passe";
            msg.Body = createTemplate();
            msg.IsBodyHtml = true;
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


    protected int get_ID(string mail)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select idUser from [user] where email=@mail";
        cmd.Parameters.AddWithValue("@mail", mail);
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        string id = "";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                id = dr["idUser"].ToString();

            }

        }
        return (int.Parse(id));
    }
    private string createTemplate()
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("template.htm")))
        {

            body = reader.ReadToEnd();

        }

        body = body.Replace("{mail}", inputEmail.Text); //replacing Parameters
        body = body.Replace("{id}", get_ID(inputEmail.Text).ToString());

        return body;
    
    
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        bool envoie = envoi_mail(inputEmail.Text);
    }
}