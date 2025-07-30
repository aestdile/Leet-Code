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
    public ListNode MergeKLists(ListNode[] lists) {
        var set = new List<int>();
        var head = new ListNode(0);
        var pointer = new ListNode(0,head);
        foreach(var item in lists)
        {
            var _current = item;
            while(_current != null)
            {
                set.Add(_current.val);
                _current = _current.next;
            }
        }
        
        if (set.Count == 0)
        {
            return null;
        }
        set.Sort();

        foreach(var item in set)
        {
            pointer.next ??= new ListNode();
            pointer.next.val = item;
            pointer = pointer.next;
        }
        return head;
    }
}
