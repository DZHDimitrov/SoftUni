using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);
            int bulletsShotPerLoad = sizeOfGunBarrel;
            int totalBullets = 0;
            while (bulletsStack.Count > 0 && locksQueue.Count > 0)
            {

                var currentBullet = bulletsStack.Pop();
                if (currentBullet <= locksQueue.Peek())
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                bulletsShotPerLoad--;
                if (bulletsShotPerLoad == 0 && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsShotPerLoad = sizeOfGunBarrel;
                }
                totalBullets++;
            }
            if (bulletsStack.Count >= 0 && locksQueue.Count == 0)
            {
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${valueOfIntelligence - (totalBullets * priceOfBullet)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
        }
    }
}