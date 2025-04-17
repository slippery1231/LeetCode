// See https://aka.ms/new-console-template for more information

// Easy_228_Summary_Ranges
// 需求 : 給定一個已排序的整數陣列，要轉換成範圍[a,b]
// 範圍摘要的格式為：
// 當範圍只包含一個數字時，只顯示該數字，例如 "1"
// 當範圍包含連續的多個數字時，用箭頭連接起始和結束數字，例如 "2->4"
// e.g. nums = [0,1,2,4,5,7] => output:["0->2","4->5","7"]

// 解題思維
// 1. 用begin & end分別記錄連續範圍的起始&結束位置
// 2. 拿nums去跑回圈，先確認 後面的值是否 =前面 +1(確認有無連續)

var nums = new int[] { };
var result = new Solution().SummaryRanges(nums);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    public IList<string> SummaryRanges(int[] nums)
    {
        var result = new List<string>();

        if (nums.Length == 0)
        {
            return result;
        }

        var begin = 0;
        var end = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1] + 1)
            {
                end = i - 1; // 設定當前範圍的結束指標為前一個元素的索引
                if (begin == end)
                {
                    result.Add($"{nums[begin]}"); //單個數字情況
                }
                else
                {
                    result.Add($"{nums[begin]}->{nums[end]}"); //連續數字
                }

                begin = i; // 更新下一個範圍的起始指標為當前元素
                end = i; // 更新下一個範圍的結束指標為當前元素
            }
        }

        // 處理最後一個範圍（迴圈結束後可能有未處理的範圍）
        end = nums.Length - 1; // 最後一個範圍的結束指標是陣列的最後一個元素
        if (begin == end)
        {
            result.Add($"{nums[begin]}"); // 如果最後範圍只有一個數字
        }
        else
        {
            result.Add($"{nums[begin]}->{nums[end]}"); // 如果最後範圍是連續的多個數字
        }

        return result;
    }
}