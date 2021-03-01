using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> itemList = new List<int>();
            Random rnd = new Random();

            for (int index = 0; index < 20; index++)
            {
                itemList.Add(rnd.Next(-1000, 1000));
            }

            Heap heap = new Heap(itemList);

            heap.Add(10);
            heap.Add(17);
            heap.Add(23);
            heap.Add(-5);
            heap.Add(99);
            heap.Add(18);
            heap.Add(5);

            Console.WriteLine("\nForeach:\n");

            foreach (var item in heap)
            {
                Console.WriteLine(item + " ");
            }

            Console.ReadLine();
        }
    }
}
