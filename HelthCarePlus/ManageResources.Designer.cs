namespace HelthCarePlus
{
    partial class ManageResources
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
            this.btn_add_new_resource = new System.Windows.Forms.Button();
            this.grid_resources = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_resources = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid_resources)).BeginInit();
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
            this.btn_download.Location = new System.Drawing.Point(125, 363);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(286, 31);
            this.btn_download.TabIndex = 18;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            // 
            // btn_add_new_resource
            // 
            this.btn_add_new_resource.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.btn_add_new_resource.Location = new System.Drawing.Point(505, 107);
            this.btn_add_new_resource.Name = "btn_add_new_resource";
            this.btn_add_new_resource.Size = new System.Drawing.Size(172, 31);
            this.btn_add_new_resource.TabIndex = 17;
            this.btn_add_new_resource.Text = "Create";
            this.btn_add_new_resource.UseVisualStyleBackColor = true;
            this.btn_add_new_resource.Click += new System.EventHandler(this.btn_add_new_resource_Click);
            // 
            // grid_resources
            // 
            this.grid_resources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_resources.Location = new System.Drawing.Point(125, 63);
            this.grid_resources.Name = "grid_resources";
            this.grid_resources.Size = new System.Drawing.Size(352, 278);
            this.grid_resources.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(120, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Resources List";
            // 
            // txt_resources
            // 
            this.txt_resources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_resources.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_resources.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txt_resources.Location = new System.Drawing.Point(505, 63);
            this.txt_resources.Name = "txt_resources";
            this.txt_resources.Size = new System.Drawing.Size(172, 26);
            this.txt_resources.TabIndex = 20;
            // 
            // ManageResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_resources);
            this.Controls.Add(this.back);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_add_new_resource);
            this.Controls.Add(this.grid_resources);
            this.Controls.Add(this.label1);
            this.Name = "ManageResources";
            this.Text = "ManageResources";
            this.Load += new System.EventHandler(this.ManageResources_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_resources)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_add_new_resource;
        private System.Windows.Forms.DataGridView grid_resources;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_resources;
    }
}