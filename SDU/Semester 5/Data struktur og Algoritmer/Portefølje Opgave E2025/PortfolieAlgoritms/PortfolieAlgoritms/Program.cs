 
using System;
using System.Collections.Generic;

namespace PortfolieAlgoritms
{
    internal class Program
    {


        public static void Main(string[] args)
        {
            int[] votes = { 7, 5, 3, 5, 5, 5, 6, 5, 5, 5, 7, 5 };
            Dictionary<int, int> candidatesDic = new Dictionary<int, int>();

            foreach (var vote in votes)
            {
                if (candidatesDic.ContainsKey(vote))
                {
                    candidatesDic[vote]++;
                }
                else
                {
                    candidatesDic[vote] = 0;
                }
            }
            
            int winner = CheckVotes(candidatesDic, votes.Length);
            Console.WriteLine("The winner is candidate: " + winner);
        }
        public static int CheckVotes(Dictionary<int, int> candidates, int voteLength)
        {
            foreach (var candidate in candidates)
            {
                if(candidate.Value > voteLength / 2)
                {
                    return candidate.Key;
                }

            }
            return -1;
        }
    }
}