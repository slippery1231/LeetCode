
// Easy88_MergeSortedArray
// 需求: 給2個int array和m&n，m&n分別代表陣列的元素數量，要把兩個合併成一個non-decreasing的陣列
// 解題思維
// 1. 先確定好各自array的最大值位置
// 2. 去比對兩個array最大值，較大的那個先放入合併後(nums1[k])的array
// 3. 已經放入元素的，要把他的index扣掉，往前找下一個元素

int[] nums1 = { 1, 2, 3, 0, 0, 0 };
int[] nums2 = { 2, 5, 6 };
var m = 3;
var n = 3;

new Solution().Merge(nums1, m, nums2, n);

public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        Array.Copy(nums2, 0, nums1, m, n);
        Array.Sort(nums1);
    }


    //不用Array既有方法
    public void Merge2(int[] nums1, int m, int[] nums2, int n)
    {
        var i = m - 1;
        var j = n - 1;
        var k = m + n - 1;
        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[k] = nums1[i];
                i--;
            }
            else
            {
                nums1[k] = nums2[j];
                j--;
            }

            k--;
        }

        // nums2還有剩餘元素就直接放進nums1
        while (j >= 0)
        {
            nums1[k] = nums2[j];
            j--;
            k--;
        }
    }
}