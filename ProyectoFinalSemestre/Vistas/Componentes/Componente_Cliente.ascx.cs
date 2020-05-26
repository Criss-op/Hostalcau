using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalSemestre.Modelo;
using ProyectoFinalSemestre.Servicios;

namespace ProyectoFinalSemestre.Vistas.Componentes
{
    public partial class Componente_Cliente : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                CargarEstadoCliente();
                CargarTabla();
            }
              

        }
        private db contexto = new db();
        private ServicioDeCliente servico = new ServicioDeCliente();













        private void CargarEstadoCliente()
        {
            DropEstado.DataSource = contexto.EstadoPersonas.ToList();
            DropEstado.DataTextField = "Nombre_Estado";
            DropEstado.DataValueField = "ID_Estado_P";
      
            DropEstado.DataBind();
           
        }



















        private void CargarTabla()
        {
            TablaCliente.DataSource = servico.mostrarTablaClientes();
            TablaCliente.DataBind();
        }

        protected void TablaCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {

                    CRut.Text = TablaCliente.Rows[fila].Cells[0].Text;
                    CNombre.Text= TablaCliente.Rows[fila].Cells[1].Text;
                    CApellido.Text= TablaCliente.Rows[fila].Cells[2].Text;
                    CTelefono.Text = TablaCliente.Rows[fila].Cells[3].Text;
                    CCorreo.Text = TablaCliente.Rows[fila].Cells[4].Text;
                    CDescripcion.Text = TablaCliente.Rows[fila].Cells[6].Text;
                    DropEstado.Text= TablaCliente.Rows[fila].Cells[5].Text;
                 


                   
                }
                if (e.CommandName.Equals("Eliminar"))
                {
                    string rut = TablaCliente.Rows[fila].Cells[0].Text;
                    if (servico.EliminarCliente(rut))
                    {
                        CargarTabla();
                        MensajeAdd.Text = "Cliente Eliminado" + DateTime.Now;
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        protected void TablaCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                TablaCliente.PageIndex = e.NewPageIndex;
                CargarTabla();
            }
            catch (Exception)
            {
            }
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            try
            {

                string Rut = CRut.Text;
                string Nombre = CNombre.Text;
                string Apellido = CApellido.Text;
                string Estado = DropEstado.Text.Trim();
                string Telefono = CTelefono.Text;
                string Correo = CCorreo.Text;
                string Descripcion = CDescripcion.Text;
                if (servico.ValidarClienteIngresado(Rut) == true)
                {
                    if (servico.validarRut(Rut) == true)
                    {

                        servico.AgregarCliente(new Cliente
                        {
                            Rut_Cliente = Rut,
                            Nombre = Nombre,
                            Apellido = Apellido,
                            Estado_Cliente = Convert.ToInt32(Estado),
                            Telefono = Convert.ToInt32(Telefono),
                            Correo = Correo,
                            DescripcionEstado = Descripcion,


                        });
                        MensajeAdd.Text = "Cliente Agregado" + DateTime.Now;
                        CargarTabla();
                        LimpiarCampos();
                    }
                    else
                    {

                        MensajeAdd.Text = "Rut Invalido";

                    }
                }
                else { MensajeAdd.Text = "El rut se encuentra Registrado"; }


             


          
            }
            catch (Exception)
            {
                MensajeAdd.Text = "Error de datos";
            }
        }

        public void LimpiarCampos()
        {
            CRut.Text = "";
            CNombre.Text = "";
            CApellido.Text = "";
            CTelefono.Text = "";
            CCorreo.Text = "";
            CDescripcion.Text = "";
           
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            object a = servico.BuscarCliente(CBuscar.Text);

            TablaCliente.DataSource = servico.BuscarCliente(CBuscar.Text);
            TablaCliente.DataBind();

            if (CBuscar.Text == "")
            {
                CargarTabla();
            }
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {

                   Cliente  A = new Cliente();
            A = contexto.Cliente.Find(CRut.Text);

            A.Rut_Cliente = CRut.Text;
            A.Nombre = CNombre.Text;
            A.Apellido = CApellido.Text;
            A.Telefono =  Convert.ToInt32(CTelefono.Text);
            A.Correo = CCorreo.Text;
            A.Estado_Cliente = Convert.ToInt32(DropEstado.SelectedValue);

            contexto.SaveChanges();
            CargarTabla();
            LimpiarCampos();


        }
    }
}