using System;
using ShopApp.Main;

namespace StyleCop.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var firstList = new MyList<int>();

            firstList.Add(1);
            firstList.Add(2);
            firstList.AddRange(new int[] { 3, 4, 5 });
            firstList.Remove(5);
            firstList.RemoveAt(1);
            for (var i = 0; i < firstList.Count; i++)
            {
                Console.Write($"{firstList[i]} ");
            }

            Console.WriteLine();

            var secondList = new MyList<string>();

            secondList.Add("a");
            secondList.Add("b");
            secondList.AddRange(new string[] { "c", "d", "e" });
            secondList.Remove("e");
            secondList.RemoveAt(1);
            for (var i = 0; i < secondList.Count; i++)
            {
                Console.Write($"{secondList[i]} ");
            }

            Console.WriteLine();
        }
    }
}
