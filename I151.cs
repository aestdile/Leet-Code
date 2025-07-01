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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
         int sz=0;
         ListNode tem=head;
         while(tem!=null){
            sz++;
            tem=tem.next;
         }
         if(sz==n) return head.next;
         sz-=n;
         tem=head;
         while(sz>1){
            sz--;
            tem=tem.next;
         }
         tem.next=tem.next.next;
         return head;
    }
}
