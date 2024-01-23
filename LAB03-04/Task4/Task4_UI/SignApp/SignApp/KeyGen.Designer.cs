
namespace SignApp
{
    partial class KeyGen
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPuKeyPath = new System.Windows.Forms.Button();
            this.btnPrKeyPath = new System.Windows.Forms.Button();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "PublicKey Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "PrivateKey Path";
            // 
            // btnPuKeyPath
            // 
            this.btnPuKeyPath.Location = new System.Drawing.Point(585, 146);
            this.btnPuKeyPath.Name = "btnPuKeyPath";
            this.btnPuKeyPath.Size = new System.Drawing.Size(78, 50);
            this.btnPuKeyPath.TabIndex = 15;
            this.btnPuKeyPath.Text = "Browse";
            this.btnPuKeyPath.UseVisualStyleBackColor = true;
            this.btnPuKeyPath.Click += new System.EventHandler(this.btnPuKeyPath_Click);
            // 
            // btnPrKeyPath
            // 
            this.btnPrKeyPath.Location = new System.Drawing.Point(585, 60);
            this.btnPrKeyPath.Name = "btnPrKeyPath";
            this.btnPrKeyPath.Size = new System.Drawing.Size(78, 50);
            this.btnPrKeyPath.TabIndex = 16;
            this.btnPrKeyPath.Text = "Browse";
            this.btnPrKeyPath.UseVisualStyleBackColor = true;
            this.btnPrKeyPath.Click += new System.EventHandler(this.btnPrKeyPath_Click);
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPublicKey.Location = new System.Drawing.Point(58, 146);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(503, 50);
            this.txtPublicKey.TabIndex = 13;
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.txtPrivateKey.Location = new System.Drawing.Point(58, 60);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(503, 50);
            this.txtPrivateKey.TabIndex = 14;
            // 
            // btnSign
            // 
            this.btnSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnSign.Location = new System.Drawing.Point(248, 255);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(210, 59);
            this.btnSign.TabIndex = 19;
            this.btnSign.Text = "Key Generate";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // KeyGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 346);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPuKeyPath);
            this.Controls.Add(this.btnPrKeyPath);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.txtPrivateKey);
            this.Name = "KeyGen";
            this.Text = "KeyGen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPuKeyPath;
        private System.Windows.Forms.Button btnPrKeyPath;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Button btnSign;
    }
}