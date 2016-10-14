using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel; 
using Microsoft.Office.Tools.Excel;
using System.Threading;
//using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Net;


namespace BackupreportTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dtpicker1.CustomFormat = "yyyy_MM_dd";
            dtpicker2.CustomFormat = "yyyy_MM_dd";
            dtpicker3.ShowUpDown = true;
            dtpicker3.CustomFormat = "HH:mm:ss";
            dtpicker3.Format = DateTimePickerFormat.Custom;
            dtpicker4.ShowUpDown = true;
            dtpicker4.CustomFormat = "HH:mm:ss";
            dtpicker4.Format = DateTimePickerFormat.Custom;
            label2.ForeColor = System.Drawing.Color.Green;
            label2.Text = "Ready";
        }

        String path = Application.StartupPath + "\\Configs\\Config.ini";

        private void Form1_Load(object sender, EventArgs e)
        {
            
            INIFile ini = new INIFile(path);
            txtDB.Text = ini.Read("Config", "Database");
            txtFile.Text = ini.Read("Config", "Path" );
            string getbool =  ini.Read("Config", "Exportallmonth");
            chkMonth.Checked = Convert.ToBoolean(getbool);
            
            
            int i = 1;
            if (File.Exists(Program.updateSettings))
            {
                string[] lines = File.ReadAllLines(Program.updateSettings);
                i = 1;
                foreach (string line in lines)
                {
                    switch (i)
                    {
                        case 1:
                            checkbox_AutoUpdate.Checked = bool.Parse(line);
                            break;
                    }
                }
            }

            if (Program.getNewestVersion() > Assembly.GetExecutingAssembly().GetName().Version)
            {
                if (checkbox_AutoUpdate.Checked)
                {
                    Form update = new Update();
                    update.ShowDialog();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("There is an Update on Github. do you want to open it ?", "Newest Version: " + Program.getNewestVersion(), MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Process.Start("https://github.com/Ar1i/PokemonGo-Bot");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //nothing   
                    }
                }

            }
        }

        private void btnsaveConfig_Click(object sender, EventArgs e)
        {
            INIFile ini = new INIFile(path);
            ini.Write("Config", "Database", txtDB.Text.ToString());
            ini.Write("Config", "Path", txtFile.Text.ToString());
            ini.Write("Config", "Exportallmonth", chkMonth.Checked.ToString());

            MySql.Data.MySqlClient.MySqlConnection conn1;
            string myConnectionString1;
            myConnectionString1 = "server=localhost;uid=root;" +
            "pwd=eibiz1234;database=" + txtDB.Text + ";default command timeout=1000000;";
            conn1 = new MySql.Data.MySqlClient.MySqlConnection();
            conn1.ConnectionString = myConnectionString1;
            conn1.Open();
            string sqlGetreportall = "DROP PROCEDURE IF EXISTS `Getreportall`; CREATE DEFINER=`root`@`localhost` PROCEDURE `Getreportall`(IN startads varchar(255), IN endads varchar(255))" +
                                    "BEGIN"+
                                      " select  medialog.type, medialog.detail, medialog.startTime, medialog.endTime, medialog.playTime, "+
                                                                       " media.`status`, medialog.idPlayer as player, player.`name`, media.displayName as MediaName, library.`name` as MediaType "+
                                                                       " from medialog "+
                                                                       " join player "+
                                                                       " on player.idPlayer = medialog.idPlayer "+
                                                                       " join media"+
                                                                       " on media.idMedia = medialog.idMedia "+
                                                                       " join library "+
                                                                       " on library.idLibrary = media.idLibrary "+
                                                                       " where medialog.idGroup = 0 "+								    
                                                                       " and medialog.startTime BETWEEN  startads and endads; "+
                                        "END";

            string sqlGetreportbyday = "DROP PROCEDURE IF EXISTS `Getreportbyday`; CREATE DEFINER=`root`@`localhost` PROCEDURE `Getreportbyday`(IN startdate varchar(255), IN enddate varchar(255))" +
                                    "BEGIN"+
                                       " select  medialog.type, medialog.detail, medialog.startTime, medialog.endTime, medialog.playTime, "+
                                                                        " media.`status`, medialog.idPlayer as player, player.`name`, media.displayName as MediaName, library.`name` as MediaType "+
                                                                        " from medialog "+
                                                                        " inner join player "+
                                                                        " on player.idPlayer = medialog.idPlayer "+
                                                                        " inner join media "+
                                                                        " on media.idMedia = medialog.idMedia "+
                                                                        " inner join library "+
                                                                        " on library.idLibrary = media.idLibrary "+
                                                                        " where startTime BETWEEN startdate and  enddate; "+
                                      "END";

            string sqlGetreportbygroup = "DROP PROCEDURE IF EXISTS `Getreportbygroup`; CREATE DEFINER=`root`@`localhost` PROCEDURE `Getreportbygroup`(IN groupid int, IN startdate varchar(255), IN enddate varchar(255)) " +
                                        "BEGIN"+
                                       " select  medialog.type, medialog.detail, medialog.startTime, medialog.endTime, medialog.playTime, "+
                                                                               " media.`status`, medialog.idPlayer as player, player.`name`, media.displayName as MediaName, library.`name` as MediaType "+
                                                                               " from medialog "+
                                                                               " inner join player "+
                                                                               " on player.idPlayer = medialog.idPlayer "+
                                                                               " inner join media "+
                                                                               " on media.idMedia = medialog.idMedia "+
                                                                               "  inner join library "+
                                                                               "  on library.idLibrary = media.idLibrary "+
                                                                               "  where medialog.idGroup = groupid "+
                                                                               "  and medialog.startTime BETWEEN startdate and enddate; "+
                                        "END";

            string sqlcreateindexstarttime = "CREATE INDEX index_startTime ON medialog (startTime)";
            string sqlcreateindexendtime = "CREATE INDEX index_endTime ON medialog (endTime)";
            try
            {

                MySqlCommand Getreportall = new MySqlCommand(sqlGetreportall, conn1);
                Getreportall.ExecuteReader();
                conn1.Close();
                conn1.Open();
                MySqlCommand Getreportbyday = new MySqlCommand(sqlGetreportbyday, conn1);
                Getreportbyday.ExecuteReader();
                conn1.Close();
                conn1.Open();
                MySqlCommand Getreportbygroup = new MySqlCommand(sqlGetreportbygroup, conn1);
                Getreportbygroup.ExecuteReader();
                conn1.Close();
                conn1.Open();
                MySqlCommand Crateindexstarttime = new MySqlCommand(sqlcreateindexstarttime, conn1);
                Crateindexstarttime.ExecuteReader();
                conn1.Close();
                conn1.Open();
                MySqlCommand Crateindexendtime = new MySqlCommand(sqlcreateindexendtime, conn1);
                Crateindexendtime.ExecuteReader();
                conn1.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(""+ex+"");
                //return;
            }
            MessageBox.Show("Save Done");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetUpTimer(new TimeSpan(06, 00, 00), new TimeSpan(06, 00, 02));
        }

        private void SetUpTimer(TimeSpan starttime, TimeSpan endtime)
        {
            DateTime current = DateTime.Now;

            if (current.TimeOfDay >= starttime && current.TimeOfDay <= endtime)
            {
                if (today != DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    timer1.Stop();
                    today = DateTime.Now.ToString("yyyy-MM-dd");
                    this.SomeMethodRunsAt1600();
                    timer1.Start();
                }
            }
            else
            {
                return;//time already passed
            }
        }
        private string today;

        private void SomeMethodRunsAt1600()
        {
            btnsubmit.Enabled = false;
            btnsaveConfig.Enabled = false;
            label2.ForeColor = System.Drawing.Color.Red;
            label2.Text = "Please wait untill message change to ready";
            backup();
            System.Threading.Thread.Sleep(10000);
            dairy();
            label2.ForeColor = System.Drawing.Color.Green;
            label2.Text = "Ready";
            btnsubmit.Enabled = true;
            btnsaveConfig.Enabled = true;
            //Send mail
            var t = new Thread(() => SendToEmail("Export report complete please check in server"));
            t.Start();
        }

        private void backup()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            DateTime sDate = DateTime.Now;
            sDate = sDate.AddDays(-1);
            label1.Text = sDate.ToString("yyyy_MM_dd");

            // connect Database
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "server=localhost;uid=root;" +
            "pwd=eibiz1234;database=" + txtDB.Text + ";default command timeout=1000000;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;

            //Query report ungroup
            string queryungroup = "call Getreportall('" + label1.Text + " 00:00:00', '" + label1.Text + " 23:59:59')";
            MySqlCommand command1 = new MySqlCommand(queryungroup, conn);
            MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
            MyAdapter1.SelectCommand = command1;
            System.Data.DataTable dTable1 = new System.Data.DataTable();
            MyAdapter1.Fill(dTable1);
            dataGridView1.DataSource = dTable1;

            //Export To CSV file
            var sb1 = new StringBuilder();
            var headers1 = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb1.AppendLine(string.Join(",", headers1.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells1 = row.Cells.Cast<DataGridViewCell>();
                sb1.AppendLine(string.Join(",", cells1.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }
            if (!Directory.Exists(@"C:\EIBIZ\i-Media Report\" + txtFile.Text))
                Directory.CreateDirectory(@"C:\EIBIZ\i-Media Report\" + txtFile.Text);
            
            string pathfile1 = @"C:\EIBIZ\i-Media Report\"+txtFile.Text+"\\UnGroup" + "_" + label1.Text + ".csv";
            File.WriteAllText(pathfile1, sb1.ToString(), Encoding.UTF8);

        }

        private void dairy()
        {
            // connect Database

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            DateTime sDate = DateTime.Now;
            int dy = sDate.Day;

            MySql.Data.MySqlClient.MySqlConnection conn1;
            string myConnectionString1;
            myConnectionString1 = "server=localhost;uid=root;" +
            "pwd=eibiz1234;database=" + txtDB.Text + ";default command timeout=1000000;";
            conn1 = new MySql.Data.MySqlClient.MySqlConnection();
            conn1.ConnectionString = myConnectionString1;

            //Query Groupmedia
            string querygroup = "select idGroup, name from `group`";
            MySqlCommand command = new MySqlCommand(querygroup, conn1);
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = command;
            System.Data.DataTable dTable = new System.Data.DataTable();
            MyAdapter.Fill(dTable);
            dataGridView1.DataSource = dTable;
            //Query report each group
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[0].Value == null)
                    break;
                //string querymedialog = "call Getreportbydaytemporary(" + dr.Cells[0].Value + ", '" + label1.Text + " 00:00:00', '" + label1.Text + " 23:59:59' )";
                string querymedialog = "call Getreportbygroup(" + dr.Cells[0].Value + ", '" + label1.Text + " 00:00:00', '" + label1.Text + " 23:59:59' )";
                MySqlCommand command1 = new MySqlCommand(querymedialog, conn1);
                MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                MyAdapter1.SelectCommand = command1;
                System.Data.DataTable dTable1 = new System.Data.DataTable();
                MyAdapter1.Fill(dTable1);
                dataGridView2.DataSource = dTable1;

                //Export To CSV file
                var sb1 = new StringBuilder();
                var headers1 = dataGridView2.Columns.Cast<DataGridViewColumn>();
                sb1.AppendLine(string.Join(",", headers1.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    var cells1 = row.Cells.Cast<DataGridViewCell>();
                    sb1.AppendLine(string.Join(",", cells1.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                }

                if (!Directory.Exists(@"C:\EIBIZ\i-Media Report\" + txtFile.Text))
                    Directory.CreateDirectory(@"C:\EIBIZ\i-Media Report\" + txtFile.Text);

                string pathfile1 = @"C:\EIBIZ\i-Media Report\" + txtFile.Text + "\\" + dr.Cells[1].Value + "_" + label1.Text + ".csv";
                File.WriteAllText(pathfile1, sb1.ToString(), Encoding.UTF8);
            }

            if (dy == 1)
            {
                if(chkMonth.Checked == true)
                {
                    var today = DateTime.Today;
                    var thisMonth = new DateTime(today.Year, today.Month, 1);
                    var prevStartMonth = thisMonth.AddMonths(-1).ToString("yyyy-MM-dd");
                    var prevEndMonth = thisMonth.AddDays(-1).ToString("yyyy-MM-dd");
                    //MessageBox.Show(prevStartMonth + " - " + prevEndMonth + "");
   
                    string sqlqueryallmonth = " select  medialog.type, medialog.detail, medialog.startTime, medialog.endTime, medialog.playTime, " +
                                                                        " media.`status`, medialog.idPlayer as player, player.`name`, media.displayName as MediaName, library.`name` as MediaType " +
                                                                        " from medialog " +
                                                                        " inner join player " +
                                                                        " on player.idPlayer = medialog.idPlayer " +
                                                                        " inner join media " +
                                                                        " on media.idMedia = medialog.idMedia " +
                                                                        " inner join library " +
                                                                        " on library.idLibrary = media.idLibrary " +
                                                                        " where startTime BETWEEN '" + prevStartMonth + " 00:00:00' and '" + prevEndMonth + " 23:59:59';";
                    MySqlCommand command1 = new MySqlCommand(sqlqueryallmonth, conn1);
                    MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                    MyAdapter1.SelectCommand = command1;
                    System.Data.DataTable dTable1 = new System.Data.DataTable();
                    MyAdapter1.Fill(dTable1);
                    dataGridView2.DataSource = dTable1;

                    var sb1 = new StringBuilder();
                    var headers1 = dataGridView2.Columns.Cast<DataGridViewColumn>();
                    sb1.AppendLine(string.Join(",", headers1.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        var cells1 = row.Cells.Cast<DataGridViewCell>();
                        sb1.AppendLine(string.Join(",", cells1.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                    }
                    //prevStartMonth = prevStartMonth.Replace("-", "_");
                    //string prevStartMonthnotime = prevStartMonth.ToString();
                    //prevEndMonth = prevEndMonth.Replace("-", "_");

                    string pathfile2 = @"C:\EIBIZ\i-Media Report\" + txtFile.Text + "\\" + prevStartMonth + "_TO_" + prevEndMonth + ".csv";
                    File.WriteAllText(pathfile2, sb1.ToString(), Encoding.UTF8);
                }
                try
                {
                    conn1.Open();
                    string querybackup = "CREATE TABLE " + txtDB.Text + ".medialog_" + sDate.AddMonths(-1).ToString("yyyy_MM") + " LIKE " + txtDB.Text + ".medialog; INSERT " + txtDB.Text + ".medialog_" + sDate.AddMonths(-1).ToString("yyyy_MM") + " SELECT * FROM " + txtDB.Text + ".medialog;";
                    MySqlCommand command2 = new MySqlCommand(querybackup, conn1);
                    command2.ExecuteReader();
                    conn1.Close();
                    //sleep 5 sec
                    System.Threading.Thread.Sleep(5000);
                    conn1.Open();
                    string querydeletetable = "TRUNCATE table " + txtDB.Text + ".medialog;";
                    MySqlCommand command3 = new MySqlCommand(querydeletetable, conn1);
                    command3.ExecuteReader();
                    conn1.Close();
                }
                catch { }
            }


        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            btnsubmit.Enabled = false;
            label2.ForeColor = System.Drawing.Color.Red;
            label2.Text = "Please wait untill message change to ready";
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();

            // connect Database
            MySql.Data.MySqlClient.MySqlConnection conn2;
            string myConnectionString2;
            myConnectionString2 = "server=localhost;uid=root;" +
            "pwd=eibiz1234;database=" + txtDB.Text + ";default command timeout=1000000;";
            conn2 = new MySql.Data.MySqlClient.MySqlConnection();
            conn2.ConnectionString = myConnectionString2;

            string queryday = "call Getreportbyday('" + dtpicker1.Text + " 00:00:00', '" + dtpicker2.Text + " 23:59:59')";
            MySqlCommand command1 = new MySqlCommand(queryday, conn2);
            MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
            MyAdapter1.SelectCommand = command1;
            System.Data.DataTable dTable1 = new System.Data.DataTable();
            MyAdapter1.Fill(dTable1);
            dataGridView2.DataSource = dTable1;

            var sb1 = new StringBuilder();
            var headers1 = dataGridView2.Columns.Cast<DataGridViewColumn>();
            sb1.AppendLine(string.Join(",", headers1.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                var cells1 = row.Cells.Cast<DataGridViewCell>();
                sb1.AppendLine(string.Join(",", cells1.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            if (!Directory.Exists(@"C:\EIBIZ\i-Media Report\" + txtFile.Text))
                Directory.CreateDirectory(@"C:\EIBIZ\i-Media Report\" + txtFile.Text);

            string pathfile2 = @"C:\EIBIZ\i-Media Report\" + txtFile.Text + "\\" + dtpicker1.Text + "_TO_" + dtpicker2.Text + ".csv";
            File.WriteAllText(pathfile2, sb1.ToString(), Encoding.UTF8);

            btnsubmit.Enabled = true;
            label2.ForeColor = System.Drawing.Color.Green;
            label2.Text = "Ready";

            //Send mail
            var t = new Thread(() => SendToEmail("Export report complete please check in server"));
            t.Start();
        }

        class INIFile
        {

            private string filePath;

            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section,
            string key,
            string val,
            string filePath);

            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section,
            string key,

            string def,
            StringBuilder retVal,
            int size,
            string filePath);



            public INIFile(string filePath)
            {
                this.filePath = filePath;
            }

            public void Write(string section, string key, string value)
            {
                WritePrivateProfileString(section, key, value.ToLower(), this.filePath);
            }

            public string Read(string section, string key)
            {
                StringBuilder SB = new StringBuilder(255);
                int i = GetPrivateProfileString(section, key, "", SB, 255, this.filePath);
                return SB.ToString();
            }

            public string FilePath
            {
                get { return this.filePath; }
                set { this.filePath = value; }
            }
        }

        public void SendToEmail(string message)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("kanabut@eibiz.co.th", "");
                mailMessage.To.Add(new MailAddress("support@eibiz.co.th"));

                mailMessage.Subject = "Export Report " + txtFile.Text ;
                mailMessage.IsBodyHtml = false;
                mailMessage.Body = message;


                SmtpClient smtp = new SmtpClient("mail.eibiz.co.th", 25);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("kanabut@eibiz.co.th", "eibiz1234");
                smtp.Send(mailMessage);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //ReSend mail
                var t = new Thread(() => SendToEmail("Export report complete please check in server"));
                t.Start();
            }
        }

        private void chkMonth_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMonth.Checked == true)
            {
               MessageBox.Show("If you choose export report 1 month it might be to large data and effect to you server please click OK to continue", "Warnning"); 
            }
        }


        public static Version getNewestVersion()
        {
            try
            {
                var match = DownloadServerVersion();

                var gitVersion = new Version(match);

                return gitVersion;

            }
            catch (Exception)
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }


        public static string DownloadServerVersion()
        {
            using (var wC = new WebClient())
                return
                    wC.DownloadString(
                        "https://raw.githubusercontent.com/Ar1i/PokemonGo-Bot/master/ver.md");
        }
  
    }
}
