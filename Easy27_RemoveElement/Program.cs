
// Easy27_RemoveElement
// 需求: 給定一個int陣列和 int value，要把陣列裡面含有value的值移除並回傳陣列中剩下的元素個數
// point : 不可以創新的array，只能在原有的陣列裡面操作
// e.g. nums = [3, 2, 2, 3] ,value = 3 => output => 2
// 解題思維
// 1. 先給個指標index，拿nums去跑回圈
// 2. 比對nums每個元素和value是否相等
// 3. 如果不相等 => 就直接把

var nums = new[] { 3, 2, 2, 3 };
var val = 3;
var result = new Solution().RemoveElement(nums, val);
Console.WriteLine(result);


public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        var result = 0;
        foreach (var item in nums)
        {
            if (item != val)
            {
                nums[result] = item;
                result++;
            }
        }

        return result;
    }
}