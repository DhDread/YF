using System;
using System.Windows.Forms;

namespace Line_Manager
{
    public partial class Login_Screen : Form
    {
        public string user = "000";
        public string pass = "000";
        public Login_Screen()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void Login_Btn_Click(object sender, EventArgs e)
        {

            if (User_Txt.Text.ToString() == user)
            {
                if (Pass_Txt.Text.ToString() == pass)
                {
                    Base_Form.logged_in = user;
                    // MessageBox.Show(user);
                }
                else
                {
                    MessageBox.Show("Password Wrong");
                }
            }
            else
            {
                MessageBox.Show("Incorrect User");
            }
        }
        private void Login_Screen_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Text = String.Empty;
            User_Txt.Text = user;
            Pass_Txt.Text = pass;
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            Pass_Txt.Text = "";
            User_Txt.Text = "";
        }
    }
}
