using System;
using Sistema_de_nomina.Constantes; 
using Sistema_de_nomina.ViewModel;

namespace Sistema_de_nomina.Models
{
    public class EmpleadoAsalariado : Empleado 
    {
        public EmpleadoAsalariado(int id, string nombre, string apellido, int seguroSocial,
                                 decimal salarioSemanal) : base(id, nombre, apellido, seguroSocial)
        {
            SalarioSemanal = salarioSemanal;
        }

        public decimal SalarioSemanal { get; private set; }

        public override decimal CalcularSueldo()
        {
            return SalarioSemanal;
        }

        public override string getInfo()
        {
            return $"el id es {Id}, el nombre es {Nombre}, el apellido es {Apellido}, " +
                   $"el seguro social es {SeguroSocial} y el salario semanal es: {SalarioSemanal}";
        }

        public override EmpleadoDisplay GetDisplayModel()
        {
            var model = new EmpleadoDisplay();
            PopulateBaseDisplayModel(model); 
            model.TipoEmpleado = TiposEmpleadoConst.Asalariado;
            model.SueldoBase = this.SalarioSemanal;
            return model;
        }
    }
}