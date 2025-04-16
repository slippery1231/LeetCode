// See https://aka.ms/new-console-template for more information

// 需求 : 把輸入的羅馬字母轉成數字
// 解題思維
// 1. 做出對照表
// 2. 拿輸入的羅馬字母去dictionary找對應的值
// 3. 判斷是否需要做減法 : 如果當前字符不是最後一個且當前值小於下一個值，則需要減去當前值

var input = "IV";
var result = new Solution().RomanToInt(input);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    public int RomanToInt(string s)
    {
        var dictionary = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        var result = 0;
        for (var i = 0; i < s.Length; i++)
        {
            // 獲取當前羅馬數字對應的值
            var currentVal = dictionary[s[i]];

            // 判斷是否需要做減法
            // 如果當前字符不是最後一個且當前值小於下一個值，則需要減去當前值
            if (i + 1 < s.Length && currentVal < dictionary[s[i + 1]])
            {
                result -= currentVal;
            }
            else
            {
                result += currentVal;
            }
        }

        return result;
    }
}