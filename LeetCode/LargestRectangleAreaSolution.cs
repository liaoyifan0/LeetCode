using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 矩形柱状图中最大的矩形
    /// </summary>
    class LargestRectangleAreaSolution
    {
        //维护height非严格单调递增的桟（存index,可以计算length）
        //如果当前height小于栈顶height，则出栈栈顶元素（代表当前最大height），并计算其length       
        public int LargestRectangleArea(int[] heights)
        {
            int maxArea = 0;

            Stack<int> stack = new Stack<int>();
            for(int i = 0; i< heights.Length; i++)
            {
                while(stack.Count > 0 && heights[i] < heights[stack.Peek()])
                {
                    var current = stack.Pop();

                    //难点！
                    //maxArea：代表能完全包含当前出栈位置高度的最大面积；
                    //但是如果出现相同高度元素，这里计算的最大面积只有最后一个元素的才准确；
                    //例如：如果栈为2，3，4，且heights[2]==heights[3]==heights[4]，则height[4]和heights[3]的最大面积都不准确，只有heights[2]的最大面积是对的                
                    var len = stack.Count > 0 ? i - stack.Peek() - 1 : i;
                    maxArea = len * heights[current] > maxArea ? len * heights[current] : maxArea;
                }
                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                var maxIndex = stack.Pop();

                //为什么用heights.Length：可以想象在heights.Length的位置有一个高度为0的木板；
                //最后一个出栈的元素，肯定是全局最小的元素，因此len就等于heights.Length；
                var len = stack.Count > 0 ? heights.Length-1 - stack.Peek() : heights.Length;
                maxArea = len * heights[maxIndex] > maxArea ? len * heights[maxIndex] : maxArea;
            }

            return maxArea;
        }
    }
}
