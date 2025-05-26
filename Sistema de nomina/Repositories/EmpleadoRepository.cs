using Sistema_de_nomina.Interfaces;
using Sistema_de_nomina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_nomina.Repositories
{
    class EmpleadoRepository : IEmpleadoRepository
    {
        private List<Empleado> _list = new List<Empleado>();

        public IEnumerable<Empleado> ObtenerEmpleados()
        {
            return _list;
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            _list.Add(empleado);
        }

        public void ActualizarEmpleado(int id, Empleado empleado)
        {
            if (empleado == null || id < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                var index = _list.FindIndex(e => e.Id == id);
                _list[index] = empleado;
            }

        }

        public void Eliminar(int id)
        {
            var empleadoAEliminar = _list.FirstOrDefault(e => e.Id == id);
            if (empleadoAEliminar != null)
            {
                _list.Remove(empleadoAEliminar);
            }
            else
            {
                throw new KeyNotFoundException($"Empleado con Id {id} no encontrado y no pudo ser eliminado.");
            }
        }

        public int ObtenerSiguienteIdDisponible()
        {
            if (!_list.Any()) 
            {
                return 1;
            }
            else
            {
                return _list.Max(e => e.Id) + 1;
            }
        }
    }
}
