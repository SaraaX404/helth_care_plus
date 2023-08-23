namespace HelthCarePlus
{
    partial class manage_doctors
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
            this.btn_download = new System.Windows.Forms.Button();
            this.grid_doctors = new System.Windows.Forms.DataGridView();
            this.btn_add_new_doctor = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_doctors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(77, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "DOCTORS LIST";
            // 
            // btn_download
            // 
            this.btn_download.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_download.Location = new System.Drawing.Point(82, 357);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(637, 31);
            this.btn_download.TabIndex = 10;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            // 
            // grid_doctors
            // 
            this.grid_doctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_doctors.Location = new System.Drawing.Point(82, 63);
            this.grid_doctors.Name = "grid_doctors";
            this.grid_doctors.Size = new System.Drawing.Size(637, 278);
            this.grid_doctors.TabIndex = 9;
            // 
            // btn_add_new_doctor
            // 
            this.btn_add_new_doctor.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_add_new_doctor.Location = new System.Drawing.Point(607, 18);
            this.btn_add_new_doctor.Name = "btn_add_new_doctor";
            this.btn_add_new_doctor.Size = new System.Drawing.Size(112, 31);
            this.btn_add_new_doctor.TabIndex = 11;
            this.btn_add_new_doctor.Text = "Add New ";
            this.btn_add_new_doctor.UseVisualStyleBackColor = true;
            this.btn_add_new_doctor.Click += new System.EventHandler(this.btn_add_new_doctor_Click);
            // 
            // back
            // 
            this.back.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.back.Location = new System.Drawing.Point(82, 394);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(112, 31);
            this.back.TabIndex = 12;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // manage_doctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back);
            this.Controls.Add(this.btn_add_new_doctor);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.grid_doctors);
            this.Controls.Add(this.label1);
            this.Name = "manage_doctors";
            this.Text = "ManageDoctors";
            this.Load += new System.EventHandler(this.doctors_load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_doctors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.DataGridView grid_doctors;
        private System.Windows.Forms.Button btn_add_new_doctor;
        private System.Windows.Forms.Button back;
    }
}