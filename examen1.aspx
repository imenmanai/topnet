<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="examen1.aspx.cs" Inherits="examen1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title></title>

    <!-- Font Icon -->
    <link rel="stylesheet" href="examen/fonts/material-icon/css/material-design-iconic-font.min.css">
    <link rel="stylesheet" href="examen/vendor/jquery-ui/jquery-ui.min.css">

    <!-- Main css -->
    <link rel="stylesheet" href="examen/csss/style.css">
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
    <body >

    <div class="main" style="width:100%; margin-left:250px; margin-top:50px;">
        
       
          <h1 style="color:#E3761C;">créer un examen</h1>
        <div class="container" >
            <form id="booking-form" class="booking-form" method="POST">
                <div class="form-group">
                    <div class="form-destination">
                        <label for="destination">Titre examen:</label>
                       <!-- <input type="text" id="destination" name="destination" placeholder="EG. HAWAII" />-->
                        <asp:TextBox ID="destination" name="destination" runat="server"  placeholder="psy"></asp:TextBox>
                    </div>
                    <div class="form-date-from form-icon">
                        <label for="date_from">Durée</label>
                       <!-- <input type="text" id="date_from" class="date_from" placeholder="Pick a date" />-->
                        <asp:TextBox ID="date_from" class="date_from" placeholder="20 min"  runat="server"></asp:TextBox>
                        <!-- <span class="icon"><i class="zmdi zmdi-calendar-alt"></i></span> -->
                    </div>
                    <div class="form-date-to form-icon">
                        <label for="date_to">Délai</label>
                       <!-- <input type="text" id="date_to" class="date_to" placeholder="Pick a date" />-->
                         <asp:TextBox ID="date_to" class="date_to" placeholder="30 jours"  runat="server"></asp:TextBox>
                        <!-- <span class="icon"><i class="zmdi zmdi-calendar-alt"></i></span> -->
                    </div>
                    <div class="form-quantity">
                        <label for="quantity">Nombre</label>
                        <span class="modify-qty plus" onClick="Tang()"><i class="zmdi zmdi-chevron-up"></i></span>
                      <!--  <input type="number" name="quantity" id="quantity" value="0" min="0" class="nput-text qty text">-->
                       <asp:TextBox ID="quantity" name="quantity"  class="nput-text qty text" value="0" min="0"  runat="server"></asp:TextBox>
                        <span class="modify-qty minus" onClick="Giam()"><i class="zmdi zmdi-chevron-down"></i></span>
                    </div>

                    <div class="form-submit">
                        <!--<input type="submit" id="submit" class="submit" value="Book now" />-->
                        <asp:Button ID="submit" type="submit" class="submit"  runat="server" 
                            Text="Valider" onclick="submit_Click" />
                    </div>
                </div>
            </form>
        </div>
        

    <asp:GridView ID="GV" class="table table-bordered" runat="server" 
              AutoGenerateColumns="False"  AllowPaging="True" DataKeyNames="idQuestion" 
              OnPageIndexChanging="PaginateTheData" PageSize="5" PagerSettings-Mode="Numeric" 
              OnRowDataBound="ReSelectSelectedRecords" BackColor="white">   
            

<Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:CheckBox ID="chkSelect" runat="server" />
   </ItemTemplate>
   
   </asp:TemplateField>
    <asp:BoundField DataField="idQuestion" HeaderText="" />

    <asp:BoundField DataField="question"  HeaderText="Question" />
   
   
      
</Columns>
<PagerSettings Mode="NumericFirstLast" />
</asp:GridView>



<p><asp:Button ID="btnGetSelected" runat="server" Text="Valider examen" OnClick="GetSelectedRecords" /></p>


    </div>







    <!-- JS -->
    <script src="examen/vendor/jquery/jquery.min.js"></script>
    <script src="examen/vendor/jquery-ui/jquery-ui.min.js"></script>
    <script src="examen/js/main.js"></script>
</body>




</asp:Content>

