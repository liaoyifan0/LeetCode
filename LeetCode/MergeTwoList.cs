using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{    
    /// <summary>
    /// 合并两个有序链表
    /// </summary>
    class MergeTwoList
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        //归并版本
        public ListNode MergeTwoLists_V1(ListNode l1, ListNode l2)
        {
            ListNode p = l1, q = l2;
            ListNode head = new ListNode(int.MinValue);
            ListNode current = head;
            while (p != null && q != null)
            {
                ListNode newNode;
                if (p.val <= q.val)
                {
                    newNode = new ListNode(p.val);
                    p = p.next;
                }
                else
                {
                    newNode = new ListNode(q.val);
                    q = q.next;
                }
                current.next = newNode;
                current = current.next;
            }
            if (p != null)
                current.next = p;

            if (q != null)
                current.next = q;

            return head.next;
        }

        //递归版本
        public ListNode MergeTwoLists_V2(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            ListNode res;
            if(l1.val <= l2.val)
            {
                res = l1;
                res.next = MergeTwoLists_V2(l1.next, l2);
            }
            else
            {
                res = l2;
                res.next = MergeTwoLists_V2(l1, l2.next);
            }

            return res;
        }

        //插入版本
        public ListNode MergeTwoLists_V3(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            if (l1.val > l2.val)
            {
                var swap = l1;
                l1 = l2;
                l2 = swap;
            }
            ListNode p = l1, q = l2;
            ListNode pre = null;
            while (q != null)
            {
                //找到l1中第一个比q大的节点
                while (p != null && p.val <= q.val)
                {
                    pre = p;
                    p = p.next;
                }

                if (p == null) //l1中所有元素都比l2小,直接将l2插入l1末尾
                {
                    pre.next = q;
                    break;
                }
                else
                {

                    ListNode tempNode = q.next;
                    pre.next = q;
                    q.next = p;

                    p = q;
                    q = tempNode;

                }
            }

            return l1;
        }
    }
}
