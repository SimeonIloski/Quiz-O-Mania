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
    public partial class HighScores : Form
    {
        public HighScores()
        {
            Image myimage = new Bitmap(Image.FromFile("Pictures\\BG.png"));
            this.BackgroundImage = myimage;
            int i = 0;
            InitializeComponent();
            cbMode.Items.Add("Normal");
            cbMode.Items.Add("Sudden Death");

        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Text = "";
            p2.Text = "";
            p3.Text = "";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=ILIEV-PC\\SQLEXPRESS;Initial Catalog=Questions;Integrated Security=True";
            SqlCommand command = new SqlCommand();
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Users WHERE Mode = @Category order by Score DESC";
            command.Parameters.AddWithValue("@Category", cbMode.Text);
            int i = 0;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (i > 2)
                    {
                        break;
                    }
                    else
                    {
                        p1.Text += reader["UserName"].ToString();
                        p2.Text += reader["Score"].ToString();
                        p3.Text += reader["Mode"].ToString();
                        p1.Text += "\n";
                        p2.Text += "\n";
                        p3.Text += "\n";
                    }
                    i++;

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
    }
}
