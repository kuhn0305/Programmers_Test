#define 다리를지나는트럭

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersTest
{
    class StackQueue
    {


#if 프린터
        struct Item
        {
            public int location;
            public int priority;
        }

        public static int solution(int[] priorities, int location)
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
#endif

#if 다리를지나는트럭

        class Truck
        {
            public int weight;
            public int count;

            public Truck(int w, int c)
            {
                weight = w;
                count = c;
            }
        }

        public static int solution(int bridge_length, int weight, int[] truck_weights)
        {
            int answer = 0;

            Queue<int> truckQueue = new Queue<int>(truck_weights);
            List<Truck> bridgeTruckList = new List<Truck>();
            Truck currentTruck;

            int totalWeight = 0;
            int tempWeight = 0;

            while(truckQueue.Count > 0 || bridgeTruckList.Count >0)
            {
                answer++;

                for(int index = bridgeTruckList.Count - 1; index >= 0; --index)
                {
                    currentTruck = bridgeTruckList[index];
                    currentTruck.count++;

                    if(currentTruck.count >= bridge_length)
                    {
                        totalWeight -= currentTruck.weight;
                        bridgeTruckList.RemoveAt(index);
                    }
                }

                if(bridgeTruckList.Count < bridge_length && truckQueue.Count > 0)
                {
                    tempWeight = truckQueue.Peek();

                    if(totalWeight + tempWeight <= weight)
                    {
                        totalWeight += truckQueue.Dequeue();

                        Truck newTruck = new Truck(tempWeight, 0);

                        bridgeTruckList.Add(newTruck);
                    }
                }
            }

            Console.WriteLine(answer);

            return answer;
        }

#endif

    }
}
