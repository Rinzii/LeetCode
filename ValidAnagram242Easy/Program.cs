using System.Diagnostics.CodeAnalysis;

namespace ValidAnagram242Easy;

public class Solution {
    
    // This implementation is already pretty efficient. It only suffers from verbosity.
    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var sHash = new Dictionary<char, int>();
        var tHash = new Dictionary<char, int>();
        
        foreach (var c in s)
        {
            if (sHash.ContainsKey(c))
            {
                sHash[c] += 1;
                continue;
            }
            
            sHash.Add(c, 1);
        }
        
        foreach (var c in t)
        {
            if (tHash.ContainsKey(c))
            {
                tHash[c] += 1;
                continue;
            }
            
            tHash.Add(c, 1);
        }

        foreach (var (key, val) in sHash)
        {
            if (!tHash.ContainsKey(key))
                return false;
            
            if (tHash[key] != sHash[key])
                return false;
        }

        return true;

    }
    
    // This implementation improves upon the first one and is slightly more efficient and simpler code wise.
    public static bool IsAnagram2(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var stHash = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (stHash.ContainsKey(c))
            {
                stHash[c] += 1;
                continue;
            }
            
            stHash.Add(c, 1);
        }
        
        foreach (var c in t)
        {
            if (stHash.ContainsKey(c))
            {
                stHash[c] -= 1;
                continue;
            }
            
            stHash.Add(c, 1);
        }

        foreach (var (key, val) in stHash)
        {

            if (stHash[key] != 0)
                return false;
        }

        return true;

    }
    
    // This version of the implementation is not as efficient as the above approaches but is far simpler.
    public static bool IsAnagram3(string s, string t)
    {
        return string.Concat(s.OrderBy(c => c)) == string.Concat(t.OrderBy(c => c));
    }
    
}