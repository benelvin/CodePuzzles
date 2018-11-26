/**

Given a linked list, swap every two adjacent nodes and return its head.

Example:

Given 1->2->3->4, you should return the list as 2->1->4->3.
Note:

Your algorithm should use only constant extra space.
You may not modify the values in the list's nodes, only nodes itself may be changed.




**/


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    
    /**
    
        1. Copy pointer to head - oldHead
        2. Head becomes head.next
        3. Insert oldhead after head.
        4. repeat for oldhead.next
        
    
    **/
    
    
    public ListNode SwapPairs(ListNode head) {
        if(head == null)
            return null;
              
        if(head.next == null)
        {
            return head;
        }
        ListNode oldHead = head;
        
        head = head.next;
        oldHead.next = SwapPairs(head.next);
        head.next = oldHead;
        
        return head;
    }
    
    
    
}
