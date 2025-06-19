// See https://aka.ms/new-console-template for more information
// Easy392_IsSubsequence
// 需求 : 判斷第一個字串 s 是否是第二個字串 t 的 子序列
// 解題思維
// 1. 把兩個字串都先拆成char陣列
// 2. 從題目判斷可以知道第二個字串的長度一定會大於第一個字串的長度 => 用第二個字串的char陣列去跑回圈
// 3. 第二個char陣列跑回圈的時候，去比對第一個字串的char陣列每個元素
// 4. 如果兩個char陣列元素相同，就往下一個元素走，直到比完第一個字串char 陣列


// test case
// 1. s = "abc" ,t ="ahbgdc" => true
// 2. s = "" , t ="ahbgdc" =>true
// 3. s= "axc" , t ="ahbgdc" =>false
// 4. s = "b" , t = "abc" =>true



var s = "abc";
var t = "ahbgdc";
var result = new Solution().IsSubsequence(s, t);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        var sChar = s.ToCharArray();
        var tChar = t.ToCharArray();
        var index = 0;
        foreach (var c in tChar)
        {
            if (index >= sChar.Length)
            {
                break;
            }

            if (sChar[index] == c)
            {
                index++;
            }
        }

        if (index == sChar.Length)
        {
            return true;
        }

        return false;
    }

    // claude重構版本，邏輯一樣只是提早return & 直接用字串去跑沒有特別再轉成陣列
    public bool IsSubsequence2nd(string s, string t)
    {
        // 空字符串是任何字符串的子序列
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        var index = 0;

        // 遍歷 t 中的每個字符
        foreach (var c in t)
        {
            // 如果當前字符匹配 s 中的當前字符
            if (s[index] == c)
            {
                index++;

                // 如果已經比對完 s 中的所有字符，立即返回 true
                if (index == s.Length)
                {
                    return true;
                }
            }
        }

        // 如果遍歷完 t 後未匹配完 s 中的所有字符
        return false;
    }
}