namespace Breakout
{
    partial class GameForm
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
            this.GamePanel = new System.Windows.Forms.Panel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.InsertCoinButton = new System.Windows.Forms.Button();
            this.lbl_Points = new System.Windows.Forms.Label();
            this.lbl_Lives = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.GamePanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.GamePanel.BackColor = System.Drawing.Color.Black;
            this.GamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GamePanel.Controls.Add(this.MenuPanel);
            this.GamePanel.Location = new System.Drawing.Point(0, 0);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(508, 324);
            this.GamePanel.TabIndex = 0;
            this.GamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseMove);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(208)))), ((int)(((byte)(240)))));
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.Controls.Add(this.MessageLabel);
            this.MenuPanel.Controls.Add(this.pictureBox1);
            this.MenuPanel.Controls.Add(this.InsertCoinButton);
            this.MenuPanel.Location = new System.Drawing.Point(126, 82);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(248, 128);
            this.MenuPanel.TabIndex = 0;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(74, 40);
            this.MessageLabel.MaximumSize = new System.Drawing.Size(102, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MessageLabel.Size = new System.Drawing.Size(102, 13);
            this.MessageLabel.TabIndex = 3;
            this.MessageLabel.Text = "Insert a coin to play!";
            // 
            // InsertCoinButton
            // 
            this.InsertCoinButton.BackColor = System.Drawing.Color.Orange;
            this.InsertCoinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertCoinButton.ForeColor = System.Drawing.Color.Yellow;
            this.InsertCoinButton.Location = new System.Drawing.Point(83, 89);
            this.InsertCoinButton.Name = "InsertCoinButton";
            this.InsertCoinButton.Size = new System.Drawing.Size(85, 34);
            this.InsertCoinButton.TabIndex = 2;
            this.InsertCoinButton.Text = "Insert Coin";
            this.InsertCoinButton.UseVisualStyleBackColor = false;
            this.InsertCoinButton.Click += new System.EventHandler(this.InsertCoinButton_Click);
            // 
            // lbl_Points
            // 
            this.lbl_Points.AutoSize = true;
            this.lbl_Points.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Points.ForeColor = System.Drawing.Color.White;
            this.lbl_Points.Location = new System.Drawing.Point(64, 328);
            this.lbl_Points.Name = "lbl_Points";
            this.lbl_Points.Size = new System.Drawing.Size(19, 20);
            this.lbl_Points.TabIndex = 3;
            this.lbl_Points.Text = "0";
            // 
            // lbl_Lives
            // 
            this.lbl_Lives.AutoSize = true;
            this.lbl_Lives.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Lives.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Lives.ForeColor = System.Drawing.Color.White;
            this.lbl_Lives.Location = new System.Drawing.Point(64, 350);
            this.lbl_Lives.Name = "lbl_Lives";
            this.lbl_Lives.Size = new System.Drawing.Size(19, 20);
            this.lbl_Lives.TabIndex = 4;
            this.lbl_Lives.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lives:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Breakout.Properties.Resources.Title;
            this.pictureBox1.Location = new System.Drawing.Point(50, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 30);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ContinueButton
            // 
            this.ContinueButton.BackColor = System.Drawing.Color.White;
            this.ContinueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueButton.Location = new System.Drawing.Point(387, 333);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(110, 31);
            this.ContinueButton.TabIndex = 7;
            this.ContinueButton.Text = "CONTINUE";
            this.ContinueButton.UseVisualStyleBackColor = false;
            this.ContinueButton.Visible = false;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(121)))), ((int)(((byte)(171)))));
            this.ClientSize = new System.Drawing.Size(509, 374);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Lives);
            this.Controls.Add(this.lbl_Points);
            this.Controls.Add(this.GamePanel);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Breakout";
            this.GamePanel.ResumeLayout(false);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Button InsertCoinButton;
        private System.Windows.Forms.Label lbl_Points;
        private System.Windows.Forms.Label lbl_Lives;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button ContinueButton;
    }
}

