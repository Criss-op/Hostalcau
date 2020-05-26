<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Componente_Usuario.ascx.cs" Inherits="ProyectoFinalSemestre.Vistas.Componentes.Componente_Usuario" %>
<link href="../../MetodoTabla/OcultarColumna.css" rel="stylesheet" />
<ul class="nav nav-tabs">
    <li class="nav-item">
        <a class="nav-link active" data-toggle="tab" href="#home"><font style="vertical-align: heredar;"> <font style = "vertical-align: heredar;"> Crear Usuario </font> </font></a>
    </li>
    <li class="nav-item">
        <a class="nav-link" data-toggle="tab" href="#profile"><font style="vertical-align: heredar;"> <font style = "vertical-align: heredar;"> Reporte </font> </font></a>
    </li>
</ul>
<div id="myTabContent" class="tab-content">
    <div class="tab-pane fade show active" id="home">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <a runat="server" class="list-group-item list-group-item-control">
                    <%--ID USUARIO--%>
                 <%--      ID--%>
                <asp:HiddenField runat="server" ID="CIdUser" />
                    
                    <%--    ID--%>
                    <%--ID USUARIO--%>
                    <div class="form-group">
                        <label>Ingrese Nombre</label>
                        <asp:TextBox ID="CNombre" placeholder="Nombre usuario" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR NOMBRE VACIO--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                        ErrorMessage="Por favor, Escriba un Nombre"
                        ControlToValidate="CNombre"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <div class="form-group">
                        <label>Ingrese Clave</label>
                        <asp:TextBox ID="CClave" placeholder="Clave Usuario" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR CONTRASEÑA--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                        ErrorMessage="Por favor, Escriba una Clave"
                        ControlToValidate="CClave"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Tipo de Usuario:"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DropEstado" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Rol de Usuario:"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DropRol" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <asp:Button ID="Agregar" ValidationGroup="ADD" OnClick="Agregar_Click" CssClass="btn btn-warning " runat="server" Text="Ingresar" />
                    <asp:Button ID="BtnEditar" ValidationGroup="ADD" OnClick="BtnEditar_Click" CssClass="btn btn-info " runat="server" Text="Editar" />
                    <br />
                    <br />
                    <br />
                    <div class="alert alert-dismissible alert-primary">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                        <strong></strong>
                        <asp:Label runat="server" ID="MensajeAdd"></asp:Label>
                    </div>
                </a>
                <a runat="server" class="list-group-item list-group-item-control">
                    <%--BUSCAR--%>
                    <div class="input-group mb-3">
                        <asp:TextBox runat="server" class="form-control" ID="CBuscar" placeholder="Ingrese Nombre" aria-describedby="button-addon2">  </asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button runat="server" class="btn btn-outline-secondary" ID="Buscar" OnClick="Buscar_Click" Text="Buscar"></asp:Button>
                        </div>
                    </div>
                    <%-- TABLA--%>
                    <asp:GridView runat="server" ID="TablaUsuario" OnRowCommand="TablaUsuario_RowCommand" AllowPaging="true" OnPageIndexChanging="TablaUsuario_PageIndexChanged" PageSize="5" AutoGenerateColumns="false" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="idUsuario" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" HeaderText="ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:BoundField DataField="Rol" HeaderText="Rol" />
                            <asp:BoundField DataField="Clave" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" HeaderText="Clave" />
                            <asp:BoundField DataField="idEstado" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" HeaderText="IdEstado" />
                            <asp:BoundField DataField="idRol" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" HeaderText="IdRol" />
                            <asp:ButtonField ButtonType="Link" HeaderText="Editar" CommandName="Editar" ControlStyle-CssClass=" btn btn-primary w-auto  glyphicon glyphicon-pencil" Text="<i class='fas fa-user-edit'></i>" />
                            <asp:ButtonField ButtonType="Link" HeaderText="Eliminar" CommandName="Eliminar" ControlStyle-CssClass=" btn btn-danger w-auto  glyphicon glyphicon-pencil" Text="<i class='fas fa-trash'></i>" />
                        </Columns>
                        <HeaderStyle CssClass="table-info" />
                        <EmptyDataTemplate>
                            <div class="alert alert-despedible alert-danger">
                                <button type="button" class="close" data-picks="alert">& times</button>
                                <strong>no Existen Usuarios</strong>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </a>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="tab-pane fade" id="profile">
        <p></p>
        <%--   Vista Reportes--%>
    </div>
</div>










































































































