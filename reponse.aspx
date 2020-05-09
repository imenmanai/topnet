<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="reponse.aspx.cs" Inherits="reponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
<style>
.input 
{
    height:60px;
  width: 40%;
  padding: 15px;
  margin: 5px 10px 22px 30px;
  display: inline-block;
  border: none;
  background: #f1f1f1;
}

.input {
  background-color: #ddd;
  outline: none;
}
hr {
 
  margin-bottom: 25px;
  width:100%;
  height:90%;
}

div#corps {
 width   : 100%;
 height  : 100%;
 padding: 10px;
}

#type 
{
 font-family: "Times New Roman", Times, serif;
 font-size : 30px;   
 margin: 5px 10px 22px 30px;
}
.registerbtn {
  background-color:#E3761C;
  color: white;
  padding: 16px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 50%;
  opacity: 0.9;
}

.registerbtn:hover {
  opacity: 1;
}

/* PIED DE PAGE */

</style>
 <body  style="background-color:#2A2A6C;">
 <h1 style="margin-left:650px;color:#E3761C;">Préparer réponses</h1>
 <div class="container" style="width:100%; margin-left:250px; margin-top:150px;border:solid orange;">
   <div id="corps">


<br />
 <asp:Label style="color:#E3761C;font-size:50px;" ID="Label1" runat="server" Text="Question :"></asp:Label>
    <asp:Label style="color:#E3761C; font-size:40px;" ID="Question1" runat="server" Text="Label"></asp:Label>
    <br />

    <!---Question+Image--->
    <asp:Image ID="questions" Visible="false" runat="server" style="width:100px;"/>
    <br />
    <br />
  
  <asp:label style="color:#E3761C;font-size:30px;">type :</asp:label>
                
         <asp:DropDownList ID="ami" class="input" runat="server" Visible="true">
        <asp:ListItem>texte</asp:ListItem>
        <asp:ListItem>image</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="rep" runat="server" Text="ok" style="width:20%;" 
        Visible="true" onclick="rep_Click"/>
          <br />
<!---------->
<asp:Label style="color:#E3761C;">réponse:</asp:Label>
<!----texte--->
<asp:FileUpload style="color:#E3761C;" ID="images" runat="server" Visible="false"/>

 <asp:TextBox style="color:#E3761C;" ID="reponse1" class="input" runat="server"  Visible="false"> </asp:TextBox>
 <asp:ImageButton ID="reponse11" Visible="false" style ="width:20px;" 
        ImageUrl="https://pngimage.net/wp-content/uploads/2018/06/true-png-15.png" 
        runat="server" onclick="reponse11_Click"/>
 <asp:ImageButton ID="reponse12" Visible="false" style ="width:20px;" 
        runat="server" 
        ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/c/c6/False.svg/746px-False.svg.png" 
        onclick="reponse12_Click"  />
 <asp:ImageButton ID="reponse13" Visible="false"   
        style ="width:30px; margin-left:25px;" runat="server" 
        ImageUrl="https://www.icone-png.com/png/50/50465.png" 
        onclick="reponse13_Click" />
<!---Image--->
 
 <!------->

 
  <asp:GridView ID="tables_rep" class="table table-bordered" runat="server" width="80%" cellspacing="0" AutoGenerateColumns="false" BackColor="white">
  
    <Columns >   
    <asp:BoundField DataField="reponse" HeaderText="Reponse" />
 <asp:BoundField DataField="bonneReponse" HeaderText="Correcte" />
   </Columns>   

     </asp:GridView>
       <!--------->
     
         <asp:GridView ID="GridView1" class="table table-bordered" runat="server" width="80%" cellspacing="0" AutoGenerateColumns="false" BackColor="white">
  
    <Columns >   
  <asp:ImageField DataImageUrlField="reponse" HeaderText="reponse"></asp:ImageField>
 <asp:BoundField DataField="bonneReponse" HeaderText="Vrai/faux" />

   </Columns>   
             
     </asp:GridView>

     <!---- terminer quetion--->
     <asp:Button ID="valider" class="registerbtn" runat="server" Text="Affecter à un Examen" 
        onclick="valider_Click" />
        <asp:Button ID="Button" class="registerbtn" runat="server" Text="Ajouter une autre question" 
           onclick="Button_Click" />
        </div>
        </div>
           </body>
</asp:Content>


