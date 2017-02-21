using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "10+8*2+10/9+3*2";
            //Regex rgx = new Regex(@"\+\-\*\/");
            //string s = "3+2*5";
            string[] tab = Regex.Split(s, @"(\D)");
            Stack<string> stack = new Stack<string>();
            List<string> output = new List<string>();
            foreach (var item in tab)
            {
                if (item == "*" || item == "/")
                {
                    if (stack.Peek() == "+" || stack.Peek() == "-")
                        stack.Push(item);
                    else
                    {
                        while (stack.Peek() != "+" && stack.Peek() != "-" && stack.Count != 0)
                        {
                            output.Add(stack.Pop());
                        }
                        stack.Push(item);
                    }
                }
                else if (item == "+" || item == "-")
                {
                    while (stack.Count != 0)
                        output.Add(stack.Pop());
                    stack.Push(item);
                }
                else
                    output.Add(item);
            }
            foreach (var item in stack)
                output.Add(item);
            Stack<double> newStack =new Stack<double>();
            int wynik = 0;
            foreach(var item in output)
            {
                if (item=="+"|| item == "-" || item == "*" || item == "/")
                {
                    double a = newStack.Pop();
                    double b = newStack.Pop();
                    switch (item)
                    {
                        case "+":
                            newStack.Push((a + b));
                            break;
                        case "-":
                            newStack.Push((a - b));
                            break;
                        case "*":
                            newStack.Push((a * b));
                            break;
                        case "/":
                            newStack.Push((a / b));
                            break;
                    }
                }
                else
                    newStack.Push(double.Parse(item));
            }
            Console.WriteLine(newStack.Peek());
            Console.ReadLine();
        }
    }
}
