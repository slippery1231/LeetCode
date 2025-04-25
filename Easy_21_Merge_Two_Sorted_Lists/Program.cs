// See https://aka.ms/new-console-template for more information

// Easy_21_Merge_Two_Sorted_Lists
// key point : linked list
// 需求: 給2個Linked list，把它們合併成有序列的linked list
// case 1 : Input: list1 = [1,2,4], list2 = [1,3,4] => Output: [1,1,2,3,4,4]
// case 2 : Input: list1 = [], list2 = [] => Output: []
// case 3 : Input: list1 = [], list2 = [0] => Output: [0]
// 解題思維
// 1. 兩個ListNode去比較大小，較小的值就放進result裡面
// 2. 只要有一個ListNode跑完，那另外一個沒跑完的就直接接在result後面

// 初始化第一個鏈表: 1->2->4
var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));

// 初始化第二個鏈表: 1->3->4
var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

var result = new Solution().MergeTwoLists(list1, list2);
PrintList(result);
Console.ReadLine();

static void PrintList(ListNode head)
{
    if (head == null)
    {
        Console.WriteLine("[]");
        return;
    }

    Console.Write("[");
    while (head != null)
    {
        Console.Write(head.val);
        if (head.next != null)
            Console.Write(",");
        head = head.next;
    }

    Console.WriteLine("]");
}

// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null)
        {
            return list2;
        }

        if (list2 == null)
        {
            return list1;
        }

        //先做出虛擬的頭節點
        var listNode = new ListNode(-1);
        
        //指針，類似index的概念
        var current = listNode;
       
        //兩個list同時去跑回圈，比較兩個linked list，把值較小的放進result linked list
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        //處理剩餘節點，因為有可能有一個linked list已經跑完了
        if (list1 != null)
            current.next = list1;
        else
            current.next = list2;
        return listNode.next;
    }
}