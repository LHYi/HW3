using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChooseLevel
    {
        private static int Level
            {get; set;}
        public ChooseLevel()
        {
            Level = 1;
        }
        public void Set(int val)
        {
            ChooseLevel.Level = val;
        }
        public int Get()
        {
            return ChooseLevel.Level;
        }
    }
}
