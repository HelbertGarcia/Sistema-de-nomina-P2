using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sistema_de_nomina.Controllers;
using Sistema_de_nomina.Interfaces;
using Sistema_de_nomina.Models;
using Sistema_de_nomina.Repositories;
using Sistema_de_nomina.Constantes;
using Sistema_de_nomina.ViewModel;
using System.Text; 
using System.IO;   

namespace Sistema_de_nomina
{
    public partial class Form1 : Form
    {
        private EmpleadoController _controller;
        private int? _idEmpleadoSeleccionado = null;

        public Form1()
        {
            InitializeComponent();
            IEmpleadoRepository repository = new EmpleadoRepository();
            _controller = new EmpleadoController(repository);

            if (txttipoEmpleado is ComboBox cmbTipo)
            {
                cmbTipo.Items.Clear();
                cmbTipo.Items.Add(TiposEmpleadoConst.Asalariado);
                cmbTipo.Items.Add(TiposEmpleadoConst.PorHora);
                cmbTipo.Items.Add(TiposEmpleadoConst.PorComision);
                cmbTipo.Items.Add(TiposEmpleadoConst.AsalariadoPorComision);
                cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            dataGridEmp.AutoGenerateColumns = true;
            CargarDatos();
            this.dataGridEmp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
        }

        private bool TryValidarCamposComunes(out string nombre, out string apellido, out int seguroSocial, out string tipoEmpleado)
        {
            nombre = txtnombre.Text;
            apellido = txtapellido.Text;
            tipoEmpleado = "";
            seguroSocial = 0;

            if (txttipoEmpleado is ComboBox cmb)
            {
                tipoEmpleado = cmb.SelectedItem?.ToString() ?? "";
            }
            else
            {
                tipoEmpleado = txttipoEmpleado.Text;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("El apellido no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtapellido.Focus();
                return false;
            }

            if (!int.TryParse(txtseguroSocial.Text, out seguroSocial))
            {
                MessageBox.Show("El número de Seguro Social ingresado no es válido. Por favor, verifique.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtseguroSocial.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tipoEmpleado))
            {
                MessageBox.Show("Debe seleccionar un tipo de empleado.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttipoEmpleado.Focus();
                return false;
            }
            return true;
        }

        private Empleado CrearInstanciaEmpleado(int id, string nombre, string apellido, int seguroSocial, string tipoEmpleado,
                                               decimal sueldoBaseParsed, decimal comisionParsed, int horasTrabajadasParsed,
                                               decimal sueldoHoraParsed, decimal ventasBrutasParsed)
        {
            switch (tipoEmpleado)
            {
                case TiposEmpleadoConst.Asalariado:
                    if (sueldoBaseParsed <= 0 && !string.IsNullOrWhiteSpace(txtsueldoBase.Text))
                    {
                        MessageBox.Show("El sueldo base para un empleado asalariado debe ser mayor que cero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtsueldoBase.Focus();
                        return null;
                    }
                    return new EmpleadoAsalariado(id, nombre, apellido, seguroSocial, sueldoBaseParsed);
                case TiposEmpleadoConst.PorComision:
                    return new EmpleadoPorComision(id, nombre, apellido, seguroSocial, ventasBrutasParsed, comisionParsed);
                case TiposEmpleadoConst.PorHora:
                    return new EmpleadoPorHoras(id, nombre, apellido, seguroSocial, sueldoHoraParsed, horasTrabajadasParsed);
                case TiposEmpleadoConst.AsalariadoPorComision:
                    if (sueldoBaseParsed <= 0 && !string.IsNullOrWhiteSpace(txtsueldoBase.Text))
                    {
                        MessageBox.Show("El salario base para un empleado asalariado por comisión debe ser mayor que cero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtsueldoBase.Focus();
                        return null;
                    }
                    return new EmpleadoAsalariadoPorComision(id, nombre, apellido, seguroSocial, ventasBrutasParsed, comisionParsed, sueldoBaseParsed);
                default:
                    MessageBox.Show("El tipo de empleado seleccionado no es reconocido para la creación/actualización.", "Error de Tipo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (!TryValidarCamposComunes(out string nombre, out string apellido, out int seguroSocial, out string tipoEmpleado))
            {
                return;
            }

            decimal.TryParse(txtsueldoBase.Text, out decimal sueldoBase);
            decimal.TryParse(txtcomision.Text, out decimal comision);
            int.TryParse(txthorasTrabajadas.Text, out int horasTrabajadas);
            decimal.TryParse(txtsueldoHora.Text, out decimal sueldoHora);
            decimal.TryParse(txtventasBrutas.Text, out decimal ventasBrutas);

            int id = _controller.getId();

            Empleado nuevoEmpleado = CrearInstanciaEmpleado(id, nombre, apellido, seguroSocial, tipoEmpleado,
                                                        sueldoBase, comision, horasTrabajadas, sueldoHora, ventasBrutas);
            if (nuevoEmpleado == null)
            {
                return;
            }

            try
            {
                _controller.AgregarEmpleado(nuevoEmpleado);

                MessageBox.Show("Empleado agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();
            }
            catch (ArgumentNullException argNullEx)
            {
                MessageBox.Show($"Error al agregar empleado: {argNullEx.Message}", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show($"Error de datos: {argEx.Message}", "Error al Agregar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error inesperado al procesar la solicitud: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txtseguroSocial.Clear();
            ((ComboBox)txttipoEmpleado).SelectedIndex = -1;
            txtsueldoBase.Clear();
            txtcomision.Clear();
            txthorasTrabajadas.Clear();
            txtsueldoHora.Clear();
            txtventasBrutas.Clear();
            txtnombre.Focus();
            _idEmpleadoSeleccionado = null;
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridEmp.Rows.Count)
            {
                DataGridViewRow filaSeleccionada = dataGridEmp.Rows[e.RowIndex];
                if (filaSeleccionada.DataBoundItem is EmpleadoDisplay empDisplay)
                {
                    _idEmpleadoSeleccionado = empDisplay.Id;
                    txtnombre.Text = empDisplay.Nombre;
                    txtapellido.Text = empDisplay.Apellido;
                    txtseguroSocial.Text = empDisplay.SeguroSocial.ToString();

                    if (txttipoEmpleado is ComboBox cmbTipo)
                    {
                        cmbTipo.SelectedItem = empDisplay.TipoEmpleado;
                        if (cmbTipo.SelectedItem == null || cmbTipo.SelectedItem.ToString() != empDisplay.TipoEmpleado)
                        {
                            for (int i = 0; i < cmbTipo.Items.Count; i++)
                            {
                                if (cmbTipo.Items[i].ToString() == empDisplay.TipoEmpleado)
                                {
                                    cmbTipo.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                    txtsueldoBase.Text = empDisplay.SueldoBase?.ToString() ?? "";
                    txtcomision.Text = empDisplay.TasaComision?.ToString() ?? "";
                    txtventasBrutas.Text = empDisplay.VentasBrutas?.ToString() ?? "";
                    txtsueldoHora.Text = empDisplay.SalarioPorHora?.ToString() ?? "";
                    txthorasTrabajadas.Text = empDisplay.HorasTrabajadas?.ToString() ?? "";
                }
                else { _idEmpleadoSeleccionado = null; }
            }
            else { _idEmpleadoSeleccionado = null; }
        }

        private void CargarDatos()
        {
            IEnumerable<Empleado> listaOriginalEmpleados = _controller.getEmpleados();
            var listaParaDisplay = listaOriginalEmpleados
                                   .Select(emp => emp.GetDisplayModel())
                                   .ToList();

            dataGridEmp.DataSource = null;
            dataGridEmp.DataSource = listaParaDisplay;

            if (dataGridEmp.Columns.Contains("SueldoBase") && dataGridEmp.Columns["SueldoBase"] != null)
                dataGridEmp.Columns["SueldoBase"].DefaultCellStyle.Format = "C2";
            if (dataGridEmp.Columns.Contains("TasaComision") && dataGridEmp.Columns["TasaComision"] != null)
                dataGridEmp.Columns["TasaComision"].DefaultCellStyle.Format = "P2";
            if (dataGridEmp.Columns.Contains("VentasBrutas") && dataGridEmp.Columns["VentasBrutas"] != null)
                dataGridEmp.Columns["VentasBrutas"].DefaultCellStyle.Format = "C2";
            if (dataGridEmp.Columns.Contains("SalarioPorHora") && dataGridEmp.Columns["SalarioPorHora"] != null)
                dataGridEmp.Columns["SalarioPorHora"].DefaultCellStyle.Format = "C2";
            if (dataGridEmp.Columns.Contains("SueldoCalculado") && dataGridEmp.Columns["SueldoCalculado"] != null)
                dataGridEmp.Columns["SueldoCalculado"].DefaultCellStyle.Format = "C2";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_idEmpleadoSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para eliminar.",
                                "Ningún Empleado Seleccionado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmacion = MessageBox.Show($"¿Está seguro de que desea eliminar al empleado seleccionado (ID: {_idEmpleadoSeleccionado.Value})?",
                                                        "Confirmar Eliminación",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    _controller.EliminarEmpleado(_idEmpleadoSeleccionado.Value);
                    MessageBox.Show("Empleado eliminado exitosamente.",
                                    "Eliminación Exitosa",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    CargarDatos();
                    LimpiarCampos();
                }
                catch (KeyNotFoundException knfEx)
                {
                    MessageBox.Show("Error: El empleado seleccionado no fue encontrado. Pudo haber sido eliminado previamente.",
                                    "Error de Eliminación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    CargarDatos();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Se produjo un error inesperado al intentar eliminar el empleado: {ex.Message}",
                                    "Error Crítico",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_idEmpleadoSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para actualizar.",
                                "Ningún Empleado Seleccionado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (!TryValidarCamposComunes(out string nombre, out string apellido, out int seguroSocial, out string tipoEmpleado))
            {
                return;
            }

            decimal.TryParse(txtsueldoBase.Text, out decimal sueldoBase);
            decimal.TryParse(txtcomision.Text, out decimal comision);
            int.TryParse(txthorasTrabajadas.Text, out int horasTrabajadas);
            decimal.TryParse(txtsueldoHora.Text, out decimal sueldoHora);
            decimal.TryParse(txtventasBrutas.Text, out decimal ventasBrutas);

            int idParaActualizar = _idEmpleadoSeleccionado.Value;
            Empleado empleadoActualizado = CrearInstanciaEmpleado(idParaActualizar, nombre, apellido, seguroSocial, tipoEmpleado,
                                                                sueldoBase, comision, horasTrabajadas, sueldoHora, ventasBrutas);

            if (empleadoActualizado == null)
            {
                return;
            }

            try
            {
                _controller.ActualizarEmpleado(idParaActualizar, empleadoActualizado);
                MessageBox.Show("Empleado actualizado exitosamente.",
                                "Actualización Exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("Error: El empleado que intenta actualizar no fue encontrado. Pudo haber sido eliminado.",
                                "Error de Actualización",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                CargarDatos();
                LimpiarCampos();
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show($"Error en los datos para actualizar: {argEx.Message}",
                               "Error de Actualización",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado al intentar actualizar el empleado: {ex.Message}",
                                "Error Crítico",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IEnumerable<Empleado> listaOriginalEmpleados = _controller.getEmpleados();
            if (!listaOriginalEmpleados.Any())
            {
                MessageBox.Show("No hay empleados para generar un reporte.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var listaParaReporte = listaOriginalEmpleados
                                   .Select(emp => emp.GetDisplayModel())
                                   .ToList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            saveFileDialog.Title = "Guardar Reporte de Nómina";
            saveFileDialog.FileName = $"ReporteNominaSemanal_{DateTime.Now:yyyyMMdd_HHmmss}.csv"; 

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sbCsv = new StringBuilder();

                    string[] encabezados = {
                "Id", "Nombre", "Apellido", "SeguroSocial", "TipoEmpleado",
                "SueldoBase", "TasaComision", "VentasBrutas",
                "SalarioPorHora", "HorasTrabajadas", "SueldoCalculado"
            };
                    sbCsv.AppendLine(string.Join(",", encabezados));

                    foreach (var empDisplay in listaParaReporte)
                    {
                        string id = empDisplay.Id.ToString();
                        string nombre = empDisplay.Nombre ?? "";
                        string apellido = empDisplay.Apellido ?? "";
                        string seguroSocial = empDisplay.SeguroSocial.ToString();
                        string tipoEmpleado = empDisplay.TipoEmpleado ?? "";
                        string sueldoBase = empDisplay.SueldoBase?.ToString("F2") ?? ""; 
                        string tasaComision = empDisplay.TasaComision?.ToString("P2") ?? ""; 
                        string ventasBrutas = empDisplay.VentasBrutas?.ToString("F2") ?? "";
                        string salarioPorHora = empDisplay.SalarioPorHora?.ToString("F2") ?? "";
                        string horasTrabajadas = empDisplay.HorasTrabajadas?.ToString() ?? "";
                        string sueldoCalculado = empDisplay.SueldoCalculado.ToString("F2");

                        string[] fila = {
                    id, nombre, apellido, seguroSocial, tipoEmpleado,
                    sueldoBase, tasaComision, ventasBrutas,
                    salarioPorHora, horasTrabajadas, sueldoCalculado
                };
                        sbCsv.AppendLine(string.Join(",", fila));
                    }

                    File.WriteAllText(saveFileDialog.FileName, sbCsv.ToString(), Encoding.UTF8);

                    MessageBox.Show("Reporte generado y guardado exitosamente.",
                                    "Reporte Guardado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar o guardar el reporte: {ex.Message}",
                                    "Error de Reporte",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }
    }
}