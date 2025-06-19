// Easy35_SearchInsertPosition
// 需求 :給定有排序而且不會重複元素的int 陣列 & target，
// 如果可以在陣列中找到target那就回傳target所在位置，如果找不到就把target插入並回傳應該插入的位置

// case 1 Input: nums = [1,3,5,6], target = 5 => Output: 2
// case 2 Input: nums = [1,3,5,6], target = 2 => Output: 1
// case 3 Input: nums = [1,3,5,6], target = 7 => Output: 4
// 解題思維
// 1. 判斷能不能在陣列裡面找到target
// 2. 找不到的話就拿各個元素和target比大小，如果該元素大於target則回傳該元素位置
// 3. 如果所有元素都小於target，則該元素應該要放在最後一個位置

var input = new[] { 1, 3, 5, 6, };
var target = 2;
var result = new Solution().SearchInsert(input, target);
Console.WriteLine(result);


public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        var index = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                index = i;
                break;
            }

            if (nums[i] > target)
            {
                index = i;
                break;
            }

            index = nums.Length;
        }

        return index;
    }

    //稍微精簡一點
    public int SearchInsert2(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target || nums[i] > target)
            {
                return i;
            }
        }

        return nums.Length;
    }
}