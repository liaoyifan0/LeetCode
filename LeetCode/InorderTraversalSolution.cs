using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    /// <summary>
    /// 二叉树中序遍历（迭代）
    /// </summary>
    class InorderTraversalSolution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {

            TreeNode current = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> result = new List<int>();

            ProcessOnLeft(stack, current);
            while (stack.Count > 0)
            {
                current = stack.Pop();
                result.Add(current.val);
                if (current.right != null)
                {
                    ProcessOnLeft(stack, current.right);
                }
            }

            return result;
        }

        private void ProcessOnLeft(Stack<TreeNode> s, TreeNode current)
        {
            while(current!= null)
            {
                s.Push(current);
                current = current.left;
            }
        }
    }
}
