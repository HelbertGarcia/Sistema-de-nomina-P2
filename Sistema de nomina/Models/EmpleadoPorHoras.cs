using System;
using Sistema_de_nomina.Constantes;
using Sistema_de_nomina.ViewModel;

namespace Sistema_de_nomina.Models
{
    public class EmpleadoPorHoras : Empleado 
    {
        public EmpleadoPorHoras(int id, string nombre, string apellido, int seguroSocial,
                                decimal sueldoPorHora, int horasTrabajadas) : base(id, nombre, apellido, seguroSocial)
        {
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
        }

        public decimal SueldoPorHora { get; private set; }
        public int HorasTrabajadas { get; private set; }

        public override decimal CalcularSueldo()
        {
            if (HorasTrabajadas <= 40)
            {
                return HorasTrabajadas * SueldoPorHora;
            }
            else
            {
                return (SueldoPorHora * 40) + (SueldoPorHora * 1.5m * (HorasTrabajadas - 40));
            }
        }

        public override string getInfo()
        {
            return $"el id es {Id}, el nombre es {Nombre}, el apellido es {Apellido}, " +
                   $"el seguro social es {SeguroSocial}, las horas trabajadas: {HorasTrabajadas}" +
                   $" y el sueldo por hora es: {SueldoPorHora}";
        }

        public override EmpleadoDisplay GetDisplayModel()
        {
            var model = new EmpleadoDisplay();
            PopulateBaseDisplayModel(model);
            model.TipoEmpleado = TiposEmpleadoConst.PorHora;
            model.SalarioPorHora = this.SueldoPorHora;
            model.HorasTrabajadas = this.HorasTrabajadas;
            return model;
        }
    }
}
