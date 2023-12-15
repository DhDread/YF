using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.Timers;
using System.Xml;

namespace justatester
{
    public partial class Form1 : Form
    {
        private static Timer loopTimer;
        public string Left_Printer_IP;
        public string Right_Printer_IP;
        public string Applique_A_Right;
        public string nl = "\r\n";
        public Form1()
        {
            InitializeComponent();
            loopTimer = new Timer();
            loopTimer.Interval = 2000;// interval in milliseconds
            loopTimer.Enabled = false;
            loopTimer.Elapsed += loopTimerEvent;
            loopTimer.AutoReset = true;
            //form button
            Settings_Btn.MouseDown += mouseDownEvent;
            Settings_Btn.MouseUp += mouseUpEvent;
            fill_data();
        }
        public void fill_data()
        {
            XmlDocument xxdoc = new XmlDocument();
            xxdoc.Load(@"Embed_data.XML");
            //Fill button data
            XmlNode LH_Printer = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_L");
            XmlNode RH_Printer = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_R");
            LH_Printer_Ip_Lbl.Text = LH_Printer.InnerText.ToString();
            RH_Printer_Ip_Lbl.Text = RH_Printer.InnerText.ToString();
            XmlNode Applique_A_L = xxdoc.SelectSingleNode("Applique_Print/Applique_A/PNL");
            XmlNode Applique_A_R = xxdoc.SelectSingleNode("Applique_Print/Applique_A/PNR");
            Applique_A_Btn.Text = "Applique_A" + nl + nl +
                                  "LH: " + Applique_A_L.InnerText.ToString() + nl +
                                  "RH: " + Applique_A_R.InnerText.ToString();
            XmlNode Applique_B_L = xxdoc.SelectSingleNode("Applique_Print/Applique_B/PNL");
            XmlNode Applique_B_R = xxdoc.SelectSingleNode("Applique_Print/Applique_B/PNR");
            Applique_B_Btn.Text = "Applique_B" + nl + nl +
                                  "LH: " + Applique_B_L.InnerText.ToString() + nl +
                                  "RH: " + Applique_B_R.InnerText.ToString();
            XmlNode Applique_C_L = xxdoc.SelectSingleNode("Applique_Print/Applique_C/PNL");
            XmlNode Applique_C_R = xxdoc.SelectSingleNode("Applique_Print/Applique_C/PNR");
            Applique_C_Btn.Text = "Applique_C" + nl + nl +
                                  "LH: " + Applique_C_L.InnerText.ToString() + nl +
                                  "RH: " + Applique_C_R.InnerText.ToString();
            //
        }
        private static void loopTimerEvent(Object source, ElapsedEventArgs e)
        {
            //MessageBox.Show("OMG");
            loopTimer.Stop();
            Form2 F2 = new Form2();
            F2.ShowDialog();
        }
        private static void mouseDownEvent(object sender, MouseEventArgs e)
        {
            loopTimer.Enabled = true;
        }
        private static void mouseUpEvent(object sender, MouseEventArgs e)
        {
            loopTimer.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Shift_Time;
            TimeSpan DayShift_Start = new TimeSpan(5, 0, 0); //5a
            TimeSpan DayShift_End = new TimeSpan(17, 0, 0); //5p
            TimeSpan now = DateTime.Now.TimeOfDay;
            if ((now > DayShift_Start) && (now < DayShift_End))
            {
                Shift_Time = "1";
            }
            else
            {
                Shift_Time = "2";
            }
            string Serial_Number = "S" + string.Format("{0:000}", DateTime.Now.DayOfYear);
            string Cur_Time = Shift_Time + DateTime.Now.ToString("HHmmss");
            //xml
            XmlDocument xxdoc = new XmlDocument();
            xxdoc.Load(@"Embed_data.XML");
            XmlNode IP_Address_R = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_R");
            Right_Printer_IP = IP_Address_R.InnerText.ToString();
            XmlNode IP_Address_L = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_L");
            Left_Printer_IP = IP_Address_L.InnerText.ToString();
            //
            if (Left_ChkBox.Checked)
            {
                XmlNode Applique_A_L = xxdoc.SelectSingleNode("Applique_Print/Applique_A/PNL");
                string Applique_A_Left = "&FCAWL21&" + Applique_A_L.InnerText.ToString() + "&01";
                string Applique_Print_String = Serial_Number + Cur_Time + Applique_A_Left;
                ZPLPrinter(Serial_Number,Cur_Time, Applique_A_L.InnerText.ToString(), Left_Printer_IP);
            }
            if (Right_ChkBox.Checked)
            {
                XmlNode Applique_A_R = xxdoc.SelectSingleNode("Applique_Print/Applique_A/PNR");
                string Applique_A_Right = "&FCAWL21&" + Applique_A_R.InnerText.ToString() + "&01";
                string Applique_Print_String = Serial_Number + Cur_Time + Applique_A_Right;
                ZPLPrinter(Serial_Number, Cur_Time, Applique_A_R.InnerText.ToString(), Right_Printer_IP);
            }
        }
        private void ZPLPrinter(string Serial,string Time, string Part_Num,string ZPL_Printer_IP)
        {
            string ZPL_Print_Data = Serial + Time + @"&FCAWL&" + Part_Num + @"&01";
            int port = 9100;

            // ZPL Command(s)
            string ZPLString =
                @"^XA^PR3^FS^JMA^FO30,55^BY3^BXN,4,200,24,24,6,_^FH\^FD" + ZPL_Print_Data + 
                @"^FS^FT150,60^A0N,20,20^FD" + Serial + Time +
                @"^FS^FT165,80^A0N,20,20^FD&FCAWL&^FS^FT145,100^A0N,20,20^FD" +
                Part_Num + @"^FS^FT185,120^A0N,20,20^FD&01^FS^XZ";            
           // MessageBox.Show(ZPLString);
            try
            {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(ZPL_Printer_IP, port);
                // Write ZPL String to connection
                System.IO.StreamWriter writer =
                                        new System.IO.StreamWriter(client.GetStream());
                writer.Write(ZPLString);
                writer.Flush();
                // Close Connection
                writer.Close();
                client.Close();
                //clear data
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //clear data
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Serial_Number = "S" + string.Format("{0:000}", DateTime.Now.DayOfYear);
            string Cur_Time = "0" + DateTime.Now.ToString("HHmmss");
            //xml
            XmlDocument xxdoc = new XmlDocument();
            xxdoc.Load(@"Embed_data.XML");
            XmlNode IP_Address_R = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_R");
            Right_Printer_IP = IP_Address_R.InnerText.ToString();
            XmlNode IP_Address_L = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_L");
            Left_Printer_IP = IP_Address_L.InnerText.ToString();
            //
            if (Left_ChkBox.Checked)
            {
                XmlNode Applique_A_L = xxdoc.SelectSingleNode("Applique_Print/Applique_B/PNL");
                string Applique_A_Left = "&FCAWL21&" + Applique_A_L.InnerText.ToString() + "&01";
                string Applique_Print_String = Serial_Number + Cur_Time + Applique_A_Left;
                ZPLPrinter(Serial_Number, Cur_Time, Applique_A_L.InnerText.ToString(), Left_Printer_IP);
            }
            if (Right_ChkBox.Checked)
            {

                XmlNode Applique_A_R = xxdoc.SelectSingleNode("Applique_Print/Applique_B/PNR");
                string Applique_A_Right = "&FCAWL21&" + Applique_A_R.InnerText.ToString() + "&01";
                string Applique_Print_String = Serial_Number + Cur_Time + Applique_A_Right;
                ZPLPrinter(Serial_Number, Cur_Time, Applique_A_R.InnerText.ToString(), Right_Printer_IP);
            }
        }

        private void Applique_C_Btn_Click(object sender, EventArgs e)
        {
            string Serial_Number = "S" + string.Format("{0:000}", DateTime.Now.DayOfYear);
            string Cur_Time = "0" + DateTime.Now.ToString("HHmmss");
            //xml
            XmlDocument xxdoc = new XmlDocument();
            xxdoc.Load(@"Embed_data.XML");
            XmlNode IP_Address_R = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_R");
            Right_Printer_IP = IP_Address_R.InnerText.ToString();
            XmlNode IP_Address_L = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_L");
            Left_Printer_IP = IP_Address_L.InnerText.ToString();
            //
            if (Left_ChkBox.Checked)
            {
                XmlNode Applique_A_L = xxdoc.SelectSingleNode("Applique_Print/Applique_C/PNL");
                string Applique_A_Left = "&FCAWL21&" + Applique_A_L.InnerText.ToString() + "&01";
                string Applique_Print_String = Serial_Number + Cur_Time + Applique_A_Left;
                ZPLPrinter(Serial_Number, Cur_Time, Applique_A_L.InnerText.ToString(), Left_Printer_IP);
            }
            if (Right_ChkBox.Checked)
            {

                XmlNode Applique_A_R = xxdoc.SelectSingleNode("Applique_Print/Applique_C/PNR");
                string Applique_A_Right = "&FCAWL21&" + Applique_A_R.InnerText.ToString() + "&01";
                string Applique_Print_String = Serial_Number + Cur_Time + Applique_A_Right;
                ZPLPrinter(Serial_Number, Cur_Time, Applique_A_R.InnerText.ToString(), Right_Printer_IP);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            fill_data();
        }
    }
}
