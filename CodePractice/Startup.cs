using System.Diagnostics;
using static CodePractice.KataCodePractice;
using static CodePractice.LeetCodePractice;

namespace CodePractice
{
    public class Startup
    {
        static void Main(string[] args)
        {
            #region CodeWars KataCodePractice Invocations
            //TestingFunction(FiveStringReverse, "This is totally crazy man!");

            //TestingFunction(FindEvenIndex, new int[] { 1, 2, 3, 4, 3, 2, 1 });

            //TestingFunction(DescendingOrderBubbleSort, 12345);
            //TestingFunction(DescendingOrderLinq, 12345);

            //TestingFunction(Multiple3Or5Summed, 10);

            //TestingFunction(DuplicatesInString, "aabbccdda");

            //string u = "I should have known that you would have a perfect answer for me!!!";
            //Console.WriteLine(string.Join(" ", movingShift(u, 1)));
            //Console.WriteLine(demovingShift(movingShift(u, 1), 1));

            //TwoSum(new int[] { 3, 2, 4 }, 6);

            ////Create the first number: 243(represents 342 in reverse)
            //ListNode l1 = new ListNode(3);
            //l1.next = new ListNode(4);
            //l1.next.next = new ListNode(2);

            ////Create the second number: 465(represents 564 in reverse)
            //ListNode l2 = new ListNode(5);
            //l2.next = new ListNode(6);
            //l2.next.next = new ListNode(4);

            ////Call the AddTwoNumbers method to get the sum
            //AddTwoNumbers(l1, l2);

            ////Split Strings
            //TestingFunction(SplitString, "abcdef");
            //TestingFunction(SplitString, "abc");

            ////Roman Numerals Decoder
            //TestingFunction(RomanNumeralsDecoder, "MMVIII");
            //TestingFunction(RomanNumeralsDecoder, "MCMLIV");

            ////Roman Numerals Encode
            //string test = RomanNumeralsEncode(1954);
            //Console.WriteLine(test);

            //// Elemental Forms
            //ElementalForms("snacks");
            #endregion

            #region LeetCode LeetCodePractice Invocations
            LetterCombinationsOfPhoneNumber("297");
            #endregion
        }

        // Helper method achieving the method:
        //  1. Print the output of the function passed in and the function's name
        //  2. Time the function using StopWatch
        //  3. Determine it's algorithmic complexity
        static void TestingFunction<T1, TResult>(Func<T1, TResult> function, T1 arg)
        {
            Console.WriteLine($"Testing method: {function.Method.Name}");

            Stopwatch sw = new Stopwatch();

            sw.Start();
            TResult result = function(arg);
            sw.Stop();

            // Print execution time
            Console.WriteLine($"Execution time: {sw.Elapsed.TotalMilliseconds}ms");

            // Print the method's return value
            Console.WriteLine($"Method result: {result}");

            // Determine the algorithmic complexity
            Console.WriteLine("Algorithmic complexity: O(?)\n");
        }
    }
}