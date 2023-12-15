using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace justatester
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            XmlDocument xxdoc = new XmlDocument();
            xxdoc.Load(@"Embed_data.XML");

            XmlNode IP_Address_L = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_L");
            Printer_IP_L.Text = IP_Address_L.InnerText.ToString();
            XmlNode IP_Address_R = xxdoc.SelectSingleNode("Applique_Print/IP_Address/Printer_R");
            Printer_IP_R.Text = IP_Address_R.InnerText.ToString();
            XmlNode Applique_A_L = xxdoc.SelectSingleNode("Applique_Print/Applique_A/PNL");
            Applique_A_L_Txt.Text = Applique_A_L.InnerText.ToString();
            XmlNode Applique_A_R = xxdoc.SelectSingleNode("Applique_Print/Applique_A/PNR");
            Applique_A_R_Txt.Text = Applique_A_R.InnerText.ToString();
            XmlNode Applique_B_L = xxdoc.SelectSingleNode("Applique_Print/Applique_B/PNL");
            Applique_B_L_Txt.Text = Applique_B_L.InnerText.ToString();
            XmlNode Applique_B_R = xxdoc.SelectSingleNode("Applique_Print/Applique_B/PNR");
            Applique_B_R_Txt.Text = Applique_B_R.InnerText.ToString();
            XmlNode Applique_C_L = xxdoc.SelectSingleNode("Applique_Print/Applique_C/PNL");
            Applique_C_L_Txt.Text = Applique_C_L.InnerText.ToString();
            XmlNode Applique_C_R = xxdoc.SelectSingleNode("Applique_Print/Applique_C/PNR");
            Applique_C_R_Txt.Text = Applique_C_R.InnerText.ToString();
            // MessageBox.Show(String.Concat("IP Address: ", IP_Address.InnerText));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xxdoc = new XmlDocument();
            XmlTextWriter writer = new XmlTextWriter("Embed_Data.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Applique_Print");
            writer.WriteStartElement("IP_Address");
            writer.WriteElementString("Printer_L", Printer_IP_L.Text);
            writer.WriteElementString("Printer_R", Printer_IP_R.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("Applique_A");
            writer.WriteElementString("PNL", Applique_A_L_Txt.Text);
            writer.WriteElementString("PNR", Applique_A_R_Txt.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("Applique_B");
            writer.WriteElementString("PNL", Applique_B_L_Txt.Text);
            writer.WriteElementString("PNR", Applique_B_R_Txt.Text);
            writer.WriteEndElement();
            writer.WriteStartElement("Applique_C");
            writer.WriteElementString("PNL", Applique_C_L_Txt.Text);
            writer.WriteElementString("PNR", Applique_C_R_Txt.Text);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();
            MessageBox.Show("-= Configuration Saved =-");
            this.Close();
        }
    }
}
