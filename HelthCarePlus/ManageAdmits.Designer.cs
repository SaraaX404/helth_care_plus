namespace HelthCarePlus
{
    partial class ManageAdmits
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
            this.back = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_add_new_admit = new System.Windows.Forms.Button();
            this.grid_admits = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_admits)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.back.Location = new System.Drawing.Point(107, 400);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(112, 31);
            this.back.TabIndex = 29;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // btn_download
            // 
            this.btn_download.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_download.Location = new System.Drawing.Point(107, 363);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(591, 31);
            this.btn_download.TabIndex = 28;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            // 
            // btn_add_new_admit
            // 
            this.btn_add_new_admit.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_add_new_admit.Location = new System.Drawing.Point(556, 20);
            this.btn_add_new_admit.Name = "btn_add_new_admit";
            this.btn_add_new_admit.Size = new System.Drawing.Size(112, 31);
            this.btn_add_new_admit.TabIndex = 27;
            this.btn_add_new_admit.Text = "Add New ";
            this.btn_add_new_admit.UseVisualStyleBackColor = true;
            this.btn_add_new_admit.Click += new System.EventHandler(this.btn_add_new_admit_Click);
            // 
            // grid_admits
            // 
            this.grid_admits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_admits.Location = new System.Drawing.Point(123, 63);
            this.grid_admits.Name = "grid_admits";
            this.grid_admits.Size = new System.Drawing.Size(545, 278);
            this.grid_admits.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(118, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "RECENT ADMITS";
            // 
            // ManageAdmits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_add_new_admit);
            this.Controls.Add(this.grid_admits);
            this.Controls.Add(this.label1);
            this.Name = "ManageAdmits";
            this.Text = "ManageAdmits";
            this.Load += new System.EventHandler(this.user_load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_admits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_add_new_admit;
        private System.Windows.Forms.DataGridView grid_admits;
        private System.Windows.Forms.Label label1;
    }
}