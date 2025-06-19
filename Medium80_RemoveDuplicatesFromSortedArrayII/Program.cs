// Medium80_RemoveDuplicatesFromSortedArrayII
// 需求 : 給一個升冪int的陣列，如果元素在該陣列出現超過2次就要把它移除。不能額外新增其他陣列只能用給定的陣列去做處理
// key point : array/string
// case 1 Input: nums = [1,1,1,2,2,3] => Output: 5, nums = [1,1,2,2,3,_]
// case 2 Input: nums = [ 0, 0, 1, 1, 1, 1, 2, 3, 3 ] => Output: 5, nums = [0,0,1,1,2,3,3]

// var input = new[] { 1, 1, 1, 2, 2, 3 };

var input = new[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
var result = new Solution().RemoveDuplicates(input);
Console.WriteLine(result);


public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length < 2) // Check if the array has fewer than 2 elements
        {
            return nums.Length; // Return the length of the array as no duplicates exist
        }

        var index = 0;
        var record = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            // 使用TryGetValue獲取當前計數，如果不存在則設為0
            record.TryGetValue(num, out var count);

            if (count < 2)
            {
                record[num] = count + 1;
                nums[index] = num;
                index++;
            }
        }

        return index;
    }
    
    //雙指針解法
    public int RemoveDuplicates2(int[] nums) {
        // 如果數組長度小於等於2，已符合要求，直接返回長度
        if (nums.Length <= 2) {
            return nums.Length;
        }
        
        // 慢指針i表示處理後的數組末尾位置
        int i = 2;
        
        // 快指針j用來遍歷整個數組
        for (int j = 2; j < nums.Length; j++) {
            // 如果當前元素與處理後數組倒數第二個元素不同，說明它最多是第二次出現
            if (nums[j] != nums[i - 2]) {
                nums[i] = nums[j];
                i++;
            }
        }
        
        return i;
    }
}