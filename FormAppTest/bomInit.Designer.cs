namespace FormAppTest
{
    partial class BomInit
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
            this.bomViewGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bomViewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // bomViewGrid
            // 
            this.bomViewGrid.AllowUserToAddRows = false;
            this.bomViewGrid.AllowUserToDeleteRows = false;
            this.bomViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bomViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bomViewGrid.Location = new System.Drawing.Point(0, 0);
            this.bomViewGrid.MultiSelect = false;
            this.bomViewGrid.Name = "bomViewGrid";
            this.bomViewGrid.ReadOnly = true;
            this.bomViewGrid.Size = new System.Drawing.Size(478, 431);
            this.bomViewGrid.TabIndex = 0;
            // 
            // BomInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 431);
            this.Controls.Add(this.bomViewGrid);
            this.Name = "BomInit";
            this.Text = "BOM View";
            ((System.ComponentModel.ISupportInitialize)(this.bomViewGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView bomViewGrid;
    }
}