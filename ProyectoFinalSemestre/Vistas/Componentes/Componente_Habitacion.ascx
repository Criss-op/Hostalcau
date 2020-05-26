<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Componente_Habitacion.ascx.cs" Inherits="ProyectoFinalSemestre.Vistas.Componentes.Componente_Habitacion" %>
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
                    <%--      ID--%>
                    <asp:HiddenField runat="server" ID="CNumero" />
                    <%--    ID--%>
                    <div class="form-group">
                        <label>Ingrese Cuarto</label>
                        <asp:TextBox ID="CCuarto" TextMode="Number" placeholder="Numero Habitacion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR Numero VACIO--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                        ErrorMessage="Por favor, Escriba un Numero"
                        ControlToValidate="CCuarto"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <div class="form-group">
                        <label>Ingrese Capacidad</label>
                        <asp:TextBox ID="CCapacidad" placeholder="Capacidad Habitacion" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR Capacidad--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                        ErrorMessage="Por favor, Escriba la capacidad"
                        ControlToValidate="CCapacidad"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <div class="form-group">
                        <label>Ingrese Precio</label>
                        <asp:TextBox ID="CPrecio" placeholder="Precio Habitacion" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR Precio Vacio--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Por favor, Escriba una Precio"
                        ControlToValidate="CPrecio"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <div class="form-group">
                        <label>Ingrese Descripcion</label>
                        <asp:TextBox ID="CDescripcion" placeholder="Descripcion" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <%-- VALIDAR Capacidad--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="Por favor, Escriba la capacidad"
                        ControlToValidate="CDescripcion"
                        ValidationGroup="ADD"
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Tipo de Usuario:"></asp:Label>
                        <br />
                        <asp:DropDownList ID="DropEstado" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <asp:Button ID="BtnEditar" ValidationGroup="ADD" CssClass="btn btn-info " OnClick="BtnEditar_Click" runat="server" Text="Editar" />
                    <asp:Button ID="Agregar" ValidationGroup="ADD" OnClick="Agregar_Click" CssClass="btn btn-warning " runat="server" Text="Ingresar" />
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
                            <asp:Button runat="server" class="btn btn-outline-secondary" OnClick="Buscar_Click" ID="Buscar" Text="Buscar"></asp:Button>
                        </div>
                    </div>
                    <%-- TABLA--%>
                    <asp:GridView runat="server" ID="TablaHabitacion" OnRowCommand="TablaHabitacion_RowCommand" OnPageIndexChanging="TablaHabitacion_PageIndexChanging" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="Cuarto" HeaderText="Cuarto" />
                            <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="${0:N0}" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataField="NombreEstado" HeaderText="Estado" />
                            <asp:BoundField DataField="IdEstado" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" />
                            <asp:BoundField DataField="Numero" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" />
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






