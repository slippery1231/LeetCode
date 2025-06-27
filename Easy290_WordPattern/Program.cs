// Easy290_WordPattern
// 需求: 給一個字串規律pattern，再給一個字串，判斷該字串是否有符合規律
// 解題思維
// 1. 如果pattern長度小於輸入字串 => false
// 2. 檢查已存在於dictionary的內容
// 3. 當前char還沒有映射，但要檢查目標單詞是否已被其他字符占用
// 4. 上述都不符合就把新資料寫入dictionary


// case 1 :Input: pattern = "abba", s = "dog cat cat fish" => Output: false
// case 2 : Input: pattern = "aaaa", s = "dog cat cat dog" => Output: false
// case 3 : Input: pattern = "abba", s = "dog cat cat dog" => Output: true

var pattern = "aaaa";
var s = "dog cat cat dog";

Console.WriteLine(new Solution().WordPattern(pattern, s));

public class Solution
{
    public bool WordPattern(string pattern, string s)
    {
        var dictionary = new Dictionary<char, string>();
        var words = s.Split();
        if (words.Length != pattern.Length)
        {
            return false;
        }

        for (int i = 0; i < pattern.Length; i++)
        {
            if (dictionary.TryGetValue(pattern[i],out var currentValue))
            {
                if (currentValue != words[i])
                {
                    return false;
                }
                continue;
            }

            if (dictionary.ContainsValue(words[i]))
            {
                return false;
            }
            dictionary.Add(pattern[i], words[i]);
        }
        return true;
    }
}