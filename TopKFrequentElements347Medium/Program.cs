using System.Collections;
using System.Runtime.InteropServices;

namespace TopKFrequentElements347Medium;

public class Solution {
    
    // Extremely slow implementation. Better approach is absolutely out there.
    public static int[] TopKFrequent(ReadOnlySpan<int> nums, int k)
    {
        var hash = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (hash.ContainsKey(nums[i]))
            {
                hash[nums[i]]++;
            }
            else
            {
                hash.Add(nums[i], 1);
            }
        }

        var output = new int[k];
        for (int i = 0; i < k; i++)
        {
            var maxValueKey = hash.MaxBy(x => x.Value).Key;
            output[i] = maxValueKey;
            hash.Remove(maxValueKey);
        }
        
        return output;
    }
    
    // TODO: Return to this at a later date to properly implement this
    /*// Extremely slow implementation. Better approach is absolutely out there.
    public static int[] TopKFrequent2(ReadOnlySpan<int> nums, int k)
    {
        var hash = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (hash.ContainsKey(nums[i]))
            {
                hash[nums[i]]++;
            }
            else
            {
                hash.Add(nums[i], 1);
            }
        }

        var output = new int[k];
        for (int i = 0; i < k; i++)
        {
            var maxValueKey = hash.MaxBy(x => x.Value).Key;
            output[i] = maxValueKey;
            hash.Remove(maxValueKey);
        }
        
        return output;
    }
    
    // Bucket sort implementation.
    public static int[] TopKFrequent3(ReadOnlySpan<int> nums, int k)
    {
        var map = new Dictionary<int, int>();
        var n = nums.Length;
        
        for (var i = 0; i < n; i++)
        {
            if (map.ContainsKey(nums[i]))
            {
                map[nums[i]]++;
            }
            else
            {
                map.Add(nums[i], 1);
            }
        }
        
        var output = map.OrderByDescending(kv => kv.Value).Select(kv => kv.Key);
        for (int i = 0; i < output.Max() i++)
        {
            
        }
        
        var frequency = new List<List<int>>(k + 1);
        foreach (var (key, val) in map)
        {
            frequency[val].Add(key);
        }

        var result = new int[k];
        var resultSize = 0;
        for (int i = frequency.Count; i > 1 || result.Length-1 < k; i--)
        {
            if (frequency[i].Capacity != 0)
            {
                
            }
        }

        var result = new int[k];
        var resultSize = 0;

        for (int i = frequency.Length; result.Length-1 > resultSize; i--)
        {
            if (frequency[i] != 0)
            {
                result[resultSize] = frequency[i];
                resultSize++;
            }
        }

        return result;
    }*/
    
}