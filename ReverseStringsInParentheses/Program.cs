/*
 * Write a C# program to reverse the strings contained in each pair of matching parentheses in a given string and also remove the parentheses within the given string.
 * Example: "This (si) my (elpmaxe)." will return "This is my example."
 */

using System;
using System.Collections.Generic;

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
            if (!input.Contains("("))
            {
                return input;
            }
            else
            {
                Stack<char> myStack = new Stack<char>();
                string output = string.Empty;
                string backup = string.Empty;

                for (int i = 0; i < input.Length; i++)
                {
                    // identify the targeted substring
                    if (input[i] == '(')
                    {
                        // creating a backup substring in case there is a nested parentheses
                        backup += input[i];
                        while (input[++i] != ')')
                        {
                            if (input[i] == '(')
                            {
                                // using the backup substring to retain the original order of characters
                                output += backup;
                                // restarting the backup substring
                                backup = string.Empty;
                                // restarting the stack
                                myStack.Clear();
                            }
                            else
                            {
                                backup += input[i];
                                myStack.Push(input[i]);
                            }
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
                        output += input[i];
                    }
                }
                return ReverseStringsInParentheses(output);
            }
        }
    }
}
