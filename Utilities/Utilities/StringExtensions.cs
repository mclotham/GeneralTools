using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Mcl.Utilities
{
    public enum HandleLongWords
    {
        CutOff,
        Allow,
        ThrowException,
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Counts the number of occurrences of a specific character in a string
        /// </summary>
        /// <param name="str">This string</param>
        /// <param name="character">The character to be counted</param>
        /// <returns>
        /// The number of occurrences of the specified character
        /// </returns>
        public static int SpecificCharCount( this string str, char character )
        {
            var charCount = 0;

            foreach (char c in str)
                if (c == character)
                    charCount++;

            return charCount;
        }

        /// <summary>
        /// Determines if there are duplicate characters in the string
        /// </summary>
        /// <param name="str">This string</param>
        /// <returns>
        /// <c>true</c> if there are duplicate(s) of any character in the string
        /// </returns>
        public static bool ContainsDuplicateChars( this string str)
        {
            foreach (char c in str)
                if (str.SpecificCharCount(c) > 1)
                    return true;

            return false;
        }

        public static byte[] ToByteArray(this string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        /// <summary>
        /// Breaks the string into 1 or more strings based on the delimiter and the maximum number of characters per line
        /// </summary>
        /// <example>
        /// <code>
        /// string myString = "It has truely been a pleasure writing this method for you.";
        /// string[] myLines = myString.LineBreak(" ", 15, HandleLongWords.CutOff);
        ///     foreach (string line in myLines)
        ///         Console.WriteLine(line);
        /// </code>
        /// Output:
        /// It has truely
        /// been a pleasure
        /// writing this
        /// method for you.
        /// </example>
        /// <param name="str">This string</param>
        /// <param name="separator">Separator or delimitter between words</param>
        /// <param name="maxLength">Maximum length of each string in the returned array</param>
        /// <param name="handleLongWords">Flag indicating how to handle words longer than maxLength</param>
        /// <returns>An array of strings</returns>
        /// <exception cref="LineBreakException">Thrown when <c>handleLongWords = HandleLongWords.ThrowException</c> 
        /// and a string token in the original string is longer than <c>maxLength</c></exception>
        public static string[] LineBreak(this String str, string separator, int maxLength, HandleLongWords handleLongWords = HandleLongWords.CutOff)
        {
            if (str == null)
                return new string[0];

            var tokens = str.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var lines = new List<string>();

            var line = "";
            for (var tokenIdx = 0; tokenIdx < tokens.Length; tokenIdx++)
            {
                var tmpBrkStr = (lines.Count() == 0 && (line.Length == 0 || line == separator)) ? "" : separator;
                if ((line + tmpBrkStr + tokens[tokenIdx]).Length <= maxLength)
                {
                    line += tmpBrkStr + tokens[tokenIdx];
                    if (tokenIdx >= tokens.Length - 1)
                        lines.Add(line);
                }
                else
                if (tokens[tokenIdx].Length > maxLength)
                {
                    if (handleLongWords == HandleLongWords.Allow || handleLongWords == HandleLongWords.CutOff)
                    {
                        if (line.Length > 0)
                            lines.Add(line);
                        line = tokens[tokenIdx];
                        if (handleLongWords == HandleLongWords.CutOff && line.Length > maxLength)
                            line = line.Substring(0, maxLength);
                        if (tokenIdx >= tokens.Length - 1)
                            lines.Add(line);
                    }
                    else
                        throw new LineBreakException( $"String contains word \'{tokens[tokenIdx]}\' longer that maxLength {maxLength}");
                }
                else
                {
                    if (line.Length > 0)
                        lines.Add(line);
                    line = tokens[tokenIdx];
                    if (tokenIdx >= tokens.Length - 1)
                        lines.Add(line);
                }
            }

            return lines.ToArray();
        }

        public class LineBreakException : Exception
        {
            public LineBreakException()
            {
            }

            public LineBreakException(string message)
                : base(message)
            {
            }

            public LineBreakException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

    }
}
