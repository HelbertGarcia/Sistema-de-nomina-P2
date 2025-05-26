using System;
using Sistema_de_nomina.Constantes;
using Sistema_de_nomina.ViewModel;

namespace Sistema_de_nomina.Models
{
    public class EmpleadoPorComision : Empleado 
    {
        public EmpleadoPorComision(int id, string nombre, string apellido, int seguroSocial,
                                   decimal ventasBrutas, decimal tarifaComision) : base(id, nombre, apellido, seguroSocial)
        {
            VentasBrutas = ventasBrutas;
            TarifaComision = tarifaComision;
        }

        public decimal VentasBrutas { get; private set; }
        public decimal TarifaComision { get; private set; }

        public override decimal CalcularSueldo()
        {
            return VentasBrutas * TarifaComision;
        }

        public override string getInfo()
        {
            return $"el id es {Id}, el nombre es {Nombre}, el apellido es {Apellido}, " +
                   $"el seguro social es {SeguroSocial}, las ventas brutas: {VentasBrutas} " +
                   $"y la comision {TarifaComision}";
        }
        public override EmpleadoDisplay GetDisplayModel()
        {
            var model = new EmpleadoDisplay();
            PopulateBaseDisplayModel(model);
            model.TipoEmpleado = TiposEmpleadoConst.PorComision;
            model.VentasBrutas = this.VentasBrutas;
            model.TasaComision = this.TarifaComision;
            return model;
        }
    }
}