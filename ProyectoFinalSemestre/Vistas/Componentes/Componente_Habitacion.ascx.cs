using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalSemestre.Modelo;
using ProyectoFinalSemestre.Servicios;
using ProyectoFinalSemestre.Vistas.Componentes;
using ProyectoFinalSemestre;

namespace ProyectoFinalSemestre.Vistas.Componentes
{
    public partial class Componente_Habitacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstado();
                CargarTabla();
                
            }
       

        }
        private ServiciosDeHabitacion servico = new ServiciosDeHabitacion();
        private db contexto = new db();
       
        private void CargarEstado()
        {
            DropEstado.DataSource = contexto.Estado_Habi.ToList();
            DropEstado.DataTextField = "Nombre_Estado";
            DropEstado.DataValueField = "ID_Estado_HAB";
            DropEstado.DataBind();
        }


        private void CargarTabla()
        {
            TablaHabitacion.DataSource = servico.CargarTablaHabitacion();
            TablaHabitacion.DataBind();
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
      
      

            if (CBuscar.Text == "")
            {
                CargarTabla();
            }
            else
            {
                TablaHabitacion.DataSource = servico.BuscarHabitacion(Convert.ToInt32(CBuscar.Text));
                TablaHabitacion.DataBind();
            }
        }

        void LimpiarCampos() {


            CCuarto.Text = "";
            CCapacidad.Text = "";
            CPrecio.Text = "";
            CDescripcion.Text = "";


        }



        protected void Agregar_Click(object sender, EventArgs e)
        {
            string Cuarto = CCuarto.Text;
            string Capacidad = CCapacidad.Text;
            string Precio = CPrecio.Text;
            string Descripcion = CDescripcion.Text;
            string Estado = DropEstado.Text.Trim();

            try
            {

                if (servico.BuscarCuarto(Convert.ToInt32(Cuarto)) == true)
                {
                    servico.AgregarHabitacion(new Habitacion
                    {
                        Cuarto = Convert.ToInt32(Cuarto),
                        Capacidad = Convert.ToInt32(Capacidad),
                        Precio = Convert.ToInt32(Precio),
                        Descripcion = Descripcion,
                        Estado_Habi = Convert.ToInt32(Estado)
                    });
                    MensajeAdd.Text = "Habitacion Agregada" + DateTime.Now;
                    CargarTabla();
                    LimpiarCampos()
                } else
                {
                    MensajeAdd.Text = "Cuarto ya registrado";
                }
            }
            catch (Exception)
            {
                MensajeAdd.Text = "Error de datos";

            }
        }

        protected void TablaHabitacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {
                    CCuarto.Text = TablaHabitacion.Rows[fila].Cells[0].Text;
                    CCapacidad.Text = TablaHabitacion.Rows[fila].Cells[1].Text;
                    CPrecio.Text = TablaHabitacion.Rows[fila].Cells[2].Text.Replace("$", "").Replace(".", "");
                    CDescripcion.Text = TablaHabitacion.Rows[fila].Cells[3].Text;
                    DropEstado.Text = TablaHabitacion.Rows[fila].Cells[5].Text;
                    CNumero.Value =TablaHabitacion.Rows[fila].Cells[6].Text;
                }
                if (e.CommandName.Equals("Eliminar"))
                {
                  string  Numero= TablaHabitacion.Rows[fila].Cells[6].Text;
                    if (servico.EliminarHabitacion(Convert.ToInt32(Numero)))
                    {
                        CargarTabla();
                                                              
                        MensajeAdd.Text = "Habitacion Eliminado" + DateTime.Now;
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            Habitacion A = new Habitacion();
            A = contexto.Habitacion.Find(Convert.ToInt32(CNumero.Value));
            A.Cuarto = Convert.ToInt32(CCuarto.Text);
            A.Capacidad = Convert.ToInt32(CCapacidad.Text);
            A.Precio = Convert.ToInt32(CPrecio.Text);
            A.Descripcion = CDescripcion.Text;
            A.Estado_Habi = Convert.ToInt32(DropEstado.SelectedValue);
            contexto.SaveChanges();
            CargarTabla();
            LimpiarCampos();
        }

        protected void TablaHabitacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                TablaHabitacion.PageIndex = e.NewPageIndex;
                CargarTabla();
            }
            catch (Exception)
            {
            }
        }
    }
    }
