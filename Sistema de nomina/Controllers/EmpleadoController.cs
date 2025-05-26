using Sistema_de_nomina.Interfaces;
using Sistema_de_nomina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_nomina.Controllers
{
    class EmpleadoController
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadoController(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado), "El objeto empleado proporcionado es nulo.");
            }
            _repository.AgregarEmpleado(empleado);
        }

        public int getId()
        {
            return _repository.ObtenerSiguienteIdDisponible();
        }

        public IEnumerable<Empleado> getEmpleados()
        {
            return _repository.ObtenerEmpleados();
        }

        public void EliminarEmpleado(int id)
        {
            _repository.Eliminar(id);
        }

        public void ActualizarEmpleado(int id, Empleado empleadoActualizado)
        {
            if (empleadoActualizado == null)
            {
                throw new ArgumentNullException(nameof(empleadoActualizado), "El objeto empleado actualizado proporcionado es nulo.");
            }
            if (id != empleadoActualizado.Id)
            {
              empleadoActualizado.Id = id;
            }
            _repository.ActualizarEmpleado(id, empleadoActualizado);
        }
    }
}
