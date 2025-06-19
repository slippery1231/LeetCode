// See https://aka.ms/new-console-template for more information

var nums = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
var solution = new Solution();
var result = solution.RemoveDuplicates(nums);
Console.WriteLine(result);
Console.ReadLine();

// 需求: 給定一個int陣列，要把該陣列中重複的元素移除，並且使用原本的陣列不可額外新增集合
// 解題思維
// 1. 先判斷原本陣列長度，如果是0的話就直接return
// 2. 把index先往下移動一個，從第二個元素開始判斷和前一個是否重複

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        int index = 1; // 從第二個位置開始，因為第一個元素已經在正確位置

        for (int i = 1; i < nums.Length; i++)
        {
            // 如果當前元素與前一個元素不同，則將其移到index位置
            if (nums[i] != nums[i - 1])
            {
                nums[index] = nums[i];
                index++;
            }
        }

        return index;
    }
}