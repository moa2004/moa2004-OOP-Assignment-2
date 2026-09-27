using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode
{
    public class Solution
    {
        public int MaxVowels(string s, int k)
        {
            int mx = int.MinValue;
            int cnt = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i >= k)
                {
                    if (s[i - k] == 'a' || s[i - k] == 'e' || s[i - k] == 'i' || s[i - k] == 'o' || s[i - k] == 'u')
                    {
                        cnt--;
                    }
                }
                if (s[i] == 'a' || s[i] == 'e' || s[i] == 'o' || s[i] == 'i' || s[i] == 'u')
                {
                    cnt++;
                }
                mx = Math.Max(mx, cnt);
            }
            return mx;
        }
    }
}
