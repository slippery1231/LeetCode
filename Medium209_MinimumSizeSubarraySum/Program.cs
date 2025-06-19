// Medium209_MinimumSizeSubarraySum
// 需求 :找出一個連續子陣列，使得最小長度子陣列所有元素總和 ≥ target
// key point : 滑動窗口 (sliding window)

// case 1 Input: target = 7, nums = [2,3,1,2,4,3] => Output: 2
// case 2 Input: target = 4, nums = [1,4,4] => Output: 1
// case 3 Input: target = 11, nums = [1,1,1,1,1,1,1,1] => Output: 0
// case 4 Input: target = 11, nums = [1,2,3,4,5] => Output: 3
// case 5 Input: target = 213, nums = [12,28,83,4,25,26,25,2,25,25,25,12] => Output: 8

var input = new[] { 12, 28, 83, 4, 25, 26, 25, 2, 25, 25, 25, 12 };
var target = 213;
var result = new Solution().MinSubArrayLen(target, input);
Console.WriteLine(result);


public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        var left = 0; // 子陣列的左邊界
        var sum = 0; // 當前窗口的總和
        var minLength = int.MaxValue; // 最小的子陣列長度

        for (var right = 0; right < nums.Length; right++)
        {
            sum += nums[right]; // 加入新元素到窗口

            // 當總和大於等於目標值時，嘗試縮小窗口（移動左邊界）
            while (sum >= target)
            {
                minLength = Math.Min(minLength, right - left + 1); // 更新最小長度
                sum -= nums[left]; // 從窗口移除左邊的元素
                left++; // 左邊界右移
            }
        }

        // 如果minLength沒有被更新，表示沒有符合條件的子陣列
        return minLength == int.MaxValue ? 0 : minLength;
    }
}