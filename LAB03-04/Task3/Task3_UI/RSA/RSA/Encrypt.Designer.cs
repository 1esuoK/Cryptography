
namespace RSA
{
    partial class Encrypt
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
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseKey = new System.Windows.Forms.Button();
            this.txtPlainPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowsePlain = new System.Windows.Forms.Button();
            this.txtCipherPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseCipher = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtCipher = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGoToDe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPublicKey.Location = new System.Drawing.Point(42, 79);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(496, 41);
            this.txtPublicKey.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(39, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "PublicKey Path";
            // 
            // btnBrowseKey
            // 
            this.btnBrowseKey.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBrowseKey.Location = new System.Drawing.Point(577, 79);
            this.btnBrowseKey.Name = "btnBrowseKey";
            this.btnBrowseKey.Size = new System.Drawing.Size(140, 41);
            this.btnBrowseKey.TabIndex = 2;
            this.btnBrowseKey.Text = "Browse";
            this.btnBrowseKey.UseVisualStyleBackColor = true;
            this.btnBrowseKey.Click += new System.EventHandler(this.btnBrowseKey_Click);
            // 
            // txtPlainPath
            // 
            this.txtPlainPath.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPlainPath.Location = new System.Drawing.Point(42, 165);
            this.txtPlainPath.Multiline = true;
            this.txtPlainPath.Name = "txtPlainPath";
            this.txtPlainPath.Size = new System.Drawing.Size(496, 41);
            this.txtPlainPath.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(40, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Plaintext Path";
            // 
            // btnBrowsePlain
            // 
            this.btnBrowsePlain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBrowsePlain.Location = new System.Drawing.Point(577, 165);
            this.btnBrowsePlain.Name = "btnBrowsePlain";
            this.btnBrowsePlain.Size = new System.Drawing.Size(140, 41);
            this.btnBrowsePlain.TabIndex = 2;
            this.btnBrowsePlain.Text = "Browse";
            this.btnBrowsePlain.UseVisualStyleBackColor = true;
            this.btnBrowsePlain.Click += new System.EventHandler(this.btnBrowsePlain_Click);
            // 
            // txtCipherPath
            // 
            this.txtCipherPath.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCipherPath.Location = new System.Drawing.Point(42, 257);
            this.txtCipherPath.Multiline = true;
            this.txtCipherPath.Name = "txtCipherPath";
            this.txtCipherPath.Size = new System.Drawing.Size(496, 41);
            this.txtCipherPath.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(40, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ciphertext Path";
            // 
            // btnBrowseCipher
            // 
            this.btnBrowseCipher.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBrowseCipher.Location = new System.Drawing.Point(577, 257);
            this.btnBrowseCipher.Name = "btnBrowseCipher";
            this.btnBrowseCipher.Size = new System.Drawing.Size(140, 41);
            this.btnBrowseCipher.TabIndex = 2;
            this.btnBrowseCipher.Text = "Browse";
            this.btnBrowseCipher.UseVisualStyleBackColor = true;
            this.btnBrowseCipher.Click += new System.EventHandler(this.btnBrowseCipher_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnEncrypt.Location = new System.Drawing.Point(577, 347);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(140, 61);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtCipher
            // 
            this.txtCipher.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtCipher.Location = new System.Drawing.Point(42, 347);
            this.txtCipher.Multiline = true;
            this.txtCipher.Name = "txtCipher";
            this.txtCipher.ReadOnly = true;
            this.txtCipher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCipher.Size = new System.Drawing.Size(496, 132);
            this.txtCipher.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(39, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ciphertext(Hex)";
            // 
            // btnGoToDe
            // 
            this.btnGoToDe.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnGoToDe.Location = new System.Drawing.Point(577, 418);
            this.btnGoToDe.Name = "btnGoToDe";
            this.btnGoToDe.Size = new System.Drawing.Size(140, 61);
            this.btnGoToDe.TabIndex = 3;
            this.btnGoToDe.Text = "Go To Decrypt";
            this.btnGoToDe.UseVisualStyleBackColor = true;
            this.btnGoToDe.Click += new System.EventHandler(this.btnGoToDe_Click);
            // 
            // Encrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 517);
            this.Controls.Add(this.btnGoToDe);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnBrowseCipher);
            this.Controls.Add(this.btnBrowsePlain);
            this.Controls.Add(this.btnBrowseKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCipher);
            this.Controls.Add(this.txtCipherPath);
            this.Controls.Add(this.txtPlainPath);
            this.Controls.Add(this.txtPublicKey);
            this.Name = "Encrypt";
            this.Text = "Encrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseKey;
        private System.Windows.Forms.TextBox txtPlainPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowsePlain;
        private System.Windows.Forms.TextBox txtCipherPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseCipher;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtCipher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGoToDe;
    }
}