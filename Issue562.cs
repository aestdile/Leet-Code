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
    public ListNode RotateRight(ListNode head, int k) {
                if (head == null || head.next == null || k == 0) return head;
        ListNode dummy = head;
ListNode result = dummy;
Queue<int> queue = new Queue<int>();

while (head != null)
{
    queue.Enqueue(head.val);
    head = head.next;
}
int i = 0;
while (i < queue.Count - (k % queue.Count))
{
    int temp = queue.Dequeue();
    queue.Enqueue(temp);
    i++;
}


while (dummy != null)
{
    dummy.val = queue.Dequeue();
    dummy = dummy.next;
}
return result;
    }
}
