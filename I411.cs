/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null) return false;  
        while (head.next != null){
            if (head.val == Int32.MaxValue) return true;
			
            head.val = Int32.MaxValue;
            head = head.next;
        }
        return false;
    }
}
