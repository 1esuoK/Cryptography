
namespace SignApp
{
    partial class Dashboard
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
            this.btnKeyGenTab = new System.Windows.Forms.Button();
            this.btnSignTab = new System.Windows.Forms.Button();
            this.btnVerifyTab = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKeyGenTab
            // 
            this.btnKeyGenTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnKeyGenTab.Location = new System.Drawing.Point(53, 44);
            this.btnKeyGenTab.Name = "btnKeyGenTab";
            this.btnKeyGenTab.Size = new System.Drawing.Size(304, 108);
            this.btnKeyGenTab.TabIndex = 0;
            this.btnKeyGenTab.Text = "Key Generation";
            this.btnKeyGenTab.UseVisualStyleBackColor = true;
            this.btnKeyGenTab.Click += new System.EventHandler(this.btnKeyGenTab_Click);
            // 
            // btnSignTab
            // 
            this.btnSignTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnSignTab.Location = new System.Drawing.Point(53, 180);
            this.btnSignTab.Name = "btnSignTab";
            this.btnSignTab.Size = new System.Drawing.Size(304, 108);
            this.btnSignTab.TabIndex = 0;
            this.btnSignTab.Text = "Sign";
            this.btnSignTab.UseVisualStyleBackColor = true;
            this.btnSignTab.Click += new System.EventHandler(this.btnSignTab_Click);
            // 
            // btnVerifyTab
            // 
            this.btnVerifyTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnVerifyTab.Location = new System.Drawing.Point(53, 318);
            this.btnVerifyTab.Name = "btnVerifyTab";
            this.btnVerifyTab.Size = new System.Drawing.Size(304, 108);
            this.btnVerifyTab.TabIndex = 0;
            this.btnVerifyTab.Text = "Verify";
            this.btnVerifyTab.UseVisualStyleBackColor = true;
            this.btnVerifyTab.Click += new System.EventHandler(this.btnVerifyTab_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 454);
            this.Controls.Add(this.btnVerifyTab);
            this.Controls.Add(this.btnSignTab);
            this.Controls.Add(this.btnKeyGenTab);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKeyGenTab;
        private System.Windows.Forms.Button btnSignTab;
        private System.Windows.Forms.Button btnVerifyTab;
    }
}