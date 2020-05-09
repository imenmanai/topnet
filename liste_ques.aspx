<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="liste_ques.aspx.cs" Inherits="liste_ques" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">

<body  style="background-color:#2A2A6C;">

<form>

    <h1  style="margin-left:650px;color:#E3761C;">Liste question</h1>
<div class="container" style="width:100%; margin-left:250px; margin-top:150px;"> 


   

    <asp:GridView ID="GV" class="table table-bordered"   
            runat="server"   AutoGenerateColumns="False"  AllowPaging="True" 
        PageSize="5"   OnPageIndexChanging="GV_PageIndexChanging" 
        onpageindexchanged="GV_PageIndexChanged1" BackColor="white">   
            

<Columns>
   
    <asp:BoundField DataField="question" HeaderText="Question" />
      
</Columns>
<PagerSettings Mode="NumericFirstLast" />
</asp:GridView>


</div>
</div>
</form>


<hr />

   </body>


</asp:Content>

