namespace WindowsFormsApplication23
{
    partial class reportprint
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.patientdetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supremhospitalDataSet1 = new WindowsFormsApplication23.supremhospitalDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.patientdetailsTableAdapter = new WindowsFormsApplication23.supremhospitalDataSet1TableAdapters.patientdetailsTableAdapter();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.patientdetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supremhospitalDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // patientdetailsBindingSource
            // 
            this.patientdetailsBindingSource.DataMember = "patientdetails";
            this.patientdetailsBindingSource.DataSource = this.supremhospitalDataSet1;
            // 
            // supremhospitalDataSet1
            // 
            this.supremhospitalDataSet1.DataSetName = "supremhospitalDataSet1";
            this.supremhospitalDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.patientdetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication23.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 26);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(886, 359);
            this.reportViewer1.TabIndex = 0;
            // 
            // patientdetailsTableAdapter
            // 
            this.patientdetailsTableAdapter.ClearBeforeFill = true;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Red;
            this.button6.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Location = new System.Drawing.Point(777, 392);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(81, 36);
            this.button6.TabIndex = 64;
            this.button6.Text = "Back";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(696, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 21);
            this.label3.TabIndex = 65;
            this.label3.Text = "SUPREM HOSPITAL";
            // 
            // reportprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 440);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.reportViewer1);
            this.Name = "reportprint";
            this.Text = "reportprint";
            this.Load += new System.EventHandler(this.reportprint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.patientdetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supremhospitalDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource patientdetailsBindingSource;
        private supremhospitalDataSet1 supremhospitalDataSet1;
        private supremhospitalDataSet1TableAdapters.patientdetailsTableAdapter patientdetailsTableAdapter;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
    }
}