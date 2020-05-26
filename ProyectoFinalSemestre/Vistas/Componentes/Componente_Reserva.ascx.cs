using ProyectoFinalSemestre.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalSemestre.Servicios;

namespace ProyectoFinalSemestre.Vistas.Componentes
{
    public partial class Componente_Reserva : System.Web.UI.UserControl

    {

        private ServiciosDeReserva servico = new ServiciosDeReserva();

        private db contexto = new db();
        static Hashtable HolidayList = new Hashtable();
        private Hashtable Getholiday()
        {
            Hashtable holiday = new Hashtable();
            holiday["10-01-2019"] = "Tarea 1";
            holiday["01-01-2019"] = "Tarea 2";
            holiday["05-05-2019"] = "Tarea 3";
            return holiday;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendario1();
                Calendario2();
                CargarTablaRe();
                VistasReserva.SetActiveView(TablaHabitacion);
                CargarEstadoReserva();
                CargarRolUsuario();
                CargarTablaReserva();
            }
        }


        //CALENDARIO IMPORT
        protected void calendario_DayRender(object sender, DayRenderEventArgs e)
        {
            if (HolidayList[e.Day.Date.ToShortDateString()] != null)
            {
                Literal literal1 = new Literal();
                literal1.Text = "<br/>";
                e.Cell.Controls.Add(literal1);
                Label label1 = new Label();
                label1.Text = (string)HolidayList[e.Day.Date.ToShortDateString()];
                label1.Font.Size = new FontUnit(FontSize.Small);
                e.Cell.Controls.Add(label1);
            }
            if (e.Day.Date.Month < DateTime.Now.Month || e.Day.Date.Year < DateTime.Now.Year || e.Day.Date.Day < DateTime.Now.Day)
            {
                e.Day.IsSelectable = false;
            }
            if (e.Day.Date.Year > DateTime.Now.Year)
            {
                if (e.Day.Date.Month > DateTime.Now.Year)
                {
                    if (e.Day.Date.Year > DateTime.Now.Year)
                    {
                        e.Day.IsSelectable = true;
                    }
                }

            }
        }
        private int calculardias(DateTime e, DateTime s)
        {
            TimeSpan diferencia;
            diferencia = s - e;
            return diferencia.Days;
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            List<DateTime> fechas = new List<DateTime>();

            if (Session["fechas"] != null)
                fechas = (List<DateTime>)Session["fechas"];
            fechas.Add(calendario.SelectedDate);
            PintarFechas(fechas);
            Session["fechas"] = fechas;
        }
        private void PintarFechas(List<DateTime> fechas)
        {
            foreach (DateTime fecha in fechas)
            {
                calendario.SelectedDates.Add(fecha);
                calendario.SelectedDayStyle.BackColor = System.Drawing.Color.Pink;
            }
        }
        public void Calendario1()
        {

            HolidayList = Getholiday();
            calendario.CellPadding = 1;
            calendario.CellSpacing = 1;
            calendario.TitleFormat = TitleFormat.MonthYear;
            calendario.TitleStyle.Font.Size = 10;
            calendario.TitleStyle.BackColor = System.Drawing.Color.White;
            calendario.ShowGridLines = true;
            calendario.DayStyle.Height = new Unit(20);
            calendario.DayStyle.Width = new Unit(80);
            calendario.DayStyle.HorizontalAlign = HorizontalAlign.Center;
            calendario.DayStyle.VerticalAlign = VerticalAlign.Middle;
            calendario.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;
        }
        public void Calendario2()
        {
            calendario2.CellPadding = 1;
            calendario2.CellSpacing = 1;
            calendario2.TitleFormat = TitleFormat.MonthYear;
            calendario2.TitleStyle.Font.Size = 10;
            calendario2.TitleStyle.BackColor = System.Drawing.Color.White;
            calendario2.ShowGridLines = true;
            calendario2.DayStyle.Height = new Unit(20);
            calendario2.DayStyle.Width = new Unit(80);
            calendario2.DayStyle.HorizontalAlign = HorizontalAlign.Center;
            calendario2.DayStyle.VerticalAlign = VerticalAlign.Middle;
            calendario2.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;
            DateTime FechaC1 = Convert.ToDateTime(calendario.SelectedDate);
            
        }
        protected void calendario2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (HolidayList[e.Day.Date.ToShortDateString()] != null)
            {
                Literal literal1 = new Literal();
                literal1.Text = "<br/>";
                e.Cell.Controls.Add(literal1);
                Label label1 = new Label();
                label1.Text = (string)HolidayList[e.Day.Date.ToShortDateString()];
                label1.Font.Size = new FontUnit(FontSize.Small);
                e.Cell.Controls.Add(label1);

            }
            DateTime FechaC1 = Convert.ToDateTime(calendario.SelectedDate);
            if (FechaC1.Day.Equals("01/01/0001"))
            {
                e.Cell.Enabled = false;
                e.Cell.Controls[0].Visible = false;
            }

