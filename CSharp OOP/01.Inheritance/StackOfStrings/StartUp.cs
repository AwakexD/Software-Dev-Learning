using System;

namespace CustomStack
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings myStack = new StackOfStrings();
            
            Console.WriteLine(myStack.IsEmpty());

            string[] arr = new string[10];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = $"Random string:{i}";
            }
            
            myStack.AddRange(arr);
            Console.WriteLine(myStack.IsEmpty());

            Console.WriteLine(String.Join('\n', myStack));
        }
    }
}
