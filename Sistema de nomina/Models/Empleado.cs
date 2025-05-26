using Sistema_de_nomina.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_nomina.Models
{
    public abstract class Empleado 
    {
        public Empleado(int id, string nombre, string apellido, int seguroSocial)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            SeguroSocial = seguroSocial;
        }

        public int Id { get; set; }

        public string Nombre { get; protected set; }
        public string Apellido { get; protected set; }
        public int SeguroSocial { get; protected set; }

        public abstract decimal CalcularSueldo();
        public abstract string getInfo();

        public abstract EmpleadoDisplay GetDisplayModel();

        protected void PopulateBaseDisplayModel(EmpleadoDisplay model)
        {
            model.Id = this.Id;
            model.Nombre = this.Nombre;
            model.Apellido = this.Apellido; 
            model.SeguroSocial = this.SeguroSocial; 
            model.SueldoCalculado = this.CalcularSueldo();
        }
    }
}
