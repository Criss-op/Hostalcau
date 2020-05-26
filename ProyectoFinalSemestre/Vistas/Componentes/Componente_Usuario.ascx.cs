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
    public partial class Componente_Usuario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstadoUsuario();
                CargarRolUsuario();
                CargarTabla();
            }
        }
        private ServiciosDeUsuario servico = new ServiciosDeUsuario();

        private db contexto = new db();
        private void CargarEstadoUsuario()
        {
           DropEstado.DataSource = contexto.Estado.ToList();
            DropEstado.DataTextField = "nombre";
            DropEstado.DataValueField = "idEstado";
            DropEstado.Items.Insert(0, "seleccione Estado");
            DropEstado.DataBind();          
        }
        private void CargarRolUsuario()
        {
            DropRol.DataSource = contexto.Roles.ToList();
            DropRol.DataTextField = "nombre";
            DropRol.DataValueField = "idRol";
            DropRol.Items.Insert(0, "seleccione Rol");
            DropRol.DataBind();       
        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            try
            {                              
                    string Nombre = CNombre.Text;
                    string Clave = CClave.Text;
                    string Estado = DropEstado.Text.Trim();
                    string Rol = DropRol.Text.Trim();
                    DateTime Fecha = DateTime.Now;
                    servico.AgregarUsuario(new Usuario
                    {
                        userNombre = Nombre,
                        userClave = Clave,
                        idEstado = Convert.ToInt32(Estado),
                        idRol = Convert.ToInt32(Rol),
                    });
                    MensajeAdd.Text = "Usuario Agregado" + DateTime.Now;
                    CargarTabla();
                    LimpiarCampos();                              
            }
            catch (Exception)
            {
                MensajeAdd.Text = "Error de datos";
            }      
        }

        private void CargarTabla() {
            TablaUsuario.DataSource = servico.CargarTablaUsuarios();
            TablaUsuario.DataBind();
        }
        protected void TablaUsuario_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            try
            {
                TablaUsuario.PageIndex = e.NewPageIndex;
                CargarTabla();
            }
            catch (Exception)
            {             
            }
        }
        protected void Buscar_Click(object sender, EventArgs e)
        {
            object a = servico.BuscarUsuario(CBuscar.Text);

            TablaUsuario.DataSource = servico.BuscarUsuario(CBuscar.Text);
          TablaUsuario.DataBind();

            if (CBuscar.Text== "")
            {
                CargarTabla();
            }

        }
        protected void TablaUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.Equals("Editar"))
                {
              CIdUser.Value= TablaUsuario.Rows[fila].Cells[0].Text;
                   CNombre.Text= TablaUsuario.Rows[fila].Cells[1].Text;
                    CClave.Text = TablaUsuario.Rows[fila].Cells[4].Text;
                   DropEstado.DataTextField = TablaUsuario.Rows[fila].Cells[2].Text;
                    DropRol.DataTextField = TablaUsuario.Rows[fila].Cells[3].Text;           
                }
                if (e.CommandName.Equals("Eliminar"))
                {
                    int id = Convert.ToInt32(TablaUsuario.Rows[fila].Cells[0].Text);
                    if (servico.EliminarUsuario(id))
                    {
                        CargarTabla();
                        MensajeAdd.Text = "Usuario Eliminado" + DateTime.Now;
                    }        
                }
            }
            catch (Exception)
            {               
            }
        }

        public void LimpiarCampos() {
            CNombre.Text = "";
            CClave.Text = "";
          
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            Usuario A = new Usuario();
            A = contexto.Usuario.Find(Convert.ToInt32(CIdUser.Value));
            A.userNombre = CNombre.Text;
            A.userClave = CClave.Text;
            A.idEstado= Convert.ToInt32(DropEstado.SelectedValue);
            A.idRol = Convert.ToInt32(DropRol.SelectedValue);                
           contexto.SaveChanges();
            CargarTabla();
            LimpiarCampos();
        }
    }
}