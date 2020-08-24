using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp
{
    class BFS
    {

        public static int GetDistance(UserNode from, UserNode to) {

            Queue<UserNode> nextToVisit = new Queue<UserNode>();
            Dictionary<UserNode, int> visited = new Dictionary<UserNode, int>();
            nextToVisit.Enqueue(from);
            int depth = 0;
            visited.Add(from, depth);

            while (nextToVisit.Count != 0)
            {
                UserNode currentUser = nextToVisit.Dequeue();

                foreach (UserNode friend in currentUser.Friends)
                {
                    if (!visited.ContainsKey(friend))
                    {
                        visited.TryGetValue(currentUser, out depth);
                        visited.Add(friend, depth + 1);
                        nextToVisit.Enqueue(friend);
                    }
                    if (to.Equals(friend))
                    {
                        visited.TryGetValue(friend, out depth);
                        return depth;
                    }
                }
            }
            return depth;
        }


        public static void GetAllFriends(UserNode person, int depth) {

            Queue<UserNode> nextToVisit = new Queue<UserNode>();
            Dictionary<UserNode, int> visited = new Dictionary<UserNode, int>();
            List<UserNode> friends = new List<UserNode>();
            nextToVisit.Enqueue(person);
            int dist = 0;
            visited.Add(person, dist);

            while (nextToVisit.Count != 0 && dist <= depth)
            {
                UserNode currentUser = nextToVisit.Dequeue();

                foreach (UserNode friend in currentUser.Friends)
                {
                    if (!visited.ContainsKey(friend))
                    {
                        visited.TryGetValue(currentUser, out dist);
                        visited.Add(friend, dist + 1);
                        nextToVisit.Enqueue(friend);
                    }
                    else 
                    {
                        visited.TryGetValue(friend, out dist);
                        if (!friends.Contains(friend)) {
                            friends.Add(friend);
                        }
                    }
                }
            }
            friends.Remove(person);
            Console.WriteLine();
            Console.WriteLine($"Friends of {person} in distance {depth} are: ");
            foreach (UserNode friend in friends) {
                Console.WriteLine(" - " + friend);
            }
        }
    }
}
