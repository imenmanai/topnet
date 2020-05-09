<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="preparer_question.aspx.cs" Inherits="preparer_question" %>

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

        <form>
        <h1  style="margin-left:650px;color:#E3761C;">Préparation des questions :</h1>

 <div class="container" style="width:100%; margin-left:250px; margin-top:150px; border:solid orange;">
  

<br />
<br />
  <asp:label ID="type" style="color:#E3761C;">Type :</asp:label>
                
              <asp:DropDownList ID="am" class="input" runat="server">
        <asp:ListItem>image</asp:ListItem>
        <asp:ListItem>texte</asp:ListItem>
         <asp:ListItem>texte et image</asp:ListItem>
        </asp:DropDownList>
          <asp:Button ID="Button111" runat="server" Text="ok"  class="registerbtn" style="width:20%;" 
         onclick="Button111_Click"/>
          <br />
<asp:Label  style="color:#E3761C;" ID="saisie"  runat="server" Text="Label" Visible="false">Saisir une question </asp:Label>
 <asp:TextBox ID="saisie_s" class="input" runat="server"  Visible="false"></asp:TextBox>

     <asp:FileUpload style="color:#E3761C;" ID="FileUpload1" runat="server" Visible="false"/>
  
     <asp:Label  style="color:#E3761C;margin-left:250px;" ID="Label11" runat="server" Font-Bold="true" Text=""></asp:Label>
     <br />
     <br />
     <asp:Image ID="Image11" runat="server" Visible="false" style="width:20%; border:10px;"/>
     <asp:Label ID="Label21" runat="server" Font-Bold="true" Text=""></asp:Label>
     <br />
       <asp:Button ID="confirmer"  class="registerbtn"  style="margin-left:250px" runat="server" Text="confirmer" Visible="false" 
         onclick="confirmer_Click" />
         <asp:Label ID="erreur" runat="server" Font-Bold="true" Text=""></asp:Label>

<!--reponse-->
 
 </div>
 </div>


</form>

  </body>

</asp:Content>

