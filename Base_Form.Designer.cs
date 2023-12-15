
using System;

namespace Line_Manager
{
    partial class Base_Form
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wLMackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RearLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrontLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RearRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrontRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wDWLJnapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WLWDFrontLeftToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.WLWDRearLeftToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.WLWDFrontRightToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.WLWDRearRightToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.broncoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BroncoFrontLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BroncoRearLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.broadCastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Base_Panel = new System.Windows.Forms.Panel();
            this.Line_Timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.broadCastToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1413, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContactsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ContactsToolStripMenuItem
            // 
            this.ContactsToolStripMenuItem.Name = "ContactsToolStripMenuItem";
            this.ContactsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ContactsToolStripMenuItem.Text = "Contacts";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wLMackToolStripMenuItem,
            this.wDWLJnapToolStripMenuItem,
            this.broncoToolStripMenuItem});
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(59, 29);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.LineToolStripMenuItem_Click);
            // 
            // wLMackToolStripMenuItem
            // 
            this.wLMackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RearLeftToolStripMenuItem,
            this.FrontLeftToolStripMenuItem,
            this.RearRightToolStripMenuItem,
            this.FrontRightToolStripMenuItem});
            this.wLMackToolStripMenuItem.Name = "wLMackToolStripMenuItem";
            this.wLMackToolStripMenuItem.Size = new System.Drawing.Size(212, 34);
            this.wLMackToolStripMenuItem.Text = "WL_Mack";
            // 
            // RearLeftToolStripMenuItem
            // 
            this.RearLeftToolStripMenuItem.Name = "RearLeftToolStripMenuItem";
            this.RearLeftToolStripMenuItem.Size = new System.Drawing.Size(203, 34);
            this.RearLeftToolStripMenuItem.Text = "Rear Left";
            this.RearLeftToolStripMenuItem.Click += new System.EventHandler(this.RearLeftToolStripMenuItem_Click_1);
            // 
            // FrontLeftToolStripMenuItem
            // 
            this.FrontLeftToolStripMenuItem.Name = "FrontLeftToolStripMenuItem";
            this.FrontLeftToolStripMenuItem.Size = new System.Drawing.Size(203, 34);
            this.FrontLeftToolStripMenuItem.Text = "Front Left";
            this.FrontLeftToolStripMenuItem.Click += new System.EventHandler(this.FrontLeftToolStripMenuItem_Click_1);
            // 
            // RearRightToolStripMenuItem
            // 
            this.RearRightToolStripMenuItem.Name = "RearRightToolStripMenuItem";
            this.RearRightToolStripMenuItem.Size = new System.Drawing.Size(203, 34);
            this.RearRightToolStripMenuItem.Text = "Rear Right";
            this.RearRightToolStripMenuItem.Click += new System.EventHandler(this.RearRightToolStripMenuItem_Click_1);
            // 
            // FrontRightToolStripMenuItem
            // 
            this.FrontRightToolStripMenuItem.Name = "FrontRightToolStripMenuItem";
            this.FrontRightToolStripMenuItem.Size = new System.Drawing.Size(203, 34);
            this.FrontRightToolStripMenuItem.Text = "Front Right";
            this.FrontRightToolStripMenuItem.Click += new System.EventHandler(this.FrontRightToolStripMenuItem_Click_1);
            // 
            // wDWLJnapToolStripMenuItem
            // 
            this.wDWLJnapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WLWDFrontLeftToolStripMenuItem3,
            this.WLWDRearLeftToolStripMenuItem3,
            this.WLWDFrontRightToolStripMenuItem3,
            this.WLWDRearRightToolStripMenuItem3});
            this.wDWLJnapToolStripMenuItem.Name = "wDWLJnapToolStripMenuItem";
            this.wDWLJnapToolStripMenuItem.Size = new System.Drawing.Size(212, 34);
            this.wDWLJnapToolStripMenuItem.Text = "WDWL_Jnap";
            // 
            // WLWDFrontLeftToolStripMenuItem3
            // 
            this.WLWDFrontLeftToolStripMenuItem3.Name = "WLWDFrontLeftToolStripMenuItem3";
            this.WLWDFrontLeftToolStripMenuItem3.Size = new System.Drawing.Size(203, 34);
            this.WLWDFrontLeftToolStripMenuItem3.Text = "Front Left";
            this.WLWDFrontLeftToolStripMenuItem3.Click += new System.EventHandler(this.WLWDFrontLeftToolStripMenuItem3_Click);
            // 
            // WLWDRearLeftToolStripMenuItem3
            // 
            this.WLWDRearLeftToolStripMenuItem3.Name = "WLWDRearLeftToolStripMenuItem3";
            this.WLWDRearLeftToolStripMenuItem3.Size = new System.Drawing.Size(203, 34);
            this.WLWDRearLeftToolStripMenuItem3.Text = "Rear Left";
            this.WLWDRearLeftToolStripMenuItem3.Click += new System.EventHandler(this.WLWDRearLeftToolStripMenuItem3_Click);
            // 
            // WLWDFrontRightToolStripMenuItem3
            // 
            this.WLWDFrontRightToolStripMenuItem3.Name = "WLWDFrontRightToolStripMenuItem3";
            this.WLWDFrontRightToolStripMenuItem3.Size = new System.Drawing.Size(203, 34);
            this.WLWDFrontRightToolStripMenuItem3.Text = "Front Right";
            this.WLWDFrontRightToolStripMenuItem3.Click += new System.EventHandler(this.WLWDFrontRightToolStripMenuItem3_Click);
            // 
            // WLWDRearRightToolStripMenuItem3
            // 
            this.WLWDRearRightToolStripMenuItem3.Name = "WLWDRearRightToolStripMenuItem3";
            this.WLWDRearRightToolStripMenuItem3.Size = new System.Drawing.Size(203, 34);
            this.WLWDRearRightToolStripMenuItem3.Text = "Rear Right";
            this.WLWDRearRightToolStripMenuItem3.Click += new System.EventHandler(this.WLWDRearRightToolStripMenuItem3_Click);
            // 
            // broncoToolStripMenuItem
            // 
            this.broncoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BroncoFrontLineToolStripMenuItem,
            this.BroncoRearLineToolStripMenuItem});
            this.broncoToolStripMenuItem.Name = "broncoToolStripMenuItem";
            this.broncoToolStripMenuItem.Size = new System.Drawing.Size(212, 34);
            this.broncoToolStripMenuItem.Text = "Bronco";
            // 
            // BroncoFrontLineToolStripMenuItem
            // 
            this.BroncoFrontLineToolStripMenuItem.Name = "BroncoFrontLineToolStripMenuItem";
            this.BroncoFrontLineToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.BroncoFrontLineToolStripMenuItem.Text = "Front Line";
            this.BroncoFrontLineToolStripMenuItem.Click += new System.EventHandler(this.BroncoFrontLineToolStripMenuItem_Click);
            // 
            // BroncoRearLineToolStripMenuItem
            // 
            this.BroncoRearLineToolStripMenuItem.Name = "BroncoRearLineToolStripMenuItem";
            this.BroncoRearLineToolStripMenuItem.Size = new System.Drawing.Size(192, 34);
            this.BroncoRearLineToolStripMenuItem.Text = "Rear Line";
            this.BroncoRearLineToolStripMenuItem.Click += new System.EventHandler(this.BroncoRearLineToolStripMenuItem_Click);
            // 
            // broadCastToolStripMenuItem
            // 
            this.broadCastToolStripMenuItem.Name = "broadCastToolStripMenuItem";
            this.broadCastToolStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.broadCastToolStripMenuItem.Text = "BroadCast";
            // 
            // Base_Panel
            // 
            this.Base_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Base_Panel.Location = new System.Drawing.Point(0, 36);
            this.Base_Panel.MaximumSize = new System.Drawing.Size(1428, 657);
            this.Base_Panel.MinimumSize = new System.Drawing.Size(1428, 657);
            this.Base_Panel.Name = "Base_Panel";
            this.Base_Panel.Size = new System.Drawing.Size(1428, 657);
            this.Base_Panel.TabIndex = 1;
            // 
            // Line_Timer
            // 
            this.Line_Timer.Interval = 2000;
            // 
            // Base_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 644);
            this.Controls.Add(this.Base_Panel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Base_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YF Line Manager";
            this.Load += new System.EventHandler(this.Base_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void lineStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.Panel Base_Panel;
        private System.Windows.Forms.ToolStripMenuItem broadCastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armRestToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem midBolsterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitPrestage1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitPrestage2ToolStripMenuItem;
        private System.Windows.Forms.Timer Line_Timer;
        private System.Windows.Forms.ToolStripMenuItem wLMackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RearLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrontLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RearRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrontRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wDWLJnapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WLWDFrontLeftToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem WLWDRearLeftToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem WLWDFrontRightToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem WLWDRearRightToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem broncoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BroncoFrontLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BroncoRearLineToolStripMenuItem;
    }
}

