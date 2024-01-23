
namespace SignApp
{
    partial class Sign
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
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.btnKeyPath = new System.Windows.Forms.Button();
            this.txtPDF = new System.Windows.Forms.TextBox();
            this.btnPDFPath = new System.Windows.Forms.Button();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.btnSignaturePath = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sfdSignature = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPrivateKey.Location = new System.Drawing.Point(36, 61);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.Name = "txtPrivateKey";
            this.txtPrivateKey.Size = new System.Drawing.Size(503, 50);
            this.txtPrivateKey.TabIndex = 0;
            // 
            // btnKeyPath
            // 
            this.btnKeyPath.Location = new System.Drawing.Point(563, 61);
            this.btnKeyPath.Name = "btnKeyPath";
            this.btnKeyPath.Size = new System.Drawing.Size(78, 50);
            this.btnKeyPath.TabIndex = 1;
            this.btnKeyPath.Text = "Browse";
            this.btnKeyPath.UseVisualStyleBackColor = true;
            this.btnKeyPath.Click += new System.EventHandler(this.btnKeyPath_Click);
            // 
            // txtPDF
            // 
            this.txtPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPDF.Location = new System.Drawing.Point(36, 147);
            this.txtPDF.Multiline = true;
            this.txtPDF.Name = "txtPDF";
            this.txtPDF.Size = new System.Drawing.Size(503, 50);
            this.txtPDF.TabIndex = 0;
            // 
            // btnPDFPath
            // 
            this.btnPDFPath.Location = new System.Drawing.Point(563, 147);
            this.btnPDFPath.Name = "btnPDFPath";
            this.btnPDFPath.Size = new System.Drawing.Size(78, 50);
            this.btnPDFPath.TabIndex = 1;
            this.btnPDFPath.Text = "Browse";
            this.btnPDFPath.UseVisualStyleBackColor = true;
            this.btnPDFPath.Click += new System.EventHandler(this.btnPDFPath_Click);
            // 
            // txtSignature
            // 
            this.txtSignature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSignature.Location = new System.Drawing.Point(36, 239);
            this.txtSignature.Multiline = true;
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(503, 50);
            this.txtSignature.TabIndex = 0;
            // 
            // btnSignaturePath
            // 
            this.btnSignaturePath.Location = new System.Drawing.Point(563, 239);
            this.btnSignaturePath.Name = "btnSignaturePath";
            this.btnSignaturePath.Size = new System.Drawing.Size(78, 50);
            this.btnSignaturePath.TabIndex = 1;
            this.btnSignaturePath.Text = "Browse";
            this.btnSignaturePath.UseVisualStyleBackColor = true;
            this.btnSignaturePath.Click += new System.EventHandler(this.btnSignaturePath_Click);
            // 
            // btnSign
            // 
            this.btnSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnSign.Location = new System.Drawing.Point(231, 325);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(173, 50);
            this.btnSign.TabIndex = 1;
            this.btnSign.Text = "Sign PDF";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "PrivateKey Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "PDF Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Signature Path";
            // 
            // Sign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 418);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSignaturePath);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnPDFPath);
            this.Controls.Add(this.btnKeyPath);
            this.Controls.Add(this.txtSignature);
            this.Controls.Add(this.txtPDF);
            this.Controls.Add(this.txtPrivateKey);
            this.Name = "Sign";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.Button btnKeyPath;
        private System.Windows.Forms.TextBox txtPDF;
        private System.Windows.Forms.Button btnPDFPath;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.Button btnSignaturePath;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog sfdSignature;
    }
}

