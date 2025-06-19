
// Easy14_LongestCommonPrefix
// 需求 : 給一個字串陣列，找到最長重複的prefix，如果沒有重複的則回傳空字串
// e.g. Input: strs = ["flower","flow","flight"] => Output: "fl"
// e.g. Input: strs = ["dog","racecar","car"] => Output: ""
// 解題思維
// 1. 先把單字用長度做排序，抓最短的單字
// 2. 拿最短的單字去跑回圈，在每個索引位置，檢查所有字串在該位置的字元是否相同
// 3. 從每個字串中選取第i個字元取出不重複的字元，如果不重複的字元數量大於1，表示在這個位置上有不同的字元
// 4. 一旦找到一個位置，在那裡字元不完全相同，用範圍運算子[..i]，返回從開始到索引i(不含i)的子字串，即共同前綴

var input = new[] { "flower", "flow", "flight" };

// var input = new[] { "dog", "racecar", "car" };
var result = new Solution().LongestCommonPrefix(input);
Console.WriteLine(result);
Console.ReadLine();


public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var shortest = strs.OrderBy(s => s.Length).First();
        for (int i = 0; i < shortest.Length; i++)
        {
            //從每個字串中選取第i個字元取出不重複的字元，如果不重複的字元數量大於1，表示在這個位置上有不同的字元
            if (strs.Select(s => s[i]).Distinct().Count() > 1)
            {
                return shortest[..i]; //一旦找到一個位置，在那裡字元不完全相同，用範圍運算子[..i]，返回從開始到索引i(不含i)的子字串，即共同前綴
            }
        }

        return shortest;
    }
}