using Sistema_de_nomina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_nomina.Interfaces
{
    interface IEmpleadoRepository 
    {
        IEnumerable<Empleado> ObtenerEmpleados();
        int ObtenerSiguienteIdDisponible();
        void AgregarEmpleado(Empleado empleado);
        void ActualizarEmpleado(int id, Empleado empleado);
        void Eliminar(int id);
    }
}
