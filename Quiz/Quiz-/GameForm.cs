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
    public partial class GameForm : Form
    {

        public GameForm()
        {
            Image myimage = new Bitmap(Image.FromFile("Pictures\\BG.png"));
            this.BackgroundImage = myimage;
            InitializeComponent();
                  
                        
        }
        public int timeCounter = 10;
        int score = 0;
        int numQuestion = 1;/* this is for the nextquestion event*/
        int first = 0;
        int count = 0;
        int numHint = 0;/*this is for the hint button event*/
        String hint;
        public List<Question> listallQuestions = new List<Question>();
        public User user;
        private void GameForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=ILIEV-PC\\SQLEXPRESS;Initial Catalog=Questions;Integrated Security=True";
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM ActiveUser";
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string category = reader["Category"].ToString();
                    string userr = reader["UserName"].ToString();
                    string gamemode = reader["GameMode"].ToString();
                    user = new User(userr, category, gamemode);

                }

            }
            catch(Exception err)
            {

            }

            finally
            {
                connection.Close();
            }
            tbUserName.Text = user.name;
            toolStripProgressBar1.Value = 0;

            int[] answers = new int[4];
            int[] positions = new int[4];
            if (first == 0)
            {
                
                timer1.Start();
                addquestion();
                selectquestions(user);


                lblQuestion.Text = (user.listQuestions.ElementAt(0).text);
                hint=user.listQuestions.ElementAt(0).hint;
                //Picture
                loadImage(0);
                answers =choseAnswer(0);
                positions = Positions();
                rb1.Text = user.listQuestions.ElementAt(answers[positions[0]]).correctAnswer;
                rb2.Text = user.listQuestions.ElementAt(answers[positions[1]]).correctAnswer;
                rb3.Text = user.listQuestions.ElementAt(answers[positions[2]]).correctAnswer;
                rb4.Text = user.listQuestions.ElementAt(answers[positions[3]]).correctAnswer;
                first++;
          }
        
        }
        
        
        /*method for the first question on loading the form or restart*/
        void loadQuestions()
        {
            clearelements();
            first = 0;
            int[] answers = new int[4];
            int[] positions = new int[4];
            if (first == 0)
            {
                toolStripProgressBar1.Value = numQuestion;
                addquestion(); //gi imame site prasanja od bazata
                selectquestions(user); //za korisnik se polnat prasanja
                timer1.Start();
                lblQuestion.Text = (user.listQuestions.ElementAt(0).text);
                hint = user.listQuestions.ElementAt(0).hint;
                //Picture
                loadImage(0);
                answers = choseAnswer(0); //biranje odgovori za rb
                positions = Positions();//pozicii za rb
                rb1.Text = user.listQuestions.ElementAt(answers[positions[0]]).correctAnswer;
                rb2.Text = user.listQuestions.ElementAt(answers[positions[1]]).correctAnswer;
                rb3.Text = user.listQuestions.ElementAt(answers[positions[2]]).correctAnswer;
                rb4.Text = user.listQuestions.ElementAt(answers[positions[3]]).correctAnswer;
                first++;

            }
           
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna restart?", "Restart???", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                user.score = 0;
                user.listQuestions.Clear();
                loadQuestions();
                numQuestion = 1;
                numHint = 0;
                count = 0;
                timer1.Stop();
                timeCounter = 10;
                tbScore.Text = user.score.ToString();
                tbTimeLeft.Text = 0.ToString();
                loadQuestions();
                toolStripProgressBar1.Value = 0;
            }
        }

        /*this method is for reading questions from database*/
        public void addquestion()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=ILIEV-PC\\SQLEXPRESS;Initial Catalog=Questions;Integrated Security=True";
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Questions WHERE Category = @Category";
            command.Parameters.AddWithValue("@Category", user.category);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    listallQuestions.Add(new Question(reader["Question"].ToString(),reader["Picture"].ToString(), reader["Category"].ToString(), reader["Answer"].ToString(), reader["Hint"].ToString()));
                }
                reader.Close();
            }
            catch(Exception err)
            {

            }
            finally
            {
                connection.Close();
            }


        }
        /*this method we should use for selecting the 10 questions for the user*/
        public void selectquestions(User user)
        {
            Random rand = new Random();
            bool[] picked = new bool[15]; //niza bool za site prasanja dali se izbrani ili ne
            int totalPicked = 0; //broj izbrani prasanja
            int[] pickedNum = new int[10]; //indeksi na prasanjata od lista
            while (totalPicked < 10)
            {
                int pick = rand.Next(0, 15);//pick e indeks na prasanje
                if (!picked[pick]) { //ako prasanje ne e izborano ( == false)
                    picked[pick] = true; //go postavuvame na true
                    pickedNum[totalPicked] = pick; // 0to(1vo prasanje) ke e random od nizata na site prasanja
                    totalPicked++; 
                }
            }
            for(int i = 0; i < 10; i++)
            {
                //napolni lista prasanja NA KORISNIK
                user.AddQuestion(listallQuestions.ElementAt(pickedNum[i]));
                
            }
        }

        /*end of the metod for selecting questions*/
       
        /* chose the four answers*/
       int []  choseAnswer(int n)
        {
            Random rand = new Random();
            bool[] picked = new bool[10];
            int totalPicked = 1; //deka edno e izbrano prethodno
            int[] pickedNum = new int[4]; //pozicija za rb
            picked[n] = true; //kazuvame deka izbranoto(n-to) prasanje e true(izbrano)
            pickedNum[0] = n; // na 0 pozicija sekogas e indeksot od postavenoto prasanje
            while (totalPicked < 4)
            {
                int pick = rand.Next(0, 10);
                if (!picked[pick])
                {
                    picked[pick] = true;
                    pickedNum[totalPicked] = pick;
                    totalPicked++;
                }
            }
            
            return pickedNum;
        }
        /*method for position of radiobuttons*/
        int [] Positions()
        {
            //razmesuvanje na prasanjata za da pozicionirame random odgovori
            Random rand = new Random();
            bool[] picked = new bool[4];
            int totalPicked = 0;
            int[] pickedNum = new int[4];
            while (totalPicked < 4)
            {
                int pick = rand.Next(0, 4);
                if (!picked[pick])
                {
                    picked[pick] = true;
                    pickedNum[totalPicked] = pick;
                    totalPicked++;
                }
            }
            return pickedNum;
        }
        /*the next button event*/
        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (count <= 10)
            {
                if (rb1.Checked)
                {
                    calculateScore(rb1.Text, count);
                }
                else if (rb2.Checked)
                {
                    calculateScore(rb2.Text, count);
                }
                else if (rb3.Checked)
                {
                    calculateScore(rb3.Text, count);
                }
                else
                {
                    calculateScore(rb4.Text, count);
              } }
                         
            count++;
            int[]positions = new int[4];
            int[] answers = new int[4];
            toolStripProgressBar1.Value = numQuestion;            
            if (numQuestion < 10)
            {
                           
                clearelements();
                answers = choseAnswer(numQuestion);
                positions = Positions();
               ++numHint;
                lblQuestion.Text = user.listQuestions.ElementAt(numQuestion).text;
                //Picture
                loadImage(numQuestion);
                timeCounter = 10;
                rb1.Text = user.listQuestions.ElementAt(answers[positions[0]]).correctAnswer;
                rb2.Text = user.listQuestions.ElementAt(answers[positions[1]]).correctAnswer;
                rb3.Text = user.listQuestions.ElementAt(answers[positions[2]]).correctAnswer;
                rb4.Text = user.listQuestions.ElementAt(answers[positions[3]]).correctAnswer;
                numQuestion++;

            }
            else
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=ILIEV-PC\\SQLEXPRESS;Initial Catalog=Questions;Integrated Security=True";
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert into Users(UserName,Score,Mode) values(@Username,@Score,@Mode)";
                command.Parameters.AddWithValue("@Username", user.name);
                command.Parameters.AddWithValue("@Score", user.score);
                command.Parameters.AddWithValue("@Mode", user.gameMode);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(Exception err)
                {

                }
                finally
                {
                    connection.Close();
                }
                string s = "Your points are " + user.score.ToString();
                    MessageBox.Show(s, "Score", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
            }                   
        }
        void calculateScore(string answer, int count)
        {
            if (user.listQuestions.ElementAt(count).correctAnswer.Equals(answer))
            {
                user.score += 10 + timeCounter;
            }
            else
            {
               
                    user.score -= 5;
                }             
            tbScore.Text = user.score.ToString();
        }

        /*clear the data in elements on the form*/
        void clearelements()
        {
            rb1.Text = "";
            rb1.Text = "";
            rb1.Text = "";
            rb1.Text = "";
            lblQuestion.Text = "";
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(user.listQuestions.ElementAt(numHint).hint, "Hint:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void loadImage(int i)
        {
            Image myimage = new Bitmap(@"Pictures\\" + user.listQuestions[i].picture);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.Image = myimage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timerPrint(timeCounter);
            timeCounter--;
        }
        void timerPrint(int b)
        {
            if (b > 0)
            {
                tbTimeLeft.Text = b.ToString();

            }
            else
            {
                timer1.Stop();
                if (MessageBox.Show("Time ran out", "Oops...", MessageBoxButtons.OK) == DialogResult.OK)
                {

                    btnNext_Click(null, null);
                    timeCounter = 10;
                }
            }
        }

        private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e)
        {
            toolStripStatusLabel1.Text = "Progress:";
        }
    }
}
