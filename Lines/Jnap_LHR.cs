using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Line_Manager
{
    public partial class Jnap_LHR : Form
    {
        public string Station;
        public int Cursor_x;
        public int Cursor_y;
        public static string sql_con = @"Server=US2270VM0027;Database=WLWDDoors;Trusted_Connection=True"; //User ID=" + @"EPSApplication;" + @"Password=" + @"EPSApplication;";
        public static string query;
        public static string line;
        public Jnap_LHR()
        {
            InitializeComponent();
            this.App_Panel.MouseClick += Applique_Station_Click; this.App_Lbl.MouseClick += Applique_Station_Click; this.App_Seq_Lbl.MouseClick += Applique_Station_Click;
            this.Appjoin_Panel.MouseClick += AppJoin_Station_Click; this.Appjoin_Lbl.MouseClick += AppJoin_Station_Click; this.Appjoin_Seq_Lbl.MouseClick += AppJoin_Station_Click;
            this.Midblster_Panel.MouseClick += Midblster_Station_Click; this.Midblster_Lbl.MouseClick += Midblster_Station_Click; this.Midblster_Seq_Lbl.MouseClick += Midblster_Station_Click;
            this.Armrest_Panel.MouseClick += Armrest_Station_Click; this.Armrest_Lbl.MouseClick += Armrest_Station_Click; this.Armrest_Seq_Lbl.MouseClick += Armrest_Station_Click;
            this.Screw_1_Panel.MouseClick += Screw_1_Station_Click; this.Screw_1_Lbl.MouseClick += Screw_1_Station_Click; this.Screw_1_Seq_Lbl.MouseClick += Screw_1_Station_Click;
            this.Screw_2_Panel.MouseClick += Screw_2_Station_Click; this.Screw_2_Lbl.MouseClick += Screw_2_Station_Click; this.Screw_2_Seq_Lbl.MouseClick += Screw_2_Station_Click;
            this.Screw_3_Panel.MouseClick += Screw_3_Station_Click; this.Screw_3_Lbl.MouseClick += Screw_3_Station_Click; this.Screw_3_Seq_Lbl.MouseClick += Screw_3_Station_Click;
            this.FRA_Load_Panel.MouseClick += FRA_Load_Station_Click; this.FRA_Load_Lbl.MouseClick += FRA_Load_Station_Click; this.FRA_Load_Seq_Lbl.MouseClick += FRA_Load_Station_Click;
            this.FRA_Station_A_Panel.MouseClick += FRA_Station_A_Station_Click; this.FRA_Station_A_Lbl.MouseClick += FRA_Station_A_Station_Click; this.FRA_Station_A_Seq_Lbl.MouseClick += FRA_Station_A_Station_Click;
            this.FRA_Station_B_Panel.MouseClick += FRA_Station_B_Station_Click; this.FRA_Station_B_Lbl.MouseClick += FRA_Station_B_Station_Click; this.FRA_Station_B_Seq_Lbl.MouseClick += FRA_Station_B_Station_Click;
            this.FRA_Station_C_Panel.MouseClick += FRA_Station_C_Station_Click; this.FRA_Station_C_Lbl.MouseClick += FRA_Station_C_Station_Click; this.FRA_Station_C_Seq_Lbl.MouseClick += FRA_Station_C_Station_Click;
            this.FRA_Unload_Panel.MouseClick += FRA_Unload_Station_Click; this.FRA_Unload_Lbl.MouseClick += FRA_Unload_Station_Click; this.FRA_Unload_Seq_Lbl.MouseClick += FRA_Unload_Station_Click;
            this.Post_FRA_Panel.MouseClick += Post_FRA_Station_Click; this.Post_FRA_Lbl.MouseClick += Post_FRA_Station_Click; this.Post_FRA_Seq_Lbl.MouseClick += Post_FRA_Station_Click;
            this.Harness_1_Panel.MouseClick += Harness_1_Click; this.Harness_1_Lbl.MouseClick += Harness_1_Click; this.Harness_1_Seq_Lbl.MouseClick += Harness_1_Click;
            this.Harness_2_Panel.MouseClick += Harness_2_Click; this.Harness_2_Lbl.MouseClick += Harness_2_Click; this.Harness_2_Seq_Lbl.MouseClick += Harness_2_Click;
            this.WD_Punch_Panel.MouseClick += Punch_Click; this.WD_Punch_Lbl.MouseClick += Punch_Click; this.WD_Punch_Seq_Lbl.MouseClick += Punch_Click;
            this.WD_Weld_1_Panel.MouseClick += Weld_1_Click; this.WD_Weld_1_Lbl.MouseClick += Weld_1_Click; this.WD_Weld_1_Seq_Lbl.MouseClick += Weld_1_Click;
            this.WD_Armrest_Panel.MouseClick += WD_Armrest_Click; this.WD_Armrest_Lbl.MouseClick += Weld_2_Click; this.WD_Armrest_Seq_Lbl.MouseClick += WD_Armrest_Click;
            this.WD_Weld_2_Panel.MouseClick += Weld_2_Click; this.WD_Weld_2_Lbl.MouseClick += Weld_2_Click; this.WD_Weld_2_Seq_Lbl.MouseClick += Weld_2_Click;
            this.Camera_Panel.MouseClick += Camera_Click; this.Camera_Lbl.MouseClick += Camera_Click; this.Camera_Seq_Lbl.MouseClick += Camera_Click;

        }
        private void Jnap_LHR_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Text = String.Empty;
            //MessageBox.Show(Base_Form.Door_pos);
            Title_Lbl.Text = Base_Form.Door_pos;
            Fill_Data();
            Timer_Stuff();
        }
        private void Timer_Stuff()
        {
            LHR_Timer.Enabled = true;
            LHR_Timer.Start();
            LHR_Timer.Tick += new EventHandler(LHR_Timer_Tick);

        }
        void LHR_Timer_Tick(object sender, EventArgs e)
        {
            Fill_Data();
        }
        public void Fill_Data()
        {
            // this will connect to sql and send the data to be filled
            //query = @"declare @jsn as nvarchar(max) = '" + Txt_JSN.Text + @"' declare @id as nvarchar(max) = (select ID from Jobs where JobSerialNumber = @jsn) select Data from TraceData where JobID = @id and TracedataType = ";
            //query = @"declare @line nvarchar(max) = '" + line + @"' " +
            //        @"select station, sequence, rack, slot, model " + 
            //        @"from [Station_Dashboard_1.4] with(nolock) where station = ";
            query = @"exec [Reports].[wlWD_get_line_dashboard] '" + Base_Form.Door_pos + @"', ";
            // MessageBox.Show(jsn);
            // MessageBox.Show(query);
            SqlConnection con = new SqlConnection(sql_con);
            SqlCommand Cur_Datetime = new SqlCommand(@"Select GETDATE()", con);
            SqlCommand Applique = new SqlCommand(query + @"'Applique_Load'", con);
            SqlCommand AppJoin = new SqlCommand(query + @"'AppJoin'", con);
            SqlCommand Armrest = new SqlCommand(query + @"'Armrest'", con);
            SqlCommand Midbolster = new SqlCommand(query + @"'Midbolster'", con);
            SqlCommand Screw1 = new SqlCommand(query + @"'Screw1'", con);
            SqlCommand Screw2 = new SqlCommand(query + @"'Screw2'", con);
            SqlCommand Screw3 = new SqlCommand(query + @"'Screw3'", con);
            SqlCommand FRA_Load = new SqlCommand(query + @"'Load'", con);
            SqlCommand FRA_Station_A = new SqlCommand(query + @"'Process1'", con);
            SqlCommand FRA_Station_B = new SqlCommand(query + @"'Process2'", con);
            SqlCommand FRA_Station_C = new SqlCommand(query + @"'Process3'", con);
            SqlCommand FRA_Station_D = new SqlCommand(query + @"'Process4'", con);
            SqlCommand FRA_Unload = new SqlCommand(query + @"'Unload'", con);
            SqlCommand Post_FRA = new SqlCommand(query + @"'POSTFRA'", con);
            SqlCommand WD_Punch = new SqlCommand(query + @"'Punch'", con);
            SqlCommand WD_Weld_1 = new SqlCommand(query + @"'Weld_1'", con);
            SqlCommand WD_Armrest = new SqlCommand(query + @"'WD_Armrest'", con);
            SqlCommand WD_Weld_2 = new SqlCommand(query + @"'Weld_2'", con);
            SqlCommand Harness_1 = new SqlCommand(query + @"'Harness1'", con);
            SqlCommand Harness_2 = new SqlCommand(query + @"'Harness2'", con);
            SqlCommand Camera = new SqlCommand(query + @"'Camera'", con);
            SqlCommand Packout = new SqlCommand(query + @"'Pack'", con);
            try
            {
                con.Open();
                SqlDataReader appli = Applique.ExecuteReader();
                while (appli.Read())
                {
                    string Server_Time;
                    Server_Time = appli.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = appli.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    App_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                appli.Close();
                SqlDataReader APJoin = AppJoin.ExecuteReader();
                while (APJoin.Read())
                {
                    string Server_Time;
                    Server_Time = APJoin.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = APJoin.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Appjoin_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";

                }
                APJoin.Close();
                SqlDataReader armar = Armrest.ExecuteReader();
                while (armar.Read())
                {
                    string Server_Time;
                    Server_Time = armar.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = armar.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Armrest_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                armar.Close();
                SqlDataReader midbol = Midbolster.ExecuteReader();
                while (midbol.Read())
                {
                    string Server_Time;
                    Server_Time = midbol.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = midbol.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Midblster_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                midbol.Close();
                SqlDataReader Screw_1 = Screw1.ExecuteReader();
                while (Screw_1.Read())
                {
                    string Server_Time;
                    Server_Time = Screw_1.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = Screw_1.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Screw_1_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                Screw_1.Close();
                SqlDataReader Screw_2 = Screw2.ExecuteReader();
                while (Screw_2.Read())
                {
                    string Server_Time;
                    Server_Time = Screw_2.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = Screw_2.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Screw_2_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                Screw_2.Close();
                SqlDataReader Screw_3 = Screw3.ExecuteReader();
                while (Screw_3.Read())
                {
                    string Server_Time;
                    Server_Time = Screw_3.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = Screw_3.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Screw_3_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                Screw_3.Close();
                SqlDataReader fraload = FRA_Load.ExecuteReader();
                while (fraload.Read())
                {
                    string Server_Time;
                    Server_Time = fraload.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = fraload.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    FRA_Load_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                fraload.Close();
                SqlDataReader fra_a = FRA_Station_A.ExecuteReader();
                while (fra_a.Read())
                {
                    string Server_Time;
                    Server_Time = fra_a.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = fra_a.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    FRA_Station_A_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                fra_a.Close();
                SqlDataReader fra_b = FRA_Station_B.ExecuteReader();
                while (fra_b.Read())
                {
                    string Server_Time;
                    Server_Time = fra_b.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = fra_b.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    FRA_Station_B_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                fra_b.Close();
                SqlDataReader fra_c = FRA_Station_C.ExecuteReader();
                while (fra_c.Read())
                {
                    string Server_Time;
                    Server_Time = fra_c.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = fra_c.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    FRA_Station_C_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                fra_c.Close();
                SqlDataReader harn_1 = Harness_1.ExecuteReader();
                while (harn_1.Read())
                {
                    string Server_Time;
                    Server_Time = harn_1.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = harn_1.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Harness_1_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                harn_1.Close();
                SqlDataReader harn_2 = Harness_2.ExecuteReader();
                while (harn_2.Read())
                {
                    string Server_Time;
                    Server_Time = harn_2.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = harn_2.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Harness_2_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                harn_2.Close();
                SqlDataReader WDPun = WD_Punch.ExecuteReader();
                while (WDPun.Read())
                {
                    string Server_Time;
                    Server_Time = WDPun.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = WDPun.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    WD_Punch_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                WDPun.Close();
                SqlDataReader WDWeld1 = WD_Weld_1.ExecuteReader();
                while (WDWeld1.Read())
                {
                    string Server_Time;
                    Server_Time = WDWeld1.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = WDWeld1.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    WD_Weld_1_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                WDWeld1.Close();
                SqlDataReader WDArm = WD_Armrest.ExecuteReader();
                while (WDArm.Read())
                {
                    string Server_Time;
                    Server_Time = WDArm.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = WDArm.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    WD_Armrest_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                WDArm.Close();
                SqlDataReader WDWeld2 = WD_Weld_2.ExecuteReader();
                while (WDWeld2.Read())
                {
                    string Server_Time;
                    Server_Time = WDWeld2.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = WDWeld2.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    WD_Weld_2_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                WDWeld2.Close();
                SqlDataReader PostFRA = Post_FRA.ExecuteReader();
                while (PostFRA.Read())
                {
                    string Server_Time;
                    Server_Time = PostFRA.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = PostFRA.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Post_FRA_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                PostFRA.Close();
                SqlDataReader fraunload = FRA_Unload.ExecuteReader();
                while (fraunload.Read())
                {
                    string Server_Time;
                    Server_Time = fraunload.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = fraunload.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    FRA_Unload_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                fraunload.Close();
                SqlDataReader cam = Camera.ExecuteReader();
                while (cam.Read())
                {
                    string Server_Time;
                    Server_Time = cam.GetValue(7).ToString();
                    DateTime ST = Convert.ToDateTime(Server_Time);
                    string seqlbl = cam.GetValue(3).ToString();
                    string CT = decimal.Truncate(Convert.ToDecimal(DateTime.Now.Subtract(ST).TotalSeconds)).ToString();
                    Camera_Seq_Lbl.Text = seqlbl.Substring(seqlbl.Length - 4, 4) + " " + "(" + CT + ")";
                }
                cam.Close();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        // Click stuff
        private void Applique_Station_Click(object sender, EventArgs e)
        {
            Station = "Applique_Load";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void AppJoin_Station_Click(object sender, EventArgs e)
        {
            Station = "AppJoin";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Midblster_Station_Click(object sender, EventArgs e)
        {
            Station = "Midbolster";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Armrest_Station_Click(object sender, EventArgs e)
        {
            Station = "Armrest";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Screw_1_Station_Click(object sender, EventArgs e)
        {
            Station = "Screw1";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Screw_2_Station_Click(object sender, EventArgs e)
        {
            Station = "Screw2";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Screw_3_Station_Click(object sender, EventArgs e)
        {
            Station = "Screw3";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void FRA_Load_Station_Click(object sender, EventArgs e)
        {
            Station = "Load";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void FRA_Station_A_Station_Click(object sender, EventArgs e)
        {
            Station = "Process1";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void FRA_Station_B_Station_Click(object sender, EventArgs e)
        {
            Station = "Process2";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void FRA_Station_C_Station_Click(object sender, EventArgs e)
        {
            Station = "Process3";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void FRA_Unload_Station_Click(object sender, EventArgs e)
        {
            Station = "Unload";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Post_FRA_Station_Click(object sender, EventArgs e)
        {
            Station = "PostFRA";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Harness_1_Click(object sender, EventArgs e)
        {
            Station = "Harness1";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Harness_2_Click(object sender, EventArgs e)
        {
            Station = "Harness2";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Punch_Click(object sender, EventArgs e)
        {
            Station = "Punch";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Weld_1_Click(object sender, EventArgs e)
        {
            Station = "Weld_1";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void WD_Armrest_Click(object sender, EventArgs e)
        {
            Station = "WD_Armrest";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Weld_2_Click(object sender, EventArgs e)
        {
            Station = "Weld_2";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        private void Camera_Click(object sender, EventArgs e)
        {
            Station = "Camera";
            Cursor_x = Cursor.Position.X;
            Cursor_y = Cursor.Position.Y - 200;
            //MessageBox.Show(Cursor.Position.ToString());
            //Console.Write("Cursor X pos: " + Cursor_x + "Cursor X pos: " + Cursor_y);
            using (Jnap_Popup Popup = new Jnap_Popup())
            {
                Jnap_Popup obj = new Jnap_Popup();
                obj.StartPosition = FormStartPosition.Manual;
                obj.Location = new Point(Cursor_x, Cursor_y);
                obj.Station = this.Station;
                obj.Door_Pos = Base_Form.Door_pos;
                obj.Show();
            }
        }
        public void button1_Click(object sender, EventArgs e)
        {
            Fill_Data();
        }
    }
}