// Easy_67_Add_Binary
// 需求 :給定兩個二進制字串 a 和 b，計算它們的和並以二進制字符串形式返回 
// key point : 二進位

// 解題思維
// 從兩個字符串的最右邊（最低位）開始加
// 記錄進位情況
// 從右到左依次計算每一位的結果


using System.Text;

var a = "2";
var b = "2";
var result = new Solution().AddBinary(a, b);
Console.WriteLine(result);


public class Solution
{
    public string AddBinary(string a, string b)
    {
        // 結果字串構建器
        var result = new StringBuilder();

        var i = a.Length - 1; // a的最右位置（最低位）
        var j = b.Length - 1; // b的最右位置（最低位）
        var carry = 0; // 進位

        // 從右到左遍歷兩個字串，直到都遍歷完且沒有進位
        while (i >= 0 || j >= 0 || carry > 0)
        {
            // 獲取當前位的值（如果索引有效）
            var digitA = (i >= 0) ? a[i] - '0' : 0;
            var digitB = (j >= 0) ? b[j] - '0' : 0;

            // 計算當前位的和（包括進位）
            var sum = digitA + digitB + carry;

            // 新的進位
            carry = sum / 2;

            // 當前位的結果
            result.Insert(0, sum % 2);

            // 移動索引
            i--;
            j--;
        }

        return result.ToString();
    }
}