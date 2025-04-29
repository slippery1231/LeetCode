// Easy_66_Plus_One
// 需求 :給定int 陣列，將整個陣列所代表的數字加一

// case 1 Input: digits = [1,2,3] => Output: [1,2,4]
// case 2 Input: digits = [9] => Output: [1,0]

// 解題思維
// 從最右邊（最低位）開始加
// 如果最後一位 < 9，直接加一就可以回傳
// 如果是 9，我們把它變成 0，因為要進位
// 如果所有位數都進位完（例如 999），那就新開一個長度加一的陣列，開頭是 1，其餘預設都是 0

var input = new[] { 1, 2, 3 };
var result = new Solution().PlusOne(input);
foreach (var item in result)
{
    Console.WriteLine(item);
}

public class Solution
{
    public int[] PlusOneFailed(int[] digits)
    {
        var result = string.Empty;
        foreach (var item in digits)
        {
            result += item.ToString();
        }

        //會有溢位問題
        int.TryParse(result, out var resultInt);
        var calculate = (resultInt + 1).ToString();
        var res = new int[calculate.Length];
        for (int i = 0; i < calculate.Length; i++)
        {
            // res[i] = a[i]; => 把 char 賦值給 int，而 C# 中 char 轉成 int 會轉成 Unicode 編碼值，不是轉成數字本身

            res[i] = calculate[i] - '0';
        }

        return res;
    }

    public int[] PlusOne(int[] digits)
    {
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits;
            }

            digits[i] = 0; // 如果是 9，就變成 0，繼續進位
        }

        // 如果全部都是 9，例如 999，最後變成 [1,0,0,0]
        var result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }
}