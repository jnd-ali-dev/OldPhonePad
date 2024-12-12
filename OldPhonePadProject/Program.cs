using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadProject
{
    class Program
    {
        public static Dictionary<char, char[]> keypadLayout = new Dictionary<char, char[]>
        {
            {'1', new char[]{'&','\'','('}},
            {'2', new char[]{'A','B','C'}},
            {'3', new char[]{'D','E','F'}},
            {'4', new char[]{'G','H','I'}},
            {'5', new char[]{'J','K','L'}},
            {'6', new char[]{'M','N','O'}},
            {'7', new char[]{'P','Q','R','S'}},
            {'8', new char[]{'T','U','V'}},
            {'9', new char[]{'W','X','Y','Z'}},
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Enter keypad string: ");
            var inputString = Console.ReadLine();
            var output = OldPhonePad(inputString);
            Console.WriteLine("Output string: " + output);
            Console.ReadKey();
        }

        public static String OldPhonePad(string input)
        {
            StringBuilder result = new StringBuilder();
            int digitCount = 0;
            char digit = input[0];

            foreach (char character in input)
            {
                bool appendChar = false;

                // Handling cases when key has to repeat the cycle i.e 2222 = 'A'

                if ((digit != '7' && digit != '9') && digitCount > 3)
                    digitCount = 1;

                if ((digit == '7' || digit == '9') && digitCount > 4)
                    digitCount = 1;

                // Handling pause and special character keys 

                if (digit == '*' || digit == ' ' || digit == '0')
                { 
                    digit = character;
                    digitCount = 0;
                    if (digit == ' ')
                        appendChar = true;
                }

                // Incrementing the index for dictionary in case same digit and no space/pause. Otherwise changing flag to append character 

                if (digit == character)
                    digitCount++;
                else
                    appendChar = true;

                // Appending the charachter and resetting the helping variables
                
                if (appendChar && (digit != ' ' && digit != '*' && digit != '#'))
                {
                    var alphabet = keypadLayout[digit][digitCount - 1];
                    result.Append(alphabet);
                    digit = character;
                    digitCount = 1;
                }

                // Appending space after the character is added

                if (character == '0')
                {
                    result.Append(' ');
                    digitCount = 0;
                    continue;
                }

                // Removing last character in case delete key is passed

                if (character == '*')
                {
                    if(result.Length > 0)
                        result.Remove(result.Length-1, 1);
                    digit = character;
                    digitCount = 0;
                }
            }
            return result.ToString();
        }
    }
}
