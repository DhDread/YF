using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Net.NetworkInformation;

namespace Line_Manager
{
    public partial class Mack_Popup : Form
    {
        public static string printer, module, data, location, orientation;
        public static string RHF_Printer_Ip = "10.17.111.66",
                             LHF_Printer_Ip = "10.17.111.103",
                             RHR_Printer_Ip = "10.17.111.65",
                             LHR_Printer_Ip = "10.17.111.62";
        public string Station;
        public string Door_Pos;
        public static string sql_con = @"Server=US2270M020;Database=WLDoors;Trusted_Connection=True"; //User ID=" + @"EPSApplication;" + @"Password=" + @"EPSApplication;";
        public static string query;
        public static string line;
        public string IP_Stuffs;
        public Mack_Popup()
        {
            InitializeComponent();
        }
       
        private void Popup_Load(object sender, EventArgs e)
        {
            //Reprint Visibles
            Chk_Bcode_Applique.UseMnemonic = false;
            Chk_Bcode_Applique.Visible = false;
            Applique_Lbl.Visible = false;
            Chk_Bcode_MidBolster.UseMnemonic = false;
            Chk_Bcode_MidBolster.Visible = false;
            Midbolster_Lbl.Visible = false;
            Chk_Bcode_ArmRest.UseMnemonic = false;
            Chk_Bcode_ArmRest.Visible = false;
            Armrest_Lbl.Visible = false;
            Chk_Bcode_Upper.UseMnemonic = false;
            Upper_Lbl.Visible = false;
            Chk_Bcode_Upper.Visible = false;
            //Door Position
            this.Text = Door_Pos + " - " + Station;
            Popup_Connect_Btn.Text = "Connect To: " + Environment.NewLine + Station;
            Fill_Data();
            Fill_Data_Reprint();
            //Popup_JSN_txt.Text = "IM A JSN";
            //Popup_Seq_txt.Text = Station;
            //Ping_Check();
        }
        //private void Ping_Check()
        //{
        //    query = @"select top 1 * from WL_Station_Dashboard_Line_Data where Station = ";
        //    SqlConnection con = new SqlConnection(sql_con);
        //    SqlCommand Applique = new SqlCommand(query + "'" + Door_Pos + "_" + Station + "'", con);
        //    try
        //    {
        //        con.Open();

