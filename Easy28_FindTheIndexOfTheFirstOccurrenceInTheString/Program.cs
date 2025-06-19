// See https://aka.ms/new-console-template for more information

// Easy28_FindTheIndexOfTheFirstOccurrenceInTheStringIn_A_String
// 需求 : 給兩個字串hayStack & needle，找到第一個重複的位置，如果沒有重複則回傳-1

// var hayStack = "sadbutsad";
var hayStack = "leetcode";
// var needle = "sad";
var needle = "leeto";
var result = new Solution().StrStr(hayStack, needle);
Console.WriteLine(result);
Console.ReadLine();

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        return haystack.IndexOf(needle);
    }
}