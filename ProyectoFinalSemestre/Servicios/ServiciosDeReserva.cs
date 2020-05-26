using ProyectoFinalSemestre.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalSemestre.Servicios
{
    public class ServiciosDeReserva
    {

        private db contexto = new db();


        public List<object> HabitacionesDisponibles()
        {
            try
            {
                var consulta = from p in contexto.Habitacion
                               where p.Estado_Habi == 1
                               select new { p.Numero, p.Cuarto, p.Capacidad, p.Precio, p.Descripcion };
                return consulta.ToList<object>();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<object> CargarReserva()
        {
            var Rese = from R in contexto.Reservacion
                       join C in contexto.Cliente
                       on R.Rut_Cliente equals C.Rut_Cliente
                       join A in contexto.Habitacion on R.Habitacion.Numero equals A.Numero
                       join E in contexto.EstadoReservacion on R.EstadodePago equals E.ID_Estado_RESE
                       select new { IDRese = R.AD_Reservacion, FechaE = R.FechaEntrada, FechaS = R.FechaSalida, Total = R.TotalaPagar, Dias = R.CantidaddeDias, Des = R.Descripcion, Estado = E.Nombre_Estado, IdEstado = E.ID_Estado_RESE, Rut = C.Rut_Cliente, NombreCli = C.Nombre, NumeroHab = A.Numero, A.Cuarto };
            return Rese.ToList<object>();
        }


        public List<object> BuscarRserva(String Nombre)
        {
            try
            {
                var Consulta = from R in contexto.Reservacion
                               join C in contexto.Cliente
                               on R.Rut_Cliente equals C.Rut_Cliente
                               join A in contexto.Habitacion on R.Habitacion.Numero equals A.Numero
                               join E in contexto.EstadoReservacion on R.EstadodePago equals E.ID_Estado_RESE
                               where R.Rut_Cliente.ToLower().StartsWith(Nombre.ToLower()) || R.Cliente.Nombre.ToLower().StartsWith(Nombre.ToLower())
                               select new { IDRese = R.AD_Reservacion, FechaE = R.FechaEntrada, FechaS = R.FechaSalida, Total = R.TotalaPagar, Dias = R.CantidaddeDias, Des = R.Descripcion, Estado = E.Nombre_Estado, IdEstado = E.ID_Estado_RESE, Rut = C.Rut_Cliente, NombreCli = C.Nombre, NumeroHab = A.Numero };

                return Consulta.ToList<object>();
            }
            catch (Exception)
            {
                return null;

            }
        }


        public bool AgregarReservacio(Reservacion reserva)
        {
            try
            {
                contexto.Reservacion.Add(reserva);

                int a = contexto.SaveChanges();

                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarReserva(int id)
        {
            try
            {
                var rese = contexto.Reservacion.Find(id);
                contexto.Reservacion.Remove(rese);
                int a = contexto.SaveChanges();

                // A repesebta la columna borrada
                return a == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}