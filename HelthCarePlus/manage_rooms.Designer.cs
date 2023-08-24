namespace HelthCarePlus
{
    partial class manage_rooms
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
            this.btn_add_new_room = new System.Windows.Forms.Button();
            this.grid_rooms = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_rooms)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.back.Location = new System.Drawing.Point(82, 400);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(112, 31);
            this.back.TabIndex = 19;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // btn_download
            // 
            this.btn_download.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_download.Location = new System.Drawing.Point(82, 363);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(591, 31);
            this.btn_download.TabIndex = 18;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            // 
            // btn_add_new_room
            // 
            this.btn_add_new_room.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_add_new_room.Location = new System.Drawing.Point(561, 20);
            this.btn_add_new_room.Name = "btn_add_new_room";
            this.btn_add_new_room.Size = new System.Drawing.Size(112, 31);
            this.btn_add_new_room.TabIndex = 17;
            this.btn_add_new_room.Text = "Add New ";
            this.btn_add_new_room.UseVisualStyleBackColor = true;
            this.btn_add_new_room.Click += new System.EventHandler(this.btn_add_new_room_Click);
            // 
            // grid_rooms
            // 
            this.grid_rooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_rooms.Location = new System.Drawing.Point(154, 63);
            this.grid_rooms.Name = "grid_rooms";
            this.grid_rooms.Size = new System.Drawing.Size(458, 278);
            this.grid_rooms.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(77, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "ROOMS LIST";
            // 
            // manage_rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_add_new_room);
            this.Controls.Add(this.grid_rooms);
            this.Controls.Add(this.label1);
            this.Name = "manage_rooms";
            this.Text = "manage_rooms";
            this.Load += new System.EventHandler(this.room_load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_rooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_add_new_room;
        private System.Windows.Forms.DataGridView grid_rooms;
        private System.Windows.Forms.Label label1;
    }
}