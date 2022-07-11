using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LeetCode;

public static class Solution {
    /*
    Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).
    Return the running sum of nums.
    
    > Input: nums = [1,2,3,4]
    > Output: [1,3,6,10]
    > Explanation: Running sum is obtained as follows: [1, 1+2, 1+2+3, 1+2+3+4].
     */
    public static int[] RunningSum(int[] nums)
    {
        var result = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            var sum = nums[0];
            
            for (int j = 1; j <= i; j++)
            {
                sum += nums[j];
            }

            result[i] += sum;
        }

        return result;
    }
    
    // Instead of having to use 2 loops we can reduce the size down to 1
    public static int[] RunningSum2(int[] nums)
    {
        var result = new int[nums.Length];
        result[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
            result[i] = result[i - 1] + nums[i];

        return result;
    }
    
    // Take advantage of the better code gen of ReadOnlySpan
    public static int[] RunningSum3(ReadOnlySpan<int> nums)
    {
        var result = new int[nums.Length];
        result[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
            // Moves through the array like such:
            // r(i) = r(i - 1) + n(i)
            // r(1) = r(0) + n(1)
            result[i] = result[i - 1] + nums[i];

        return result;
    }
    
    // This is the fastest option but is not suggested in a production environment 
    // This also does not work on LeetCode and seems to be overkill
    public static int[] RunningSum4(ReadOnlySpan<int> nums)
    {
        int[] result = new int[nums.Length];
        int sum = 0;
    
        ref int source = ref MemoryMarshal.GetReference(nums);
        ref int destination = ref MemoryMarshal.GetArrayDataReference(result);
        ref int end = ref Unsafe.Add(ref destination, nums.Length);
    
        while (Unsafe.IsAddressLessThan(ref destination, ref end))
        {
            destination = sum = sum + source;
            source = ref Unsafe.Add(ref source, (nuint)1);
            destination = ref Unsafe.Add(ref destination, (nuint)1);
        }
    
        return result;
    }

    public static void Main()
    {
        var input = new int[] {1, 2, 3, 4};
        var result = RunningSum4(input);
        foreach (var num in result)
        {
            Console.Write(num + " ");
        }
        
    }
}