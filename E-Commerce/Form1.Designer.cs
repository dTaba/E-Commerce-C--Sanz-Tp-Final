namespace E_Commerce
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelPerfil = new System.Windows.Forms.Panel();
            this.btAjustes = new System.Windows.Forms.Button();
            this.btPedidos = new System.Windows.Forms.Button();
            this.btCerrarSesion = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btPerfil = new System.Windows.Forms.Button();
            this.panelSeleccionado = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btFiltros = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelPerfil.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btFiltros);
            this.panel1.Controls.Add(this.panelPerfil);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btPerfil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 776);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelPerfil
            // 
            this.panelPerfil.Controls.Add(this.btAjustes);
            this.panelPerfil.Controls.Add(this.btPedidos);
            this.panelPerfil.Controls.Add(this.btCerrarSesion);
            this.panelPerfil.Location = new System.Drawing.Point(3, 590);
            this.panelPerfil.Name = "panelPerfil";
            this.panelPerfil.Size = new System.Drawing.Size(207, 183);
            this.panelPerfil.TabIndex = 5;
            this.panelPerfil.Visible = false;
            // 
            // btAjustes
            // 
            this.btAjustes.FlatAppearance.BorderSize = 0;
            this.btAjustes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAjustes.ForeColor = System.Drawing.Color.White;
            this.btAjustes.Image = ((System.Drawing.Image)(resources.GetObject("btAjustes.Image")));
            this.btAjustes.Location = new System.Drawing.Point(9, 75);
            this.btAjustes.Name = "btAjustes";
            this.btAjustes.Size = new System.Drawing.Size(174, 38);
            this.btAjustes.TabIndex = 6;
            this.btAjustes.Text = "Editar Perfil";
            this.btAjustes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAjustes.UseVisualStyleBackColor = true;
            this.btAjustes.Click += new System.EventHandler(this.btAjustes_Click);
            // 
            // btPedidos
            // 
            this.btPedidos.FlatAppearance.BorderSize = 0;
            this.btPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPedidos.ForeColor = System.Drawing.Color.White;
            this.btPedidos.Image = ((System.Drawing.Image)(resources.GetObject("btPedidos.Image")));
            this.btPedidos.Location = new System.Drawing.Point(3, 3);
            this.btPedidos.Name = "btPedidos";
            this.btPedidos.Size = new System.Drawing.Size(180, 66);
            this.btPedidos.TabIndex = 4;
            this.btPedidos.Text = "Mis Pedidos";
            this.btPedidos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPedidos.UseVisualStyleBackColor = true;
            // 
            // btCerrarSesion
            // 
            this.btCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btCerrarSesion.Image")));
            this.btCerrarSesion.Location = new System.Drawing.Point(3, 119);
            this.btCerrarSesion.Name = "btCerrarSesion";
            this.btCerrarSesion.Size = new System.Drawing.Size(194, 48);
            this.btCerrarSesion.TabIndex = 5;
            this.btCerrarSesion.Text = "Cerrar Sesión";
            this.btCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(213, 100);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estafarino";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btPerfil
            // 
            this.btPerfil.FlatAppearance.BorderSize = 0;
            this.btPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPerfil.ForeColor = System.Drawing.Color.White;
            this.btPerfil.Image = ((System.Drawing.Image)(resources.GetObject("btPerfil.Image")));
            this.btPerfil.Location = new System.Drawing.Point(6, 518);
            this.btPerfil.Name = "btPerfil";
            this.btPerfil.Size = new System.Drawing.Size(194, 66);
            this.btPerfil.TabIndex = 3;
            this.btPerfil.Text = "Perfil";
            this.btPerfil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btPerfil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btPerfil.UseVisualStyleBackColor = true;
            this.btPerfil.Click += new System.EventHandler(this.btPerfil_Click);
            // 
            // panelSeleccionado
            // 
            this.panelSeleccionado.BackColor = System.Drawing.Color.Yellow;
            this.panelSeleccionado.Location = new System.Drawing.Point(219, 109);
            this.panelSeleccionado.Name = "panelSeleccionado";
            this.panelSeleccionado.Size = new System.Drawing.Size(10, 76);
            this.panelSeleccionado.TabIndex = 3;
            this.panelSeleccionado.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(213, 676);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1225, 100);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label2.Location = new System.Drawing.Point(356, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 23);
            this.label2.TabIndex = 2;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btFiltros
            // 
            this.btFiltros.FlatAppearance.BorderSize = 0;
            this.btFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFiltros.ForeColor = System.Drawing.Color.White;
            this.btFiltros.Image = ((System.Drawing.Image)(resources.GetObject("btFiltros.Image")));
            this.btFiltros.Location = new System.Drawing.Point(6, 109);
            this.btFiltros.Name = "btFiltros";
            this.btFiltros.Size = new System.Drawing.Size(194, 66);
            this.btFiltros.TabIndex = 6;
            this.btFiltros.Text = "Filtros";
            this.btFiltros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btFiltros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btFiltros.UseVisualStyleBackColor = true;
            this.btFiltros.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Location = new System.Drawing.Point(3, 181);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 169);
            this.panel4.TabIndex = 7;
            this.panel4.Visible = false;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(6, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 38);
            this.button2.TabIndex = 6;
            this.button2.Text = "Descuento";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 66);
            this.button3.TabIndex = 4;
            this.button3.Text = "Precio";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(6, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 48);
            this.button4.TabIndex = 5;
            this.button4.Text = "Categorias";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(360, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(978, 32);
            this.textBox1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(219, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(135, 66);
            this.button5.TabIndex = 8;
            this.button5.Text = "Buscar";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1438, 776);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelSeleccionado);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panelPerfil.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCerrarSesion;
        private System.Windows.Forms.Button btPedidos;
        private System.Windows.Forms.Button btPerfil;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSeleccionado;
        private System.Windows.Forms.Panel panelPerfil;
        private System.Windows.Forms.Button btAjustes;
        private System.Windows.Forms.Button btFiltros;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
    }
}

