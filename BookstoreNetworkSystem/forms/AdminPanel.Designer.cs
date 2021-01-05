namespace BookstoreNetworkSystem.forms
{
    partial class AdminPanel
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.authorsButton = new System.Windows.Forms.Button();
            this.bookStoresButton = new System.Windows.Forms.Button();
            this.booksButton = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(265, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1033, 60);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.authorsButton);
            this.panel1.Controls.Add(this.bookStoresButton);
            this.panel1.Controls.Add(this.booksButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 628);
            this.panel1.TabIndex = 3;
            // 
            // authorsButton
            // 
            this.authorsButton.FlatAppearance.BorderSize = 0;
            this.authorsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorsButton.ForeColor = System.Drawing.Color.White;
            this.authorsButton.Image = global::BookstoreNetworkSystem.Properties.Resources.author_sign;
            this.authorsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.authorsButton.Location = new System.Drawing.Point(12, 61);
            this.authorsButton.Name = "authorsButton";
            this.authorsButton.Size = new System.Drawing.Size(253, 73);
            this.authorsButton.TabIndex = 4;
            this.authorsButton.Text = "    Автори";
            this.authorsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.authorsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.authorsButton.UseVisualStyleBackColor = true;
            this.authorsButton.Click += new System.EventHandler(this.authorsButton_Click);
            // 
            // bookStoresButton
            // 
            this.bookStoresButton.FlatAppearance.BorderSize = 0;
            this.bookStoresButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookStoresButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bookStoresButton.ForeColor = System.Drawing.Color.White;
            this.bookStoresButton.Image = global::BookstoreNetworkSystem.Properties.Resources.market;
            this.bookStoresButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bookStoresButton.Location = new System.Drawing.Point(12, 219);
            this.bookStoresButton.Name = "bookStoresButton";
            this.bookStoresButton.Size = new System.Drawing.Size(253, 73);
            this.bookStoresButton.TabIndex = 3;
            this.bookStoresButton.Text = "    Книгарні";
            this.bookStoresButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bookStoresButton.UseVisualStyleBackColor = true;
            this.bookStoresButton.Click += new System.EventHandler(this.bookStoresButton_Click);
            // 
            // booksButton
            // 
            this.booksButton.FlatAppearance.BorderSize = 0;
            this.booksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.booksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.booksButton.ForeColor = System.Drawing.Color.White;
            this.booksButton.Image = global::BookstoreNetworkSystem.Properties.Resources.open_book;
            this.booksButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.booksButton.Location = new System.Drawing.Point(12, 140);
            this.booksButton.Name = "booksButton";
            this.booksButton.Size = new System.Drawing.Size(253, 73);
            this.booksButton.TabIndex = 2;
            this.booksButton.Text = "    Книги";
            this.booksButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.booksButton.UseVisualStyleBackColor = true;
            this.booksButton.Click += new System.EventHandler(this.booksButton_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Location = new System.Drawing.Point(265, 59);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1033, 569);
            this.controlPanel.TabIndex = 5;
            // 
            // AdminPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1298, 628);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bookStoresButton;
        private System.Windows.Forms.Button booksButton;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button authorsButton;
    }
}