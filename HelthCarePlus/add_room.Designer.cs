namespace HelthCarePlus
{
    partial class add_room
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
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.txt_room_number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rd_ac = new System.Windows.Forms.RadioButton();
            this.rc_non_ac = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.button1.ForeColor = System.Drawing.Color.Honeydew;
            this.button1.Location = new System.Drawing.Point(503, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 31);
            this.button1.TabIndex = 51;
            this.button1.Text = "Continue";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(405, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(107, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Room Number";
            // 
            // txt_price
            // 
            this.txt_price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txt_price.Location = new System.Drawing.Point(522, 151);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(143, 26);
            this.txt_price.TabIndex = 40;
            // 
            // txt_room_number
            // 
            this.txt_room_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_room_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_room_number.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txt_room_number.Location = new System.Drawing.Point(236, 151);
            this.txt_room_number.Name = "txt_room_number";
            this.txt_room_number.Size = new System.Drawing.Size(143, 26);
            this.txt_room_number.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(106, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "ADD A ROOM";
            // 
            // rd_ac
            // 
            this.rd_ac.AutoSize = true;
            this.rd_ac.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rd_ac.Location = new System.Drawing.Point(111, 229);
            this.rd_ac.Name = "rd_ac";
            this.rd_ac.Size = new System.Drawing.Size(39, 17);
            this.rd_ac.TabIndex = 52;
            this.rd_ac.TabStop = true;
            this.rd_ac.Text = "AC";
            this.rd_ac.UseVisualStyleBackColor = true;
            // 
            // rc_non_ac
            // 
            this.rc_non_ac.AutoSize = true;
            this.rc_non_ac.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rc_non_ac.Location = new System.Drawing.Point(202, 229);
            this.rc_non_ac.Name = "rc_non_ac";
            this.rc_non_ac.Size = new System.Drawing.Size(62, 17);
            this.rc_non_ac.TabIndex = 53;
            this.rc_non_ac.TabStop = true;
            this.rc_non_ac.Text = "Non-AC";
            this.rc_non_ac.UseVisualStyleBackColor = true;
            // 
            // add_room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rc_non_ac);
            this.Controls.Add(this.rd_ac);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.txt_room_number);
            this.Controls.Add(this.label1);
            this.Name = "add_room";
            this.Text = "add_room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.TextBox txt_room_number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rd_ac;
        private System.Windows.Forms.RadioButton rc_non_ac;
    }
}