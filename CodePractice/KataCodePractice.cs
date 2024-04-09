using System.Diagnostics;
using System.Text;

namespace CodePractice
{
    class KataCodePractice
    {
        static void Main(string[] args)
        {
            //TestingFunction(FiveStringReverse, "This is totally crazy man!");

            //TestingFunction(FindEvenIndex, new int[] { 1, 2, 3, 4, 3, 2, 1 });

            //TestingFunction(DescendingOrderBubbleSort, 12345);
            //TestingFunction(DescendingOrderLinq, 12345);

            //TestingFunction(Multiple3Or5Summed, 10);

            //TestingFunction(DuplicatesInString, "aabbccdda");

            //string u = "I should have known that you would have a perfect answer for me!!!";
            //Console.WriteLine(string.Join(" ", movingShift(u, 1)));
            //Console.WriteLine(demovingShift(movingShift(u, 1), 1));

            //TwoSum(new int[] { 3,2,4 }, 6);

            // Create the first number: 243 (represents 342 in reverse)
            //ListNode l1 = new ListNode(3);
            //l1.next = new ListNode(4);
            //l1.next.next = new ListNode(2);

            // Create the second number: 465 (represents 564 in reverse)
            //ListNode l2 = new ListNode(5);
            //l2.next = new ListNode(6);
            //l2.next.next = new ListNode(4);

            // Call the AddTwoNumbers method to get the sum
            //AddTwoNumbers(l1, l2);

            // Split Strings
            //TestingFunction(SplitString, "abcdef");
            //TestingFunction(SplitString, "abc");

            // Roman Numerals Decoder
            //TestingFunction(RomanNumeralsDecoder, "MMVIII");
            // TestingFunction(RomanNumeralsDecoder, "MCMLIV");

            // Roman Numerals Encode
            //string test = RomanNumeralsEncode(1954);
            //Console.WriteLine(test);#

            // Elemental Forms
            ElementalForms("snacks");
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

        static string FiveStringReverse(string sentence)
        {
            string[] words = sentence.Split(" ");
            StringBuilder newSentence = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length >= 5)
                {
                    var charArray = words[i].ToCharArray();
                    Array.Reverse(charArray);
                    words[i] = new string(charArray);
                }
                var word = i == words.Length - 1 ? words[i] : words[i] + " ";
                newSentence.Append(word);
            }
            return newSentence.ToString();
        }

        // Determine the index at which the sum of the left side and right side of an array are equal, if this doesn't occur return -1
        public static int FindEvenIndex(int[] arr)
        {
            int n = arr.Length;
            int[] left = new int[n];
            int[] right = arr;
            bool equal = false;
            int index = 0;

            while (!equal && index != n)
            {
                int val = right[index];
                right[index] = 0;
                equal = CompareArrays(left, right, index);
                // Return the index where the arrays were equal
                if (equal)
                {
                    return index;
                }
                left[index] = val;
                index++;
            }

            // Return -1 indicating no matching index
            return -1;
        }

        public static bool CompareArrays(int[] arr1, int[] arr2, int index)
        {
            int arr1Sum = 0;
            int arr2Sum = 0;
            foreach (int i in arr1)
            {
                arr1Sum += i;
            }

            foreach (int i in arr2)
            {
                arr2Sum += i;
            }
            Console.WriteLine($"Index {index}, {arr1Sum} == {arr2Sum} = {arr1Sum == arr2Sum}");
            return arr1Sum == arr2Sum ? true : false;
        }

        public static int DescendingOrderBubbleSort(int num)
        {
            char[] nums = num.ToString().ToCharArray();
            char temp;
            int n = nums.Length;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (int.Parse(nums[j].ToString()) < int.Parse(nums[j + 1].ToString()))
                    {
                        temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                {
                    break;
                }
            }

            return int.Parse(string.Concat(nums));
        }

        public static int DescendingOrderLinq(int num)
        {
            return int.Parse(string.Concat(num.ToString().OrderByDescending(m => m)));
        }

        public static int Multiple3Or5Summed(int value)
        {
            if (value <= 0) return 0;
            int sum = 0;

            while (value > 0)
            {
                value--;
                sum += value % 3 == 0 || value % 5 == 0 ? value : 0;
            }

            return sum;
        }
        public static int DuplicatesInString(string str)
        {
            return str.ToLower().GroupBy(x => x).Where(g => g.Count() > 1).Count();
        }

