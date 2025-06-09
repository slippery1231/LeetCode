// Easy_9_Palindrome_Number
// 需求 : 給定一個int，判斷是不是迴文數字(從左讀和從右讀都會是相同的數字)，是的話要回傳true，反之則回false
// test case 1 : 121 => true
// test case 2 : -121 => false =>左: -121 右: 121-

// 解題思維
// 1. int轉字串，從最後跑回來，加進新的字串內
// 2. 把新的字串轉成int去比對

using System.Diagnostics;
using System.Text;

var nums = 121;
var stopwatch = new Stopwatch();
stopwatch.Start();

var result = new Solution().IsPalindrome3(nums);
stopwatch.Stop();
Console.WriteLine(result);
Console.WriteLine(stopwatch.Elapsed);
Console.WriteLine("Finished");

public class Solution
{
    // 效能問題
    // 1. b += a[i].ToString();  => 字串不可變特性，每次+=都會產生新的字串物件
    // 2. int.TryParse() => 要解析每個字
    // 3. 迴圈
    public bool IsPalindrome(int x)
    {
        var a = x.ToString();
        var b = string.Empty;
        for (var i = a.Length - 1; i >= 0; i--)
        {
            b += a[i].ToString();
        }

        if (int.TryParse(b, out var result))
        {
            if (result == x)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsPalindrome3(int x)
    {
        var str = x.ToString();
        var reversed = new StringBuilder(); //可以避免字串重複創建問題
        for (var i = str.Length - 1; i >= 0; i--)
        {
            reversed.Append(str[i]);
        }

        return str == reversed.ToString();
    }

    // 負數、尾數為0的先return出去
    // 只反轉一半 : x 代表原數字的前半部分（不斷被除以10）、 reversedHalf 代表原數字後半部分的反轉
    public bool IsPalindrome2(int x)
    {
        if (x < 0 || (x % 10 == 0 && x != 0)) return false;

        var reversedHalf = 0;
        while (x > reversedHalf)
        {
            reversedHalf = reversedHalf * 10 + x % 10;
            x /= 10;
        }

        // 偶數位、奇數位回文判斷
        return x == reversedHalf || x == reversedHalf / 10;
    }
}