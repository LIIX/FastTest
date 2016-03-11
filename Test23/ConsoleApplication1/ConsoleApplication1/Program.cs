using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("vvedite stroky, no tolko odny");
            string str = Console.ReadLine();
            var list = movingShift(str, 1);
            foreach (var elem in list)
                Console.WriteLine(elem);
            Console.WriteLine(demovingShift(list, 1));
            Console.WriteLine("ny kak ono?");
            Console.ReadKey();
        }

        public static List<string> movingShift(string s, int shift)
        {
            const string AlfabetU = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string AlfabetL = "abcdefghijklmnopqrstuvwxyz";
            string result = "";
            foreach(char ch in s)
            {
                int index = AlfabetU.IndexOf(ch);
                if (index > -1)
                {
                    int ind = (index + shift) % 26 >= 0 ? (index + shift) % 26 : (AlfabetU.Length - Math.Abs((index + shift) % 26));
                    result += AlfabetU[ind];
                }
                else
                {
                    index = AlfabetL.IndexOf(ch);
                    if (index > -1)
                    {
                        int ind = (index + shift) % 26 >= 0 ? (index + shift) % 26 : (AlfabetL.Length - Math.Abs((index + shift) % 26));
                        result += AlfabetL[ind];
                    }
                    else
                        result += ch;
                }
                if (shift > 0)
                    shift++;
                else
                    shift--;
            }
            int partLength = s.Length / 5 + 1;
            List<string> resultList = new List<string>();
            for(int i = 0; i < s.Length;)
            {
                if (i + partLength < s.Length)
                    resultList.Add(result.Substring(i, partLength));
                else
                    resultList.Add(result.Substring(i, s.Length - i));
                i += partLength;
            }
            if (resultList.Count < 5)
                resultList.Add("");

            return resultList;
        }

        public static string demovingShift(List<string> s, int shift)
        {
            string str = "";
            foreach(var st in s)
                str += st;
            var list = movingShift(str, 0 - shift);
            str = "";
            foreach (var st in list)
                str += st;
            return str;
        }
    }
}
