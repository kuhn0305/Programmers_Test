using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersTest
{
    class StackQueue
    {

        struct Item
        {
            public int location;
            public int priority;
        }

        public static int Printer(int[] priorities, int location)
        {
            int answer = 0;

            Queue<Item> itemQueue = new Queue<Item>();

            for(int index = 0; index < priorities.Length; index++)
            {
                Item item = new Item();
                item.location = index;
                item.priority = priorities[index];

                itemQueue.Enqueue(item);
            }

            int maxValue = 0;
            Item currentItem;

            while(itemQueue.Count > 0)
            {
                maxValue = itemQueue.ToArray().Max(x => x.priority);
                currentItem = itemQueue.Dequeue();

                if(currentItem.priority >= maxValue)
                {
                    answer++;

                    if(currentItem.location == location)
                        break;
                }
                else
                {
                    itemQueue.Enqueue(currentItem);
                }
            }

            return answer;
        }
    }
}
