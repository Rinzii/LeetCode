namespace ValidAnagram242Easy;

public class Solution {
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
}