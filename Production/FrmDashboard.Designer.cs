
namespace Production
{
    partial class FrmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.lblcorreo = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.iconminimizar = new System.Windows.Forms.PictureBox();
            this.iconrestaurar = new System.Windows.Forms.PictureBox();
            this.iconmaximizar = new System.Windows.Forms.PictureBox();
            this.iconcerrar = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnprod = new System.Windows.Forms.Button();
            this.btnlogoInicio = new System.Windows.Forms.PictureBox();
            this.BarraTitulo.SuspendLayout();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconrestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconmaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconcerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogoInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(250, 45);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(758, 684);
            this.panelContenedor.TabIndex = 5;
            // 
            // lblcorreo
            // 
            this.lblcorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcorreo.AutoSize = true;
            this.lblcorreo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcorreo.ForeColor = System.Drawing.Color.White;
            this.lblcorreo.Location = new System.Drawing.Point(72, 710);
            this.lblcorreo.Name = "lblcorreo";
            this.lblcorreo.Size = new System.Drawing.Size(53, 17);
            this.lblcorreo.TabIndex = 17;
            this.lblcorreo.Text = "Correo";
            // 
            // lbluser
            // 
            this.lbluser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbluser.AutoSize = true;
            this.lbluser.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluser.ForeColor = System.Drawing.Color.White;
            this.lbluser.Location = new System.Drawing.Point(72, 692);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(54, 17);
            this.lbluser.TabIndex = 16;
            this.lbluser.Text = "Usuario";
            // 
            // lblusuario
            // 
            this.lblusuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblusuario.AutoSize = true;
            this.lblusuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(72, 675);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(50, 17);
            this.lblusuario.TabIndex = 14;
            this.lblusuario.Text = "Cargo";
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BarraTitulo.Controls.Add(this.iconminimizar);
            this.BarraTitulo.Controls.Add(this.iconrestaurar);
            this.BarraTitulo.Controls.Add(this.iconmaximizar);
            this.BarraTitulo.Controls.Add(this.iconcerrar);
            this.BarraTitulo.Controls.Add(this.btnMenu);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(250, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(758, 45);
            this.BarraTitulo.TabIndex = 4;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.MenuVertical.Controls.Add(this.lblcorreo);
            this.MenuVertical.Controls.Add(this.lbluser);
            this.MenuVertical.Controls.Add(this.pictureBox2);
            this.MenuVertical.Controls.Add(this.lblusuario);
            this.MenuVertical.Controls.Add(this.button6);
            this.MenuVertical.Controls.Add(this.button5);
            this.MenuVertical.Controls.Add(this.button4);
            this.MenuVertical.Controls.Add(this.button3);
            this.MenuVertical.Controls.Add(this.button2);
            this.MenuVertical.Controls.Add(this.btnprod);
            this.MenuVertical.Controls.Add(this.btnlogoInicio);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(250, 729);
            this.MenuVertical.TabIndex = 3;
            // 
            // iconminimizar
            // 
            this.iconminimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconminimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconminimizar.Image = ((System.Drawing.Image)(resources.GetObject("iconminimizar.Image")));
            this.iconminimizar.Location = new System.Drawing.Point(669, 13);
            this.iconminimizar.Name = "iconminimizar";
            this.iconminimizar.Size = new System.Drawing.Size(18, 18);
            this.iconminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconminimizar.TabIndex = 4;
            this.iconminimizar.TabStop = false;
            this.iconminimizar.Click += new System.EventHandler(this.iconminimizar_Click);
            // 
            // iconrestaurar
            // 
            this.iconrestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconrestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconrestaurar.Image = ((System.Drawing.Image)(resources.GetObject("iconrestaurar.Image")));
            this.iconrestaurar.Location = new System.Drawing.Point(700, 13);
            this.iconrestaurar.Name = "iconrestaurar";
            this.iconrestaurar.Size = new System.Drawing.Size(18, 18);
            this.iconrestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconrestaurar.TabIndex = 3;
            this.iconrestaurar.TabStop = false;
            this.iconrestaurar.Visible = false;
            this.iconrestaurar.Click += new System.EventHandler(this.iconrestaurar_Click);
            // 
            // iconmaximizar
            // 
            this.iconmaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconmaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconmaximizar.Image = ((System.Drawing.Image)(resources.GetObject("iconmaximizar.Image")));
            this.iconmaximizar.Location = new System.Drawing.Point(697, 13);
            this.iconmaximizar.Name = "iconmaximizar";
            this.iconmaximizar.Size = new System.Drawing.Size(18, 18);
            this.iconmaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconmaximizar.TabIndex = 2;
            this.iconmaximizar.TabStop = false;
            this.iconmaximizar.Click += new System.EventHandler(this.iconmaximizar_Click);
            // 
            // iconcerrar
            // 
            this.iconcerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconcerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconcerrar.Image = ((System.Drawing.Image)(resources.GetObject("iconcerrar.Image")));
            this.iconcerrar.Location = new System.Drawing.Point(728, 13);
            this.iconcerrar.Name = "iconcerrar";
            this.iconcerrar.Size = new System.Drawing.Size(18, 18);
            this.iconcerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconcerrar.TabIndex = 1;
            this.iconcerrar.TabStop = false;
            this.iconcerrar.Click += new System.EventHandler(this.iconcerrar_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(8, 6);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(35, 35);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenu.TabIndex = 0;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 659);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 66);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 356);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(250, 40);
            this.button6.TabIndex = 6;
            this.button6.Text = "About Us";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(0, 310);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(250, 40);
            this.button5.TabIndex = 5;
            this.button5.Text = "Compras";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(0, 264);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(250, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "Proveedores";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 218);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(250, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "Clientes";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(250, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Ventas";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnprod
            // 
            this.btnprod.FlatAppearance.BorderSize = 0;
            this.btnprod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnprod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprod.ForeColor = System.Drawing.Color.White;
            this.btnprod.Image = ((System.Drawing.Image)(resources.GetObject("btnprod.Image")));
            this.btnprod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprod.Location = new System.Drawing.Point(0, 126);
            this.btnprod.Name = "btnprod";
            this.btnprod.Size = new System.Drawing.Size(250, 40);
            this.btnprod.TabIndex = 1;
            this.btnprod.Text = "Productio List";
            this.btnprod.UseVisualStyleBackColor = true;
            this.btnprod.Click += new System.EventHandler(this.btnprod_Click);
            // 
            // btnlogoInicio
            // 
            this.btnlogoInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogoInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnlogoInicio.Image")));
            this.btnlogoInicio.Location = new System.Drawing.Point(3, 6);
            this.btnlogoInicio.Name = "btnlogoInicio";
            this.btnlogoInicio.Size = new System.Drawing.Size(254, 76);
            this.btnlogoInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnlogoInicio.TabIndex = 0;
            this.btnlogoInicio.TabStop = false;
            this.btnlogoInicio.Click += new System.EventHandler(this.btnlogoInicio_Click);
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ControlBox = false;
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.MenuVertical);
            this.Name = "FrmDashboard";
            this.Text = "FrmDashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.BarraTitulo.ResumeLayout(false);
            this.MenuVertical.ResumeLayout(false);
            this.MenuVertical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconrestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconmaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconcerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogoInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.PictureBox iconcerrar;
        private System.Windows.Forms.Label lblcorreo;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox iconminimizar;
        private System.Windows.Forms.PictureBox iconrestaurar;
        private System.Windows.Forms.PictureBox iconmaximizar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox btnlogoInicio;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Button btnprod;
    }
}