
namespace SignApp
{
    partial class Verify
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignaturePath = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnPDFPath = new System.Windows.Forms.Button();
            this.btnKeyPath = new System.Windows.Forms.Button();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.txtPDF = new System.Windows.Forms.TextBox();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Signature Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "PDF Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "PublicKey Path";
            // 
            // btnSignaturePath
            // 
            this.btnSignaturePath.Location = new System.Drawing.Point(562, 232);
            this.btnSignaturePath.Name = "btnSignaturePath";
            this.btnSignaturePath.Size = new System.Drawing.Size(78, 50);
            this.btnSignaturePath.TabIndex = 6;
            this.btnSignaturePath.Text = "Browse";
            this.btnSignaturePath.UseVisualStyleBackColor = true;
            this.btnSignaturePath.Click += new System.EventHandler(this.btnSignaturePath_Click);
            // 
            // btnSign
            // 
            this.btnSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnSign.Location = new System.Drawing.Point(230, 318);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(173, 50);
            this.btnSign.TabIndex = 7;
            this.btnSign.Text = "Verify PDF";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnPDFPath
            // 
            this.btnPDFPath.Location = new System.Drawing.Point(562, 140);
            this.btnPDFPath.Name = "btnPDFPath";
            this.btnPDFPath.Size = new System.Drawing.Size(78, 50);
            this.btnPDFPath.TabIndex = 8;
            this.btnPDFPath.Text = "Browse";
            this.btnPDFPath.UseVisualStyleBackColor = true;
            this.btnPDFPath.Click += new System.EventHandler(this.btnPDFPath_Click);
            // 
            // btnKeyPath
            // 
            this.btnKeyPath.Location = new System.Drawing.Point(562, 54);
            this.btnKeyPath.Name = "btnKeyPath";
            this.btnKeyPath.Size = new System.Drawing.Size(78, 50);
            this.btnKeyPath.TabIndex = 9;
            this.btnKeyPath.Text = "Browse";
            this.btnKeyPath.UseVisualStyleBackColor = true;
            this.btnKeyPath.Click += new System.EventHandler(this.btnKeyPath_Click);
            // 
            // txtSignature
            // 
            this.txtSignature.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSignature.Location = new System.Drawing.Point(35, 232);
            this.txtSignature.Multiline = true;
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(503, 50);
            this.txtSignature.TabIndex = 3;
            // 
            // txtPDF
            // 
            this.txtPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPDF.Location = new System.Drawing.Point(35, 140);
            this.txtPDF.Multiline = true;
            this.txtPDF.Name = "txtPDF";
            this.txtPDF.Size = new System.Drawing.Size(503, 50);
            this.txtPDF.TabIndex = 4;
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPublicKey.Location = new System.Drawing.Point(35, 54);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(503, 50);
            this.txtPublicKey.TabIndex = 5;
            // 
            // Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 415);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSignaturePath);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnPDFPath);
            this.Controls.Add(this.btnKeyPath);
            this.Controls.Add(this.txtSignature);
            this.Controls.Add(this.txtPDF);
            this.Controls.Add(this.txtPublicKey);
            this.Name = "Verify";
            this.Text = "Verify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSignaturePath;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnPDFPath;
        private System.Windows.Forms.Button btnKeyPath;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.TextBox txtPDF;
        private System.Windows.Forms.TextBox txtPublicKey;
    }
}