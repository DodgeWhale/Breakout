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
            this.DebugButton = new System.Windows.Forms.Button();
            this.InsertCoinButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.GamePanel.Location = new System.Drawing.Point(12, 12);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(536, 324);
            this.GamePanel.TabIndex = 0;
            // 
            // DebugButton
            // 
            this.DebugButton.Location = new System.Drawing.Point(473, 369);
            this.DebugButton.Name = "DebugButton";
            this.DebugButton.Size = new System.Drawing.Size(75, 23);
            this.DebugButton.TabIndex = 1;
            this.DebugButton.Text = "Debug";
            this.DebugButton.UseVisualStyleBackColor = true;
            this.DebugButton.Click += new System.EventHandler(this.DebugButton_Click);
            // 
            // InsertCoinButton
            // 
            this.InsertCoinButton.Location = new System.Drawing.Point(392, 369);
            this.InsertCoinButton.Name = "InsertCoinButton";
            this.InsertCoinButton.Size = new System.Drawing.Size(75, 23);
            this.InsertCoinButton.TabIndex = 2;
            this.InsertCoinButton.Text = "Insert Coin";
            this.InsertCoinButton.UseVisualStyleBackColor = true;
            this.InsertCoinButton.Click += new System.EventHandler(this.InsertCoinButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 420);
            this.Controls.Add(this.InsertCoinButton);
            this.Controls.Add(this.DebugButton);
            this.Controls.Add(this.GamePanel);
            this.Name = "GameForm";
            this.Text = "Breakout";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Button DebugButton;
        private System.Windows.Forms.Button InsertCoinButton;
    }
}

