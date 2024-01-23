
namespace RSA
{
    partial class Decrypt
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
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnBrowseCipher = new System.Windows.Forms.Button();
            this.btnBrowsePlain = new System.Windows.Forms.Button();
            this.btnBrowseKey = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCipherPath = new System.Windows.Forms.TextBox();
            this.txtPlainPath = new System.Windows.Forms.TextBox();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.txtPlain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnDecrypt.Location = new System.Drawing.Point(586, 336);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(140, 61);
            this.btnDecrypt.TabIndex = 9;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnBrowseCipher
            // 
            this.btnBrowseCipher.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBrowseCipher.Location = new System.Drawing.Point(586, 146);
            this.btnBrowseCipher.Name = "btnBrowseCipher";
            this.btnBrowseCipher.Size = new System.Drawing.Size(140, 41);
            this.btnBrowseCipher.TabIndex = 10;
            this.btnBrowseCipher.Text = "Browse";
            this.btnBrowseCipher.UseVisualStyleBackColor = true;
            this.btnBrowseCipher.Click += new System.EventHandler(this.btnBrowseCipher_Click);
            // 
            // btnBrowsePlain
            // 
            this.btnBrowsePlain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBrowsePlain.Location = new System.Drawing.Point(586, 240);
            this.btnBrowsePlain.Name = "btnBrowsePlain";
            this.btnBrowsePlain.Size = new System.Drawing.Size(140, 41);
            this.btnBrowsePlain.TabIndex = 11;
            this.btnBrowsePlain.Text = "Browse";
            this.btnBrowsePlain.UseVisualStyleBackColor = true;
            this.btnBrowsePlain.Click += new System.EventHandler(this.btnBrowsePlain_Click);
            // 
            // btnBrowseKey
            // 
            this.btnBrowseKey.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBrowseKey.Location = new System.Drawing.Point(586, 60);
            this.btnBrowseKey.Name = "btnBrowseKey";
            this.btnBrowseKey.Size = new System.Drawing.Size(140, 41);
            this.btnBrowseKey.TabIndex = 12;
            this.btnBrowseKey.Text = "Browse";
            this.btnBrowseKey.UseVisualStyleBackColor = true;
            this.btnBrowseKey.Click += new System.EventHandler(this.btnBrowseKey_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(48, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ciphertext Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(48, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Plaintext Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(48, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "PrivateKey Path";
            // 
            // txtCipherPath
            // 
            this.txtCipherPath.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCipherPath.Location = new System.Drawing.Point(51, 146);
            this.txtCipherPath.Multiline = true;
            this.txtCipherPath.Name = "txtCipherPath";
            this.txtCipherPath.Size = new System.Drawing.Size(496, 41);
            this.txtCipherPath.TabIndex = 3;
            // 
            // txtPlainPath
            // 
            this.txtPlainPath.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPlainPath.Location = new System.Drawing.Point(51, 240);
            this.txtPlainPath.Multiline = true;
            this.txtPlainPath.Name = "txtPlainPath";
            this.txtPlainPath.Size = new System.Drawing.Size(496, 41);
            this.txtPlainPath.TabIndex = 4;
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPrivateKey.Location = new System.Drawing.Point(51, 60);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(496, 41);
            this.txtPrivateKey.TabIndex = 5;
            // 
            // txtPlain
            // 
            this.txtPlain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPlain.Location = new System.Drawing.Point(51, 336);
            this.txtPlain.Multiline = true;
            this.txtPlain.Name = "txtPlain";
            this.txtPlain.ReadOnly = true;
            this.txtPlain.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtPlain.Size = new System.Drawing.Size(496, 106);
            this.txtPlain.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(48, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Plaintext";
            // 
            // Decrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 484);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnBrowseCipher);
            this.Controls.Add(this.btnBrowsePlain);
            this.Controls.Add(this.btnBrowseKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCipherPath);
            this.Controls.Add(this.txtPlain);
            this.Controls.Add(this.txtPlainPath);
            this.Controls.Add(this.txtPrivateKey);
            this.Name = "Decrypt";
            this.Text = "Decrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnBrowseCipher;
        private System.Windows.Forms.Button btnBrowsePlain;
        private System.Windows.Forms.Button btnBrowseKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCipherPath;
        private System.Windows.Forms.TextBox txtPlainPath;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.TextBox txtPlain;
        private System.Windows.Forms.Label label4;
    }
}