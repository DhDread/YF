using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rack_Slot_Printer
{
    public partial class Form1 : Form
    {
       // public static int Print_Count = 0;
        public static int Print_Rack_Int = 0; public static string Print_Rack_Str = null;
        public static string Print_Loc = null;
        public static string Print_Loc_Line = null;
        public static string Print_Final = null;
       // public static string Print_Final = null;
        public static string IP_Address = "10.17.98.27";
        public static int Print_Rack_Start_Int = 0; public static string Print_Rack_Start_Str;
        public static int Print_Rack_End_Int = 0; public static string Print_Rack_End_Str;
        public static string data;
        public static string ZPLString = null;


        public Form1()
        {
            InitializeComponent();
            values();
        }
        private void values()
        {
            CB_Line.Text = "- = Select = -";
            Txt_Ip_Address.Text = IP_Address;
            Txt_Rack_Id.Text = null;
            Txt_Start.Text = "1";
            Txt_End.Text = "24";
            ZPLString = null;
            JNAP_ChkBox.Checked = false;
            DPI_ChkBox.Checked = false;
        }
        private void CB_Line_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JNAP_ChkBox.Checked)
                {
                Print_Loc_Line = "J";
                }
            else
                {
                Print_Loc_Line = "C";
                 }
            if (CB_Line.Text == "Front Left Hand")
            {
                Print_Loc = Print_Loc_Line + "LHF00";
                //Txt_Ip_Address.Text = "1.2.3.4";
            }
            if (CB_Line.Text == "Rear Left Hand")
            {
                Print_Loc = Print_Loc_Line + "LHR00";
                // Txt_Ip_Address.Text = "2.3.4.5";
            }
            if (CB_Line.Text == "Front Right Hand")
            {
                Print_Loc = Print_Loc_Line + "RHF00";
                //Txt_Ip_Address.Text = "3.4.5.6";
            }
            if (CB_Line.Text == "Rear Right Hand")
            {
                Print_Loc = Print_Loc_Line + "RHR00";
                //Txt_Ip_Address.Text = "4.5.6.7";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Txt_Rack_Id.Text == "")
            {
                MessageBox.Show("Please Enter Rack #", "- = E R R O R = -");
            }
            else
            {
                Print_Rack_Int = Int32.Parse(Txt_Rack_Id.Text);
            }
            Print_Rack_Start_Int = Int32.Parse(Txt_Start.Text);
            Print_Rack_End_Int = Int32.Parse(Txt_End.Text);
            if(Print_Rack_Start_Int < 10)
            {
                Print_Rack_Start_Str = "0" + Print_Rack_Start_Int.ToString();
            }
            else
            {
                Print_Rack_Start_Str = Txt_Start.Text;
            }
            if(Print_Rack_End_Int < 10)
            {
                Print_Rack_End_Str = "0" + Print_Rack_End_Int.ToString();
            }
            else
            {
                Print_Rack_End_Str = Txt_End.Text;
            }
            if(Print_Rack_Int < 10)
            {
                Print_Rack_Str = "0" + Print_Rack_Int.ToString();
            }
            else
            {          
                Print_Rack_Str = Txt_Rack_Id.Text;
            }
            if(Print_Loc == null)
            {
                MessageBox.Show("Please Pick a Line", "- = E R R O R = -");
            }
            else
            {
                string Print_Final_Start = Print_Loc + Print_Rack_Str + "-" + Print_Rack_Start_Str;
                string Print_Final_End = Print_Loc + Print_Rack_Str + "-" + Print_Rack_End_Str;
                MessageBox.Show("Printing:" + "\n" + Print_Final_Start + "\n" + "to" + "\n" + Print_Final_End);
                
                //Z_Print();
                Counter();
                values();
            }           
        }
        private void Counter()
        {
            for(int count = Print_Rack_Start_Int; count <= Print_Rack_End_Int; count++)
            {
                //Print_Final = null;
                if(count < 10)
                {
                    Print_Final = Print_Loc + Print_Rack_Str + "-0" + count;
                    Console.Write(Print_Final + "\n");
                    Z_Print();
                }
                else
                {
                    Print_Final = Print_Loc + Print_Rack_Str + "-" + count;
                    Console.Write(Print_Final + "\n");
                    Z_Print();
                }
                
                //Console.WriteLine(count.ToString());
            }
        }
        private void Z_Print()
        {
            // Printer IP Address and communication port
            // location decided by which check from chk_print
            //ips are global up top
            int port = 9100;

            // ZPL Command(s)
            if (DPI_ChkBox.Checked)
            {
                ZPLString =
                @"^XA^PR3^FS^JMA^MUd,200,600^FS^FO45,35^BY3^BXN,18,200,16,16,6,_^FH\^FD"
                + Print_Final +
                @"^FS^FO230,35^BY3^BXN,18,200,16,16,6,_^FH\^FD"
                + Print_Final +
                @"^FS^FT50,180^A0N,45,45^FD"
                + Print_Final +
                @"^FS^MUd,600,600^FS^XZ";
            }
            else
            {
                ZPLString =
                @"^XA^PR3^FS^JMA^FO45,35^BY3^BXN,6,200,16,16,6,_^FH\^FD"
                + Print_Final +
                @"^FS^FO230,35^BY3^BXN,6,200,16,16,6,_^FH\^FD"
                + Print_Final +
                @"^FS^FT50,180^A0N,45,45^FD"
                + Print_Final +
                @"^FS^XZ";
            }
            try
            {
                // Open connection
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                client.Connect(Txt_Ip_Address.Text, port);
                // Write ZPL String to connection
                System.IO.StreamWriter writer =
                new System.IO.StreamWriter(client.GetStream());
                writer.Write(ZPLString);
                writer.Flush();
                // Close Connection
                writer.Close();
                client.Close();
                //clear data
                values();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //clear data
                values();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            values();
        }
    }
}
