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
            Stack<char> myStack = new Stack<char>();
            string currentSegment = string.Empty;
            string output = string.Empty;
            
            for (int i = 0; i < input.Length; i++)
            {
                // identify the targeted substring
                if (input[i] == '(')
                {
                    i++;
                    while (input[i] != ')')
                    {
                        myStack.Push(input[i]);
                        i++;
                    }
                    // reversing the targeted substring and add it to the output string
                    foreach (var ch in myStack)
                    {
                        output += ch;
                    }
                    // clear the stack for the next targeted substring
                    myStack.Clear();
                }
                else
                {
                    // add 
                    output += input[i];
                }
            }
            return output;
        }
    }
}
