﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="acceuilaspx.aspx.cs" Inherits="acceuilaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <head>
    <title>Home</title>
    <meta name="format-detection" content="telephone=no">
    <meta name="viewport" content="width=device-width, height=device-height, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta charset="utf-8">
    <link rel="icon" href="images/favicon.ico" type="image/x-icon">
    <!-- Stylesheets-->
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Roboto:100,300,300i,400,500,600,700,900%7CRaleway:500">
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/fonts.css">
    <link rel="stylesheet" href="css/style.css">

  </head>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">

    
<body style="background-color:#2A2A6C;">
 <div>
     <asp:Button ID="logout" runat="server" Text="Déconnecter" 
         style="margin-left:92%;" onclick="logout_Click1"/>
 
 
 </div>
    
       <div class="preloader">
      <div class="wrapper-triangle">
        <div class="pen">
          <div class="line-triangle">
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
          </div>
          <div class="line-triangle">
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
          </div>
          <div class="line-triangle">
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
            <div class="triangle"></div>
          </div>
        </div>
      </div>
    </div>
    <div class="page">
      <!-- Top Banner-->
      <!-- Page Header-->
    
      <!-- Swiper-->
      <section class="section swiper-container swiper-slider swiper-slider-2 swiper-slider-3" data-loop="true" dataautoplay="5000" data-simulate-touch="false" data-slide-effect="fade">
        <div class="swiper-wrapper text-sm-left" style="width:100%">
          <div class="swiper-slide context-dark" data-slide-bg="https://tuniscope.com/uploads/images/content/topnet-030118-1.jpg" style="width:100%;">
         <img src="https://tuniscope.com/uploads/images/content/topnet-030118-1.jpg" style="margin-left:400px;margin-top:0px; width:100%;"/>
            <div class="swiper-slide-caption section-md">
              <div class="container">
                <div class="row">
                  <div class="col-sm-9 col-md-8 col-lg-7 col-xl-7 offset-lg-1 offset-xxl-0">
                    
                    
                  </div>
                </div>
              </div>
            </div>
          </div>
    
        </div>
        <!-- Swiper Pagination-->
        <div class="swiper-pagination" data-bullet-custom="true"></div>
        <!-- Swiper Navigation-->
        <div class="swiper-button-prev">
          <div class="preview">
            <div class="preview__img"></div>
          </div>
          <div class="swiper-button-arrow"></div>
        </div>
        <div class="swiper-button-next">
          <div class="swiper-button-arrow"></div>
          <div class="preview">
            <div class="preview__img"></div>
          </div>
        </div>
      </section>
      <!-- What We Offer-->
      <section class="section section-md bg-default" style="margin-left:400px;">
        <div class="container" >
          <h3 class="oh-desktop"><span class="d-inline-block wow slideInDown">Bienvenue   <asp:Label class="d-inline-block wow slideInDown" ID="user" runat="server"></asp:Label></span></h3>
          <div class="row row-md row-30">
            <div class="col-sm-6 col-lg-4">
              <div class="oh-desktop">
                <!-- Services Terri-->
                <article class="services-terri wow slideInUp">
                  <div class="services-terri-figure"><img src="images/usser.ico" alt="" width="370" height="278"/>
                  </div>
                  <div class="services-terri-caption"><span ></span>
                    <h5 class="services-terri-title"><a href="ajout_login.aspx">Ajouter utilisateur</a></h5>
                  </div>
                </article>

              </div>
            </div>  
           
                 <div class="col-sm-6 col-lg-4">
              <div class="oh-desktop">
                <!-- Services Terri-->
                <article class="services-terri wow slideInUp">
                  <div class="services-terri-figure"><img src="images/consulter.png" alt="" width="370" height="278"/>
                  </div>
                  <div class="services-terri-caption"><span></span>
                    <h5 class="services-terri-title"><a href="consulter_admin.aspx">Consulter utilisateurs</a></h5>
                  </div>
                </article>
                
              </div>
        

          </div>
          </div>
        </div>
      </section>
<!---rien-->

      <!-- Section CTA-->
      
      <!-- Our Shop-->
      
    <!-- Global Mailform Output-->
    <div class="snackbars" id="form-output-global"></div>
    <!-- Javascript-->
    <script src="js/core.min.js"></script>
    <script src="js/script.js"></script>
  </body>
 

</asp:Content>

