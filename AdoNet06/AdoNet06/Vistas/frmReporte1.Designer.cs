namespace AdoNet06.Vistas
{
    partial class frmReporte1
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
            this.crvPrecios = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPrecios
            // 
            this.crvPrecios.ActiveViewIndex = -1;
            this.crvPrecios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrecios.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPrecios.Location = new System.Drawing.Point(0, 0);
            this.crvPrecios.Name = "crvPrecios";
            this.crvPrecios.Size = new System.Drawing.Size(709, 505);
            this.crvPrecios.TabIndex = 0;
            // 
            // frmReporte1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 505);
            this.Controls.Add(this.crvPrecios);
            this.Name = "frmReporte1";
            this.Text = "REPORTE DE PRECIOS";
            this.Load += new System.EventHandler(this.frmReporte1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrecios;
    }
}