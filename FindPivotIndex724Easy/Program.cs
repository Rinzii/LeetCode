namespace LeetCode;

// go for readability / ease of solution almost always. I will consider optimizing if an operation
// seems slow in human terms. Others will optimize if an operation has high server costs or adds
// latency.

public class Solution 
{
    /*
    Given an array of integers nums, calculate the pivot index of this array.

    The pivot index is the index where the sum of all the numbers strictly to the left of the index is equal to the sum of all the numbers strictly to the index's right.

    If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.

    Return the leftmost pivot index. If no such index exists, return -1.

    Example 1:

        Input: nums = [1,7,3,6,5,6]
        Output: 3
        Explanation:
            The pivot index is 3.
            Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
            Right sum = nums[4] + nums[5] = 5 + 6 = 11
     */
    public static int PivotIndex(ReadOnlySpan<int> nums)
    {
        // If our input is {1, 7, 3, 6, 5, 6} then we will return 3 like such:
        // leftSum == sum - leftSum - nums[i]
        // 11      == 28  - 11      - 6           total(11)
        // Result:
        // 11 == 11

        var sum = 0;
        foreach (var num in nums) // This runs in O(n)
            sum += num;

        var leftSum = 0;

        /*
         * We know the sum of the entire array is never changing
         * so we can take the total and subtract the left sum and
         * the current pivot value we are to make it easy to compare the
         * right sum with the left sum. This is done in O(1) since
         * we are doing addition and subtraction.
         */
        for (int i = 0; i < nums.Length; i++)
        {
            // if leftSum == rightSum   |   this is O(1)
            if (leftSum == sum - leftSum - nums[i]) return i; 
            leftSum += nums[i];
        }

        return -1;
    }

    public static void Main()
    {
        var input = new int[] {1, 7, 3, 6, 5, 6};
        var output = PivotIndex(input);

        Console.WriteLine(output);
    }
}