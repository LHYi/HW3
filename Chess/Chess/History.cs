using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class History
    {
        public static void Save(string gameResult)
        {
            FileStream fs = new FileStream("C:\\Users\\Public\\GameResults.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(gameResult);
            sw.Close();
            fs.Close();
        }

        public static string  Load()
        {
            return File.ReadAllText("C:\\Users\\Public\\GameResults.txt");
        }
    }
}