            if (FechaC1.Day > e.Day.Date.Day)
            {
                e.Day.IsSelectable = false;
            }
        }
        //CALENDARIO IMPORT FIN
        public void CargarTablaRe()
        {
            TablaHabitacionesReserva.DataSource = servico.HabitacionesDisponibles();
            TablaHabitacionesReserva.DataBind();
        }



        protected void TablaHabitacionesReserva_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("Reservar"))
                {
                    CIDHabitacion.Value = TablaHabitacionesReserva.Rows[fila].Cells[0].Text;
                    VistasReserva.SetActiveView(CrudReserva);
                }

            }
            catch (Exception)
            {
            }
        }

        protected void TablaHabitacionesReserva_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                TablaHabitacionesReserva.PageIndex = e.NewPageIndex;
                CargarTablaRe();
            }
            catch (Exception)
            {
            }
        }
        protected void Volver_Click(object sender, EventArgs e)
        {
            VistasReserva.SetActiveView(TablaHabitacion);
        }
        public void CargarEstadoReserva()
        {
            CEstadoPago.DataSource = contexto.EstadoReservacion.ToList();
            CEstadoPago.DataTextField = "Nombre_Estado";
            CEstadoPago.DataValueField = "ID_Estado_RESE";
            CEstadoPago.DataBind();
        }
        private void CargarRolUsuario()
        {
            CCliente.DataSource = contexto.Cliente.ToList();
            CCliente.DataTextField = "Nombre";
            CCliente.DataValueField = "Rut_Cliente";
            CCliente.Items.Insert(0, "Seleccione Cliente");
            CCliente.DataBind();
        }
        public void CargarTablaReserva()
        {
            TablaReserva.DataSource = servico.CargarReserva();
            TablaReserva.DataBind();
        }

        protected void TablaReserva_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                TablaReserva.PageIndex = e.NewPageIndex;
                CargarTablaReserva();
            }
            catch (Exception)
            {
            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {


            try
            {
                HiddenField HabiatcionS = CIDHabitacion;
                String Rut = CCliente.SelectedValue;
                String Descr = Cdescripcion.Text;
                DateTime FechaEntrada = Convert.ToDateTime(calendario.SelectedDate);
                DateTime FechaSalida = Convert.ToDateTime(calendario2.SelectedDate.Date);
                int dias = calculardias(FechaEntrada, FechaSalida);
                int Cuarto = 0;
                Cuarto = Convert.ToInt32(HabiatcionS.Value);
                int Precio = contexto.Habitacion.Where(Habitacion => Habitacion.Cuarto == Cuarto).First().Precio;
                int CostoHospedaje = 0;
                CostoHospedaje = Precio * dias;
                string Estado = CEstadoPago.SelectedValue;
                int NumeroHabitacion = contexto.Habitacion.Where(Habitacion => Habitacion.Cuarto == Cuarto).First().Numero;

                servico.AgregarReservacio(new Reservacion
                {
                    FechaEntrada = Convert.ToDateTime(FechaEntrada),
                    FechaSalida = Convert.ToDateTime(FechaSalida),
                    Rut_Cliente = Rut,
                    Descripcion = Descr,
                    CantidaddeDias = dias,
                    Numero = NumeroHabitacion,
                    TotalaPagar = CostoHospedaje,
                    EstadodePago = Convert.ToInt32(Estado),

                });
                MensajeAdd.Text = "Reserva Realizada" + DateTime.Now;
                CargarTablaReserva();
                BloquearHabitacionReservada();
                CargarTablaRe();
                VistasReserva.SetActiveView(ReservasView);

            }
            catch (Exception)
            {

                MensajeAdd.Text = "Error reserva ya existe" + DateTime.Now;
            }

        }

        public void BloquearHabitacionReservada()
        {
            HiddenField HabiatcionS = CIDHabitacion;
            int Cuarto = 0;
            Cuarto = Convert.ToInt32(HabiatcionS.Value);
            int Numero = contexto.Habitacion.Where(Habitacion => Habitacion.Cuarto == Cuarto).First().Numero;

            Habitacion A = new Habitacion();
            A = contexto.Habitacion.Find(Convert.ToInt32(Numero));
            A.Estado_Habi = Convert.ToInt32(2);
            contexto.SaveChanges();
        }

        protected void TablaReserva_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            int FILA = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                IdReserva.Value = TablaReserva.Rows[FILA].Cells[0].Text;
                String FechaE = TablaReserva.Rows[FILA].Cells[1].Text;
                String FechaS = TablaReserva.Rows[FILA].Cells[2].Text;
                String Precio = TablaReserva.Rows[FILA].Cells[3].Text;
                Cdescripcion.Text = TablaReserva.Rows[FILA].Cells[7].Text;
                String RutCliente = TablaReserva.Rows[FILA].Cells[12].Text;
                CIDHabitacion.Value = TablaReserva.Rows[FILA].Cells[10].Text;
                CEstadoPago.SelectedValue = TablaReserva.Rows[FILA].Cells[11].Text;


                String Rut = CCliente.Text;
                String Descr = Cdescripcion.Text;
                DateTime FechaEntrada = Convert.ToDateTime(calendario.SelectedDate);
                DateTime FechaSalida = Convert.ToDateTime(calendario2.SelectedDate.Date);

                CCliente.SelectedValue = Rut;
                calendario.SelectedDate = Convert.ToDateTime(FechaE);
                calendario2.SelectedDate = Convert.ToDateTime(FechaS);
                CFechaEntrada.Text = FechaE;
                CFechaSalida.Text = FechaS;

                VistasReserva.SetActiveView(CrudReserva);
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                String IdRese = TablaReserva.Rows[FILA].Cells[0].Text;
                if (servico.EliminarReserva(Convert.ToInt32(IdRese)))
                {
                    CargarTablaReserva();
                    MensajeAdd.Text = "Reserva Eliminado" + DateTime.Now;
                }
            }


        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            Reservacion A = new Reservacion();
            A = contexto.Reservacion.Find(Convert.ToInt32(IdReserva.Value));
            HiddenField HabiatcionS = CIDHabitacion;
            int Numero = 0;
            Numero = Convert.ToInt32(HabiatcionS.Value);
            int dias = calculardias(calendario.SelectedDate, calendario2.SelectedDate.Date);
            int Precio = contexto.Habitacion.Where(Habitacion => Habitacion.Numero == Numero).First().Precio;
            int CostoHospedaje = 0;
            CostoHospedaje = Precio * dias;
            A.FechaEntrada = Convert.ToDateTime(calendario.SelectedDate);
            A.FechaSalida = Convert.ToDateTime(calendario2.SelectedDate.Date);
            A.EstadodePago = Convert.ToInt32(CEstadoPago.SelectedValue);
            A.Rut_Cliente = CCliente.SelectedValue;
            A.Descripcion = Cdescripcion.Text;
            A.Numero = Numero;
            A.CantidaddeDias = dias;
            A.TotalaPagar = CostoHospedaje;
            contexto.SaveChanges();
            CargarTablaReserva();
            VistasReserva.SetActiveView(ReservasView);

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {


            TablaReserva.DataSource = servico.BuscarRserva(CBuscar.Text);
            TablaReserva.DataBind();

            if (CBuscar.Text == "")
            {
                CargarTablaReserva();
            }

        }

        protected void Volver2_Click(object sender, EventArgs e)
        {
            VistasReserva.SetActiveView(CrudReserva);
        }

        protected void Volver3_Click(object sender, EventArgs e)
        {
            VistasReserva.SetActiveView(ReservasView);
        }


    }
}




