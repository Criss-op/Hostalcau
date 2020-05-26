using ProyectoFinalSemestre.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProyectoFinalSemestre.Servicios
{
    public class ServiciosDeHabitacion
    {

        private db contexto = new db();

        public bool EliminarHabitacion(int IdHabitacion)
        {
            try
            {
                var Delete = contexto.Habitacion.Find(IdHabitacion);
                contexto.Habitacion.Remove(Delete);
                int a = contexto.SaveChanges();

                // A repesebta la columna borrada
                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public bool AgregarHabitacion(Habitacion habitacion)
        {
            try
            {
                contexto.Habitacion.Add(habitacion);

                int a = contexto.SaveChanges();

                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<object> BuscarHabitacion(int A)
        {
            try
            {
                var consulta = from p in contexto.Habitacion
                               where p.Numero == A
                               select new { p.Numero, p.Cuarto, p.Capacidad, p.Precio, p.Descripcion, IdEstado = p.Estado_Habi1, NombreEstado = p.Estado_Habi1.Nombre_Estado };
                return consulta.ToList<object>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool BuscarCuarto (int cuarto) {
            try
            {
                //Buscar Si un cuarto esta repetido
                int  Buscador = 0;
                foreach (var g in contexto.Habitacion)
                {
                    if (g.Cuarto == cuarto)
                    {
                        Buscador++;
                    }                 
                }
                if (Buscador == 0)
                {
                    return true;
                }
                else {
                 return false;
                }
            }
            catch (Exception)
            {
                return false;
           
            }
                               
                                 
        }



        public List<object> CargarTablaHabitacion()
        {
            try
            {

                var consulta = from c in contexto.Estado_Habi
                               join p in contexto.Habitacion on c.ID_Estado_HAB equals p.Estado_Habi
                               select new { p.Numero, p.Cuarto,p.Capacidad, p.Precio, p.Descripcion, NombreEstado = c.Nombre_Estado, IdEstado = p.Estado_Habi };

                return consulta.ToList<object>();
            }
            catch (Exception)
            {
                return null;
            }

        }

















    }
}