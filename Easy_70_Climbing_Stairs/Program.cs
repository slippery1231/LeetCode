// Easy_70_Climbing_Stairs
// 需求 : 給一個整數n，現在要爬梯子，每次都可以決定走一步或2步，總共會有幾種爬法
// key point : dynamic programming、費式數列(arr[i] = arr[i-1] + arr[i-2])
// case 1 Input: 2 => output = 2
// case 2 Input: 3 => output = 3

// 解題思維
// i = 1 和 i = 2 的情況已經被特殊處理了
// 對於 i = 3 開始的每一階，都可以應用動態規劃的遞推公式：dp[i] = dp[i-1] + dp[i-2]

var input = 2;
var result = new Solution().ClimbStairs(input);
Console.WriteLine(result);


public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 1)
        {
            return 1;
        }

        var first = 1; //代表 dp[i-2]，也就是爬到第 i-2 階的方法數
        var second = 2; // 代表 dp[i-1]，也就是爬到第 i-1 階的方法數
        var output = second; // 代表 dp[i]，也就是爬到第 i 階的方法數，等於 dp[i-1] + dp[i-2]
        for (int i = 3; i <= n; i++)
        {
            output = first + second;
            first = second;
            second = output;
        }

        return output;
    }

    public int ClimbStairs2(int n)
    {
        if (n == 1)
        {
            return 1;
        }

        var dp = new int[n + 1]; //索引對齊: 這樣使得索引 i 可以直接對應到「第 i 階樓梯」
        dp[1] = 1;
        dp[2] = 2;
        for (int i = 3; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }
}