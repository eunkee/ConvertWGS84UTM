
namespace ConvertWGS84UTM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonWGS84toUTM = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.TextBoxWGSLon = new System.Windows.Forms.TextBox();
            this.TextBoxWGSLat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxUTMLon = new System.Windows.Forms.TextBox();
            this.TextBoxUTMLat = new System.Windows.Forms.TextBox();
            this.ButtonUTMtoWGS84 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxWGSLon2 = new System.Windows.Forms.TextBox();
            this.TextBoxWGSLat2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonWGS84toUTM
            // 
            this.ButtonWGS84toUTM.Location = new System.Drawing.Point(64, 128);
            this.ButtonWGS84toUTM.Name = "ButtonWGS84toUTM";
            this.ButtonWGS84toUTM.Size = new System.Drawing.Size(94, 23);
            this.ButtonWGS84toUTM.TabIndex = 24;
            this.ButtonWGS84toUTM.Text = "Convert to ";
            this.ButtonWGS84toUTM.UseVisualStyleBackColor = true;
            this.ButtonWGS84toUTM.Click += new System.EventHandler(this.ButtonWGS84toUTM_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "WGS84";
            // 
            // TextBoxWGSLon
            // 
            this.TextBoxWGSLon.Location = new System.Drawing.Point(37, 81);
            this.TextBoxWGSLon.Name = "TextBoxWGSLon";
            this.TextBoxWGSLon.Size = new System.Drawing.Size(146, 23);
            this.TextBoxWGSLon.TabIndex = 22;
            // 
            // TextBoxWGSLat
            // 
            this.TextBoxWGSLat.Location = new System.Drawing.Point(37, 44);
            this.TextBoxWGSLat.Name = "TextBoxWGSLat";
            this.TextBoxWGSLat.Size = new System.Drawing.Size(146, 23);
            this.TextBoxWGSLat.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "UTM";
            // 
            // TextBoxUTMLon
            // 
            this.TextBoxUTMLon.Location = new System.Drawing.Point(37, 222);
            this.TextBoxUTMLon.Name = "TextBoxUTMLon";
            this.TextBoxUTMLon.Size = new System.Drawing.Size(146, 23);
            this.TextBoxUTMLon.TabIndex = 26;
            // 
            // TextBoxUTMLat
            // 
            this.TextBoxUTMLat.Location = new System.Drawing.Point(37, 185);
            this.TextBoxUTMLat.Name = "TextBoxUTMLat";
            this.TextBoxUTMLat.Size = new System.Drawing.Size(146, 23);
            this.TextBoxUTMLat.TabIndex = 25;
            // 
            // ButtonUTMtoWGS84
            // 
            this.ButtonUTMtoWGS84.Location = new System.Drawing.Point(64, 269);
            this.ButtonUTMtoWGS84.Name = "ButtonUTMtoWGS84";
            this.ButtonUTMtoWGS84.Size = new System.Drawing.Size(94, 23);
            this.ButtonUTMtoWGS84.TabIndex = 28;
            this.ButtonUTMtoWGS84.Text = "Convert to ";
            this.ButtonUTMtoWGS84.UseVisualStyleBackColor = true;
            this.ButtonUTMtoWGS84.Click += new System.EventHandler(this.ButtonUTMtoWGS84_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "WGS84";
            // 
            // TextBoxWGSLon2
            // 
            this.TextBoxWGSLon2.Location = new System.Drawing.Point(37, 363);
            this.TextBoxWGSLon2.Name = "TextBoxWGSLon2";
            this.TextBoxWGSLon2.Size = new System.Drawing.Size(146, 23);
            this.TextBoxWGSLon2.TabIndex = 30;
            // 
            // TextBoxWGSLat2
            // 
            this.TextBoxWGSLat2.Location = new System.Drawing.Point(37, 326);
            this.TextBoxWGSLat2.Name = "TextBoxWGSLat2";
            this.TextBoxWGSLat2.Size = new System.Drawing.Size(146, 23);
            this.TextBoxWGSLat2.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 413);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxWGSLon2);
            this.Controls.Add(this.TextBoxWGSLat2);
            this.Controls.Add(this.ButtonUTMtoWGS84);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxUTMLon);
            this.Controls.Add(this.TextBoxUTMLat);
            this.Controls.Add(this.ButtonWGS84toUTM);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TextBoxWGSLon);
            this.Controls.Add(this.TextBoxWGSLat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Convert WGS84 UTM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonWGS84toUTM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TextBoxWGSLon;
        private System.Windows.Forms.TextBox TextBoxWGSLat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxUTMLon;
        private System.Windows.Forms.TextBox TextBoxUTMLat;
        private System.Windows.Forms.Button ButtonUTMtoWGS84;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxWGSLon2;
        private System.Windows.Forms.TextBox TextBoxWGSLat2;
    }
}

