using System;
using System.Collections.Generic;
using System.Text;

namespace Remove_K_Digits
{
  class Program
  {
    static void Main(string[] args)
    {
      string num = "10";
      int k = 2;
      Solution s = new Solution();
      s.RemoveKdigits(num, k);
    }
  }

  public class Solution
  {
    public string RemoveKdigits(string num, int k)
    {
      // Algo intiution
      // We have to look for the peak when to delete an element
      // example - 13582799
      // 1348 till here we have order in increasing order and 8 is the peak after that we see slide
      // we have to be greede and remove the peaks
      // after remove 8 => 1352799
      // now if we can remove another one, will find the peak and remove 
      // 135 till here increasing and after that we see a slide so will remove peak i.e 132799
      // 13 after that we have slide, remove 3 => 12799
      // now as you can see its in creasing order only and no slide, as we know now all elements are at the end are higher
      // if we left say k = 2 more deletion , we can remove the last two directly i.e 99 => 132 is final result

      Stack<char> stk = new Stack<char>();
      foreach (char c in num)
      {
        while (stk.Count > 0 && k > 0 && stk.Peek() > c)
        {
          stk.Pop();
          k--;
        }
        stk.Push(c);
      }

      while (stk.Count > 0 && k > 0)
      {
        stk.Pop();
        k--;
      }

      List<char> builder = new List<char>();
      while (stk.Count > 0)
      {
        builder.Insert(0, stk.Pop());
      }

      while (builder.Count > 0 && builder[0] == '0')
      {
        builder.RemoveAt(0);
      }

      string result = string.Join("", builder);
      return result == string.Empty ? "0" : result;
    }
  }
}
