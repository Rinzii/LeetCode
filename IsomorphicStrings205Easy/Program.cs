using System;

namespace IsomorphicStrings205Easy
{
    internal class Program
    {
        
        /*
        Given two strings s and t, determine if they are isomorphic.

        Two strings s and t are isomorphic if the characters in s can be replaced to get t.

        All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character, but a character may map to itself.
        */
        public static bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var mapSt = new Dictionary<char, char>();
            var mapTs = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (mapSt.ContainsKey(s[i]) && mapSt[s[i]] != t[i] ||
                    mapTs.ContainsKey(t[i]) && mapTs[t[i]] != s[i])
                    return false;

                mapSt.TryAdd(s[i], t[i]);
                mapTs.TryAdd(t[i], s[i]);
            }

            return true;
        }

        static void Main(string[] args)
        {
            var t = IsIsomorphic("foo", "bar");
            var x = IsIsomorphic("egg", "add");
            Console.WriteLine(t);
            Console.WriteLine(x);

        }
    }
}