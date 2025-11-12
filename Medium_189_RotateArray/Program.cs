// Medium189_RotateArray
// 需求: 給定一個int陣列 和 要往右移動的步數k，k必定為正整數。將陣列的元素向右移動k個位子
// 解題思維 - Rotate
// 1. 複製一份nums、算出陣列最大的index位置及長度
// 2. 算出真正要移動的次數 => k % nums.Length
// 3. 把元素移動到新的位置
// => 如果元素原本index + 移動次數 >= num.Length => 就要回到0再繼續往下移動
// => 如果原本index + 移動次數 < num.Length => 就直接移動到新的位置


// 解題思維 - Rotate2
// 1. 把既有array整個翻轉 [1,2,3,4] => [4,3,2,1]
// 2. 把前面k個元素翻轉 [4,3,2,1] => [3,4,2,1]
// 3. 把後面k個元素翻轉 [3,4,2,1] => [3,4,1,2]


// case 1 : nums = { -1, -100, 3, 99 } k = 2
// case 1 : nums = { -1, 2 } k = 3

var solution = new Solution();
var nums = new[] { -1, -100, 3, 99 };
var k = 2;
solution.Rotate2(nums, k);
public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        var oldNums = nums.ToArray();
        var maxIndex = nums.Length - 1;
        var length = nums.Length;

        // 要移動次數
        var times = k % nums.Length;

        for (var i = 0; i <= maxIndex; i++)
        {
            if (i + times < length)
            {
                nums[i + times] = oldNums[i];
                Console.WriteLine($"i= {i}, nums[{i + times}] = {oldNums[i]}");
            }
            
            if (i + times >= length)
            {
                nums[i - length + times] = oldNums[i];
                Console.WriteLine($"i= {i}, nums[{i - length + times}] = {oldNums[i]}");
            }
        } 
    }
    
    // 三次翻轉
    public void Rotate2(int[] nums, int k)
    {
        k = k % nums.Length;

        // 1. 翻轉全部
        Reverse(nums, 0, nums.Length - 1);

        // 2. 翻轉前面k個
        Reverse(nums, 0, k - 1);
        
        // 3. 翻轉後面 n-k 個元素
        Reverse(nums, k, nums.Length - 1);
    }

    private void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            var temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }
}