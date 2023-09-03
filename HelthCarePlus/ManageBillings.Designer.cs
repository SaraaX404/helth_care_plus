namespace HelthCarePlus
{
    partial class ManageBillings
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
            this.rdb_admit = new System.Windows.Forms.RadioButton();
            this.rdb_apt = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTot = new System.Windows.Forms.Label();
            this.lblBal = new System.Windows.Forms.Label();
            this.cmb_id = new System.Windows.Forms.ComboBox();
            this.txt_pay = new System.Windows.Forms.TextBox();
            this.btn_add_new_resource = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_res = new System.Windows.Forms.Label();
            this.data_grid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // rdb_admit
            // 
            this.rdb_admit.AutoSize = true;
            this.rdb_admit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rdb_admit.Location = new System.Drawing.Point(73, 47);
            this.rdb_admit.Name = "rdb_admit";
            this.rdb_admit.Size = new System.Drawing.Size(87, 17);
            this.rdb_admit.TabIndex = 0;
            this.rdb_admit.TabStop = true;
            this.rdb_admit.Text = "Room Admits";
            this.rdb_admit.UseVisualStyleBackColor = true;
            this.rdb_admit.CheckedChanged += new System.EventHandler(this.rdb_admit_CheckedChanged);
            // 
            // rdb_apt
            // 
            this.rdb_apt.AutoSize = true;
            this.rdb_apt.ForeColor = System.Drawing.SystemColors.Control;
            this.rdb_apt.Location = new System.Drawing.Point(197, 47);
            this.rdb_apt.Name = "rdb_apt";
            this.rdb_apt.Size = new System.Drawing.Size(92, 17);
            this.rdb_apt.TabIndex = 1;
            this.rdb_apt.TabStop = true;
            this.rdb_apt.Text = "Appointments ";
            this.rdb_apt.UseVisualStyleBackColor = true;
            this.rdb_apt.CheckedChanged += new System.EventHandler(this.rdb_apt_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(61, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(61, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Balance";
            // 
            // lblTot
            // 
            this.lblTot.AutoSize = true;
            this.lblTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTot.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTot.Location = new System.Drawing.Point(185, 139);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(0, 24);
            this.lblTot.TabIndex = 4;
            // 
            // lblBal
            // 
            this.lblBal.AutoSize = true;
            this.lblBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBal.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBal.Location = new System.Drawing.Point(185, 258);
            this.lblBal.Name = "lblBal";
            this.lblBal.Size = new System.Drawing.Size(0, 24);
            this.lblBal.TabIndex = 5;
            // 
            // cmb_id
            // 
            this.cmb_id.FormattingEnabled = true;
            this.cmb_id.Location = new System.Drawing.Point(73, 92);
            this.cmb_id.Name = "cmb_id";
            this.cmb_id.Size = new System.Drawing.Size(121, 21);
            this.cmb_id.TabIndex = 6;
            this.cmb_id.SelectedIndexChanged += new System.EventHandler(this.cmb_id_SelectedIndexChanged);
            // 
            // txt_pay
            // 
            this.txt_pay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pay.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txt_pay.Location = new System.Drawing.Point(65, 198);
            this.txt_pay.Name = "txt_pay";
            this.txt_pay.Size = new System.Drawing.Size(120, 26);
            this.txt_pay.TabIndex = 21;
            // 
            // btn_add_new_resource
            // 
            this.btn_add_new_resource.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_add_new_resource.Location = new System.Drawing.Point(191, 198);
            this.btn_add_new_resource.Name = "btn_add_new_resource";
            this.btn_add_new_resource.Size = new System.Drawing.Size(75, 26);
            this.btn_add_new_resource.TabIndex = 22;
            this.btn_add_new_resource.Text = "Pay";
            this.btn_add_new_resource.UseVisualStyleBackColor = true;
            this.btn_add_new_resource.Click += new System.EventHandler(this.btn_add_new_resource_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.button1.Location = new System.Drawing.Point(65, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 26);
            this.button1.TabIndex = 23;
            this.button1.Text = "Download Invoice";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(330, 240);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(441, 151);
            this.dataGridView1.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(326, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "History";
            // 
            // lbl_res
            // 
            this.lbl_res.AutoSize = true;
            this.lbl_res.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_res.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_res.Location = new System.Drawing.Point(326, 47);
            this.lbl_res.Name = "lbl_res";
            this.lbl_res.Size = new System.Drawing.Size(58, 24);
            this.lbl_res.TabIndex = 26;
            this.lbl_res.Text = "Admit";
            // 
            // data_grid
            // 
            this.data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid.Location = new System.Drawing.Point(330, 92);
            this.data_grid.Name = "data_grid";
            this.data_grid.Size = new System.Drawing.Size(441, 98);
            this.data_grid.TabIndex = 29;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.button2.Location = new System.Drawing.Point(65, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 26);
            this.button2.TabIndex = 30;
            this.button2.Text = "Print Invoice";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.button3.Location = new System.Drawing.Point(65, 390);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 26);
            this.button3.TabIndex = 31;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ManageBillings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.data_grid);
            this.Controls.Add(this.lbl_res);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_add_new_resource);
            this.Controls.Add(this.txt_pay);
            this.Controls.Add(this.cmb_id);
            this.Controls.Add(this.lblBal);
            this.Controls.Add(this.lblTot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdb_apt);
            this.Controls.Add(this.rdb_admit);
            this.Name = "ManageBillings";
            this.Text = "ManageBillings";
            this.Load += new System.EventHandler(this.ManageBillings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb_admit;
        private System.Windows.Forms.RadioButton rdb_apt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTot;
        private System.Windows.Forms.Label lblBal;
        private System.Windows.Forms.ComboBox cmb_id;
        private System.Windows.Forms.TextBox txt_pay;
        private System.Windows.Forms.Button btn_add_new_resource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_res;
        private System.Windows.Forms.DataGridView data_grid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}