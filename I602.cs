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
    public ListNode DeleteMiddle(ListNode head) {
        ListNode slow = head; ListNode fast = head; ListNode behind = null;

        if (head == null || head.next == null) return null;

        while (fast != null && fast.next != null){
            behind = slow;
            slow = slow.next;
            fast = fast.next.next;
        }

        // now delete the middle node
        behind.next = slow.next;
        return head;
    }
}
