using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 逆波兰表达式求值
    /// </summary>
    class EvalRPNSolution
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> numbers = new Stack<int>();
            foreach(var s in tokens)
            {
                if (!IsOperator(s))
                {
                    numbers.Push(Convert.ToInt32(s));
                }
                else if(numbers.Count >= 2)
                {
                    int right = numbers.Pop();
                    int left = numbers.Pop();
                    switch (s)
                    {
                        case "+":
                            numbers.Push(right + left);
                            break;
                        case "-":
                            numbers.Push(left - right);
                            break;
                        case "*":
                            numbers.Push(left * right);
                            break;
                        case "/":
                            numbers.Push(left / right);
                            break;
                            
                    }
                }
            }

            int result = numbers.Pop();
            return result;
        }

        private bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }
    }
}
