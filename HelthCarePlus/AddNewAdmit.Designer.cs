namespace HelthCarePlus
{
    partial class AddNewAdmit
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.select_room = new System.Windows.Forms.ComboBox();
            this.select_patient = new System.Windows.Forms.ComboBox();
            this.btn_addmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(384, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 47;
            this.label3.Text = "Select Paitent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(112, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Select Room";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(111, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 25);
            this.label1.TabIndex = 43;
            this.label1.Text = "NEW ROOM ADMIT";
            // 
            // select_room
            // 
            this.select_room.FormattingEnabled = true;
            this.select_room.Location = new System.Drawing.Point(230, 137);
            this.select_room.Name = "select_room";
            this.select_room.Size = new System.Drawing.Size(121, 21);
            this.select_room.TabIndex = 48;
            // 
            // select_patient
            // 
            this.select_patient.FormattingEnabled = true;
            this.select_patient.Location = new System.Drawing.Point(521, 137);
            this.select_patient.Name = "select_patient";
            this.select_patient.Size = new System.Drawing.Size(121, 21);
            this.select_patient.TabIndex = 49;
            // 
            // btn_addmit
            // 
            this.btn_addmit.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_addmit.Location = new System.Drawing.Point(116, 230);
            this.btn_addmit.Name = "btn_addmit";
            this.btn_addmit.Size = new System.Drawing.Size(112, 31);
            this.btn_addmit.TabIndex = 50;
            this.btn_addmit.Text = "Admit";
            this.btn_addmit.UseVisualStyleBackColor = true;
            this.btn_addmit.Click += new System.EventHandler(this.btn_addmit_Click);
            // 
            // AddNewAdmit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_addmit);
            this.Controls.Add(this.select_patient);
            this.Controls.Add(this.select_room);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "AddNewAdmit";
            this.Text = "AddNewAdmit";
            this.Load += new System.EventHandler(this.load_admit);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox select_room;
        private System.Windows.Forms.ComboBox select_patient;
        private System.Windows.Forms.Button btn_addmit;
    }
}