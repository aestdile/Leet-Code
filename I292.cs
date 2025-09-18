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
    public bool IsPalindrome(ListNode head)
    {
       var values = new List<int>();
       var current = head;

       while (current != null)
       {
           values.Add(current.val);
           current = current.next;
       }

       int start = 0, end = values.Count-1;
       while (start < end)
           if (values[start++] != values[end--])
               return false;

       return true;
    }
}
