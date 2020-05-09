<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.master" AutoEventWireup="true" CodeFile="consulter_examen.aspx.cs" Inherits="consulter_examen" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <head>

    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
    <body  style="background-color:#2A2A6C;">
    <form>



<h1  style="margin-left:650px;color:#E3761C;">Liste des examens</h1>
<div class="container" style="width:100%; margin-left:250px; margin-top:150px;"> 
 <asp:GridView ID="GV" class="table table-bordered" style="width:100%;"  
            runat="server"   AutoGenerateColumns="False"  AllowPaging="True" 
        PageSize="8" onpageindexchanged="GV_PageIndexChanged" 
        onpageindexchanging="GV_PageIndexChanging" onrowcommand="GV_RowCommand" 
        onselectedindexchanged="GV_SelectedIndexChanged" 
        onrowdatabound="GV_RowDataBound" BackColor="white">   
            

<Columns>
   
    <asp:BoundField DataField="titreExamen" HeaderText="Examen" />

    <asp:BoundField DataField="duree" HeaderText="Durée" />
      <asp:BoundField DataField="etat" HeaderText="Etat" />
    <asp:TemplateField>
    
    <ItemTemplate>
        <asp:ImageButton ID="quest" runat="server" CommandName="consulter" ImageUrl="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAb1BMVEX///8AAADj4+Pz8/P39/f8/PxWVlY+Pj7FxcW+vr61tbXNzc2FhYWwsLDg4OAyMjJ1dXUnJyfS0tJfX1/p6ektLS1vb28bGxuhoaE2NjaSkpIJCQkgICBhYWGenp4ZGRmJiYlKSkp8fHxDQ0NoaGgVMOT8AAAFAElEQVR4nO2d55aqMBSFkV4UFcGCXe/7P+MdZAhIQEAP4CT7+zVrjZQNyckpSVAUAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABUY+g9aSvKnMfYNEWGEfjCLp4v16h4dzvtJyv58iO6r9WIazwI//Kta9cC5HK9RJqqefXQ9XpxAH/uGu6A7p+O5UVmZ8/Hk/AGZurq9RZ3F5US3rfrFMlV3/Yk6pnLtqmNLqcKb7gjUZeym3tiCnjDsG6G6jJv9JVbW8BY9yEtZeOOL9ON5b/oS5rE/qj7X6lVeiuWOJS+MB5CXEocj6AvWg+lLWAcD6/PMQfUlmEOOH/YQ3Y/HsgfSF9xH0ZdwH6Kt+v9G05fwr+/BQ+/DeenGrU/P3DiNLe/BqTdHx12Ore2XZT8+gDr8AFGP2UN89R0NNOdErM8fb4So405qVb/tBabQvUZ1HBemGYuoNw4XQnQnJtCnUZrQ/Sayok1zDrU9pvapwOBAdCvz29ZTQ003dC1Uve2NKjVw+NBV3dLchunyIWzoErWO7Qf6jBXFHcy3dS1J25K8ydXbXpxPcf2GLAtJpmf+5tDoEFx7Mmu8zIziMs47Aim64KJNpKNT5Fvf6IwXgsu2fbIUreXSVSBBJs1qnwIMCXrjupM+4/r5FU3ewqm2485cx+adLYNg5Lh2MKkhwTC/KEnw4mJtaheXKxIEnfHQutGo3Qu4HM8C1Sn/zA7T51dJIPHc0hOnEGg+nbCuU6+f7oigobaTGH5+oYlVbIKvrPKl8DuDYvBv0VB9gssUr+O/Tl8tC+4IxbOdNLo3PkVoUxgH3cYfF7w6inFx3yCR5DEWrEyb9EchGUFSTX7ZUDWS4DR31drld3KJOsXl9y+CYo1kOkXubDc30ZS8oZK44btaiRSOxY8dZedrb7TyvkOS9Kpwp1JI4t3CC2lfBFh2fu2vWVULpClbz9n5ukQnF3YUTf6m0g0nSsmwQE3tdJja123k2DRnnrBe3q1JsIeuEd0HVxHv9sTrMd89IXuJVPnZkouqb4jOy+zMtOOB0+xAGlszmWyeMyhHotMyh8KoCTGXVo2FPWQWnsStSjj2YGUKltSr+u/KfuS87cphiU2XIZsoV7A2JPHEg1t2yopyzibPvwcVnYIVWegmQzBHwqCrz7PHxvt/m6IvpfESd+QNarLMWj7h/FDW1Ph/PVdQAv4HLxv4e/xGOVTGKyEz0fxYUXak+L5Yf+z7PEw7me36YZ+ZUt5/KI/A9b8IKeuLyQ1RVkBZX+Oj9XJEw/suWWagoo++j0lUf8mIslGWa/nLcgVD58xb5izoFEsaGE6HEKcFLMfGRbJWOWTjM2uz2v98wlKCdyh+P5TAloo/Hkrg00jgl4ofW0gQH0oQ40uQpxE/1yZBvlSCnLcEdQsJak8S1A/FrwFLUMeXYC6GBPNpJJgTJcG8NgnmJkowv1SCOcISzPNWxJ+rr0iw3kKCNTMSrHuSYO2aBOsPFfHXkCoSrAOWYC23Iv56fEWCPRUU8ffFUCTY20T5vtdIvT+NIsEeQ4r4+0QpEuz1pYi/X1uC6HvuJYi+b2KC6HtfJoi+f2mC6HvQJoi+j/ADwfeCfiD6ft4Jou/J/kDwffV/EfvbCL8I/n2LFMG/UZIh9HdmcoT+VlABkb/3VEbUb3YBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMf8BRoN8g3lX7zwAAAAASUVORK5CYII=" style="width:30px;"/>
    
    </ItemTemplate>
    </asp:TemplateField>
      
</Columns>
     
<PagerSettings Mode="NextPreviousFirstLast" />
</asp:GridView>
<asp:Label ID="imeni" runat="server" Text=""></asp:Label>

</div>
</div>
</form>


<hr />

     </body>
</asp:Content>

