<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="accueil_admin.aspx.cs" Inherits="accueil_admin" %>

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


<body>
 

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
      <header class="section page-header">
        <!-- RD Navbar-->
      
      </header>
      <!-- Swiper-->
      <section class="section swiper-container swiper-slider swiper-slider-2 swiper-slider-3" data-loop="true" data-autoplay="5000" data-simulate-touch="false" data-slide-effect="fade">
        <div class="swiper-wrapper text-sm-left">
          <div class="swiper-slide context-dark" data-slide-bg="https://tuniscope.com/uploads/images/content/topnet-030118-1.jpg">
         <img src="https://tuniscope.com/uploads/images/content/topnet-030118-1.jpg" style="margin-left:10px;margin-top:10px;"/>
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
      <section class="section section-md bg-default">
        <div class="container">
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

            
               <div class="col-sm-6 col-lg-4">
              <div class="oh-desktop">
                <!-- Services Terri-->
                <article class="services-terri wow slideInUp">
                  <div class="services-terri-figure"><img src="images/exam.png" alt="" width="370" height="278"/>
                  </div>
                  <div class="services-terri-caption"><span></span>
                    <h5 class="services-terri-title"><a href="examen1ma.aspx">Ajouter un Examen</a></h5>
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
                    <h5 class="services-terri-title"><a href="consulter_examen.aspx">Consulter Examens</a></h5>
                  </div>
                </article>
                
              </div>
            </div>

                           <div class="col-sm-6 col-lg-4">
              <div class="oh-desktop">
                <!-- Services Terri-->
                <article class="services-terri wow slideInUp">
                  <div class="services-terri-figure"><img src="images/question.png" alt="" width="270" height="178"/>
                  </div>
                  <div class="services-terri-caption"><span></span>
                    <h5 class="services-terri-title"><a href="preparer_question.aspx">Ajouter question</a></h5>
                  </div>
                </article>
                
              </div>
            </div>

            
                           <div class="col-sm-6 col-lg-4">
              <div class="oh-desktop">
                <!-- Services Terri-->
                <article class="services-terri wow slideInUp">
                  <div class="services-terri-figure"><img src="images/affecter.png" alt="" width="270" height="178"/>
                  </div>
                  <div class="services-terri-caption"><span></span>
                    <h5 class="services-terri-title"><a href="affecter_examen.aspx">Affecter examen</a></h5>
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

