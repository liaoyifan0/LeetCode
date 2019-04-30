using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 最小栈
    /// </summary>
    public class MinStack
    {
        private Stack<int> stack;
        
        public MinStack()
        {
            stack = new Stack<int>();      
        }

        public void Push(int x)
        {
            if(stack.Count == 0)
            {
                stack.Push(x);
                stack.Push(x);
            }
            else
            {
                int temp = stack.Peek();
                stack.Push(x);
                if(temp < x)
                {
                    stack.Push(temp);
                }
                else
                {
                    stack.Push(x);
                }
            }
        }

        public void Pop()
        {
            stack.Pop();
            stack.Pop();
        }

        public int Top()
        {
            int temp = stack.Pop();
            int top = stack.Peek();
            stack.Push(temp);
            return top;
        }

        public int GetMin()
        {
            return stack.Peek();           
        }
    }
}
