// See https://aka.ms/new-console-template for more information


// 需求 : 給一個int陣列，找出哪時買進哪時賣出可以得到最大利潤
// e.g. prices = [7,1,5,3,6,4] => 在day 2買進(price = 1 )，day 5賣出(price = 6)可以得到最大利潤 = 5
// 必須先買進才能賣出

var price = new[] { 7, 1, 5, 3, 6, 4 };
var result = new Solution().MaxProfit(price);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var minPrice = prices[0];
        var maxProfit = 0;
        foreach (var today in prices)
        {
            maxProfit = Math.Max(maxProfit, today - minPrice);
            minPrice = Math.Min(minPrice, today);
        }

        return maxProfit;
    }
}