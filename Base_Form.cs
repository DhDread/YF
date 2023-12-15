using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Line_Manager
{
    public partial class Base_Form : Form
    {
        public static string Door_pos;
        public string Station;
        public static string logged_in = "";
        //public string WLDoor_Filled;
        //public object backgroundWorker1;
        // Stations
        public static string Station_Applique = "APP_Test";
        public static string Station_Midbolster = "MB_Test";
        public static string Station_Armrest = "AR_Test";
        public Base_Form()
        {
            InitializeComponent();
        }
        private void Base_Form_Load(object sender, EventArgs e)
        {
            Login();
        }
        private void Login()
        {
            Door_pos = "login";
            menuStrip1.Visible = false;
            this.Base_Panel.Controls.Clear();
            Login_Screen Login_Screen = new Login_Screen()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Login_Screen);
            Login_Screen.Show();
            Wait_For_Menu();
        }
        private async void Wait_For_Menu()
        {
            while (logged_in == "")
            {
                await Task.Delay(1);
            }
            this.menuStrip1.Visible = true;
            this.Base_Panel.Controls.Clear();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(WLDoor.ToString());
            this.Close();
        }
#region Line Tool strip Menu
        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // PlaceHolder
            //Line_Timer.Stop();
            this.Activate();
        }
#region Mack Side
        private void RearLeftToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Door_pos = "D2_LHR";
            this.Base_Panel.Controls.Clear();
            Mack_LHR Mack_LHR = new Mack_LHR()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Mack_LHR);
            Mack_LHR.Show();
            Mack_LHR.Activate();
            //Timer_Stuff();
        }
        private void FrontLeftToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Door_pos = "D2_LHF";
            this.Base_Panel.Controls.Clear();
            Mack_LHF Mack_LHF = new Mack_LHF()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Mack_LHF);
            Mack_LHF.Show();
            Mack_LHF.Activate();
            //Timer_Stuff();
        }
        private void RearRightToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Door_pos = "D2_RHR";
            this.Base_Panel.Controls.Clear();
            Mack_RHR Mack_RHR = new Mack_RHR()
            {
                TopLevel = false,
                TopMost = true
                
            };
            this.Base_Panel.Controls.Add(Mack_RHR);
            Mack_RHR.Show();
            Mack_RHR.Activate();
            //Timer_Stuff();
        }
        private void FrontRightToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Door_pos = "D2_RHF";
            this.Base_Panel.Controls.Clear();
            Mack_RHF Mack_RHF = new Mack_RHF()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Mack_RHF);
            Mack_RHF.Show();
            Mack_RHF.Activate();
            //Timer_Stuff();
        }
        #endregion
#region Jnap Side
        private void WLWDFrontLeftToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Door_pos = "JN_LHF";
            this.Base_Panel.Controls.Clear();
            Jnap_LHF Jnap_LHF = new Jnap_LHF()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Jnap_LHF);
            Jnap_LHF.Show();
            //Timer_Stuff();
        }

        private void WLWDRearLeftToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Door_pos = "JN_LHR";
            this.Base_Panel.Controls.Clear();
            Jnap_LHR Jnap_LHR = new Jnap_LHR()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Jnap_LHR);
            Jnap_LHR.Show();
            //Timer_Stuff();
        }

        private void WLWDFrontRightToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Door_pos = "JN_RHF";
            this.Base_Panel.Controls.Clear();
            Jnap_RHF Jnap_RHF = new Jnap_RHF()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Jnap_RHF);
            Jnap_RHF.Show();
            //Timer_Stuff();
        }

        private void WLWDRearRightToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Door_pos = "JN_RHR";
            this.Base_Panel.Controls.Clear();
            Jnap_RHR Jnap_RHR = new Jnap_RHR()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Jnap_RHR);
            Jnap_RHR.Show();
            //Timer_Stuff();
        }
        #endregion
#region Bronco
        private void BroncoFrontLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Door_pos = "Bronco_Front";
            this.Base_Panel.Controls.Clear();
            Bronco_Front Bronco_Front = new Bronco_Front()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Bronco_Front);
            Bronco_Front.Show();
            //Timer_Stuff();
        }
        private void BroncoRearLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Door_pos = "Bronco_Rear";
            this.Base_Panel.Controls.Clear();
            Bronco_Rear Bronco_Rear = new Bronco_Rear()
            {
                TopLevel = false,
                TopMost = true
            };
            this.Base_Panel.Controls.Add(Bronco_Rear);
            Bronco_Rear.Show();
            //Timer_Stuff();
        }
#endregion
#endregion
#region LHR Remote Menu Items
        private void LHR_Applique_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.25 -a:1"); }
        private void LHR_SunShade_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.28 -a:1"); }
        private void LHR_ArmRest_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.22 -a:1"); }
        private void LHR_MidBolster_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.16 -a:1"); }
        private void LHR_Prestage_1_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.43 -a:1"); }
        private void LHR_Prestage_2_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.60 -a:1"); }
#endregion
#region LHF Remote Menu Items
        private void LHF_Applique_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.24 -a:1"); }
        private void LHF_Upper_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.28 -a:1"); }
        private void LHF_ArmRest_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.13 -a:1"); }
        private void LHF_MidBolster_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.12 -a:1"); }
        private void LHF_Prestage_1_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.45 -a:1"); }
        private void LHF_Prestage_2_Menu_Click(object sender, EventArgs e)
        { System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.61 -a:1"); }



#endregion






        //private void upperToolStripMenuItem_Click(object sender, EventArgs e)
        //{ System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.16 -a:1"); }
        //private void armRestToolStripMenuItem1_Click(object sender, EventArgs e)
        //{ System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.16 -a:1"); }
        //private void midBolsterToolStripMenuItem_Click(object sender, EventArgs e)
        //{ System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.16 -a:1"); }
        //private void kitPrestage1ToolStripMenuItem_Click(object sender, EventArgs e)
        //{ System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.16 -a:1"); }
        //private void kitPrestage2ToolStripMenuItem_Click(object sender, EventArgs e)
        //{ System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.16 -a:1"); }
        //private void appliqueToolStripMenuItem_Click(object sender, EventArgs e)
        //{ System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:10.17.111.16 -a:1"); }
        //private void armRestToolStripMenuItem3_Click(object sender, EventArgs e)
        //{

        //}
    }
}
