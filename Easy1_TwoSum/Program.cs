// Easy1_TwoSum
// 需求 : 給定一個int陣列和target，找出陣列中哪些元素相加會等於target
// 解題思維
// 1. int array跑回圈，算出當前元素和target的差值
// 2. 判斷dictionary有沒有差值這個key，找不到就繼續往下
// 3. 判斷dictionary有沒有當前迴圈的元素，沒有的話就把元素加進dictionary

// case 1 : nums =[2,7,11,15], target = 9 => output =[0,1]
// case 2 : nums =[3,2,4], target = 6 => output =[1,2]

var nums = new[] { 2, 7, 11, 15 };
var target = 9;
var result = new Solution().TwoSum(nums, target);
foreach (var item in result)
{
    Console.WriteLine(item);
}

Console.ReadLine();

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var numMap = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var fulfill = target - nums[i];
            if (numMap.TryGetValue(fulfill, out var value))
            {
                return new[] { value, i };
            }

            if (!numMap.ContainsKey(nums[i]))
            {
                numMap.Add(nums[i], i);
            }
        }

        return Array.Empty<int>(); // 如果沒有解
    }
}