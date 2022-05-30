using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace praktikumw14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string sqlConnection = "server=139.255.11.84;uid=student;pwd=isbmantap;database=premier_league";
        public MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        string sqlQuery;
        int counter = 0;
        string temp = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnect.Open();
            sqlQuery = "SELECT `team_name`, CONCAT(manager_name , '(' , n.nation , ')') as Manager , CONCAT(home_stadium , ', ' , city , '(' , capacity , ')') as Stadium, (j.jumlah_goal + j.jumlah_goal_penalty) as Top_Scorer, concat(`player_name`,'. ',(j.jumlah_kartu_kuning),' Yellow Card and ',j.jumlah_kartu_merah,' Red Card') AS 'Worst Discipline' FROM team t, manager m, nationality n, dmatch d, dt_Jesslyn j WHERE t.manager_id = m.manager_id and t.team_id = d.team_id AND d.player_id = j.player_id and m.nationality_id = n.nationality_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlAdapter.Fill(dt);
            labelTeam.Text = dt.Rows[0][0].ToString();
            labelManager.Text = dt.Rows[0][1].ToString();
            labelStadium.Text = dt.Rows[0][2].ToString();
            labelTop.Text = dt.Rows[0][3].ToString();
            labelWorst.Text = dt.Rows[0][4].ToString();

            sqlQuery = "select match_date, date_format(m.match_date, \"%d/%c/%Y\") as `Match Date`, 'HOME' as `Home/Away`, concat('vs ', t.team_name) as `Lawan`, concat(m.goal_home, ' - ', m.goal_away) as `Score` from `match` m, team t where m.team_home = 'A001' and m.team_away = t.team_id union select match_date, date_format(m.match_date, \"%d/%c/%Y\") as `Match Date`, 'AWAY' as 'Home/Away', concat('vs ', t.team_name) as Lawan, concat(m.goal_home, ' - ', m.goal_away) as Score from `match` m, team t where m.team_away = 'A001' and m.team_home = t.team_id order by 1 desc limit 0, 5;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable lastMatch = new DataTable();
            sqlAdapter.Fill(lastMatch);
            dataGridView1.DataSource = lastMatch;
        }
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (counter <= 0)
            {
                MessageBox.Show("Ini Data Pertama");
            }
            else
            {
                counter--;
                sqlQuery = "SELECT `team_name`, CONCAT(manager_name , '(' , n.nation , ')') as Manager , CONCAT(home_stadium , ', ' , city , '(' , capacity , ')') as Stadium, (j.jumlah_goal + j.jumlah_goal_penalty) as Top_Scorer, concat(`player_name`,'. ',(j.jumlah_kartu_kuning),' Yellow Card and ',j.jumlah_kartu_merah,' Red Card') AS 'Worst Discipline' FROM team t, manager m, nationality n, dmatch d, dt_Jesslyn j WHERE t.manager_id = m.manager_id and t.team_id = d.team_id AND d.player_id = j.player_id and m.nationality_id = n.nationality_id";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                DataTable Prev = new DataTable();
                sqlAdapter.Fill(Prev);
                labelTeam.Text = Prev.Rows[counter][0].ToString();
                labelManager.Text = Prev.Rows[counter][1].ToString();
                labelStadium.Text = Prev.Rows[counter][2].ToString();
                labelTop.Text = Prev.Rows[counter][3].ToString();
                labelWorst.Text = Prev.Rows[counter][4].ToString();
            }
        }

        private void buttonDPrev_Click(object sender, EventArgs e)
        {
            counter = 0;
            sqlQuery = "SELECT `team_name`, CONCAT(manager_name , '(' , n.nation , ')') as Manager , CONCAT(home_stadium , ', ' , city , '(' , capacity , ')') as Stadium, (j.jumlah_goal + j.jumlah_goal_penalty) as Top_Scorer, concat(`player_name`,'. ',(j.jumlah_kartu_kuning),' Yellow Card and ',j.jumlah_kartu_merah,' Red Card') AS 'Worst Discipline' FROM team t, manager m, nationality n, dmatch d, dt_Jesslyn j WHERE t.manager_id = m.manager_id and t.team_id = d.team_id AND d.player_id = j.player_id and m.nationality_id = n.nationality_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable DPrev = new DataTable();
            sqlAdapter.Fill(DPrev);
            labelTeam.Text = DPrev.Rows[counter][0].ToString();
            labelManager.Text = DPrev.Rows[counter][1].ToString();
            labelStadium.Text = DPrev.Rows[counter][2].ToString();
            labelTop.Text = DPrev.Rows[counter][3].ToString();
            labelWorst.Text = DPrev.Rows[counter][4].ToString();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (counter >= 19)
            {
                MessageBox.Show("Ini Data Terakhir");
            }
            else
                counter++;
            sqlQuery = "SELECT `team_name`, CONCAT(manager_name , '(' , n.nation , ')') as Manager , CONCAT(home_stadium , ', ' , city , '(' , capacity , ')') as Stadium, (j.jumlah_goal + j.jumlah_goal_penalty) as Top_Scorer, concat(`player_name`,'. ',(j.jumlah_kartu_kuning),' Yellow Card and ',j.jumlah_kartu_merah,' Red Card') AS 'Worst Discipline' FROM team t, manager m, nationality n, dmatch d, dt_Jesslyn j WHERE t.manager_id = m.manager_id and t.team_id = d.team_id AND d.player_id = j.player_id and m.nationality_id = n.nationality_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable Next = new DataTable();
            sqlAdapter.Fill(Next);
            labelTeam.Text = Next.Rows[counter][0].ToString();
            labelManager.Text = Next.Rows[counter][1].ToString();
            labelStadium.Text = Next.Rows[counter][2].ToString();
            labelTop.Text = Next.Rows[counter][3].ToString();
            labelWorst.Text = Next.Rows[counter][4].ToString();
        }

        private void buttonDNext_Click(object sender, EventArgs e)
        {
            counter = 19;
            sqlQuery = "SELECT `team_name`, CONCAT(manager_name , '(' , n.nation , ')') as Manager , CONCAT(home_stadium , ', ' , city , '(' , capacity , ')') as Stadium, (j.jumlah_goal + j.jumlah_goal_penalty) as Top_Scorer, concat(`player_name`,'. ',(j.jumlah_kartu_kuning),' Yellow Card and ',j.jumlah_kartu_merah,' Red Card') AS 'Worst Discipline' FROM team t, manager m, nationality n, dmatch d, dt_Jesslyn j WHERE t.manager_id = m.manager_id and t.team_id = d.team_id AND d.player_id = j.player_id and m.nationality_id = n.nationality_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            DataTable Next = new DataTable();
            sqlAdapter.Fill(Next);
            labelTeam.Text = Next.Rows[counter][0].ToString();
            labelManager.Text = Next.Rows[counter][1].ToString();
            labelStadium.Text = Next.Rows[counter][2].ToString();
            labelTop.Text = Next.Rows[counter][3].ToString();
            labelWorst.Text = Next.Rows[counter][4].ToString();
        }
    }
}
