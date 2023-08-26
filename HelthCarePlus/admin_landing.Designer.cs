namespace HelthCarePlus
{
    partial class AdminLanding
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
            this.btn_manage_users = new System.Windows.Forms.Button();
            this.btn_manage_doctors = new System.Windows.Forms.Button();
            this.btn_manage_paitents = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_manage_users
            // 
            this.btn_manage_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manage_users.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_manage_users.Location = new System.Drawing.Point(311, 93);
            this.btn_manage_users.Name = "btn_manage_users";
            this.btn_manage_users.Size = new System.Drawing.Size(183, 70);
            this.btn_manage_users.TabIndex = 20;
            this.btn_manage_users.Text = "Manage Users";
            this.btn_manage_users.UseVisualStyleBackColor = true;
            this.btn_manage_users.Click += new System.EventHandler(this.btn_manage_users_Click);
            // 
            // btn_manage_doctors
            // 
            this.btn_manage_doctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manage_doctors.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_manage_doctors.Location = new System.Drawing.Point(83, 93);
            this.btn_manage_doctors.Name = "btn_manage_doctors";
            this.btn_manage_doctors.Size = new System.Drawing.Size(183, 70);
            this.btn_manage_doctors.TabIndex = 22;
            this.btn_manage_doctors.Text = "Manage Doctors";
            this.btn_manage_doctors.UseVisualStyleBackColor = true;
            this.btn_manage_doctors.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_manage_paitents
            // 
            this.btn_manage_paitents.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manage_paitents.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_manage_paitents.Location = new System.Drawing.Point(555, 93);
            this.btn_manage_paitents.Name = "btn_manage_paitents";
            this.btn_manage_paitents.Size = new System.Drawing.Size(183, 70);
            this.btn_manage_paitents.TabIndex = 23;
            this.btn_manage_paitents.Text = "Manage Paitents";
            this.btn_manage_paitents.UseVisualStyleBackColor = true;
            this.btn_manage_paitents.Click += new System.EventHandler(this.btn_manage_paitents_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.button1.Location = new System.Drawing.Point(83, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 70);
            this.button1.TabIndex = 24;
            this.button1.Text = "Manage Rooms";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.button2.Location = new System.Drawing.Point(311, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 70);
            this.button2.TabIndex = 25;
            this.button2.Text = "Manage Appointment";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // AdminLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_manage_paitents);
            this.Controls.Add(this.btn_manage_doctors);
            this.Controls.Add(this.btn_manage_users);
            this.Name = "AdminLanding";
            this.Text = "AdminLanding";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_manage_users;
        private System.Windows.Forms.Button btn_manage_doctors;
        private System.Windows.Forms.Button btn_manage_paitents;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}