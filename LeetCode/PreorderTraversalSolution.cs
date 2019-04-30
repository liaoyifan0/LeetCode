using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 二叉树的前序遍历（迭代）
    /// </summary>
    public class PreorderTraversalSolution
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            ProcessOnLeft(stack, result, root);
            while (stack.Count != 0)
            {
                var current = stack.Pop();
                ProcessOnLeft(stack, result, current);
            }
            return result;
        }

        private void ProcessOnLeft(Stack<TreeNode> stack, List<int> result, TreeNode node)
        {
            while(node != null)
            {
                result.Add(node.val);
                stack.Push(node.right);
                node = node.left;
            }
        }
    }
}
