using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssignment
{
    public class Result
    {
        public char Character { get; set; }
        public int Count { get; set; }

        public Result(char character, int count)
        {
            Character = character;
            Count = count;
        }


    }
}
