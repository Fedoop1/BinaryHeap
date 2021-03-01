using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    class Heap : IEnumerable
    {
        private List<int> items = new List<int>();
        public int count => items.Count();
        
        public int? Peek()
        {
            if(count > 0)
            {
                return items[0];
            }
            else
            {
                return null;
            }
        }

        public Heap() { }


        public Heap(List<int> list)
        {
            this.items.AddRange(list);

            for (int index = count; index >= 0; index--)
            {
                Sort(index);
            }
        }

        public void Add(int item)
        {
            items.Add(item);

            int current = count - 1;
            int parrent = GetParrent(current);

            while(current > 0 && items[parrent] < items[current])
            {
                Swap(current, parrent);
                current = parrent;
                parrent = GetParrent(current);
            }
        }

        public int GetMax()
        {
            int result = items[0];
            items[0] = items[count - 1];
            items.RemoveAt(count - 1);
            Sort(0);
            return result;
        }

        private static int GetParrent(int current)
        {
            return (current - 1) / 2;
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            int temp = items[currentIndex];
            items[currentIndex] = items[parentIndex];
            items[parentIndex] = temp;
        }

        private void Sort(int index)
        {
            
            int maxIndex = index;
            int leftIndex;
            int rightIndex;

            while (index < count)
            {
                leftIndex = 2 * index + 1;
                rightIndex = 2 * index + 2;

                if (leftIndex < count && items[leftIndex] > items[maxIndex])
                {
                    maxIndex = leftIndex;
                }

                if(rightIndex < count && items[rightIndex] > items[maxIndex])
                {
                    maxIndex = rightIndex;
                }

                if(maxIndex == index)
                {
                    break;
                }

                Swap(index, maxIndex);
                index = maxIndex;
            }
        }

        public IEnumerator GetEnumerator()
        {
            while(count > 0)
            {
                yield return GetMax();
            }
        }
    }
}
