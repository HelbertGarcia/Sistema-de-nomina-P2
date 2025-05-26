using Sistema_de_nomina.Controllers;
using Sistema_de_nomina.Interfaces;
using Sistema_de_nomina.Repositories;

namespace Sistema_de_nomina
{
    
    partial class Form1
    {

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dataGridEmp = new DataGridView();
            txttipoEmpleado = new ComboBox();
            txtnombre = new TextBox();
            txtapellido = new TextBox();
            txtseguroSocial = new TextBox();
            Agregar = new Button();
            btnEliminar = new Button();
            button3 = new Button();
            button4 = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtsueldoBase = new TextBox();
            txtcomision = new TextBox();
            txthorasTrabajadas = new TextBox();
            txtsueldoHora = new TextBox();
            label10 = new Label();
            txtventasBrutas = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmp).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(423, 7);
            label1.Name = "label1";
            label1.Size = new Size(552, 81);
            label1.TabIndex = 0;
            label1.Text = "Nomina Empleados";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1440, 116);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(83, 154);
            label2.Name = "label2";
            label2.Size = new Size(85, 28);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(82, 220);
            label3.Name = "label3";
            label3.Size = new Size(86, 28);
            label3.TabIndex = 3;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(82, 294);
            label4.Name = "label4";
            label4.Size = new Size(129, 28);
            label4.TabIndex = 4;
            label4.Text = "Seguro social";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(82, 358);
            label5.Name = "label5";
            label5.Size = new Size(171, 28);
            label5.TabIndex = 5;
            label5.Text = "Tipo de Empleado";
            // 
            // dataGridEmp
            // 
            dataGridEmp.BackgroundColor = SystemColors.ControlLight;
            dataGridEmp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEmp.Location = new Point(2, 442);
            dataGridEmp.Name = "dataGridEmp";
            dataGridEmp.RowHeadersWidth = 51;
            dataGridEmp.Size = new Size(1440, 266);
            dataGridEmp.TabIndex = 6;
            dataGridEmp.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txttipoEmpleado
            // 
            txttipoEmpleado.AutoCompleteCustomSource.AddRange(new string[] { "Empleado asalariado", "Empleado por hora", "Empleado por comision", "Empleado asalariado por comision" });
            txttipoEmpleado.FormattingEnabled = true;
            txttipoEmpleado.Items.AddRange(new object[] { "Empleado asalariado", "Empleado por comision", "Empleado por hora", "Empleado asalariado por comision" });
            txttipoEmpleado.Location = new Point(259, 358);
            txttipoEmpleado.Name = "txttipoEmpleado";
            txttipoEmpleado.Size = new Size(215, 28);
            txttipoEmpleado.TabIndex = 7;
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(259, 165);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(157, 27);
            txtnombre.TabIndex = 8;
            // 
            // txtapellido
            // 
            txtapellido.Location = new Point(259, 228);
            txtapellido.Name = "txtapellido";
            txtapellido.Size = new Size(157, 27);
            txtapellido.TabIndex = 9;
            // 
            // txtseguroSocial
            // 
            txtseguroSocial.Location = new Point(259, 302);
            txtseguroSocial.Name = "txtseguroSocial";
            txtseguroSocial.Size = new Size(157, 27);
            txtseguroSocial.TabIndex = 10;
            // 
            // Agregar
            // 
            Agregar.BackColor = Color.YellowGreen;
            Agregar.FlatStyle = FlatStyle.Flat;
            Agregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Agregar.Location = new Point(419, 394);
            Agregar.Name = "Agregar";
            Agregar.Size = new Size(121, 42);
            Agregar.TabIndex = 11;
            Agregar.Text = "Agregar";
            Agregar.UseVisualStyleBackColor = false;
            Agregar.Click += Agregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEliminar.Location = new Point(563, 394);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(121, 42);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.MenuHighlight;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button3.Location = new Point(708, 394);
            button3.Name = "button3";
            button3.Size = new Size(121, 42);
            button3.TabIndex = 13;
            button3.Text = "Actualizar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.PaleGreen;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button4.Location = new Point(856, 394);
            button4.Name = "button4";
            button4.Size = new Size(121, 42);
            button4.TabIndex = 14;
            button4.Text = "Reporte";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(520, 165);
            label6.Name = "label6";
            label6.Size = new Size(123, 28);
            label6.TabIndex = 15;
            label6.Text = "Sueldo base ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(520, 221);
            label7.Name = "label7";
            label7.Size = new Size(94, 28);
            label7.TabIndex = 16;
            label7.Text = "Comision";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(520, 281);
            label8.Name = "label8";
            label8.Size = new Size(159, 28);
            label8.TabIndex = 17;
            label8.Text = "Horas trabajadas";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(525, 341);
            label9.Name = "label9";
            label9.Size = new Size(154, 28);
            label9.TabIndex = 18;
            label9.Text = "Sueldo por hora";
            // 
            // txtsueldoBase
            // 
            txtsueldoBase.Location = new Point(714, 169);
            txtsueldoBase.Name = "txtsueldoBase";
            txtsueldoBase.Size = new Size(186, 27);
            txtsueldoBase.TabIndex = 19;
            // 
            // txtcomision
            // 
            txtcomision.Location = new Point(714, 224);
            txtcomision.Name = "txtcomision";
            txtcomision.Size = new Size(186, 27);
            txtcomision.TabIndex = 20;
            // 
            // txthorasTrabajadas
            // 
            txthorasTrabajadas.Location = new Point(714, 285);
            txthorasTrabajadas.Name = "txthorasTrabajadas";
            txthorasTrabajadas.Size = new Size(186, 27);
            txthorasTrabajadas.TabIndex = 21;
            // 
            // txtsueldoHora
            // 
            txtsueldoHora.Location = new Point(714, 342);
            txtsueldoHora.Name = "txtsueldoHora";
            txtsueldoHora.Size = new Size(186, 27);
            txtsueldoHora.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(1062, 165);
            label10.Name = "label10";
            label10.Size = new Size(128, 28);
            label10.TabIndex = 23;
            label10.Text = "Ventas Brutas";
            label10.Click += label10_Click;
            // 
            // txtventasBrutas
            // 
            txtventasBrutas.Location = new Point(1032, 196);
            txtventasBrutas.Name = "txtventasBrutas";
            txtventasBrutas.Size = new Size(176, 27);
            txtventasBrutas.TabIndex = 24;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1437, 707);
            Controls.Add(txtventasBrutas);
            Controls.Add(label10);
            Controls.Add(txtsueldoHora);
            Controls.Add(txthorasTrabajadas);
            Controls.Add(txtcomision);
            Controls.Add(txtsueldoBase);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(btnEliminar);
            Controls.Add(Agregar);
            Controls.Add(txtseguroSocial);
            Controls.Add(txtapellido);
            Controls.Add(txtnombre);
            Controls.Add(txttipoEmpleado);
            Controls.Add(dataGridEmp);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = " ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridEmp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dataGridEmp;
        private Button Agregar;
        private Button btnEliminar;
        private Button button3;
        private Button button4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        public ComboBox txttipoEmpleado;
        public TextBox txtnombre;
        public TextBox txtapellido;
        public TextBox txtseguroSocial;
        public TextBox txtsueldoBase;
        public TextBox txtcomision;
        public TextBox txthorasTrabajadas;
        public TextBox txtsueldoHora;
        private Label label10;
        private TextBox txtventasBrutas;
    }
}
