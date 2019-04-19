using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class NextGreaterElementSolution
    {
        public int[] NextGreaterElementWithStackAndHashMao(int[] nums1, int[] nums2)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int[] result = new int[nums1.Length];

            foreach (var num in nums2)
            {
                while (stack.Count >0 && num > stack.Peek())
                {
                    dictionary.Add(stack.Pop(), num);
                }
                stack.Push(num);
            }
            for(int i = 0; i < nums1.Length; i++)
            {
                result[i] = dictionary.GetValueOrDefault(nums1[i], -1);
            }

            return result;
        }


        // n^2复杂度
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length];
            for (int a = 0; a< nums1.Length; a++)
            {
                //用来指示是否是num的右侧
                bool flag = false;
                int i;
                for( i =0; i < nums2.Length; i++)
                {
                    if(nums2[i] == nums1[a])
                    {
                        flag = true;
                    }

                    if(flag == true && nums2[i] > nums1[a])
                    {
                        result[a] = nums2[i];
                        break;
                    }
                }
                if(i == nums2.Length && nums2[i-1] <= nums1[a])
                {
                    result[a] = -1;
                }
            }

            return result;
        }
    }
}
