using System.Collections;

/*
Given an integer array nums, return true if any value appears at 
least twice in the array, and return false if every element is distinct.
*/

public class Solution {
    // This solution is extremely slow
    public bool ContainsDuplicate(int[] nums)
    {
        var mapped = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (mapped.Contains(nums[i]))
            {
                return true;
            }
            
            mapped.Add(nums[i]);
        }

        return false;
    }
    
    // This is better than the above solution but using HashTable is unideal
    public bool ContainsDuplicate2(int[] nums) {
        var hashTable = new Hashtable();
        foreach (var num in nums)
        {
            if (hashTable.Contains(num))
            {
                return true;
            }
            hashTable.Add(num, num);
        }

        return false;
    }
    
    // This is the best approach in comparison of the other approaches above
    public bool ContainsDuplicate3(int[] nums) {
        var hashTable = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            if (hashTable.ContainsKey(n))
            {
                return true;
            }
            hashTable.Add(n, n);
        }

        return false;
    }

    
    // Better than the dictionary approach in conciseness 
    // This solution is O(n) in both time and space complexity
    public bool ContainsDuplicate4(int[] nums) {
        HashSet<int> hash = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            if (hash.Contains(n))
            {
                return true;
            }

            hash.Add(n);
        }

        return false;
    }
    
    // This is the best solution hands down but is equivalent to the HashSet approach
    // This solution is O(n) in both time and space complexity
    public bool ContainsDuplicate5(int[] nums) {
        return nums.Distinct().Count() != nums.Length;
    }
    
}