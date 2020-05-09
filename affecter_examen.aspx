<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="affecter_examen.aspx.cs" Inherits="affecter_examen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<head>
    

    <style type="text/css">
.modalPopup
{ background-color:White;
  width:800px;
  border:3px solid orange;
  height:450px;
}
.modalPopup .header
{background-color: Orange;
 height:30px;
 color:White;
 line-height:30px;
 text-align:center;
 font-weight:bold;
}
.modalPopup .footer
{padding:3px;
}
.modalPopup .button
{height:23px;
 color:White;
 line-height:23px;
 text-align: center;
 font-weight:bold;
 cursor:pointer;
 background-color:Red;
 border: 1px solid orange;
 
 
}
</style>
</head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
<body  style="background-color:#2A2A6C;">
 <h1 style="margin-left:650px;color:#E3761C;"> Affecter Un examen</h1>
    <div class="card mb-3" style="width:100%; margin-left:250px; margin-top:150px;">
<!-- <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
   <asp:UpdatePanel ID="panel1" runat="server"><ContentTemplate>-->


          <div class="card-header">
              <asp:TextBox ID="myInput" runat="server"></asp:TextBox>
              <asp:Button ID="search" runat="server" Text="rechercher" 
                  onclick="search_Click" />
                  
     

          </div>
          <div class="card-body">
            <div class="table-responsive">

            <label>Choisir un examen</label>

            <asp:DropDownList ID="DropDownList12" runat="server">
       
       </asp:DropDownList>
  
                  <label>Poste:</label>
  
          
       <asp:TextBox ID="nom_poste" runat="server"  placeholder="Nom poste"></asp:TextBox>
    
    
                <asp:Button ID="affecter" runat="server" Text="Valider" onclick="affecter_Click" />
      


     <asp:GridView ID="dataTables" class="table table-bordered"  width="80%" cellspacing="0" 
                    runat="server" AutoGenerateColumns="false" 
                    OnRowCommand ="datables_rowCommand" AllowPaging="True"  PageSize="4" 
                    onpageindexchanging="dataTables_PageIndexChanging" 
                    onpageindexchanged="dataTables_PageIndexChanged" 
                    onrowdatabound="dataTables_RowDataBound" DataKeyNames="idUser" >
    
                 
    <Columns >
   <asp:TemplateField>
    
   <ItemTemplate>
       <asp:CheckBox ID="ajout" runat="server" />
   </ItemTemplate>
   </asp:TemplateField>
  
 <asp:BoundField DataField="idUser" HeaderText="" />

 <asp:BoundField DataField="nom" HeaderText="Nom" />
  <asp:BoundField DataField="prenom" HeaderText="Prenom" />
   <asp:TemplateField>
  
   <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Bind("email") %>'></asp:Label>
        </ItemTemplate>
   </asp:TemplateField>
      
   
    <asp:BoundField DataField="matricule" HeaderText="Matricule" />
     <asp:BoundField DataField="numTel" HeaderText="Numéro Téléphone" />
 

   

   </Columns>   
         


         <PagerSettings Mode="NumericFirstLast" />

         
     </asp:GridView>
     
       
                <asp:Label ID="test" runat="server" Text=""></asp:Label>
             <asp:Label ID="test2" runat="server" Text=""></asp:Label>
              <asp:Label ID="test3" runat="server" Text=""></asp:Label>
               <asp:Label ID="test4" runat="server" Text=""></asp:Label>
            </div>
           
          </div>
    <!-- </ContentTemplate></asp:UpdatePanel>-->
   
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

