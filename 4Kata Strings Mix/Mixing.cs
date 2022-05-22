using System;
using System.Collections.Generic;
using System.Linq;


namespace _4Kata_Strings_Mix
{
    internal class Mixing
    {
        public static string Mix(string s1, string s2)
        {
            char[] s1Char = s1.Where(x => char.IsLower(x)).Select(x => x).OrderBy(x => x).ToArray();
            char[] s2Char = s2.Where(x => char.IsLower(x)).Select(x => x).OrderBy(x => x).ToArray();
            char[] union = s1Char.Union(s2Char).OrderBy(x => x).Distinct().ToArray();
            int s1Count = 0;
            int s2Count = 0;
            List<string> answerList = new List<string>();

            foreach (var item in union)
            {
                s1Count = s1Char.Where(x => x == item).Count();
                s2Count = s2Char.Where(x => x == item).Count();
                if (s1Count > 1 || s2Count > 1)
                {
                    if (s1Count > s2Count) answerList.Add("1:" + string.Concat(Enumerable.Repeat(item, s1Count)));
                }
            }
            foreach (var item in union)
            {
                s1Count = s1Char.Where(x => x == item).Count();
                s2Count = s2Char.Where(x => x == item).Count();
                if (s1Count > 1 || s2Count > 1)
                {
                    if (s1Count < s2Count) answerList.Add("2:" + string.Concat(Enumerable.Repeat(item, s2Count)));
                }
            }
            foreach (var item in union)
            {
                s1Count = s1Char.Where(x => x == item).Count();
                s2Count = s2Char.Where(x => x == item).Count();
                if (s1Count > 1 || s2Count > 1)
                {
                    if (s1Count == s2Count) answerList.Add("=:" + string.Concat(Enumerable.Repeat(item, s1Count)));
                }
            }
            return string.Join('/', answerList.OrderByDescending(x => x.Length));
        }

    }
}
