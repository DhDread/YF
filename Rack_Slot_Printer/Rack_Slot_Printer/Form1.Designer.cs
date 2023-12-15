
namespace Rack_Slot_Printer
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
            this.CB_Line = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Ip_Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_Start = new System.Windows.Forms.TextBox();
            this.Txt_End = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_Rack_Id = new System.Windows.Forms.TextBox();
            this.JNAP_ChkBox = new System.Windows.Forms.CheckBox();
            this.DPI_ChkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CB_Line
            // 
            this.CB_Line.FormattingEnabled = true;
            this.CB_Line.Items.AddRange(new object[] {
            "Front Left Hand",
            "Rear Left Hand",
            "Front Right Hand",
            "Rear Right Hand"});
            this.CB_Line.Location = new System.Drawing.Point(196, 108);
            this.CB_Line.Name = "CB_Line";
            this.CB_Line.Size = new System.Drawing.Size(182, 33);
            this.CB_Line.TabIndex = 0;
            this.CB_Line.SelectedIndexChanged += new System.EventHandler(this.CB_Line_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Line:";
            // 
            // Txt_Ip_Address
            // 
            this.Txt_Ip_Address.Location = new System.Drawing.Point(492, 108);
            this.Txt_Ip_Address.Name = "Txt_Ip_Address";
            this.Txt_Ip_Address.Size = new System.Drawing.Size(194, 31);
            this.Txt_Ip_Address.TabIndex = 2;
            this.Txt_Ip_Address.Text = "10.17.98.27";
            this.Txt_Ip_Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "End:";
            // 
            // Txt_Start
            // 
            this.Txt_Start.Location = new System.Drawing.Point(246, 293);
            this.Txt_Start.Name = "Txt_Start";
            this.Txt_Start.Size = new System.Drawing.Size(85, 31);
            this.Txt_Start.TabIndex = 5;
            this.Txt_Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_End
            // 
            this.Txt_End.Location = new System.Drawing.Point(521, 293);
            this.Txt_End.Name = "Txt_End";
            this.Txt_End.Size = new System.Drawing.Size(85, 31);
            this.Txt_End.TabIndex = 6;
            this.Txt_End.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 68);
            this.button1.TabIndex = 7;
            this.button1.Text = "PRINT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(567, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 68);
            this.button2.TabIndex = 8;
            this.button2.Text = "CANCEL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(535, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "IP Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Rack:";
            // 
            // Txt_Rack_Id
            // 
            this.Txt_Rack_Id.Location = new System.Drawing.Point(392, 213);
            this.Txt_Rack_Id.Name = "Txt_Rack_Id";
            this.Txt_Rack_Id.Size = new System.Drawing.Size(72, 31);
            this.Txt_Rack_Id.TabIndex = 11;
            this.Txt_Rack_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // JNAP_ChkBox
            // 
            this.JNAP_ChkBox.AutoSize = true;
            this.JNAP_ChkBox.Location = new System.Drawing.Point(24, 22);
            this.JNAP_ChkBox.Name = "JNAP_ChkBox";
            this.JNAP_ChkBox.Size = new System.Drawing.Size(79, 29);
            this.JNAP_ChkBox.TabIndex = 12;
            this.JNAP_ChkBox.Text = "JNAP";
            this.JNAP_ChkBox.UseVisualStyleBackColor = true;
            // 
            // DPI_ChkBox
            // 
            this.DPI_ChkBox.AutoSize = true;
            this.DPI_ChkBox.Location = new System.Drawing.Point(24, 66);
            this.DPI_ChkBox.Name = "DPI_ChkBox";
            this.DPI_ChkBox.Size = new System.Drawing.Size(101, 29);
            this.DPI_ChkBox.TabIndex = 13;
            this.DPI_ChkBox.Text = "600 DPI";
            this.DPI_ChkBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 549);
            this.Controls.Add(this.DPI_ChkBox);
            this.Controls.Add(this.JNAP_ChkBox);
            this.Controls.Add(this.Txt_Rack_Id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Txt_End);
            this.Controls.Add(this.Txt_Start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Ip_Address);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_Line);
            this.Name = "Form1";
            this.Text = "WL Rack Slot Printer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Line;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Ip_Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_Start;
        private System.Windows.Forms.TextBox Txt_End;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txt_Rack_Id;
        private System.Windows.Forms.CheckBox JNAP_ChkBox;
        private System.Windows.Forms.CheckBox DPI_ChkBox;
    }
}

