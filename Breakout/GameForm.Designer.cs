﻿namespace Breakout
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
            this.DebugButton = new System.Windows.Forms.Button();
            this.InsertCoinButton = new System.Windows.Forms.Button();
            this.lbl_Points = new System.Windows.Forms.Label();
            this.lbl_Lives = new System.Windows.Forms.Label();
            this.TESTMEMES = new System.Windows.Forms.PictureBox();
            this.GamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TESTMEMES)).BeginInit();
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.GamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GamePanel.Controls.Add(this.TESTMEMES);
            this.GamePanel.Location = new System.Drawing.Point(12, 12);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(485, 324);
            this.GamePanel.TabIndex = 0;
            this.GamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseMove);
            // 
            // DebugButton
            // 
            this.DebugButton.Location = new System.Drawing.Point(422, 368);
            this.DebugButton.Name = "DebugButton";
            this.DebugButton.Size = new System.Drawing.Size(75, 23);
            this.DebugButton.TabIndex = 1;
            this.DebugButton.Text = "Debug";
            this.DebugButton.UseVisualStyleBackColor = true;
            this.DebugButton.Click += new System.EventHandler(this.DebugButton_Click);
            // 
            // InsertCoinButton
            // 
            this.InsertCoinButton.Location = new System.Drawing.Point(341, 368);
            this.InsertCoinButton.Name = "InsertCoinButton";
            this.InsertCoinButton.Size = new System.Drawing.Size(75, 23);
            this.InsertCoinButton.TabIndex = 2;
            this.InsertCoinButton.Text = "Insert Coin";
            this.InsertCoinButton.UseVisualStyleBackColor = true;
            this.InsertCoinButton.Click += new System.EventHandler(this.InsertCoinButton_Click);
            // 
            // lbl_Points
            // 
            this.lbl_Points.AutoSize = true;
            this.lbl_Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Points.Location = new System.Drawing.Point(12, 354);
            this.lbl_Points.Name = "lbl_Points";
            this.lbl_Points.Size = new System.Drawing.Size(70, 20);
            this.lbl_Points.TabIndex = 3;
            this.lbl_Points.Text = "Points: 0";
            // 
            // lbl_Lives
            // 
            this.lbl_Lives.AutoSize = true;
            this.lbl_Lives.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Lives.Location = new System.Drawing.Point(20, 374);
            this.lbl_Lives.Name = "lbl_Lives";
            this.lbl_Lives.Size = new System.Drawing.Size(62, 20);
            this.lbl_Lives.TabIndex = 4;
            this.lbl_Lives.Text = "Lives: 0";
            // 
            // TESTMEMES
            // 
            this.TESTMEMES.Location = new System.Drawing.Point(0, 0);
            this.TESTMEMES.Name = "TESTMEMES";
            this.TESTMEMES.Size = new System.Drawing.Size(70, 35);
            this.TESTMEMES.TabIndex = 0;
            this.TESTMEMES.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 420);
            this.Controls.Add(this.lbl_Lives);
            this.Controls.Add(this.lbl_Points);
            this.Controls.Add(this.InsertCoinButton);
            this.Controls.Add(this.DebugButton);
            this.Controls.Add(this.GamePanel);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "Breakout";
            this.GamePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TESTMEMES)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Button DebugButton;
        private System.Windows.Forms.Button InsertCoinButton;
        private System.Windows.Forms.Label lbl_Points;
        private System.Windows.Forms.Label lbl_Lives;
        private System.Windows.Forms.PictureBox TESTMEMES;
    }
}

