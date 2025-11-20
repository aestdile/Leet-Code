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
    public ListNode ReverseKGroup(ListNode head1, int k) {
        if(k==0||head1==null) return head1;
        List<int> list=new List<int>();
        while(head1!=null){
            list.Add(head1.val);
            head1=head1.next;
        }
        int l=0,cnt=0;
        for(int i=0;i<list.Count();i++){
            cnt++;
            if(cnt==k){
                int r=i;
                while(l<r){
                    int value=list[r];
                    list[r]=list[l];
                    list[l]=value;
                    l++;r--;
                }
                cnt=0;
                l=i+1;
            }
        }
        ListNode head=null,current=null;
        foreach(int u in list){
            ListNode tem=new ListNode(u);
            if(head==null){
                head=tem;
                current=head;
            }
            else{
                current.next=tem;
                current=current.next;
            }
        }
        return head;
    }
}