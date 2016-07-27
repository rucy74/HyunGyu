using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication24
{
    public static class LinqExtentions
    {
        public static Random random = new Random();
        public static T GetRandom<T>(this IEnumerable<T> list)
        {            
            return list.ElementAt(random.Next(list.Count()));
        }

        public static void ForEach<TKey,TValue>(this IDictionary<TKey,TValue> dictionary, Action<TKey,TValue> func)
        {
            foreach(var entry in dictionary)
            {
                func(entry.Key, entry.Value);
            }
        }
    }
    class Program
    {       

        static void Main(string[] args)
        {           
            
            string AllText = File.ReadAllText(@"E:\[ S t u d y ]\대학자료\HyunGyu\과제4(TextGenerator)\ConsoleApplication24\aaa.txt");
            Dictionary<string, List<char>> dictionary = new Dictionary<string, List<char>>();

            Console.Write("Write a OrderNum : ");
            string OrderNum = Console.ReadLine();
            int orderNum = Convert.ToInt32(OrderNum);

            string tmpText;
            int j;

            for (int i = 0; i + orderNum < AllText.Length; i++) 
            {
                tmpText = "";
                j = i;
                for (; j < i + orderNum; j++)
                {
                    tmpText += AllText[j];
                }
                if (!dictionary.ContainsKey(tmpText))
                {
                    dictionary.Add(tmpText, new List<char>());
                    dictionary[tmpText].Add(AllText[j]);
                }
                else dictionary[tmpText].Add(AllText[j]);                              
            }

            Console.Write("Write a TextNum : ");
            string TextNum = Console.ReadLine();
            int textNum = Convert.ToInt32(TextNum);
            Console.WriteLine("");           
            
            StringBuilder str = new StringBuilder(dictionary.Keys.GetRandom());
            Console.Write(str.ToString());
            char tmp;           

            for (int i = 0; i + orderNum < textNum; i++)
            {
                tmp = dictionary[str.ToString()].GetRandom();
                Console.Write(tmp);
                str.Remove(0, 1);
                str.Append(tmp);                             
            }

        }
    }
}
