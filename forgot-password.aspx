<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgot-password.aspx.cs" Inherits="forgot_password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>SB Admin - Forgot Password</title>

  <!-- Custom fonts for this template-->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">

  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet">

</head>
<head runat="server">
    <title></title>
</head>
<body class="bg-dark">
<style>
body 
{ background-color: #2A2A6C;
}
</style>
    <form id="form1" runat="server">
    <div>
      <div class="container">
    <div class="card card-login mx-auto mt-5">
      <div class="card-header">Changer mot de passe</div>
      <div class="card-body">
        <div class="text-center mb-4">
          <h4>Mot de passe oublié?</h4>
          <p>Entrer votre Adresse Email.</p>
        </div>
        <form>
          <div class="form-group">
          
            <div class="form-label-group">
                
             <!--<input type="email" id="inputEmail" class="form-control" placeholder="Entrer email address" required="required" autofocus="autofocus">-->
         
             <asp:TextBox type="email" ID="inputEmail" class="form-control" placeholder="Entrer email address" required="required" autofocus="autofocus" runat="server"></asp:TextBox>
              <label for="inputEmail">Entrer email address</label>
            </div>
          </div>
      <asp:Button ID="Button1" class="btn btn-primary btn-block" runat="server" 
              Text="Confirmer" onclick="Button1_Click" />

        </form>
        <div class="text-center">
          
          <a class="d-block small" href="login.aspx">Login Page</a>
        </div>
      </div>
    </div>
  </div>
    </div>
    </form>
     <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

</body>
</html>
