/*
 * Write a C# program to reverse the strings contained in each pair of matching parentheses in a given string and also remove the parentheses within the given string.
 * Example: "This (si) my (elpmaxe)." will return "This is my example."
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringsInParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.Write("\nInput a statements with two parentheses.\n\n>>> ");
                    var input = Console.ReadLine();
                    Console.WriteLine($"\n{ReverseStringsInParentheses(input)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                }
                Console.Write("\nPress Enter to do another merge...");
                Console.ReadLine();
                Console.Clear();
            } while (true);
        }

        static string ReverseStringsInParentheses(string input)
        {
            List<string> segments = new List<string>();
            Stack<char> myStack = new Stack<char>();
            string currentSegment = string.Empty;
            string output = string.Empty;
            
            // removes the parentheses and puts the target substrings in indicies 1 and 3
            foreach(var ch in input)
            {
                if (ch == '(' || ch == ')')
                {
                    segments.Add(currentSegment);
                    currentSegment = string.Empty;
                }
                else
                {
                    currentSegment += ch;
                }
            }
            segments.Add(currentSegment);

            // reversing the target substrings
            for (int i = 1; i < 4; i += 2)
            {
                foreach (var ch in segments[i])
                {
                    myStack.Push(ch);
                }
                segments[i] = string.Empty;
                foreach (var ch in myStack)
                {
                    segments[i] += ch;
                }
                myStack.Clear();
            }

            // rebuilding the input string with the target substrings reversed
            foreach(var segment in segments)
            {
                output += segment;
            }

            return output;
        }
    }
}
