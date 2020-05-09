<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="consulter.aspx.cs" Inherits="consulter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
<body  style="background-color:#2A2A6C;">
<h1 style="margin-left:650px;color:#E3761C;">Les candidats</h1>
 <div class="card mb-3"  style="width:100%; margin-left:250px; margin-top:50px;">
          <div class="card-header">
              
              <asp:TextBox ID="myInput" runat="server"></asp:TextBox>
              <asp:Button ID="search" runat="server" Text="rechercher" 
                  onclick="search_Click" />
            <i class="fas fa-table"></i>
            Liste des candidats</div>
          <div class="card-body">
            <div class="table-responsive">
     
     <asp:GridView ID="dataTables" class="table table-bordered"  width="80%" cellspacing="0" 
                    runat="server" AutoGenerateColumns="false" 
                    OnRowCommand ="datables_rowCommand" AllowPaging="True"  PageSize="4" 
                    onpageindexchanging="dataTables_PageIndexChanging" 
                    onpageindexchanged="dataTables_PageIndexChanged">
    
                 
    <Columns >
   
    <asp:BoundField DataField="idUser" HeaderText="ID" />
 <asp:BoundField DataField="nom" HeaderText="Nom" />
  <asp:BoundField DataField="prenom" HeaderText="Prenom" />
   <asp:BoundField DataField="email" HeaderText="Email" />
    <asp:BoundField DataField="matricule" HeaderText="Matricule" />
     <asp:BoundField DataField="numTel" HeaderText="Numéro Téléphone" />
    
   <asp:ButtonField ButtonType="Button" CommandName="modifier" HeaderText="modifier" Text="modifier"  />
   </Columns>   


         <PagerSettings Mode="NumericFirstLast" />


     </asp:GridView>

            
            </div>
          </div>
         
   

       <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Page level plugin JavaScript-->
  <script src="vendor/datatables/jquery.dataTables.js"></script>
  <script src="vendor/datatables/dataTables.bootstrap4.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="js/sb-admin.min.js"></script>

  <!-- Demo scripts for this page-->
  <script src="js/demo/datatables-demo.js"></script>

    </body>

</asp:Content>

