namespace Subsequence392Easy;

public class Solution 
{
    public bool IsSubsequence(string s, string t)
    {
        // we must compare s to t
        // the order of s can not be changed in t

        var str = new Dictionary<int, char>();
        var sub = s.ToList();

        for (int i = 0; i < t.Length; i++)
            str.Add(i, t[i]);

        for (int i = 0; i < str.Count; i++)
        {
            if (sub.Any())
            {
                if (sub[0] == str[i])
                {
                    sub.RemoveAt(0);
                }
            }
            else
            {
                break;
            }
        }

        if (sub.Any())
            return false;
        
        return true;
    }

    // This version is a linear search and is in line with linear time
    // This is the superior way to do this.
    // And appears better than the for loop version
    public bool IsSubsequence2(string s, string t)
    {
        int subLen = s.Length;
        int strLen = t.Length;

        // Edge cases for fast validation
        if (subLen > strLen)
            return false;
        if (s == t)
            return true;
        
        int i = 0;
        int j = 0;
        while (i < subLen && j < strLen)
        {
            if (s[i] == t[j])
                i++;
            j++;
        }

        return i == subLen;
    }
    
    // This two pointer approach uses a for instead of a while
    public bool IsSubsequence3(string s, string t)
    {
        int subLen = s.Length;
        int strLen = t.Length;

        // Edge cases for fast validation
        if (subLen > strLen)
            return false;
        if (s == t)
            return true;
        
        int j = 0;
        for (int i = 0; j < subLen && i < strLen; i++)
        {
            if (t[i] == s[j])
                j++;
        }

        return (j == subLen);
    }
    
    static void Main(string[] args)
    {
    }
}