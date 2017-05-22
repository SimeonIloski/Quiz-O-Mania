# Quiz-O-Mania
Проект по Визуелно програмирање 2017 година

1) Опис на апликацијата

Апликацијата претставува игра на знаење. Потребно е да се даде точен одговор на поставени прашања со помош на слика. Целта е да се тестира знаењето на играчот во повеќе категории од секојдневниот живот. На слика 1 е прикажано почетното мени каде играчот избира дали да започне игра или да излезе од играта, а во формата од слика 2, корисникот внесува username, селектира game mode и категорија (Music, Movies, Country flags, Sport). Во истата форма, со клик на копчето How to play, на корисникот му се нуди помош и правилата на играта, додека со клик на копчето High scores, корисникот избира соодветен game mode од drop-down менито и во зависност од избраното му се прикажуваат првите три играчи со најдобар резултат. (слика 3)
https://github.com/DimitarIliev/Quiz-O-Mania/blob/master/slika1.png
https://github.com/DimitarIliev/Quiz-O-Mania/blob/master/slika2.jpg
https://github.com/DimitarIliev/Quiz-O-Mania/blob/master/slika3.jpg


2) Упатство за користење

2.1) Категории
Прашањата се поделени во категории(Movies, Music, Sport, Country flags). Секоја категорија е прочитана од самата база на податоци и понудена за избор.

2.2) Модови на игра
Играта има два вида на Game Modes: Normal и Sudden Death.
 Normal Mode: На играчот му се поставуваат 10 прашања случајно избрани од базата со прашања, соодветно од неговата избрана категорија. Понудени се 4 можни одговори од кои само еден е точен. За секој точен одговор се добиваат 10 поени. Ако играчот го одговори прашањето побрзо од 10 секунди, преостанатите секунди се додаваат како освоени поени. За секој неточен одговор се добиваат 5 негативни поени. Може да се побара помош преку копчето Hint, со што се појавува одредена асоцијација за можниот одговор на прашањето. Доколку корисникот кликне Restart, играта се почнува од почеток.
*Мора да се даде одговор на секое прашање.
Sudden Death: На играчот му се поставуаат 20 прашања случајно избрани од базата на податоци од секоја постоечка категорија. При избор на оваа опција, играчот нема право да избира категорија. Дадено е време за кое треба да се одговори прашањето и време за целокупната игра. За секое прашање има 10 секунди за одговарање на истото, но постои timer кој го мери вкупното време на играта, кое може да биде најмногу 15 секунди, а најмалку 5. Времето за кое се зголемува вкупното време на играта е преостанатото (неискористено) време од прашањето кое се одговарало. Доколку времето за целокупната игра истече, играчот не може да продолжи со одговарање на прашањата. За секој точен одговор се добиваат 10 поени. За еден неточен одговор играта завршува и поените кои ги добива се половина од освоените. Доколку корисникот реши да се откаже, му се доделуваат поените кои ги има освоено.
Ако корисникот кликне Restart, играта се почнува од почеток.
*Мора да се даде одговор на секое прашање.
Game mode: Sudden death
https://github.com/DimitarIliev/Quiz-O-Mania/blob/master/slika5.jpg

Game mode: Normal
https://github.com/DimitarIliev/Quiz-O-Mania/blob/master/slika6.jpg
3) Претставување на проблемот

Имаме две основни класи со кои манипулираме во целата апликација.
Прва е класта Question во која се чуваат текстот (прашањето), слика, категорија, hint и точен одговор. За бирање на прашањата за корисникот, како и понудените одговори, користиме функции кои се базирани на случаен избор.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Quiz_
{
  public class Question
  {
    public string text { get; set; }
    public string picture { get; set; }
    public string category { get; set; }
    public string correctAnswer { get; set; }
    public string hint { get; set; }
    public Question(string text, string picture, string category, string answer, string hint)
    {
    this.category = category;
    this.correctAnswer = answer;
    this.hint = hint;
    this.picture = picture;
    this.text = text;
    }
    public override string ToString()
    {
    return string.Format("{0} ?", text);
    }
  }
}

Втора е класата User во која се чуваат username, gameMode, category, score и листа од прашања за корисникот.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Quiz_
{
  public class User
  {
    public string name{get;set;}
    public string category { get; set; }
    public string gameMode { get; set; }
    public int score { get; set; }
    public List<Question> listQuestions = null;
    public User(string user,string category, string gameMode)
    {
      this.category = category;
      this.name = user;
      this.score = 0;
      this.gameMode = gameMode;
      listQuestions = new List<Question>();
     }
    public override string ToString()
    { 
      return string.Format("{0} -{1}", name, score);
    }
    public void AddQuestion(Question q)
    {
      listQuestions.Add(q);
    } 
  }
}

4) База на податоци

За чување на корисници, прашања и активен корисник искористивме едноставна база на податоци. Таа се состои од 3 табели. Базата која е користена е MSSQL. Базата се користи за читање на податоци (прашања,корисници,категории) од неа, како и запишување податоци во неа (корисници,поени). Начинот на кој се прави тоа е прикажан подолу:

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
  listallQuestions.Add(new Question(reader["Question"].ToString(),reader["Picture"].ToString(), reader["Category"].ToString(),  reader["Answer"].ToString(), reader["Hint"].ToString()));
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

Направено од: Димитар Илиев 141059, Ана Гоцевска 141139, Симеон Илоски 141138
