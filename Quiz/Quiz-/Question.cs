using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_
{
   public  class Question
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
