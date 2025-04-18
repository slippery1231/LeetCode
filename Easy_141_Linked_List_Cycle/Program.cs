// See https://aka.ms/new-console-template for more information

// Easy_141_Linked_List_Cycle
// 需求 : 給一個鏈表的頭節點 head，判斷這個鏈表中是否有環。如果鏈表中存在環，則返回 true；否則，返回 false
// 環 : 鏈表中的某個節點可以通過不斷跟隨 next 指針再次到達自己。=> 鏈表的尾部連接到鏈表中的某個位置。

// 解題思維
// 快慢指針 = 龜兔賽跑算法
// 1. 設置兩個指針 slow 和 fast，初始都指向頭節點
// 2. slow 每次移動一步，fast 每次移動兩步
// 3. 如果存在環，fast 最終會追上 slow（兩者指向同一節點）
// 4. 如果不存在環，fast 會先到達鏈表末尾（遇到 null）

var result = new Solution().HasCycle(new ListNode(0).CreateCycleList());
Console.WriteLine(result);
Console.ReadLine();


// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int x)
    {
        val = x;
        next = null;
    }

    public ListNode CreateCycleList()
    {
        ListNode head = new ListNode(3);
        ListNode node1 = new ListNode(2);
        ListNode node2 = new ListNode(0);
        ListNode node3 = new ListNode(-4);

        head.next = node1;
        node1.next = node2;
        node2.next = node3;
        node3.next = node1; // 指回node1，形成環

        return head;
    }
}


public class Solution
{
    public bool HasCycle(ListNode head)
    {
        // 檢查邊界情況（空鏈表或只有一個節點）
        if (head == null || head.next == null)
        {
            return false;
        }

        //初始化兩個指針，都從頭節點開始
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            //慢指針每次移動一步，快指針每次移動兩步
            slow = slow.next;
            fast = fast.next.next;

            //如果存在環，兩個指針最終會相遇,如果快指針到達了鏈表末尾（遇到了 null），則說明不存在環
            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }
}