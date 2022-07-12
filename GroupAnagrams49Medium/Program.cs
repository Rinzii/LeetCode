using System.Collections;
using System.Collections.Immutable;

public class Solution {
    
    public IList<IList<string>> GroupAnagrams(ReadOnlySpan<string> strs)
    {
        Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
        for (int i = 0; i < strs.Length; i++)
        {
            var arr = strs[i].ToCharArray();
            Array.Sort(arr);
            var sorted = new string(arr);
            if(map.ContainsKey(sorted))
            {
                map[sorted].Add(strs[i]);
            }
            else
            {
                map.Add(sorted, new List<string>() {strs[i]});
            }
        }
        var result = map.Values.ToList();
        return result;
    }
    
    // Slightly faster implementation using a mixture of linq and a sorting method
    public static IList<IList<string>> GroupAnagrams2(ReadOnlySpan<string> strs)
    {
        var configStr = strs.ToArray().Select(x => new
            {
                Base = x // Base value used to generate result
                ,sorted = Sort(x) 
            }) 
            .GroupBy(x => x.sorted) // Group Anagram together
            .Select(y => y.Select(z => z.Base).ToArray()).ToArray();
        return configStr;
    }
    // Sort string to check for anagram later
    static string Sort(string x)
    {
        var res = x.ToCharArray();
        Array.Sort(res);
        return new string(res);
    }
}