using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// 生成所有可能的合法括号组合
    /// </summary>
    public class GenerateParenthesis
    {
        //回溯算法
        public IList<string> GenerateParenthesis_backtrack(int n)
        {
            List<string> result = new List<string>();
            char[] str = new char[2*n];
            GetAllParentthesis(str, 0, result, 0 , 0);

            return result;
        }

        private List<string> GetAllParentthesis(char[] current, int pos, List<string> result, int leftCount, int leftCurrent)
        {
            if(pos == current.Length)
            {
                result.Add(new string(current));
            }
            else
            {
                if(leftCount < current.Length / 2)
                {
                    current[pos] = '(';
                    GetAllParentthesis(current, pos + 1, result, leftCount + 1, leftCurrent + 1);
                }
                if(leftCurrent > 0)
                {
                    current[pos] = ')';
                    GetAllParentthesis(current, pos + 1, result, leftCount, leftCurrent - 1);
                }                
            }

            return result;
        }

        public IList<string> GenerateParenthesis_Force(int n)
        {
            List<string> result = new List<string>();
            char[] str = new char[2 * n];
            GetAllParentthesis(str, 0, result);

            return result;
        }
        private List<string> GetAllParentthesis(char[] current, int pos, List<string> result)
        {
            if (pos == current.Length)
            {
                if (Validate(current))
                {
                    result.Add(new string(current));
                }
            }
            else
            {
                current[pos] = '(';
                GetAllParentthesis(current, pos + 1, result);
                current[pos] = ')';
                GetAllParentthesis(current, pos + 1, result);
            }

            return result;
        }
        private bool Validate(char[] str)
        {
            int balanceIndex = 0;
            foreach (var c in str)
            {
                if (c == '(')
                    balanceIndex++;
                else
                    balanceIndex--;

                if (balanceIndex < 0)
                    return false;
            }
            if (balanceIndex != 0)
                return false;

            return true;
        }
    }
}
