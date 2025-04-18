// See https://aka.ms/new-console-template for more information

// Easy_104_Maximum_Depth_of_Binary_Tree
// 需求 : 給一個樹狀，找到最大層數
// e.g. [ 3, 9, 20, null, null, 15, 7 ]
// 第一層 :3
// 第二層 : 9(left), 20(right)
// 第三層 : 9往下左右節點都是null, 20往下左右分別為 15、7
// 節點20的深度 1+1(當前) = 2  => 節點3最大深度 = 2 + 1 = 3

var input = new int?[] { 3, 9, 20, null, null, 15, 7 };
var result = new Solution().MaxDepth(new TreeNode().BuildTree(input));
Console.WriteLine(result);
Console.ReadLine();

// Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public TreeNode BuildTree(int?[] nums)
    {
        if (nums == null || nums.Length == 0 || nums[0] == null)
            return null;

        var root = new TreeNode(nums[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        for (int i = 1; i < nums.Length; i += 2)
        {
            var current = queue.Dequeue();

            // 左子節點
            if (i < nums.Length && nums[i].HasValue)
            {
                current.left = new TreeNode(nums[i].Value);
                queue.Enqueue(current.left);
            }

            // 右子節點
            if (i + 1 < nums.Length && nums[i + 1].HasValue)
            {
                current.right = new TreeNode(nums[i + 1].Value);
                queue.Enqueue(current.right);
            }
        }

        return root;
    }
}

public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        // 節點為空 => 深度 = 0
        if (root == null)
            return 0;

        // 用遞迴計算左子樹和右子樹的深度
        var leftDepth = MaxDepth(root.left);
        var rightDepth = MaxDepth(root.right);

        // 返回最大深度 + 1（因為要包含當前節點）
        return Math.Max(leftDepth, rightDepth) + 1;
    }
}