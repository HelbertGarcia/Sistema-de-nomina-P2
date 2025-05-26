using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_nomina.ViewModel
{
    public class EmpleadoDisplay
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int SeguroSocial { get; set; }
        public string? TipoEmpleado { get; set; }
        public decimal? SueldoBase { get; set; }
        public decimal? TasaComision { get; set; }
        public decimal? VentasBrutas { get; set; }
        public decimal? SalarioPorHora { get; set; }
        public int? HorasTrabajadas { get; set; }
        public decimal SueldoCalculado { get; set; }
    }
}
