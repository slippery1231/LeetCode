// See https://aka.ms/new-console-template for more information

// 需求: 給定一個int陣列，找出該陣列中佔多數的元素為何
// e.g. nums = [2,2,1,1,1,2,2] output = 2
// 解題思維
// 1.先把數字分類，再去看數字出現的總次數

// var nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };

var nums = new int[]
{
    32, 41, 21, 29, 7, 53, 97, 76, 71, 53, 53, 53, 72, 53, 53, 14, 22, 53, 67, 53, 53, 53, 54, 98, 53, 46, 53, 53, 62,
    53, 76, 20, 60, 53, 31, 53, 53, 53, 95, 27, 53, 53, 53, 53, 36, 59, 40, 53, 53, 64, 53, 53, 53, 21, 53, 51, 53, 53,
    2, 53, 53, 53, 53, 53, 50, 53, 53, 53, 23, 88, 3, 53, 61, 19, 53, 68, 53, 35, 42, 53, 53, 48, 34, 54, 53, 75, 53,
    53, 50, 44, 92, 41, 71, 53, 53, 82, 53, 53, 14, 53
};
var result = new Solution().MajorityElement(nums);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    //只適用於只有2種數字的情況
    public int MajorityElement1st(int[] nums)
    {
        var a = new List<int>();
        var b = new List<int>();
        a.Add(nums[0]);
        foreach (var num in nums.Skip(1))
        {
            if (a.Contains(num))
            {
                a.Add(num);
            }
            else if (b.Contains(num))
            {
                b.Add(num);
            }
            else
            {
                var c = new List<int>();
                c.Add(num);
            }
        }

        if (a.Count > b.Count)
        {
            return a.First();
        }

        return b.First();
    }

    //適用於多種數字情況但效能差，因為要從頭排序
    public int MajorityElement2nd(int[] nums)
    {
        Array.Sort(nums);
        return nums[nums.Length / 2];
    }

    // 用Dictionary去紀錄數字(作為key)、List<int>作為放置重複元素的集何，最後再看哪個List<int>數量最多
    public int MajorityElement3rd(int[] nums)
    {
        var result = new Dictionary<int, List<int>>();
        foreach (var num in nums)
        {
            if (result.Keys.Contains(num))
            {
                result[num].Add(num);
            }
            else
            {
                result.Add(num, new List<int> { num });
            }
        }

        var maxCount = 0;
        var majorityElement = 0;

        foreach (var kvp in result)
        {
            if (kvp.Value.Count > maxCount)
            {
                maxCount = kvp.Value.Count;
                majorityElement = kvp.Key;
            }
        }

        return majorityElement;
    }

    // 用Dictionary去紀錄數字(作為key)、value作為紀錄該key出現幾次
    public int MajorityElement(int[] nums)
    {
        var result = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (result.Keys.Contains(num))
            {
                result[num]++;
            }
            else
            {
                result[num] = 1;
            }
        }

        var maxCount = 0;
        var majorityElement = 0;

        foreach (var kvp in result)
        {
            if (kvp.Value > maxCount)
            {
                maxCount = kvp.Value;
                majorityElement = kvp.Key;
            }
        }

        return majorityElement;
    }
}