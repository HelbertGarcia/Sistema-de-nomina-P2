using System;
using Sistema_de_nomina.Constantes;
using Sistema_de_nomina.ViewModel;

namespace Sistema_de_nomina.Models
{
    public class EmpleadoAsalariadoPorComision : Empleado 
    {
        public EmpleadoAsalariadoPorComision(int id, string nombre, string apellido, int seguroSocial,
                                           decimal ventasBrutas, decimal tarifaComision, decimal salarioBase) :
                                           base(id, nombre, apellido, seguroSocial)
        {
            VentasBrutas = ventasBrutas;
            TarifaComision = tarifaComision;
            SalarioBase = salarioBase;
        }

        public decimal VentasBrutas { get; private set; }
        public decimal TarifaComision { get; private set; }
        public decimal SalarioBase { get; private set; }

        public override decimal CalcularSueldo()
        {
            return (VentasBrutas * TarifaComision) + SalarioBase + (SalarioBase * 0.10m);
        }

        public override string getInfo()
        {
            return $"el id es {Id}, el nombre es {Nombre}, el apellido es {Apellido}, " +
                   $"el seguro social es {SeguroSocial}, el salario semanal es: {SalarioBase}, " +
                   $"la comision es: {TarifaComision} y las ventas brutas son: {VentasBrutas}";
        }

        public override EmpleadoDisplay GetDisplayModel()
        {
            var model = new EmpleadoDisplay();
            PopulateBaseDisplayModel(model);
            model.TipoEmpleado = TiposEmpleadoConst.AsalariadoPorComision;
            model.SueldoBase = this.SalarioBase;
            model.VentasBrutas = this.VentasBrutas;
            model.TasaComision = this.TarifaComision;
            return model;
        }
    }
}