        //        SqlDataReader appli = Applique.ExecuteReader();
        //        while (appli.Read())
        //        {
        //            IP_Stuffs = appli.GetValue(1).ToString();
        //        }
        //        appli.Close();
        //        con.Close();
        //        //Popup_Connect_Btn.Text = IP_Stuffs.ToString();
        //        //Popup_Connect_Btn.BackColor = System.Drawing.Color.Green;
        //        Ping p = new Ping();
        //        PingReply r;
        //        r = p.Send(IP_Stuffs);
        //        if (r.Status == IPStatus.Success)
        //        {
        //            Popup_Connect_Btn.BackColor = System.Drawing.Color.LightGreen;
        //        }
        //        else if (r.Status == IPStatus.DestinationHostUnreachable)
        //        {
        //            Popup_Connect_Btn.BackColor = System.Drawing.Color.Red;
        //        }
        //    }
        //    catch (Exception es)
        //    {
        //        MessageBox.Show(es.Message);
        //    }
        //    //System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:" + IP_Stuffs + " -a:1");
        //    //Popup_Connect_Btn.Text = IP_Stuffs;
        //    //Popup_Connect_Btn.BackColor = System.Drawing.Color.Green;
        //}
        private void Chk_Bcode_Applique_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Bcode_Applique.Checked)
            {
                module = null; data = null;
                Chk_Bcode_Upper.Checked = false;
                Chk_Bcode_ArmRest.Checked = false;
                Chk_Bcode_MidBolster.Checked = false;
                module = "Applique:"; data = Chk_Bcode_Applique.Text;
            }
        }
        private void Chk_Bcode_MidBolster_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Bcode_MidBolster.Checked)
            {
                module = null; data = null;
                Chk_Bcode_Applique.Checked = false;
                Chk_Bcode_ArmRest.Checked = false;
                Chk_Bcode_Upper.Checked = false;
                module = "MidBolster:"; data = Chk_Bcode_MidBolster.Text;
            }
        }
        private void Chk_Bcode_ArmRest_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Bcode_ArmRest.Checked)
            {
                module = null; data = null;
                Chk_Bcode_Applique.Checked = false;
                Chk_Bcode_Upper.Checked = false;
                Chk_Bcode_MidBolster.Checked = false;
                module = "ArmRest:"; data = Chk_Bcode_ArmRest.Text;
            }
        }
        private void Chk_Bcode_Upper_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Bcode_Upper.Checked)
            {
                module = null; data = null;
                Chk_Bcode_Applique.Checked = false;
                Chk_Bcode_ArmRest.Checked = false;
                Chk_Bcode_MidBolster.Checked = false;
                module = "Upper:"; data = Chk_Bcode_Upper.Text;
            }
        }
        private void Chk_LHF_Print_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_LHF_Print.Checked)
            {
                printer = null; location = null;
                Chk_LHR_Print.Checked = false;
                Chk_RHR_Print.Checked = false;
                // Chk_LHF_Print.Checked = false;
                Chk_RHF_Print.Checked = false;
                printer = "Left Hand Front"; location = LHF_Printer_Ip;
            }
        }
        private void Chk_RHF_Print_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_RHF_Print.Checked)
            {
                printer = null; location = null;
                Chk_LHR_Print.Checked = false;
                Chk_RHR_Print.Checked = false;
                Chk_LHF_Print.Checked = false;
                // Chk_RHF_Print.Checked = false;
                printer = "Right Hand Front"; location = RHF_Printer_Ip;
            }
        }
        private void Chk_LHR_Print_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_LHR_Print.Checked)
            {
                printer = null; location = null;
                // Chk_LHR_Print.Checked = false;
                Chk_RHR_Print.Checked = false;
                Chk_LHF_Print.Checked = false;
                Chk_RHF_Print.Checked = false;
                printer = "Left Hand Rear"; location = LHR_Printer_Ip;
            }
        }
        private void Chk_RHR_Print_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_RHR_Print.Checked)
            {
                printer = null; location = null;
                Chk_LHR_Print.Checked = false;
                // Chk_RHR_Print.Checked = false;
                Chk_LHF_Print.Checked = false;
                Chk_RHF_Print.Checked = false;
                printer = "Right Hand Rear"; location = RHR_Printer_Ip;
            }
        }
        private void Close_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Print_Click(object sender, EventArgs e)
        {
            // print_it();
            //Btn_Print.Text = data;
            //Chk_LHF_Print.Text = location;
            Z_Print();
        }
        private void print_it()
        {

            if (module != null)
            {
                if (printer != null)
                {
                    //MessageBox.Show("Reprinting: " + Popup_JSN_txt.Text
                    //        + "\n" + printer
                    //        + "\n" + module
                    //        + "\n" + data
                    //        + "\n" + "Ip Address:"
                    //        + "\n" + location, "WL Printing: " + Popup_JSN_txt.Text);
                    Z_Print();
                }
                else
                {
                    MessageBox.Show("Please Check Module and Location", "<-= ERROR =->");
                }
            }
            else
            {
                MessageBox.Show("Please Check Module and Location", "<-= ERROR =->");
            }

        }
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Close();
        }
        private void Fill_Data()
        {
            query = @"exec [Reports].[wl_get_line_dashboard] '" + Base_Form.Door_pos + @"', ";
            SqlConnection con = new SqlConnection(sql_con);
            SqlCommand Applique = new SqlCommand(query + "'" + Station + "'", con);
            try
            {
                con.Open();

                SqlDataReader appli = Applique.ExecuteReader();
                while (appli.Read())
                {
                    Popup_JSN_txt.Text = appli.GetValue(2).ToString();
                    Popup_Seq_txt.Text = appli.GetValue(3).ToString();
                    Popup_Rack_txt.Text = appli.GetValue(4).ToString();
                    Popup_Slot_txt.Text = appli.GetValue(5).ToString();
                    Popup_Time_txt.Text = appli.GetValue(7).ToString();
                }
                appli.Close();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private void Fill_Data_Reprint()
        {
            query = @"EXEC [Reports].[Dan_Reprinter] " + "'" + Popup_JSN_txt.Text + "'";
            //MessageBox.Show(jsn);
            //MessageBox.Show(query);
            SqlConnection con = new SqlConnection(sql_con);
            SqlCommand app1 = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader DR = app1.ExecuteReader();
                while (DR.Read())
                {
                    orientation = DR.GetValue("Ori").ToString();
                    Chk_Bcode_Applique.Text = DR.GetValue("Applique").ToString();
                    Chk_Bcode_ArmRest.Text = DR.GetValue("ArmRest").ToString();
                    Chk_Bcode_MidBolster.Text = DR.GetValue("MidBolster").ToString();
                    Chk_Bcode_Upper.Text = DR.GetValue("Upper").ToString();
                }
                DR.Close();
                //MessageBox.Show("works");
                con.Close();
                if (orientation == "LHR") { Chk_LHR_Print.Checked = true; }
                if (orientation == "LHF") { Chk_LHF_Print.Checked = true; }
                if (orientation == "RHR") { Chk_RHR_Print.Checked = true; }
                if (orientation == "RHF") { Chk_RHF_Print.Checked = true; }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        private void Z_Print()
        {
            // Printer IP Address and communication port
            // location decided by which check from chk_print
            //ips are global up top
            string ipAddress = location;
            int port = 9100;

            // ZPL Command(s)
            string ZPLString =
                        "^XA" + "^PR3^FS" + "^JMA" +
                        @"^FO160,55^BY3^BXN,10,200,24,24,6,_^FH\^FD" +
                        data + "^FS" + "^XZ";
            try
            {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ipAddress, port);
                // Write ZPL String to connection
                System.IO.StreamWriter writer =
                new System.IO.StreamWriter(client.GetStream());
                writer.Write(ZPLString);
                writer.Flush();
                // Close Connection
                writer.Close();
                client.Close();
                //clear data
                //clearit();
                MessageBox.Show("Clear");
            }
            catch (Exception ex)
            {
                this.Close();
                //MessageBox.Show(ex.Message);
                //clear data
                //clearit();
            }
        }
        private void Popup_Connect_Btn_Click(object sender, EventArgs e)
        {
            query = @"select top 1 * from WL_Station_Dashboard_Line_Data where Station = ";
            SqlConnection con = new SqlConnection(sql_con);
            SqlCommand Applique = new SqlCommand(query + "'" + Door_Pos + "_" + Station + "'", con);
            try
            {
                con.Open();

                SqlDataReader appli = Applique.ExecuteReader();
                while (appli.Read())
                {
                    IP_Stuffs = appli.GetValue(1).ToString();
                }
                appli.Close();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            System.Diagnostics.Process.Start(@"C:\Program Files\SolarWinds\DameWare Mini Remote Control x64\dwrcc.exe", " -c: -h: -m:"+ IP_Stuffs + " -a:1");
        }
        private void Reprint_Btn_Click(object sender, EventArgs e)
        {
            Popup_JSN_txt.Visible = false; Popup_Seq_txt.Visible = false; Popup_Rack_txt.Visible = false; Popup_Slot_txt.Visible = false;
            Popup_Time_txt.Visible = false; Popup_Connect_Btn.Visible = false; Popup_JSN_Lbl.Visible = false; Popup_Seq_Lbl.Visible = false;
            Popup_Rack_Lbl.Visible = false; Popup_Slot_Lbl.Visible = false; Popup_Time_Lbl.Visible = false;
            // Show Reprint Labels
            Chk_Bcode_Applique.Visible = true; Applique_Lbl.Visible = true;
            Chk_Bcode_ArmRest.Visible = true; Armrest_Lbl.Visible = true;
            Chk_Bcode_MidBolster.Visible = true; Midbolster_Lbl.Visible = true;
            Chk_Bcode_Upper.Visible = true; Upper_Lbl.Visible = true;
            Btn_Print.Visible = true;
            Reprint_Btn.Visible = false;
        }
    }
}