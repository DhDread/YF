
namespace Line_Manager
{
    partial class Login_Screen
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
            this.User_Txt = new System.Windows.Forms.TextBox();
            this.Pass_Txt = new System.Windows.Forms.TextBox();
            this.Login_Btn = new System.Windows.Forms.Button();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // User_Txt
            // 
            this.User_Txt.Location = new System.Drawing.Point(548, 171);
            this.User_Txt.Name = "User_Txt";
            this.User_Txt.PlaceholderText = "User Name";
            this.User_Txt.Size = new System.Drawing.Size(309, 31);
            this.User_Txt.TabIndex = 0;
            this.User_Txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.User_Txt.UseWaitCursor = true;
            // 
            // Pass_Txt
            // 
            this.Pass_Txt.Location = new System.Drawing.Point(548, 262);
            this.Pass_Txt.Name = "Pass_Txt";
            this.Pass_Txt.PasswordChar = '*';
            this.Pass_Txt.PlaceholderText = "Password";
            this.Pass_Txt.Size = new System.Drawing.Size(309, 31);
            this.Pass_Txt.TabIndex = 1;
            this.Pass_Txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Login_Btn
            // 
            this.Login_Btn.Location = new System.Drawing.Point(493, 345);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(132, 57);
            this.Login_Btn.TabIndex = 2;
            this.Login_Btn.Text = "Login";
            this.Login_Btn.UseCompatibleTextRendering = true;
            this.Login_Btn.UseVisualStyleBackColor = true;
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.Location = new System.Drawing.Point(789, 345);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(132, 57);
            this.Cancel_Btn.TabIndex = 3;
            this.Cancel_Btn.Text = "Cancel";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // Login_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 601);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.Login_Btn);
            this.Controls.Add(this.Pass_Txt);
            this.Controls.Add(this.User_Txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Login_Screen";
            this.Text = "Login_Screen";
            this.Load += new System.EventHandler(this.Login_Screen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox User_Txt;
        private System.Windows.Forms.TextBox Pass_Txt;
        private System.Windows.Forms.Button Login_Btn;
        private System.Windows.Forms.Button Cancel_Btn;
    }
}