// See https://aka.ms/new-console-template for more information

// Easy_125_Valid_Palindrome
// 需求 : 判斷字串是否為回文
// e.g. s = "A man, a plan, a canal: Panama" => true
// e.g.  s = "race a car" => false

var input = "A man, a plan, a canal: Panama";
var result = new Solution().IsPalindrome(input);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    // 解題思維
    // 兩個指標 left 和 right 從字串的兩端往中間移動，逐個比對有效字元是否相同
    // 把字串轉成小寫 & 判斷是否為字母或數字
    public bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        var left = 0;
        var right = s.Length - 1;

        while (left < right)
        {
            // char.IsLetterOrDigit()用來判斷是否為字母或數字
            while (left < right && !char.IsLetterOrDigit(s[left]))
            {
                left++;
            }

            while (left < right && !char.IsLetterOrDigit(s[right]))
            {
                right--;
            }

            // Compare characters (case-insensitive)
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    // 先把字串轉小寫、判斷是否為數字和字母
    // 把轉完後的集合整個翻轉，比較反轉後的序列與原本的序列是否完全一樣
    public bool IsPalindrome2nd(string s)
    {
        var clean = s.ToLower().Where(char.IsLetterOrDigit);
        var reversed = clean.Reverse();
        return reversed.SequenceEqual(clean);
    }
}