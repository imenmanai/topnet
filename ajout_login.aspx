<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="ajout_login.aspx.cs" Inherits="ajout_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
<style>
body {font-family: Arial, Helvetica, sans-serif; background-color:#2A2A6C;}
* {box-sizing: border-box}

/* Full-width input fields */
.input {
  width: 100%;
  padding: 15px;
  margin: 5px 0 22px 0;
  display: inline-block;
  border: none;
  background: #f1f1f1;
}

.input:focus{
  background-color: #ddd;
  outline: none;
}

hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}

/* Set a style for all buttons */
.signupbtn {
  background-color: orange;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}
.signupbtn:hover {
  opacity:1;
}

/* Extra styles for the cancel button */
.

/* Float cancel and signup buttons and add an equal width */
.signupbtn {
  float: left;
  width: 50%;
}

/* Add padding to container elements */
.container {
  padding: 16px;
}

/* Clear floats */
.clearfix::after {
  content: "";
  clear: both;
  display: table;
}

/* Change styles for cancel button and signup button on extra small screens */
@media screen and (max-width: 300px) {
   .signupbtn {
     width: 100%;
  }
}
</style>
<!--style-->
<form style="border:1px solid #ccc">
  <div class="container" style="width:100%; margin-left:300px; margin-top:150px;">
   <h1 style="color:orange;">Ajouter un utilisateur</h1>
    <p  style="color:orange;">Veuillez remplir les champs.</p>
    <hr>

    <label for="email"  style="color:orange;" ><b>Login</b></label>
     <asp:TextBox ID="logi" class="input" placeholder="Entrer login" name="email" required runat="server"></asp:TextBox>
    <label for="psw"  style="color:orange;"><b>Mot de passe</b></label>
   
    <asp:TextBox ID="pwd" class="input" placeholder="Entrer le mot de passe" name="psw" required runat="server"></asp:TextBox>
  
    
    

    <div class="clearfix">
        <asp:Button ID="Button_log" class="signupbtn" runat="server" Text="confirmer" 
            onclick="Button_log_Click" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
  </div>
</form>


</asp:Content>

