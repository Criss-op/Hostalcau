<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProyectoFinalSemestre.index" %>
<%@ Register Src="~/Vistas/Componentes/Componente_Habitacion.ascx" TagPrefix="uc1" TagName="Componente_Habitacion" %>
<%@ Register Src="~/Vistas/Componentes/Componente_Cliente.ascx" TagPrefix="uc1" TagName="Componente_Cliente" %>
<%@ Register Src="~/Vistas/Componentes/Componente_Reserva.ascx" TagPrefix="uc1" TagName="Componente_Reserva" %>
<%@ Register Src="~/Vistas/Componentes/Componente_Usuario.ascx" TagPrefix="uc1" TagName="Componente_Usuario" %>
<%@ Register Src="~/Vistas/Componentes/Componente_Configuracion.ascx" TagPrefix="uc1" TagName="Componente_Configuracion" %>
<%@ Register Src="~/Vistas/Componentes/Componente_Bienvenida.ascx" TagPrefix="uc1" TagName="Componente_Bienvenida" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Proyecto Hostal</title>
    <link href="https://stackpath.bootstrapcdn.com/bootswatch/4.4.1/united/bootstrap.min.css" rel="stylesheet" integrity="sha384-bzjLLgZOhgXbSvSc5A9LWWo/mSIYf7U7nFbmYIB2Lgmuiw3vKGJuu+abKoaTx4W6" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.0/animate.min.css"/>  
</head>
<body>
   
    <form id="form1" runat="server" method="post">    
    <asp:ScriptManager runat="server"></asp:ScriptManager>


        <asp:UpdatePanel runat="server" ID="ubarra" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <nav class="navbar navbar-dark bg-dark navbar-expand-lg">     
                    <!-- Brand/logo -->
                        <a class="navbar-brand" href="#">
                        <img src="imagenes/Casanaranja.png" alt="logo" style="width:40px;">
                        </a>

                      <!-- Links -->
                    <asp:LinkButton CssClass="navbar-brand active" runat="server" OnClick="Menu_home_Click" ID="Menu_home">Home</asp:LinkButton>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarColor01">
                        <ul class="navbar-nav mr-auto">                          
                                <li class="nav-item">
                                 <asp:LinkButton Visible="false" CssClass="nav-link"  runat="server" OnClick="Menu_Usuario_Click" ID="Menu_Usuario">Menu Usuario</asp:LinkButton>                      
                            </li>
                            <li class="nav-item">
                                 <asp:LinkButton Visible="false" CssClass="nav-link"  runat="server" OnClick="Menu_Cliente_Click" ID="Menu_Cliente">Registrar Cliente</asp:LinkButton>                        
                            </li>
                            <li class="nav-item">
                                <asp:LinkButton Visible="false" CssClass="nav-link"  runat="server" OnClick="Menu_Habitacion_Click" ID="Menu_Habitacion">Registrar Habitacion</asp:LinkButton>                             
                            </li>
                            <li class="nav-item">
                                <asp:LinkButton Visible="false" CssClass="nav-link" runat="server"  OnClick="Menu_Reservacion_Click" ID="Menu_Reservacion">Realizar Reservacion</asp:LinkButton>                             
                            </li>
                        </ul>
                        <div class="form-inline my-2 my-lg-0"> 
                            <span class="badge badge-success" style="width: 100px ; height: 20px;"  > <%= Session["nombreUsuario"] %> </span>
                           
                          
                        
                            <asp:LinkButton runat="server" ID="lodin"  OnClick="lodin_Click"  class="btn btn-success btn-sm my-2 my-sm-0">Login <i class="fas fa-user "></i></asp:LinkButton>
                            <asp:LinkButton runat="server" Visible="false"  ID="salir" OnClick="salir_Click" class="btn btn-success btn-sm my-2 my-sm-0">Salir <i class="fas fa-sign-out-alt"></i></i></asp:LinkButton>
                        </div>
                    </div>
                </nav>
            </ContentTemplate>
        </asp:UpdatePanel>




        <asp:UpdatePanel runat="server" ID="ucontenido" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div class="conteiner-fluid">
                    <asp:MultiView runat="server" ID="mcontenido">
                        <asp:View runat="server" ID="vHabitacion">
   
                            <uc1:Componente_Habitacion runat="server" ID="Componente_Habitacion" />
                        </asp:View>
                        <asp:View runat="server" ID="vCliente">
                        
                            <uc1:Componente_Cliente runat="server"  ID="Componente_Cliente" />
                        </asp:View>
                        <asp:View runat="server" ID="vReserva">
                         
                            <uc1:Componente_Reserva runat="server" ID="Componente_Reserva" />
                        </asp:View>

                        <asp:View runat="server" ID="vUsuario">
               
                            <uc1:Componente_Usuario runat="server" ID="Componente_Usuario" />
                        </asp:View>
                        <asp:View runat="server" ID="vConfiguracion">
                      
                            <uc1:Componente_Configuracion runat="server" ID="Componente_Configuracion" />
                        </asp:View>
                        <asp:View runat="server" ID="vBienvenida">
                    
                            <uc1:Componente_Bienvenida runat="server" ID="Componente_Bienvenida" />
                        </asp:View>
                    </asp:MultiView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--  Modal--%>
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel runat="server" ID="uModal" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Ingresar Al sistema</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                              <div class="form-group">
                                  <label for="tUsuario">Usuario:</label>
                                  <asp:TextBox runat="server" ID="tusuario" placeholder="Nombre Usuario" Cssclass="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator
                                      runat="server"
                                     display="Dynamic"
                                      ForeColor="Red"
                                      ControlToValidate="tusuario"
                                      ErrorMessage="Usuario Obligatorio"
                                      ValidationGroup="g1"                                      
                                      >         
                                  </asp:RequiredFieldValidator>
                              </div>
                                <div class="form-group">
                                    <label for="tclave">Clave:</label>
                                    <asp:TextBox runat="server" ID="tclave" TextMode="Password" placeholder="Clave" CssClass="form-control"></asp:TextBox>
                                      <asp:RequiredFieldValidator
                                      runat="server"
                                     display="Dynamic"
                                      ForeColor="Red"
                                      ControlToValidate="tclave"
                                      ErrorMessage="Clave Obligatoria"
                                      ValidationGroup="g1"                                      
                                      >         
                                  </asp:RequiredFieldValidator>
                                </div>
                                <asp:Label runat="server" ID="ms_validarUsuario" CssClass="text-danger"></asp:Label>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-info" data-dismiss="modal">Close</button>
                                <asp:Button runat="server" Text="Ingresar" ValidationGroup="g1"  OnClick="bValidarUsuario_Click" ID="bValidarUsuario"  CssClass="btn btn-primary"/>                               
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
    
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</body>
</html>
