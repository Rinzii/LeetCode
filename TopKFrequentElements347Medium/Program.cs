using System.Collections;

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
    
    // Bucket sort implementation.
    public static int[] TopKFrequent2(ReadOnlySpan<int> nums, int k)
    {
        if (nums.Length == 1)
            return nums.ToArray();

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
        
        // TODO: This needs to be properly implemented as the current approach is broken.
        var freq = new int[nums.Length + 1];
        foreach (var (key, val) in hash)
        {
            freq[val].;
        }

        var result = new int[k];
        var resultSize = 0;

        for (int i = freq.Length; result.Length-1 > resultSize; i--)
        {
            if (freq[i] != 0)
            {
                result[resultSize] = freq[i];
                resultSize++;
            }
        }

        return result;
    }


    public static void Main()
    {
        var nums = new[] {1, 1, 1, 2, 2, 3};
        var nums2 = new[] {1, 2};
        var nums3 = new[] {-1, -1};
        var k = 2;

        var output = TopKFrequent2(nums2, k);
        Console.WriteLine();
    }
}