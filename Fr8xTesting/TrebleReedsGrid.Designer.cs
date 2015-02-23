namespace Fr8xTesting
{
    partial class TrebleReedsGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Foot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reedType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cassotto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trebleRegisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trebleRegisterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Foot,
            this.reedType,
            this.Enabled,
            this.Cassotto,
            this.Volume});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(544, 199);
            this.dataGridView1.TabIndex = 0;
            // 
            // Foot
            // 
            this.Foot.HeaderText = "Foot";
            this.Foot.Name = "Foot";
            this.Foot.ReadOnly = true;
            // 
            // reedType
            // 
            this.reedType.HeaderText = "Reed Type";
            this.reedType.Name = "reedType";
            // 
            // Enabled
            // 
            this.Enabled.DataPropertyName = "name";
            this.Enabled.HeaderText = "Enabled?";
            this.Enabled.Name = "Enabled";
            // 
            // Cassotto
            // 
            this.Cassotto.HeaderText = "Cassotto?";
            this.Cassotto.Name = "Cassotto";
            // 
            // Volume
            // 
            this.Volume.HeaderText = "Volume";
            this.Volume.Name = "Volume";
            // 
            // trebleRegisterBindingSource
            // 
            this.trebleRegisterBindingSource.DataSource = typeof(Fr8xTesting.TrebleRegister);
            // 
            // TrebleReedsGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "TrebleReedsGrid";
            this.Size = new System.Drawing.Size(550, 206);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trebleRegisterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource trebleRegisterBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Foot;
        private System.Windows.Forms.DataGridViewComboBoxColumn reedType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enabled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cassotto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
    }
}
