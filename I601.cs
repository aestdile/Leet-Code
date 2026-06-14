/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int PairSum(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;

        while(fast !=null && fast.next !=null){
            slow = slow.next;
            fast = fast.next.next;
        }
         ListNode prev = null;
        ListNode curr = slow;

        while (curr != null) {
            ListNode nextNode = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextNode;
        }

        ListNode first = head;
        ListNode second = prev;

        int maxSum = 0;

        while (second != null) {
            int sum = first.val + second.val;
            maxSum = Math.Max(maxSum, sum);

            first = first.next;
            second = second.next;
        }

        return maxSum;
    }
}
