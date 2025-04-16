// See https://aka.ms/new-console-template for more information

// Easy_20_Valid_Parentheses
// 需求 : 判斷括號是否左右成對
// e.g. {}、[()]、()[]{} => true (}{) => false
// 解題思維(IsValid2)
// 1. 做出對照表
// 2. 把左括弧放進stack裡面
// 3. 判斷右括弧是否和左括弧成對 => stack先進後出

var input = "([)]";
var result = new Solution().IsValid(input);
Console.WriteLine(result);
Console.ReadLine();


public class Solution
{
    public bool IsValid(string s)
    {
        while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
        {
            s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");
        }

        return s.Length == 0;
    }

    public bool IsValid2(string s)
    {
        // 創建字典來儲存括號對應關係
        var bracketPairs = new Dictionary<char, char>()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        // 使用堆疊來檢查匹配
        var stack = new Stack<char>();

        foreach (char c in s)
        {
            // 如果是左括號，推入堆疊
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            // 如果是右括號，檢查是否匹配
            else if (c == ')' || c == ']' || c == '}')
            {
                // 如果堆疊為空或頂部括號不匹配，則不平衡
                if (stack.Count == 0 || stack.Pop() != bracketPairs[c])
                {
                    return false;
                }
            }
        }

        // 檢查堆疊是否為空（所有左括號都有對應的右括號）
        return stack.Count == 0;
    }
}