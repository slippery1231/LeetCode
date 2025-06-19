// Easy100_SameTree
// key point : Binary Tree
// 需求 : 給2個 binary tree，檢查他們是否相同
// case 1 : Input: p = [1,2,3], q = [1,2,3] => Output: true
// case 2 : Input: p = [1,2], q = [1,null,2] => Output: false
// case 3 : Input: p = [1,2,1], q = [1,1,2] => Output: false


TreeNode p1 = new TreeNode(1, new TreeNode(2), new TreeNode(1));

TreeNode q1 = new TreeNode(1, new TreeNode(1), new TreeNode(2));

var result = new Solution().IsSameTree(p1, q1);
Console.WriteLine(result);
Console.ReadLine();

// Definition for a binary tree node.
public class TreeNode
{
    //節點的值
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        // 如果兩個節點都為空，則相同
        if (p == null && q == null)
        {
            return true;
        }

        // 如果一個節點為空而另一個不為空，則不相同
        if (p == null || q == null)
        {
            return false;
        }

        // 檢查當前節點的值是否相同
        if (p.val != q.val)
        {
            return false;
        }

        // // 遞歸檢查左子樹和右子樹
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}