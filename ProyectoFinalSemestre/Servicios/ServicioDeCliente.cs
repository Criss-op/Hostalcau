using ProyectoFinalSemestre.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoFinalSemestre.Servicios
{
    public class ServicioDeCliente
    {
        private db contexto = new db();

       public List<object> mostrarTablaClientes()
        {
     //   e= ESTADO CLIENTE  c = CLIENTE

            var Consulta = from e in contexto.EstadoPersonas
                           join c in contexto.Cliente on e.ID_Estado_P equals c.Estado_Cliente
                           select new { c.Rut_Cliente, c.Nombre, c.Apellido, c.Telefono, c.Correo, c.DescripcionEstado, EstadoCliente = e.Nombre_Estado, idestado = c.Estado_Cliente };
            return Consulta.ToList<object>();
        }
        public bool AgregarCliente(Cliente cliente)
        {
            try
            {
                contexto.Cliente.Add(cliente);

                int a = contexto.SaveChanges();

                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarCliente(string Rut)
        {
            try
            {
                var user = contexto.Cliente.Find(Rut);
                contexto.Cliente.Remove(user);
                int a = contexto.SaveChanges();

                // A repesebta la columna borrada
                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditarUsuario(Cliente cliente)
        {
            try
            {
                contexto.Cliente.Attach(cliente);
                contexto.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                int a = contexto.SaveChanges();
                // A representa el numero de filas afectadas 
                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<object> BuscarCliente(String Nombre)
        {
            try
            {
                var Consulta = from C in contexto.Cliente
                            where C.Rut_Cliente.ToLower().StartsWith(Nombre.ToLower()) || C.Nombre.ToLower().StartsWith(Nombre.ToLower())
                               select new { C.Rut_Cliente, C.Nombre, C.Apellido, C.Telefono, C.Correo, C.DescripcionEstado, EstadoCliente = C.EstadoPersonas.Nombre_Estado, idestado = C.Estado_Cliente };

                return Consulta.ToList<object>();
            }
            catch (Exception)
            {
                return null;

            }
        }



        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        public bool ValidarClienteIngresado(string rut)
        {
            try
            {
                //Buscar Si un  cliente esta repetido
                int Buscador = 0;
                foreach (var g in contexto.Cliente)
                {
                    if (g.Rut_Cliente == rut)
                    {
                        Buscador++;
                    }
                }
                if (Buscador == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;

            }

        }






        }
    }