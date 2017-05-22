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
    public partial class SuddenDeath : Form
    {
        public bool flag = false;
        public SuddenDeath()
        {
            Image myimage = new Bitmap(Image.FromFile("Pictures\\BG.png"));
            this.BackgroundImage = myimage;
            InitializeComponent();


        }
        public User user;
        public List<Question> listallquestions = new List<Question>();
        public int[] answers = new int[4];
        public int[] positions = new int[4];
        public int[] indexallQuestions = new int[20];
        int numQuestion = 1;
        int numHint = 0;
        int count = 0;
        int timeLeft = 10;
        int pbTimervalue = 1;
        int totalTimeLeft = 0;
        int first = 0;
        private void SuddenDeath_Load(object sender, EventArgs e)
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
            catch (Exception err)
            {

            }
            finally
            {
                connection.Close();
            }
            if (first == 0)
            {
                addQuestions();
                indexallQuestions=selectquestions(user);
                tbUser.Text = user.name;
                timer2.Start();
                timer1.Start();
                loadImage(indexallQuestions[0]);
                label4.Text ="Question " + numQuestion.ToString()+ ":";
                Question q = listallquestions[indexallQuestions[0]];
                gbQuestions.Text = q.text;
                answers = choseAnswer(indexallQuestions[0]);
                positions = Positions();
                rb1.Text = listallquestions.ElementAt(answers[positions[0]]).correctAnswer;
                rb2.Text = listallquestions.ElementAt(answers[positions[1]]).correctAnswer;
                rb3.Text = listallquestions.ElementAt(answers[positions[2]]).correctAnswer;
                rb4.Text = listallquestions.ElementAt(answers[positions[3]]).correctAnswer;
            }
            first++;
            }
       
        public void addQuestions()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=ILIEV-PC\\SQLEXPRESS;Initial Catalog=Questions;Integrated Security=True";
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Questions";
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listallquestions.Add(new Question(reader["Question"].ToString(), reader["Picture"].ToString(), reader["Category"].ToString(), reader["Answer"].ToString(), reader["Hint"].ToString()));
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
        /*odberi prasanja za korisnik*/
      int [] selectquestions(User user)
        {
            Random rand = new Random();
            bool[] picked = new bool[60]; //niza bool za site prasanja dali se izbrani ili ne
            int totalPicked = 0; //broj izbrani prasanja
            int[] pickedNum = new int[20]; //indeksi na prasanjata od lista
            while (totalPicked < 20)
            {
                int pick = rand.Next(0, 60);//pick e indeks na prasanje
                if (!picked[pick])
                { //ako prasanje ne e izborano ( == false)
                    picked[pick] = true; //go postavuvame na true
                    pickedNum[totalPicked] = pick; // 0to(1vo prasanje) ke e random od nizata na site prasanja
                    totalPicked++;
                }
            }
            return pickedNum;
        } 

        /* odberi 4 odgovori odd koi eden sigurno e tocen*/
        public int minBorder=0;
        public int maxBorder = 0;
        int[] choseAnswer(int n)
        {
            Random rand = new Random();
            bool[] picked = new bool[60];
            int totalPicked = 1; //deka edno e izbrano prethodno
            int[] pickedNum = new int[4]; //pozicija za rb
            picked[n] = true; //kazuvame deka izbranoto(n-to) prasanje e true(izbrano)
            pickedNum[0] = n; // na 0 pozicija sekogas e indeksot od postavenoto prasanje
            selectBorders(n);
            while (totalPicked < 4)
            {

                int pick = rand.Next(minBorder, maxBorder);
                if (!picked[pick])
                {
                    picked[pick] = true;
                    pickedNum[totalPicked] = pick;
                    totalPicked++;
                }
            }

            return pickedNum;
        }
        
        /*za pozicii na radiobuttons */
        int[] Positions()
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (count <= 20)
            {
                if (rb1.Checked)
                {
                    calculateScore(rb1.Text, indexallQuestions[count]);
                }
                else if (rb2.Checked)
                {
                    calculateScore(rb2.Text, indexallQuestions[count]);
                }
                else if (rb3.Checked)
                {
                    calculateScore(rb3.Text, indexallQuestions[count]);
                }
                else
                {
                    calculateScore(rb4.Text, indexallQuestions[count]);
                }
            }
            timer1.Stop();
            timeLeft = 10;
            pbTimervalue = 0;
            count++;
            int[] positions = new int[4];
            int[] answers = new int[4];
            if (numQuestion < 20)
            {
                clearelements();
                answers = choseAnswer(indexallQuestions[numQuestion]);
                positions = Positions();
                timer1.Start();
                loadImage(indexallQuestions[numQuestion]);
                Question q = listallquestions[indexallQuestions[numQuestion]];
                gbQuestions.Text = q.text;
                rb1.Text = listallquestions.ElementAt(answers[positions[0]]).correctAnswer;
                rb2.Text = listallquestions.ElementAt(answers[positions[1]]).correctAnswer;
                rb3.Text = listallquestions.ElementAt(answers[positions[2]]).correctAnswer;
                rb4.Text = listallquestions.ElementAt(answers[positions[3]]).correctAnswer;
                numQuestion++;
                label4.Text = string.Format("Question {0} :", numQuestion);



            }
            else {
                timer2.Stop();
                timer1.Stop();
                closeApp();
            }
        }
        void closeApp()
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
            catch (Exception err)
            {

            }
            finally
            {
                connection.Close();
            }
            string s = "Your points are " + user.score.ToString();
            if (MessageBox.Show(s, "Score", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                timer1.Stop();
                timer2.Stop();
                flag = true;
                Close();
            }
        }
        void clearelements()
        {
            gbQuestions.Text = "";
            rb1.Text = "";
            rb2.Text = "";
            rb3.Text = "";
            rb4.Text = "";
            lblPoints.Text = user.score.ToString();
        }
        void calculateScore(string answer, int count)
        {
            if (listallquestions.ElementAt(count).correctAnswer.Equals(answer))
            {
                user.score += 10+timeLeft;
                if (pbTotalTimeLeft.Value + timeLeft <= 15)
                {
                    if (pbTotalTimeLeft.Value + timeLeft >= 5)
                    {
                        pbTotalTimeLeft.Value = timeLeft + pbTotalTimeLeft.Value;
                    }
                    else
                    {
                        pbTotalTimeLeft.Value = 5;
                    }
                }
                else
                {
                    pbTotalTimeLeft.Value = 15;
                }              
                }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                timer2.Stop();
                timer2.Enabled = false;
                user.score /= 2;
                closeApp();
            }
            lblPoints.Text = user.score.ToString();
        }
        /*event za timerot*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!flag)
            {
                if (timeLeft > 0)
                {
                    pbTime.Value = pbTimervalue++;
                    timeLeft--;
                }
                else
                {
                    if (timeLeft == 0)
                    {
                        timer1.Stop();
                        timer1.Enabled = false;
                        timer2.Stop();
                        timer2.Enabled = false;
                        if (MessageBox.Show("You ran out of time...", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Stop) == DialogResult.OK)
                        {
                            if (numQuestion != 20)
                            {

                                user.score /= 2;
                                timeLeft = 0;
                                closeApp();

                            }
                        }
                    }
                }
            }
           
        }
        void loadImage(int i)
        {
            Image myimage = new Bitmap(@"Pictures\\"+listallquestions[i].picture);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.Image = myimage;
        }
        
        void loadQuestions()
        {
            clearelements();
            first = 0;
            int[] answers = new int[4];
            int[] positions = new int[4];
            if (first == 0)
            {
                addQuestions(); //gi imame site prasanja od bazata
              indexallQuestions=selectquestions(user); //za korisnik se polnat prasanja
                Question q = listallquestions[indexallQuestions[0]];
                gbQuestions.Text = q.text;
                loadImage(0);
                answers = choseAnswer(0); //biranje odgovori za rb
                positions = Positions();//pozicii za rb
                rb1.Text = listallquestions.ElementAt(indexallQuestions[answers[positions[0]]]).correctAnswer;
                rb2.Text = listallquestions.ElementAt(indexallQuestions[answers[positions[1]]]).correctAnswer;
                rb3.Text = listallquestions.ElementAt(indexallQuestions[answers[positions[2]]]).correctAnswer;
                rb4.Text = listallquestions.ElementAt(indexallQuestions[answers[positions[3]]]).correctAnswer;

                //Picture
                first++;

            }

        }

        private void btnRestart_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to restart?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                user.listQuestions.Clear();
                user.score = 0;
                numQuestion = 1;
                count = 0;
                timeLeft = 10;
                pbTimervalue = 0;
                totalTimeLeft = 0;
                first = 0;
                timer1.Stop();
                timer2.Stop();
                pbTotalTimeLeft.Value = 10;
                clearelements();
                SuddenDeath_Load(null, null);
            }
        }

        private void btnGiveUp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to give up? ", "Give up", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                timer1.Stop();
                timer1.Enabled = false;
                timer2.Stop();
                timer2.Enabled = false;
                closeApp();
            }
        }

        /* odbiranje na min i max za random za da se od ista kategorija */
        public void  selectBorders(int n)
        {
            if (listallquestions[n].category == "Music")
            {
                minBorder = 0;
                maxBorder = 15;
            }
            if (listallquestions[n].category == "Movies")
            {
                minBorder = 15;
                maxBorder = 30;
            }
            if (listallquestions[n].category == "Sport")
            {
                minBorder = 30;
                maxBorder = 45;
            }
            if (listallquestions[n].category == "CountryFlags")
            {
                minBorder = 45;
                maxBorder = 60;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!flag)
            {
                if (pbTotalTimeLeft.Value > 0)
                {
                    int t = pbTotalTimeLeft.Value;
                    t--;
                    pbTotalTimeLeft.Value = t;
                }
                else
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    timer2.Stop();
                    timer2.Enabled = false;
                    user.score /= 2;
                    closeApp();
                }
            }
        }
    }
   

} 
