namespace Sklep.Forms
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.footer_author = new System.Windows.Forms.Label();
            this.footer_university = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_goto_shop = new System.Windows.Forms.Button();
            this.btn_goto_admin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // footer_author
            // 
            this.footer_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.footer_author.AutoSize = true;
            this.footer_author.Location = new System.Drawing.Point(12, 404);
            this.footer_author.Name = "footer_author";
            this.footer_author.Size = new System.Drawing.Size(220, 13);
            this.footer_author.TabIndex = 0;
            this.footer_author.Text = "Autor: Mateusz Rytelewski, Jakub Ptaszyński";
            // 
            // footer_university
            // 
            this.footer_university.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.footer_university.AutoSize = true;
            this.footer_university.Location = new System.Drawing.Point(390, 404);
            this.footer_university.Name = "footer_university";
            this.footer_university.Size = new System.Drawing.Size(232, 13);
            this.footer_university.TabIndex = 1;
            this.footer_university.Text = "UWM - Wydział Matematyki i Informatyki - 2017";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(610, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_goto_shop
            // 
            this.btn_goto_shop.Location = new System.Drawing.Point(12, 273);
            this.btn_goto_shop.Name = "btn_goto_shop";
            this.btn_goto_shop.Size = new System.Drawing.Size(202, 51);
            this.btn_goto_shop.TabIndex = 3;
            this.btn_goto_shop.Text = "Sklep";
            this.btn_goto_shop.UseVisualStyleBackColor = true;
            this.btn_goto_shop.Click += new System.EventHandler(this.btn_goto_shop_Click);
            // 
            // btn_goto_admin
            // 
            this.btn_goto_admin.Location = new System.Drawing.Point(420, 273);
            this.btn_goto_admin.Name = "btn_goto_admin";
            this.btn_goto_admin.Size = new System.Drawing.Size(202, 51);
            this.btn_goto_admin.TabIndex = 4;
            this.btn_goto_admin.Text = "Panel administracyjny";
            this.btn_goto_admin.UseVisualStyleBackColor = true;
            this.btn_goto_admin.Click += new System.EventHandler(this.btn_goto_admin_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 426);
            this.Controls.Add(this.btn_goto_admin);
            this.Controls.Add(this.btn_goto_shop);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.footer_university);
            this.Controls.Add(this.footer_author);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 465);
            this.MinimumSize = new System.Drawing.Size(650, 465);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empik - Zarządzenie Sklepem";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label footer_author;
        private System.Windows.Forms.Label footer_university;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_goto_shop;
        private System.Windows.Forms.Button btn_goto_admin;
    }
}