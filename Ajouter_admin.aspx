<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Ajouter_admin.aspx.cs" Inherits="Ajouter_admin" %>

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
  background-color:#E3761C;
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

/* Set a grey background color and center the text of the "sign in" section */
.signin {
  background-color: #f1f1f1;
  text-align: center;
}
</style>
<body  style="background-color:#2A2A6C;">
<form>
  <div class="container" style="width:100%; margin-left:300px; margin-top:20px;">
    <h1  style="color:#E3761C;">Ajouter un utilisateur</h1>
    <p  style="color:#E3761C;">Veuillez remplir le formulaire.</p>
    <hr>
      <asp:Label ID="nom"  runat="server" Text="Label"  style="color:#E3761C;">Nom</asp:Label>
      <asp:TextBox ID="nom_s" class="input" runat="server"></asp:TextBox>

     <asp:Label ID="prenom" runat="server" Text="Label"  style="color:#E3761C;">prenom</asp:Label>
      <asp:TextBox ID="prenom_s" class="input" runat="server"></asp:TextBox>
         
         <asp:Label ID="mail" runat="server" Text="Label"  style="color:#E3761C;">Email</asp:Label>
      <asp:TextBox ID="mail_s" class="input"  runat="server"></asp:TextBox>
   
      
      <asp:Label ID="matricule" runat="server" Text="Label"  style="color:#E3761C;">Matricule</asp:Label>
      <asp:TextBox ID="matricule_s" class="input" runat="server"></asp:TextBox>
        
        <asp:Label ID="tel" runat="server" Text="Label"  style="color#E3761C;">numéro téléphone</asp:Label>
      <asp:TextBox ID="tel_s" class="input" runat="server"></asp:TextBox>
    
  
   <asp:Label ID="type" runat="server" Text="Label"  style="color:#E3761C;">Type :</asp:Label>   
   
        <asp:DropDownList ID="a" class="input" runat="server">
        <asp:ListItem >Admin</asp:ListItem>
        <asp:ListItem>Super user</asp:ListItem>
        </asp:DropDownList>
     
    

    <hr>
    <asp:Label ID="verif" runat="server" Text=""></asp:Label>
 
      <asp:Button ID="submit" class="registerbtn" runat="server" Text="Ajouter" 
          onclick="submit_Click" />
   <!-- <button type="submit" class="registerbtn">Register</button>-->
  </div>


</form>
</body>
</asp:Content>

