using ProyectoFinalSemestre.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoFinalSemestre.Servicios
{
    public class ServiciosDeUsuario
    {
        private db contexto = new db();



        public int[] validarUsuario(String user, String pass)
        {
            int[] respuesta = new int[4];
            try
            {
                var result = from u in contexto.Usuario
                             where u.userNombre.Trim().ToUpper().Equals(user.Trim().ToUpper())
                             && u.userClave.Equals(pass)
                             select u;
                respuesta[0] = result.Count() == 1 ? 1 : 0;
                respuesta[1] = result.First().idEstado == 1 ? 1 : 0;
                respuesta[2] = result.First().idRol;
                respuesta[3] = result.First().idUsuario;
                return respuesta;
            }
            catch (Exception)
            {
                respuesta[0] = 0;
                return respuesta;
            }
        }



        public List<LinkButton> MenuRoles(int idRol, List<LinkButton> listaMenu)
        {
            try
            {
                var result = from asig in contexto.AsignarMenu
                             join menu in contexto.Menu
                             on asig.idMenu equals menu.idMenu
                             where asig.idRol == idRol
                             select new { menu.linkMenu };
                foreach (var sis in result.ToList())
                {
                    foreach (var app in listaMenu)
                    {
                        if (sis.linkMenu.Equals(app.ID))
                        {
                            app.Visible = true;
                        }
                    }
                }
                return listaMenu;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool EliminarUsuario(int IdUsuario)
        {
            try
            {
                var user = contexto.Usuario.Find(IdUsuario);
                contexto.Usuario.Remove(user);
                int a = contexto.SaveChanges();

                // A repesebta la columna borrada
                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool EditarUsuario(Usuario usuario)
        {
            try
            {
                contexto.Usuario.Attach(usuario);
                contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                int a = contexto.SaveChanges();
                // A representa el numero de filas afectadas 
                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool AgregarUsuario(Usuario usuario)
        {
            try
            {
                contexto.Usuario.Add(usuario);

                int a = contexto.SaveChanges();

                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<object> BuscarUsuario(String Nombre)
        {
            try
            {
                var Resultado = from User in contexto.Usuario
                                where User.userNombre.ToLower().StartsWith(Nombre.ToLower()) 
                                select new { User.idUsuario, Nombre = User.userNombre, Clave = User.userClave, Estado = User.Estado.nombre, Rol = User.Roles.nombre, User.idEstado, User.idRol };
                return Resultado.ToList<object>();
            }
            catch (Exception)
            {
                return null;
            }
        }
    
    
        public List<object> CargarTablaUsuarios() {      
            try
            {
                var Resultado = from User in contexto.Usuario
                                join Es in contexto.Estado
                                on User.idEstado equals Es.idEstado
                                join Rol in contexto.Roles
                                on User.idRol equals Rol.idRol                                                                              
                                select new { User.idUsuario, Nombre = User.userNombre, Clave = User.userClave, Estado = User.Estado.nombre, Rol = User.Roles.nombre ,User.idEstado,User.idRol};            
                return Resultado.ToList<object>();
            }
            catch (Exception)
            {
                return null;
            }
        }
      }
    }