        public static List<string> movingShift(string s, int shift)
        {
            List<string> splitString = s.Split(' ').ToList();
            for (int i = 0; i < splitString.Count - 1; i++)
            {
                var currentString = splitString[i];
                StringBuilder sb = new StringBuilder();
                foreach (var ch in currentString.ToCharArray())
                {
                    sb.Append(ShiftChar(ch, shift));
                }
                splitString[i] = sb.ToString();
            }

            return splitString;
        }

        static char ShiftChar(char original, int shift)
        {
            int asciiValue = (int)original;
            int shiftedCharInt = asciiValue + shift;
            char shiftedChar = (char)shiftedCharInt;
            return (char)shiftedChar;
        }

        public static string demovingShift(List<string> s, int shift)
        {
            for (int i = 0; i < s.Count - 1; i++)
            {
                var currentString = s[i];
                StringBuilder sb = new StringBuilder();
                foreach (var ch in currentString.ToCharArray())
                {
                    sb.Append(ShiftChar(ch, -shift));
                }
                s[i] = sb.ToString();
            }

            return string.Join(" ", s);
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            bool found = false;
            int n = nums.Length;
            int[] indexArr = new int[2];
            for (int i = 0; i < n - 1; i++)
            {
                var currentNum = nums[i];
                for (int j = i + 1; j < n; j++)
                {
                    var comparisonNum = nums[j];
                    if (nums[i] + nums[j] == target)
                    {
                        indexArr[0] = i; indexArr[1] = j;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            return indexArr;
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode();
            ListNode current = dummyHead;
            int carry = 0;

            while (l1 != null || l2 != null || carry > 0)
            {
                int sum = carry;

                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
            }

            return dummyHead.next;
        }

        static string[] SplitString(string str)
        {
            if (str.Length % 2 != 0) str += "_";
            string[] strings = new string[str.Length / 2];

            var n = str.Length;
            int p = 0;
            for (int i = 0; p + 2 <= n; i++, p += 2)
            {
                strings[i] = str.Substring(p, 2);
            }

            return strings;
        }
        public static Dictionary<char, int> romanDictionary = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

        public static int RomanNumeralsDecoder(string roman)
        {
            char[] splitNumerals = roman.ToCharArray();

            int lastNumIndex = splitNumerals.Length - 1;
            int total = romanDictionary[splitNumerals[lastNumIndex]];
            for (int i = lastNumIndex; i > 0; i--) total = romanDictionary[splitNumerals[i - 1]] < romanDictionary[splitNumerals[i]] ? total - romanDictionary[splitNumerals[i - 1]] : total + romanDictionary[splitNumerals[i - 1]];
            return total;
        }

        public static string RomanNumeralsEncode(int num, char current_numeral = 'M', string romanNumeralsString = "")
        {
            if (num == 0) return ReplaceDuplicates(romanNumeralsString);

            int val = romanDictionary[current_numeral];
            int div = num / val;
            int result = num % val;

            for (int i = 0; i < div; i++) romanNumeralsString += current_numeral;

            return RomanNumeralsEncode(result, romanDictionary.OrderByDescending(x => x.Value).FirstOrDefault(x => x.Value < val).Key, romanNumeralsString);
        }

        public static string ReplaceDuplicates(string str)
        {
            str = str.Replace("DCCCC", "CM");
            str = str.Replace("CCCC", "CD");
            str = str.Replace("LXXXX", "XC");
            str = str.Replace("XXXX", "XL");
            str = str.Replace("VIIII", "IX");
            str = str.Replace("IIII", "IV");
            return str;
        }

        public static Dictionary<string, string> Elements = new Dictionary<string, string>() {
            { "H", "Hydrogen" },
            { "He", "Helium" },
            { "Li", "Lithium" },
            { "Be", "Beryllium" },
            { "B", "Boron" },
            { "C", "Carbon" },
            { "N", "Nitrogen" },
            { "O", "Oxygen" },
            { "F", "Fluorine" },
            { "Ne", "Neon" },
            { "Na", "Sodium" },
            { "Mg", "Magnesium" },
            { "Al", "Aluminum" },
            { "Si", "Silicon" },
            { "P", "Phosphorus" },
            { "S", "Sulfur" },
            { "Cl", "Chlorine" },
            { "Ar", "Argon" },
            { "K", "Potassium" },
            { "Ca", "Calcium" },
            { "Sc", "Scandium" },
            { "Ti", "Titanium" },
            { "V", "Vanadium" },
            { "Cr", "Chromium" },
            { "Mn", "Manganese" },
            { "Fe", "Iron" },
            { "Co", "Cobalt" },
            { "Ni", "Nickel" },
            { "Cu", "Copper" },
            { "Zn", "Zinc" },
            { "Ga", "Gallium" },
            { "Ge", "Germanium" },
            { "As", "Arsenic" },
            { "Se", "Selenium" },
            { "Br", "Bromine" },
            { "Kr", "Krypton" },
            { "Rb", "Rubidium" },
            { "Sr", "Strontium" },
            { "Y", "Yttrium" },
            { "Zr", "Zirconium" },
            { "Nb", "Niobium" },
            { "Mo", "Molybdenum" },
            { "Tc", "Technetium" },
            { "Ru", "Ruthenium" },
            { "Rh", "Rhodium" },
            { "Pd", "Palladium" },
            { "Ag", "Silver" },
            { "Cd", "Cadmium" },
            { "In", "Indium" },
            { "Sn", "Tin" },
            { "Sb", "Antimony" },
            { "Te", "Tellurium" },
            { "I", "Iodine" },
            { "Xe", "Xenon" },
            { "Cs", "Cesium" },
            { "Ba", "Barium" },
            { "La", "Lanthanum" },
            { "Ce", "Cerium" },
            { "Pr", "Praseodymium" },
            { "Nd", "Neodymium" },
            { "Pm", "Promethium" },
            { "Sm", "Samarium" },
            { "Eu", "Europium" },
            { "Gd", "Gadolinium" },
            { "Tb", "Terbium" },
            { "Dy", "Dysprosium" },
            { "Ho", "Holmium" },
            { "Er", "Erbium" },
            { "Tm", "Thulium" },
            { "Yb", "Ytterbium" },
            { "Lu", "Lutetium" },
            { "Hf", "Hafnium" },
            { "Ta", "Tantalum" },
            { "W", "Tungsten" },
            { "Re", "Rhenium" },
            { "Os", "Osmium" },
            { "Ir", "Iridium" },
            { "Pt", "Platinum" },
            { "Au", "Gold" },
            { "Hg", "Mercury" },
            { "Tl", "Thallium" },
            { "Pb", "Lead" },
            { "Bi", "Bismuth" },
            { "Po", "Polonium" },
            { "At", "Astatine" },
            { "Rn", "Radon" },
            { "Fr", "Francium" },
            { "Ra", "Radium" },
            { "Ac", "Actinium" },
            { "Th", "Thorium" },
            { "Pa", "Protactinium" },
            { "U", "Uranium" },
            { "Np", "Neptunium" },
            { "Pu", "Plutonium" },
            { "Am", "Americium" },
            { "Cm", "Curium" },
            { "Bk", "Berkelium" },
            { "Cf", "Californium" },
            { "Es", "Einsteinium" },
            { "Fm", "Fermium" },
            { "Md", "Mendelevium" },
            { "No", "Nobelium" },
            { "Lr", "Lawrencium" },
            { "Rf", "Rutherfordium" },
            { "Db", "Dubnium" },
            { "Sg", "Seaborgium" },
            { "Bh", "Bohrium" },
            { "Hs", "Hassium" },
            { "Mt", "Meitnerium" },
            { "Ds", "Darmstadtium" },
            { "Rg", "Roentgenium" },
            { "Cn", "Copernicium" },
            { "Nh", "Nihonium" },
            { "Fl", "Flerovium" },
            { "Mc", "Moscovium" },
            { "Lv", "Livermorium" },
            { "Ts", "Tennessine" },
            { "Og", "Oganesson" }
        };


        public static string[][] ElementalForms(string word)
        {
            List<string> elements = Elements.Keys.ToList().ForEach(e => { e.ToLower(); });
            int n = word.Length;
            int r = 1;
            for (int l = 0; l < n - 1; l++)
            {
                string outVal = "";
                Elements.TryGetValue(word.Substring(l, r), out outVal);

            }

            return new string[0][];
        }
    }
}
