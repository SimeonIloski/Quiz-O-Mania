using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_
{
   public  class User
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
