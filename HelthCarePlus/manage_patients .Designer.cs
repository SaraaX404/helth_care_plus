namespace HelthCarePlus
{
    partial class manage_patients
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
            this.label1 = new System.Windows.Forms.Label();
            this.grid_patients = new System.Windows.Forms.DataGridView();
            this.btn_add_new_patient = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_patients)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(120, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "PATIENT LIST";
            // 
            // grid_patients
            // 
            this.grid_patients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_patients.Location = new System.Drawing.Point(125, 60);
            this.grid_patients.Name = "grid_patients";
            this.grid_patients.Size = new System.Drawing.Size(549, 278);
            this.grid_patients.TabIndex = 10;
            // 
            // btn_add_new_patient
            // 
            this.btn_add_new_patient.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_add_new_patient.Location = new System.Drawing.Point(562, 17);
            this.btn_add_new_patient.Name = "btn_add_new_patient";
            this.btn_add_new_patient.Size = new System.Drawing.Size(112, 31);
            this.btn_add_new_patient.TabIndex = 12;
            this.btn_add_new_patient.Text = "Add New ";
            this.btn_add_new_patient.UseVisualStyleBackColor = true;
            this.btn_add_new_patient.Click += new System.EventHandler(this.btn_add_new_patient_Click);
            // 
            // back
            // 
            this.back.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.back.Location = new System.Drawing.Point(82, 397);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(112, 31);
            this.back.TabIndex = 14;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            // 
            // btn_download
            // 
            this.btn_download.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_download.Location = new System.Drawing.Point(82, 360);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(637, 31);
            this.btn_download.TabIndex = 13;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            // 
            // manage_patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_add_new_patient);
            this.Controls.Add(this.grid_patients);
            this.Controls.Add(this.label1);
            this.Name = "manage_patients";
            this.Text = "manage_patients";
            this.Load += new System.EventHandler(this.manage_patients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_patients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grid_patients;
        private System.Windows.Forms.Button btn_add_new_patient;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button btn_download;
    }
}