<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>SB Admin - Login</title>

  <!-- Custom fonts for this template-->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">

  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet">

</head>
<head runat="server">
    <title></title>
</head>
<body>
<style>
body 
{ background-color: #2A2A6C;
}
</style>



    <form id="form1" runat="server">
    <div>
    
  <div class="container">
    <img src="topnet.png" style="width:200px;height:100px;"/>
    <div class="card card-login mx-auto mt-5">
      <div class="card-header"><p style="  text-align: center;font-size:30px;color:Orange;font-style: oblique;">Connexion</p></div>
      <div class="card-body">
        <form>
          <div class="form-group">
            <div class="form-label-group">
                  
               <asp:TextBox  ID="inputEmail" class="form-control" placeholder="Nom d'utilisateur" required="required" autofocus="autofocus" runat="server"></asp:TextBox>
             <label for="inputEmail">Nom utilisateur</label>
            </div>
             
          </div>
          <div class="form-group">
            <div class="form-label-group">
           <!-- <asp:TextBox id="inputPassword"  placeholder="Password" required="required" runat="server"></asp:TextBox>-->
             <asp:TextBox ID="inputPasswordee" TextMode="Password" class="form-control" placeholder=" Password" required="required" runat="server"></asp:TextBox>
            
                  <label for="inputPasswordee">Mot de passe</label>
            </div>
          </div>
         
         <!-- <Button  href="index.html" Text="se connecter">-->

<asp:Button ID="Button_login" class="btn btn-primary btn-block" runat="server" 
              Text="Se connecter" onclick="Button1_Click" />
        </form>
        <div class="text-center">
          <a class="d-block small" href="forgot-password.aspx">Mot de passe oublié ?</a>
        </div>
        
              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
      </div>
    </div>
  </div>
    </div>
    </form>
     <!-- Bootstrap core JavaScript-->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

</body>
</html>
