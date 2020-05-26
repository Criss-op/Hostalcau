<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Componente_Cliente.ascx.cs" Inherits="ProyectoFinalSemestre.Vistas.Componentes.Componente_Cliente" %>
<link href="../../MetodoTabla/OcultarColumna.css" rel="stylesheet" />
<ul class="nav nav-tabs">
    <li class="nav-item">
        <a class="nav-link active" data-toggle="tab" href="#home"><font style="vertical-align: heredar;"> <font style = "vertical-align: heredar;"> Crear Cliente </font> </font></a>
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
                    <div class="form-group">
                        <label>Ingrese Rut</label>
                        <asp:TextBox ID="CRut" placeholder="1977846-7"  CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR Rut VACIO--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Por favor, Escriba un Rut"
                        ControlToValidate="CRut"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <div class="form-group">
                        <label>Ingrese Nombre</label>
                        <asp:TextBox ID="CNombre" placeholder="Nombre Cliente"  CssClass="form-control" runat="server"></asp:TextBox>
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
                        <label>Ingrese Apellido</label>
                        <asp:TextBox ID="CApellido" placeholder="Apellido Cliente" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR Apellido VACIO--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="Por favor, Escriba un Telefono"
                        ControlToValidate="CTelefono"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <div class="form-group">
                        <label>Ingrese Telefono</label>
                        <asp:TextBox ID="CTelefono" placeholder="Ingrese Telefono" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR Telefono VACIO--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ErrorMessage="Por favor, Escriba un Telefono"
                        ControlToValidate="CTelefono"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <div class="form-group">
                        <label>Ingrese Correo</label>
                        <asp:TextBox ID="CCorreo" placeholder="Diego@gmail.com" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR Correo VACIO--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="Por favor, Escriba un Correo"
                        ControlToValidate="CCorreo"
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
                        <label>Ingrese Descripcion</label>
                        <asp:TextBox ID="CDescripcion" placeholder="Ingrese Descripcion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR Descripcio VACIO--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ErrorMessage="Por favor, Escriba un Descripcion"
                        ControlToValidate="CDescripcion"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:Button ID="Agregar" OnClick="Agregar_Click" ValidationGroup="ADD" CssClass="btn btn-warning " runat="server" Text="Ingresar" />
                    <asp:Button ID="BtnEditar" ValidationGroup="ADD" CssClass="btn btn-info " OnClick="BtnEditar_Click" runat="server" Text="Editar" />
                    <br />
                    <br />
                    <br />
                    <div class="alert alert-dismissible alert-primary">
                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                        <strong></strong>
                        <asp:Label runat="server" ID="MensajeAdd"></asp:Label>
                    </div>
                    <%--BUSCAR--%>
                    <div class="input-group mb-3">
                        <asp:TextBox runat="server" class="form-control" ID="CBuscar" placeholder="Ingrese Nombre o Rut" aria-describedby="button-addon2">  </asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button runat="server" class="btn btn-outline-secondary" ID="Buscar" OnClick="Buscar_Click" Text="Buscar"></asp:Button>
                        </div>
                    </div>
                    <asp:GridView runat="server" ID="TablaCliente" OnRowCommand="TablaCliente_RowCommand" AllowPaging="true" OnPageIndexChanging="TablaCliente_PageIndexChanging" PageSize="5" AutoGenerateColumns="false" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="Rut_Cliente" HeaderText="Rut" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="Correo" HeaderText="Correo" />
                            <asp:BoundField DataField="EstadoCliente" HeaderText="Estado" />
                            <asp:BoundField DataField="DescripcionEstado" HeaderText="Descripcion" />
                            <asp:BoundField DataField="idestado" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" HeaderText="IdEstado" />
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
        <p>Ello</p>
        <%--   Vista Reportes--%>
    </div>
</div>






























