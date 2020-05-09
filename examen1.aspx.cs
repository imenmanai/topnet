using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class examen1 : System.Web.UI.Page
{
    public static string strcon = ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString;
    //create new sqlconnection and connection to database by using connection string from web.config file  
    SqlConnection con = new SqlConnection(strcon);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        if (!IsPostBack)
        { afficher(); }

    }
    protected void afficher()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select idQuestion,question from Question ";
        SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
        DataTable dtb1 = new DataTable();

        sqlDa.Fill(dtb1);

        GV.DataSource = dtb1;
        GV.DataBind();

    }
    protected void PaginateTheData(object sender, GridViewPageEventArgs e)
    {
        List<int> list = new List<int>();
        if (ViewState["SelectedRecords"] != null)
        {
            list = (List<int>)ViewState["SelectedRecords"];
        }

        foreach (GridViewRow row in GV.Rows)
        {
            CheckBox chk = (CheckBox)(row.Cells[0].FindControl("chkSelect"));
            var selectedKey = int.Parse(GV.DataKeys[row.RowIndex].Value.ToString());
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
        GV.PageIndex = e.NewPageIndex;

        afficher();
    }
    protected void GetSelectedRecords(object sender, EventArgs e)
    {
        List<int> list = new List<int>();
        if (ViewState["SelectedRecords"] != null)
        {
            list = (List<int>)ViewState["SelectedRecords"];
        }

        foreach (GridViewRow row in GV.Rows)
        {
            CheckBox chk = (CheckBox)(row.Cells[0].FindControl("chkSelect"));
            var selectedKey = int.Parse(GV.DataKeys[row.RowIndex].Value.ToString());
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
        int x = list.Count;
      
        ViewState["SelectedRecords"] = list;
       // Response.Write("<h3>Selected records</h3>");
       // List<int> list = ViewState["SelectedRecords"] as List<int>;
        if ((list != null) && (x <= (int.Parse(quantity.Text))))
        {
            foreach (int id in list)
            {
                int refExamen = select_refExamen(destination.Text);
                //  Response.Write(id.ToString() + "<br />");
                ajouter_listequestion(refExamen, id);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Liste des questions affectée');</script>");
            }
        }
        else { Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('vous avez dépassé le nombre des questions.');</script>"); }
    }
    protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
    {
        List<int> list = ViewState["SelectedRecords"] as List<int>;
        if (e.Row.RowType == DataControlRowType.DataRow && list != null)
        {
            var idQuestion = int.Parse(GV.DataKeys[e.Row.RowIndex].Value.ToString());
            if (list.Contains(idQuestion))
            {
                CheckBox chk = (CheckBox)e.Row.Cells[0].FindControl("chkSelect");
                chk.Checked = true;
            }
        }

    }
    protected void ajout_examen()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT INTO examen (nbrQuestions,duree,dateInsertion,titreExamen,intervalleDate) VALUES (@nbr,@duree,getDate(),@titre,@delai)";
        cmd.Parameters.AddWithValue("@nbr", quantity.Text);
        cmd.Parameters.AddWithValue("@duree", date_from.Text);
        cmd.Parameters.AddWithValue("@titre", destination.Text);
        cmd.Parameters.AddWithValue("@delai", date_to.Text);
        var xi = cmd.ExecuteNonQuery();
        if (xi != 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('examen créé.');</script>");

        }
        else Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('examen non créé.');</script>");

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        ajout_examen();
    }
    protected void ajouter_listequestion(int ref_ex, int id_ques)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "INSERT INTO Question_Examen (idQuestion,refExamen,dateInsertion) VALUES (@id1,@id2,getDate()) ";
        cmd.Parameters.AddWithValue("@id1", id_ques);
        cmd.Parameters.AddWithValue("@id2", ref_ex);
        cmd.ExecuteNonQuery();
    }

    protected int select_refExamen(string titre)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select refExamen from examen where titreExamen=@titre";
        cmd.Parameters.AddWithValue("@titre", titre);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        string refe = "";
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                refe = dr["refExamen"].ToString();

            }
        }
        return (int.Parse(refe));

    }






}
