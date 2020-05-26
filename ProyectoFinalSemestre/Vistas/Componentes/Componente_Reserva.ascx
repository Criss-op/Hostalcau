<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Componente_Reserva.ascx.cs" Inherits="ProyectoFinalSemestre.Vistas.Componentes.Componente_Reserva" %>
<link href="../../MetodoTabla/OcultarColumna.css" rel="stylesheet" />
<ul class="nav nav-pills">
    <li class="nav-item">
        <a class="nav-link active" data-toggle="tab" href="#home"><font style="vertical-align: heredar;"> <font style = "vertical-align: heredar;"> Realizar Reserva </font> </font></a>
    </li>
    <li class="nav-item">
        <a class="nav-link" data-toggle="tab" href="#profile"><font style="vertical-align: heredar;"> <font style = "vertical-align: heredar;"> Reporte </font> </font></a>
    </li>
        <li class="nav-item">
        <a class="nav-link" data-toggle="tab" href="#misreservas"><font style="vertical-align: heredar;"> <font style = "vertical-align: heredar;">Mis Reservaciones</font> </font></a>
    </li>
</ul>



<%--Container Para Centrar Panel--%>

<div class="container">
    <div class="abs-center">


        <div id="myTabContent" class="tab-content">
            <div class="tab-pane fade show active" id="home">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <asp:MultiView runat="server" ID="VistasReserva">

                            <asp:View ID="TablaHabitacion" runat="server">
                                 <%-- Borde Cuadro Blanco--%>
                              <a runat="server" class="list-group-item list-group-item-control">
                                <%-- TABLA--%>
                                <asp:GridView runat="server" ID="TablaHabitacionesReserva" OnRowCommand="TablaHabitacionesReserva_RowCommand" OnPageIndexChanging="TablaHabitacionesReserva_PageIndexChanging" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" CssClass="table table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="Cuarto" HeaderText="Cuarto" />
                                        <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="${0:N0}" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="Numero" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" />
                                        <asp:ButtonField ButtonType="Link" HeaderText="Reservar" CommandName="Reservar" ControlStyle-CssClass=" btn btn-primary w-auto  glyphicon glyphicon-pencil" Text="<i class='fas fa-user-edit'></i>" />
                                    </Columns>
                                    <HeaderStyle CssClass="table-info" />
                                    <EmptyDataTemplate>
                                        <div class="alert alert-despedible alert-danger">
                                            <button type="button" class="close" data-picks="alert">& times</button>
                                            <strong>no Existen Habitaciones</strong>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                    </a>
                            </asp:View>
                            <asp:View ID="CrudReserva" runat="server">
                                <a runat="server" class="list-group-item list-group-item-control">
                                    <%--ID--%>
                                    <asp:HiddenField runat="server" ID="CIDHabitacion" />
                                    <asp:HiddenField runat="server" ID="IdReserva" />
                                    <div class="form-group">
                                        <asp:Label runat="server" Text="Selecione Cliente:"></asp:Label>
                                        <asp:DropDownList ID="CCliente" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>ESTADO PAGO</label>
                                        <asp:RadioButtonList runat="server" ID="CEstadoPago" CssClass="checkbox"></asp:RadioButtonList>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" Text="Descripcion:"></asp:Label>
                                        <asp:TextBox placeholder="Descripcion" ID="Cdescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <%--    ID--%>
                                <div class="col-md-12">
                                    <div class="  col-md-4">
                                        <h5 class="text-info">Seleccione Fecha De Entrada<span class="glyphicon glyphicon-calendar"></span></h5>
                                        <asp:Label runat="server" ID="CFechaEntrada" class="text-dark "><%=calendario.SelectedDate.ToShortDateString()%></asp:Label>
                                        <br />
                                        <asp:Calendar runat="server" ID="calendario"
                                            OnDayRender="calendario_DayRender"
                                            DayHeaderStyle-CssClass="btn-info"
                                            ShowTitle="true"
                                                                                       
                                            ></asp:Calendar>
                                    </div>
                                    <div class="col-md-4">
                                        <h5 class="text-info">Seleccione Fecha De Salida<span class="glyphicon glyphicon-calendar"></span></h5>
                                        <asp:Label runat="server" ID="CFechaSalida" class="text-dark"><%=calendario2.SelectedDate.ToShortDateString()%></asp:Label>
                                        <asp:Calendar runat="server" ID="calendario2"
                                            OnDayRender="calendario2_DayRender"
                                            DayHeaderStyle-CssClass="btn-info"
                                            ShowTitle="true"></asp:Calendar>
                                    </div>
                               


                                        </div>
                                    <asp:Button ID="BtnEditar" OnClick="BtnEditar_Click" CssClass="btn btn-info " runat="server" Text="Editar" />
                                    <asp:Button ID="Agregar" OnClick="Agregar_Click" CssClass="btn btn-warning " runat="server" Text="Registrar" />

                                    <div class="alert alert-dismissible alert-primary">
                                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                                        <strong></strong>
                                        <asp:Label runat="server" ID="MensajeAdd"></asp:Label>
                                    </div>


                                    <asp:Button ID="Volver3" CssClass="btn btn-info " Text="Ver Reservaciones" OnClick="Volver3_Click" runat="server" />
                                    <asp:Button ID="Volver" CssClass="btn btn-info " Text="Volver" OnClick="Volver_Click" runat="server" />
                                </a>
                            </asp:View>
                            <asp:View ID="ReservasView" runat="server">
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" class="form-control" ID="CBuscar" placeholder="Ingrese Nombre" aria-describedby="button-addon2">  </asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:Button runat="server" class="btn btn-outline-secondary" ID="Buscar" OnClick="Buscar_Click" Text="Buscar"></asp:Button>
                                    </div>
                                </div>
                                <asp:GridView runat="server" ID="TablaReserva" CssClass="table table-bordered" AutoGenerateColumns="false" OnPageIndexChanging="TablaReserva_PageIndexChanging" AllowPaging="true" PageSize="5" OnRowCommand="TablaReserva_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="IDRese" HeaderText="ID Reserva " HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" />
                                        <asp:BoundField DataField="FechaE" HeaderText="Fecha Entrada" DataFormatString="{0:M}"/>
                                        <asp:BoundField DataField="FechaS" HeaderText="Fecha Salida" DataFormatString="{0:M}"/>
                                        <asp:BoundField DataField="Total" DataFormatString="${0:N0}" HeaderText="Precio" />
                                        <asp:BoundField DataField="Dias" HeaderText="Dias de estadia" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado De Pago" />
                                        <asp:BoundField DataField="IdEstado" HeaderText="Estado De Pago" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" />
                                        <asp:BoundField DataField="Des" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="NombreCli" HeaderText="Nombre Cliente" />
                                        <asp:BoundField DataField="Cuarto" HeaderText="Numero Habitacion" />
                                        <asp:BoundField DataField="NumeroHab" HeaderText="Numero Habitacion" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" />
                                        <asp:BoundField DataField="IDESTADO" HeaderText="Pago ID " HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" />
                                        <asp:BoundField DataField="Rut" HeaderText="Rut Cliente" HeaderStyle-CssClass="OcultarColumna" ItemStyle-CssClass="OcultarColumna" />
                                        <asp:ButtonField ButtonType="Link" HeaderText="Editar Reserva" CommandName="Editar" ControlStyle-CssClass="btn   btn-success w-auto " Text="Editar" />
                                        <asp:ButtonField ButtonType="Link" HeaderText="Eliminar" CommandName="Eliminar" ControlStyle-CssClass=" btn btn-danger w-auto  glyphicon glyphicon-pencil" Text="<i class='fas fa-trash'></i>" />
                                    </Columns>
                                    <HeaderStyle CssClass="table-info" />
                                    <EmptyDataTemplate>
                                        <div class="alert alert-despedible alert-danger">
                                            <button type="button" class="close" data-picks="alert">& times</button>
                                            <strong>no Existen Reservas</strong>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>



                                <asp:Button ID="Volver2" CssClass="btn btn-info " Text="Volver" OnClick="Volver2_Click" runat="server" />
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="tab-pane fade" id="profile">
                <p></p>
                <%--   Vista Reportes--%>




            </div>



        </div>




    </div>
</div>
