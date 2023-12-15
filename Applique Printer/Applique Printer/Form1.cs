using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applique_Printer
{
    public partial class App_Printer : Form
    {
        public string dateinfo;
        public App_Printer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public double ToJulianDate(this DateTime date)
        {
            return date.ToOADate() + 2415018.5;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //double date = date.ToOADate() + 2415018.5;
            //   string text = (date.ToString());
            dateinfo = ToJulianDate(DateTime.Now).ToString();
            MessageBox.Show(dateinfo);
        }
    }
}
