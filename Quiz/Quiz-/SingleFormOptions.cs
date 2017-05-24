using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_
{
    public partial class SingleFormOptions : Form
    {
        public SingleFormOptions()
        {
            Image myimage = new Bitmap(Image.FromFile("Pictures\\BG.png"));
            this.BackgroundImage = myimage;
            InitializeComponent();
            cbGameMode.Items.Add("Normal");
            cbGameMode.Items.Add("Sudden Death");
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=ILIEV-PC\\SQLEXPRESS;Initial Catalog=Questions;Integrated Security=True";
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT Distinct Category from Questions";
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbCategory.Items.Add(reader["Category"].ToString());
                }
                reader.Close();
            }
            catch (Exception err)
            {

            }
            finally
            {
                connection.Close();
            }
            
        }
        public List<Question> listallQuestions = new List<Question>();
        public   User user { get; set; }
        public Game game { get; set; }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) {
                //Insert the Active User into the Database
                if (cbGameMode.Text == "Normal")
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = "Data Source=ILIEV-PC\\SQLEXPRESS;Initial Catalog=Questions;Integrated Security=True";
                    SqlCommand insert = new SqlCommand();
                    insert.Connection = connection;
                    insert.CommandText = "Update ActiveUser set UserName = @UN, GameMode=@GM, Category=@C";

                    insert.Parameters.AddWithValue("@UN", tbUser.Text);
                    insert.Parameters.AddWithValue("@GM", cbGameMode.Text);
                    insert.Parameters.AddWithValue("@C", cbCategory.Text);
                    try
                    {
                        connection.Open();
                        insert.ExecuteNonQuery();

                    }
                    catch (Exception err)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }
                    GameForm gf = new GameForm();
                    gf.Show();
                }
                else
                {
                    if (cbGameMode.Text == "Sudden Death")
                    {
                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = "Data Source=ILIEV-PC\\SQLEXPRESS;Initial Catalog=Questions;Integrated Security=True";
                        SqlCommand insert = new SqlCommand();
                        insert.Connection = connection;
                        insert.CommandText = "Update ActiveUser set UserName = @UN, GameMode=@GM, Category=@C";
                        insert.Parameters.AddWithValue("@UN", tbUser.Text);
                        insert.Parameters.AddWithValue("@GM", cbGameMode.Text);
                        insert.Parameters.AddWithValue("@C", cbCategory.Text);
                        try
                        {
                            connection.Open();
                            insert.ExecuteNonQuery();
                        }
                        catch (Exception err)
                        {

                        }
                        finally
                        {
                            connection.Close();
                        }
                        SuddenDeath sd = new SuddenDeath();
                        sd.Show();
                    }
                }
        }

        }

        private void tbUser_Validating(object sender, CancelEventArgs e)
        {
            if (tbUser.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUser, "Insert User Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUser, "");
            }
        }

        private void cbCategory_Validating(object sender, CancelEventArgs e)
        {
            if (cbCategory.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbCategory, "Select Category");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbCategory, "");
            }
        }

        private void cbGameMode_Validating(object sender, CancelEventArgs e)
        {
            if (cbGameMode.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbGameMode, "Select Game Mode");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbGameMode, "");
            }
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            HighScores hs = new HighScores();
            hs.ShowDialog();
        }

        private void btnHow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You must guess the answer based on the picture. Normal Mode: For every correct answer you get +10 points + the remaining seconds. For every wrong answer you get -5 points. Total of 10 questions are selected from the category and total of 10 seconds per question. For the Sudden Death mode you have 20 questions of all categories.You must choose a correct answer or game over.You have 10 seconds per question (maybe more maybe less, but not less than 5) and a total of 10 seconds. Every correct answer increases your score by 10 points + the timeleft for that question. Also it increases the total time left to a maximum of 15 seconds. If you do not know the answer you can give up to save you current points.Every wrong answer causes game over and also cuts your points in half. Though isn't it??","How to play", MessageBoxButtons.OK);
        }

        private void cbGameMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cbGameMode.SelectedItem as string;
            if (s == "Normal")
            {
                cbCategory.Enabled = true;
            }
            else
            {
                cbCategory.Enabled = false;
            }
        }
    }
}

