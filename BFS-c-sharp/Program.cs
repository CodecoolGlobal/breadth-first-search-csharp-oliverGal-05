using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            int size = users.Count;
            Random rng = new Random();

            UserNode random1 = users[rng.Next(0, size)];
            UserNode random2 = users[rng.Next(0, size)];

            while (random2.Equals(random1)) {
                random2 = users[rng.Next(0, size)];
            }

            Console.WriteLine($"The distance is {BFS.GetDistance(random1, random2)} from {random1} to {random2}");

            BFS.GetAllFriends(random1, 4);

            Console.ReadKey();
        }
    }
}
