// See https://aka.ms/new-console-template for more information

// 需求: 輸入一個句子or 詞彙，找到最後一個單字的文字長度
// 解題思維
// 1. 先把輸入的句子/詞彙全部拆開
// 2. 移除空白，放到新的集合裡面
// 3. 去集合抓最後一個元素的長度

// var input = "Hello World";

// var input = "   fly me   to   the moon  ";
var input = "Today is a nice day";
var result = new Solution().LengthOfLastWord(input);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        var split = s.Split(' ');
        var result = new List<string>();
        foreach (var item in split)
        {
            if (!string.IsNullOrEmpty(item))
            {
                result.Add(item);
            }
        }

        return result.Last().Length;
    }
}