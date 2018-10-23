using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4InaRow
{
    class Player
    {
        public string _number { get; set; }
        public char _piece { get; set; }

        public Player(string number, char piece)
        {
            _number = number;
            _piece = piece;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_number + "'s turn:");
            return sb.ToString();
        }
    }
}
