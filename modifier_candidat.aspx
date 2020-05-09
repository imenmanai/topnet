<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="modifier_candidat.aspx.cs" Inherits="modifier_candidat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
<style>
body {
  font-family: Arial, Helvetica, sans-serif;
   background-color:#2A2A6C;
}


* {
  box-sizing: border-box;
}

/* Add padding to containers */
.container {
  padding: 16px;
  background-color: white;
}

/* Full-width input fields */
.input {
  width: 100%;
  padding: 15px;
  margin: 5px 0 22px 0;
  display: inline-block;
  border: none;
  background: #f1f1f1;
}

.input {
  background-color: #ddd;
  outline: none;
}

/* Overwrite default styles of hr */
hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}

/* Set a style for the submit button */
.registerbtn {
  background-color: #E3761C;;
  color: white;
  padding: 16px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}

.registerbtn:hover {
  opacity: 1;
}

/* Add a blue text color to links */
a {
  color: dodgerblue;
}
input[type=checkbox] {
	margin: 10px 15px 18px 22px;
}
/* Set a grey background color and center the text of the "sign in" section */
.signin {
  background-color: #f1f1f1;
  text-align: center;
}
</style>
<form ID="f">
  <div class="container" style="width:100%; margin-left:300px; margin-top:20px;">
    <h1 style="color:#E3761C;">Modifier un candidat </h1>
  <div> <p style="color:#E3761C;">Voulez appliquez les modifications relative au user </p>

      <asp:Button ID="Button1" runat="server" Text="Afficher" 
          onclick="afficherCandidatForm_Click" />
    <hr>
      
      <asp:Label ID="nom" style="color:#E3761C;" runat="server" Text="Label">Nom</asp:Label>
   
      <asp:TextBox ID="nom_s" class="input"  runat="server" ></asp:TextBox>
      <!--<asp:Label ID="n_a"  runat="server" Text="Label"></asp:Label> -->
  <!-- <label for="email"><b>Email</b></label>
    <input type="text" placeholder="Enter Email" name="email" required>-->
     <asp:Label style="color:#E3761C;" ID="prenom" runat="server" Text="Label">prenom</asp:Label>
      <asp:TextBox ID="prenom_s" class="input"  runat="server"></asp:TextBox>
       
         <asp:Label style="color:#E3761C;" ID="mail" runat="server" Text="Label">Email</asp:Label>
          <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
       

      <asp:TextBox  ID="mail_s" class="input"  runat="server"></asp:TextBox>
  
      
      <asp:Label style="color:#E3761C;" ID="matricule" runat="server" Text="Label">Matricule</asp:Label>
      <asp:TextBox ID="matricule_s" class="input" runat="server"></asp:TextBox>
        
        <asp:Label style="color:#E3761C;" ID="tel" runat="server" Text="Label">numéro téléphone</asp:Label>
      <asp:TextBox ID="tel_s" class="input" runat="server"></asp:TextBox>
    
  
   <asp:Label style="color:#E3761C;" ID="type" runat="server" Text="Label">Type :</asp:Label>   
   
      
       
      <asp:Label ID="erreur" runat="server" Text="Label"></asp:Label>
    </hr>
    <asp:Label ID="verif" runat="server" Text="Label"></asp:Label>
    
      <asp:Button ID="submit" class="registerbtn" runat="server" Text="Enregistrer" 
          onclick="modifierCandidat_Click"   />
          </div>
      

</form>
</asp:Content>

