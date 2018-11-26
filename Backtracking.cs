/**
Given a set of candidate numbers (candidates) (without duplicates) and a target number (target), find all unique combinations in candidates where the candidate numbers sums to target.

The same repeated number may be chosen from candidates unlimited number of times.

Note:

All numbers (including target) will be positive integers.
The solution set must not contain duplicate combinations.
Example 1:

Input: candidates = [2,3,6,7], target = 7,
A solution set is:
[
  [7],
  [2,2,3]
]
Example 2:

Input: candidates = [2,3,5], target = 8,
A solution set is:
[
  [2,2,2,2],
  [2,3,3],
  [3,5]
]



**/


public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        
        //used to store the solutions
        List<IList<int>> output = new List<IList<int>>();
        
        //We need to start a backtrack from every element of the provided
        //array of numbers, because they don't all necessarily feature in the solution
        //i.e. if we only started our backtracks from the first element, it assumes that the first element
        //must be in the solutions.
        for(int i = 0; i<candidates.Length;i++)
        {
            //start building a candidate, 
            //the candidate will contain only one number, the first one that we're starting with.
            List<int> candidate = new List<int>();
            candidate.Add(candidates[i]);
        
            //start backtracking the candidate, makes sure we don't repeat solutions by restricting the input number list
            //e.g. solution with elements 1,2,1 is the same as solution 2,1,1
            //for this reason once we have a backtrack going that includes the element 1, we don't want to start another one that 
            //could go back to that element
            backtrack(candidates,i, (IList<int>)candidate,   candidates[i], target, (IList<IList<int>>)output);
            
        }
        
        return (IList<IList<int>>)output;
        
    }
    
    
    private void backtrack(int[] candidateNumbers, int candidateNumbersStart, IList<int> candidate, int sum, int target, IList<IList<int>> output )
    {
        //should we reject?
        if(reject(sum, target))
            return;
        
        //should we accept?
        if(accept(sum,target))
        {
            //add to the output and stop - if we extend further it will just get rejected on the next step.
            output.Add(candidate);
            return;
        }
        
        //run a backtrack for each possible extension to the candidate from this point.
        for(int i = candidateNumbersStart; i<candidateNumbers.Length; i++)
        {
            int newSum = sum;
            IList<int> newCandidate = extendWith(candidate, ref newSum, candidateNumbers,i);
            backtrack(candidateNumbers, i, newCandidate, newSum, target, output);
        }
        
    }
    
    
    private bool reject(int sum, int target)
    {
        if(sum > target)
            return true;
        else 
            return false;
    }
    
    private bool accept(int sum, int target)
    {
        if(sum == target)
            return true;
        else
            return false;
    }
    
    private IList<int> extendWith(IList<int> candidate, ref int sum, int[] candidateNumbers, int index )
    {
        sum += candidateNumbers[index];
        List<int> extended = new List<int>();
        
        extended.AddRange(candidate);
        extended.Add(candidateNumbers[index]);
        
        return extended;
    }
    
    
}
