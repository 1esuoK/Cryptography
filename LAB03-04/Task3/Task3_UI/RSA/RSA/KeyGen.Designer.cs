
namespace RSA
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
            this.btnBrowsePrKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.btnBrowsePuKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.btnKeyGen = new System.Windows.Forms.Button();
            this.txtModulus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrime1 = new System.Windows.Forms.TextBox();
            this.txtPrime2 = new System.Windows.Forms.TextBox();
            this.txtPrEx = new System.Windows.Forms.TextBox();
            this.txtPuEx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGoToEn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrowsePrKey
            // 
            this.btnBrowsePrKey.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnBrowsePrKey.Location = new System.Drawing.Point(795, 42);
            this.btnBrowsePrKey.Name = "btnBrowsePrKey";
            this.btnBrowsePrKey.Size = new System.Drawing.Size(103, 41);
            this.btnBrowsePrKey.TabIndex = 5;
            this.btnBrowsePrKey.Text = "Browse";
            this.btnBrowsePrKey.UseVisualStyleBackColor = true;
            this.btnBrowsePrKey.Click += new System.EventHandler(this.btnBrowsePrKey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(257, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "PrivateKey Path";
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPrivateKey.Location = new System.Drawing.Point(260, 42);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(496, 41);
            this.txtPrivateKey.TabIndex = 3;
            // 
            // btnBrowsePuKey
            // 
            this.btnBrowsePuKey.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBrowsePuKey.Location = new System.Drawing.Point(795, 131);
            this.btnBrowsePuKey.Name = "btnBrowsePuKey";
            this.btnBrowsePuKey.Size = new System.Drawing.Size(103, 41);
            this.btnBrowsePuKey.TabIndex = 8;
            this.btnBrowsePuKey.Text = "Browse";
            this.btnBrowsePuKey.UseVisualStyleBackColor = true;
            this.btnBrowsePuKey.Click += new System.EventHandler(this.btnBrowsePuKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(257, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "PublicKey Path";
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPublicKey.Location = new System.Drawing.Point(260, 131);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(496, 41);
            this.txtPublicKey.TabIndex = 6;
            // 
            // btnKeyGen
            // 
            this.btnKeyGen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnKeyGen.Location = new System.Drawing.Point(394, 205);
            this.btnKeyGen.Name = "btnKeyGen";
            this.btnKeyGen.Size = new System.Drawing.Size(140, 61);
            this.btnKeyGen.TabIndex = 9;
            this.btnKeyGen.Text = "Generate";
            this.btnKeyGen.UseVisualStyleBackColor = true;
            this.btnKeyGen.Click += new System.EventHandler(this.btnKeyGen_Click);
            // 
            // txtModulus
            // 
            this.txtModulus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtModulus.Location = new System.Drawing.Point(38, 330);
            this.txtModulus.Multiline = true;
            this.txtModulus.Name = "txtModulus";
            this.txtModulus.ReadOnly = true;
            this.txtModulus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModulus.Size = new System.Drawing.Size(496, 91);
            this.txtModulus.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(35, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Modulus n:";
            // 
            // txtPrime1
            // 
            this.txtPrime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPrime1.Location = new System.Drawing.Point(573, 330);
            this.txtPrime1.Multiline = true;
            this.txtPrime1.Name = "txtPrime1";
            this.txtPrime1.ReadOnly = true;
            this.txtPrime1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrime1.Size = new System.Drawing.Size(496, 91);
            this.txtPrime1.TabIndex = 6;
            // 
            // txtPrime2
            // 
            this.txtPrime2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPrime2.Location = new System.Drawing.Point(38, 455);
            this.txtPrime2.Multiline = true;
            this.txtPrime2.Name = "txtPrime2";
            this.txtPrime2.ReadOnly = true;
            this.txtPrime2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrime2.Size = new System.Drawing.Size(496, 91);
            this.txtPrime2.TabIndex = 6;
            // 
            // txtPrEx
            // 
            this.txtPrEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPrEx.Location = new System.Drawing.Point(573, 455);
            this.txtPrEx.Multiline = true;
            this.txtPrEx.Name = "txtPrEx";
            this.txtPrEx.ReadOnly = true;
            this.txtPrEx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrEx.Size = new System.Drawing.Size(496, 91);
            this.txtPrEx.TabIndex = 6;
            // 
            // txtPuEx
            // 
            this.txtPuEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPuEx.Location = new System.Drawing.Point(310, 579);
            this.txtPuEx.Multiline = true;
            this.txtPuEx.Name = "txtPuEx";
            this.txtPuEx.ReadOnly = true;
            this.txtPuEx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPuEx.Size = new System.Drawing.Size(496, 72);
            this.txtPuEx.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(570, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Prime p:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(570, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "PrivateExponent d:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(35, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Prime q:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(307, 559);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "PublicExponent e:";
            // 
            // btnGoToEn
            // 
            this.btnGoToEn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnGoToEn.Location = new System.Drawing.Point(571, 205);
            this.btnGoToEn.Name = "btnGoToEn";
            this.btnGoToEn.Size = new System.Drawing.Size(140, 61);
            this.btnGoToEn.TabIndex = 10;
            this.btnGoToEn.Text = "Go To Encrypt";
            this.btnGoToEn.UseVisualStyleBackColor = true;
            this.btnGoToEn.Click += new System.EventHandler(this.btnGoToEn_Click);
            // 
            // KeyGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 677);
            this.Controls.Add(this.btnGoToEn);
            this.Controls.Add(this.btnKeyGen);
            this.Controls.Add(this.btnBrowsePuKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPuEx);
            this.Controls.Add(this.txtPrEx);
            this.Controls.Add(this.txtPrime2);
            this.Controls.Add(this.txtPrime1);
            this.Controls.Add(this.txtModulus);
            this.Controls.Add(this.txtPublicKey);
            this.Controls.Add(this.btnBrowsePrKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrivateKey);
            this.Name = "KeyGen";
            this.Text = "KeyGen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowsePrKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Button btnBrowsePuKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.Button btnKeyGen;
        private System.Windows.Forms.TextBox txtModulus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrime1;
        private System.Windows.Forms.TextBox txtPrime2;
        private System.Windows.Forms.TextBox txtPrEx;
        private System.Windows.Forms.TextBox txtPuEx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGoToEn;
    }
}