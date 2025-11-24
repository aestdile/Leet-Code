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
    public ListNode SwapPairs(ListNode head) {
        ListNode prev = new();
        var a = head;
        var b = head?.next;

        head = b ?? a;

        while (a != null && b != null){
            (prev.next, a.next, b.next) = (b, b.next, a);
            (prev, a, b) = (a, a.next, a.next?.next); 
        }

        return head;
    }
}
