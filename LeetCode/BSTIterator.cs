using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 二叉搜索树迭代器
    /// </summary>
    class BSTIterator
    {
        private Stack<int> result = new Stack<int>();
        public BSTIterator(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            ProcessOnRight(stack, root);            
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Push(current.val);
                ProcessOnRight(stack, current.left);
            }
        }

        private void ProcessOnRight(Stack<TreeNode> stack, TreeNode node)
        {
            while(node != null)
            {
                stack.Push(node);
                node = node.right;
            }
        }


        /** @return the next smallest number */
        public int Next()
        {
            return result.Pop();
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return result.Count > 0;
        }
    }
}
