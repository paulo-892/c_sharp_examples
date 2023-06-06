using System;
using System.Collections.Generic;
using System.Linq;

using Xunit.Sdk;

public static class Dominoes
{
    private static bool recurCanChain(List<int> ends, List<(int, int)> remDominoes) 
    {
        // get left and right of current chain
        int left = ends[0];
        int right = ends[1];

        // if collection empty, all dominoes processed => return True if ends match
        if (remDominoes.Count == 0)
        {
            return left == right;
        }

        // for each remaining domino...
        foreach ((int, int) domino in remDominoes)
        {
            // get left and right of new domino
            int curLeft = domino.Item1;
            int curRight = domino.Item2;

            // create copies of two lists, and initialize result
            List<(int, int)> remDominoesCopy = new List<(int, int)>(remDominoes);
            List<int> endsCopy = new List<int>(ends);

            bool result = false;

            // if new domino's left is a match...
            if (curLeft == left || curLeft == right)
            {
                // remove domino from remaining set
                remDominoesCopy.Remove(domino);
                
                // update ends
                bool matchIsLeft = curLeft == left;
                if (matchIsLeft)
                {
                    endsCopy[0] = curRight;
                }
                else
                {
                    endsCopy[1] = curRight;
                }
                
                // recur
                if (recurCanChain(endsCopy, remDominoesCopy))
                {
                    result = true;
                }
            }
            
            // else if new domino's right is match...
            if (curRight == left || curRight == right)
            {
                // remove domino from remaining set
                remDominoesCopy.Remove(domino);
                
                // update ends
                bool matchIsLeft = curRight == left;
                if (matchIsLeft)
                {
                    endsCopy[0] = curLeft;
                }
                else
                {
                    endsCopy[1] = curLeft;
                }
                
                // recur
                if (recurCanChain(endsCopy, remDominoesCopy))
                {
                    result = true;
                }
            }
            
            // if chain found, return True
            if (result)
            {
                return true;
            }

        }
        
        // if no more dominoes to consider, branch does not work => return False
        return false;
    }
    
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        // converts enumerable to collection
        List<(int, int)> dominoesList = dominoes.ToList();
        
        // handles empty case
        if (dominoesList.Count == 0)
        {
            return true;
        }

        // get first domino
        (int, int) first = dominoesList.First();
        
        // initialize set of endpoints
        List<int> ends = new List<int> { first.Item1, first.Item2 };
        
        // remove first domino
        dominoesList.Remove(first);
        
        // recur
        return recurCanChain(ends, dominoesList);
    }
}