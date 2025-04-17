// See https://aka.ms/new-console-template for more information

// Easy_383_Ransom Note
// 需求 : 判斷是否可以從 magazine 的字符中構建出 ransomNote，每個字符只能用一次
// key point : 每個字母出現的次數

// test case
// 1. ransomNote = "a" , magazine ="b" => false
// 2. ransomNote = "aa" , magazine ="ab" => false
// 3. ransomNote = "aa" , magazine ="aab" => true
// 4. ransomNote = "aab" , magazine ="baa" => true

var ransomNote = "aab";
var magazine = "baa";
var result = new Solution().CanConstruct(ransomNote, magazine);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        if (string.IsNullOrEmpty(ransomNote))
        {
            return true;
        }

        if (string.IsNullOrEmpty(magazine))
        {
            return false;
        }

        // 建立char頻率dictionary
        Dictionary<char, int> magazineChars = new Dictionary<char, int>();

        // 統計 magazine 中每個char的頻率
        foreach (char c in magazine)
        {
            if (magazineChars.ContainsKey(c))
            {
                magazineChars[c]++;
            }
            else
            {
                magazineChars[c] = 1;
            }
        }

        // 檢查是否有足夠的字符構建 ransomNote
        foreach (char c in ransomNote)
        {
            if (!magazineChars.ContainsKey(c) || magazineChars[c] == 0)
            {
                return false; // 缺少必要的字符
            }

            magazineChars[c]--; // 使用一個字符
        }

        return true;
    }
}