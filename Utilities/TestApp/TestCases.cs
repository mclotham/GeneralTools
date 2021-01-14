using Mcl.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mcl.Utilities.StringExtensions;

namespace TestApp
{
    public class TestCases
    {
        public static void TestLineBreak()
        {
            string myString = "It has truely been a pleasure writing this method for you.";
            string[] myLines = myString.LineBreak(" ", 15, HandleLongWords.CutOff);
            Console.WriteLine(myString);
            foreach (string line in myLines)
                Console.WriteLine(line);
            Console.WriteLine();

            myString = "It has truely been a superawesomepleasure writing this method for you.";
            myLines = myString.LineBreak(" ", 15, HandleLongWords.CutOff);
            Console.WriteLine(myString);
            foreach (string line in myLines)
                Console.WriteLine(line);
            Console.WriteLine();

            myLines = myString.LineBreak(" ", 15, HandleLongWords.Allow);
            Console.WriteLine(myString);
            foreach (string line in myLines)
                Console.WriteLine(line);
            Console.WriteLine();

            try
            {
                myLines = myString.LineBreak(" ", 15, HandleLongWords.ThrowException);
            }
            catch (LineBreakException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        public static void TestBaseConvert()
        {

        }
    }
}
