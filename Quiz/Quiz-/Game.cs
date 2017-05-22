using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_
{
    public class Game
    {
        public User user { get; set;}
        public Game(User user)
        {
            this.user = user;
        }
    }
}
