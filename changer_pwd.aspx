<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changer_pwd.aspx.cs" Inherits="changer_pwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">tr
  <meta name="author" content="">

  <title>SB Admin - changer mot de passe</title>

  <!-- Custom fonts for this template-->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">

  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet">

</head>
<body class="bg-dark">
    <form id="form1" runat="server">
    <div>
    
    
  <div class="container">
    <div class="card card-register mx-auto mt-5">
      <div class="card-header">Réinitialisation du mot de passe</div>
      <div class="card-body">
        <form>
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <div class="form-label-group">
                  <asp:TextBox TextMode="Password" ID="pwd" class="form-control" placeholder="Mot de passe" required="required" autofocus="autofocus" runat="server"></asp:TextBox>
                 <!-- <input type="text" id="firstName" class="form-control" placeholder="Mot de passe" required="required" autofocus="autofocus">-->
                  <label for="pwd">mot de passe</label>
                </div>
      
              </div>
              <div class="col-md-6">
                <div class="form-label-group">
                   <asp:TextBox TextMode="Password" ID="pwd1" class="form-control" placeholder="Mot de passe" required="required" autofocus="autofocus"  runat="server"></asp:TextBox>
                 <!-- <input type="text" id="lastName" class="form-control" placeholder="nouveau mot de passe" required="required">-->
                  <label for="pwd1">resaisir votre mot de passe</label>
                </div>
              </div>
            </div>
          </div>
        <asp:Button ID="Button1"  class="btn btn-primary btn-block" runat="server" 
              Text="Réinitialiser" onclick="Button1_Click" />
                      <asp:Label ID="Erreur" runat="server" Text="" Visible="false"></asp:Label>
        </form>
        <div class="text-center">
          <a class="d-block small mt-3" href="login.aspx">Page de connexion</a>
         
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
