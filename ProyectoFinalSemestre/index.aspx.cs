using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalSemestre.Servicios;
using ProyectoFinalSemestre.Vistas.Componentes;

namespace ProyectoFinalSemestre
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    mcontenido.SetActiveView(vBienvenida);
                    if (!Session["idUsuario"].Equals("") || !Session["idUsuario"].Equals(null))
                    {
                        int idRol = Convert.ToInt32(Session["idRol"]);
                        activaMenu(idRol);
                        ucontenido.Update();
                    }


                }
            }
            catch (Exception)
            {

                lodin.Visible = true;
            }

        }
        private Componente_Reserva Reserva = new Componente_Reserva();
        protected void Menu_Usuario_Click(object sender, EventArgs e)
        {
            mcontenido.SetActiveView(vUsuario);
            ucontenido.Update();
        }
        protected void Menu_Cliente_Click(object sender, EventArgs e)
        {
            mcontenido.SetActiveView(vCliente);
            ucontenido.Update();
        }
        protected void Menu_Habitacion_Click(object sender, EventArgs e)
        {
            mcontenido.SetActiveView(vHabitacion);
            ucontenido.Update();
        }
        protected void Menu_Reservacion_Click(object sender, EventArgs e)
        {
            mcontenido.SetActiveView(vReserva);
            ucontenido.Update();
    
          

        }
        protected void Menu_home_Click(object sender, EventArgs e)
        {
            mcontenido.SetActiveView(vBienvenida);
            ucontenido.Update();
        }



        private void LiampiarVistas() {
            //menu

            Menu_Habitacion.Visible = false;
            Menu_Cliente.Visible = false;
            Menu_Reservacion.Visible = false;
            Menu_Usuario.Visible = false;
            lodin.Visible = true;
            salir.Visible = false;
            mcontenido.SetActiveView(vBienvenida);
            ucontenido.Update();
        }

        protected void salir_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Session.Abandon();
            LiampiarVistas();
           

        }
        protected void lodin_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType()
                , "exampleModal", "$('#exampleModal').modal('show'); ", true);
            uModal.Update();
        }

    
        public void activaMenu(int idRol)
        {
            ServiciosDeUsuario Servi = new ServiciosDeUsuario();
            List<LinkButton> listaMenuss = new List<LinkButton>();
            listaMenuss.Add(Menu_Cliente);
            listaMenuss.Add(Menu_Usuario);
            listaMenuss.Add(Menu_Habitacion);
            listaMenuss.Add(Menu_Reservacion);
            Servi.MenuRoles(idRol, listaMenuss);
            lodin.Visible = false;
            salir.Visible = true;
        }
        

        protected void bValidarUsuario_Click(object sender, EventArgs e)
        {
            ServiciosDeUsuario Servi = new ServiciosDeUsuario();
            int[] resp = Servi.validarUsuario(tusuario.Text, tclave.Text);
            if (resp[0] == 0)
            {
                ms_validarUsuario.Text = "Usuario no Existe";
            }
            else
            {
                if (resp[1] == 0)
                {
                    ms_validarUsuario.Text = "Usuario Bloqueado";
                }
                else
                {
                    Session["nombreUsuario"] = tusuario.Text;
                    Session["idRol"] = resp[2];
                    Session["idUsuario"] = resp[3];
                    Session.Timeout = 5;


                    activaMenu( Convert.ToInt32(resp[2]));

                    ScriptManager.RegisterStartupScript(Page, Page.GetType()
                                  , "exampleModal", "$('#exampleModal').modal('hide'); ", true);
                    mcontenido.SetActiveView(vBienvenida);
                    uModal.Update();
                    ucontenido.Update();
                    ubarra.Update();

                }

            }
        }
    }
}