using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 生成所有合法的二叉搜索树
    /// </summary>
    class GenerateTreesSolution
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            List<TreeNode> result = new List<TreeNode>();
            
            if(n == 0)
            {
                return result;
            }
            else
            {
                return GenerateTrees(1, n);
            }
        }

        public IList<TreeNode> GenerateTrees(int start, int end)
        {
            List<TreeNode> result = new List<TreeNode>();
            //只出现在i=start或i=end时，意味左子树或右子树为空
            if (start > end)
            {
                result.Add(null);
                return result;
            }
                        
            for(int i = start; i <= end; i++)
            {
                //所有比当前节点小的节点都可能作为当前节点的左子树
                var leftNodes = GenerateTrees(start, i - 1);
                //所有比当前节点大的节点都可能作为当前节点的右子树
                var rightNodes = GenerateTrees(i + 1, end);
                foreach (var left in leftNodes) 
                {
                    foreach (var right in rightNodes)
                    {                        
                        TreeNode node = new TreeNode(i);
                        node.left = left;
                        node.right = right;
                        result.Add(node);
                    }
                }
            }
            return result;
        }
    }
}
