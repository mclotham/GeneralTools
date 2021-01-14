using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Mcl.Utilities
{
    class BaseConvert
    {
        /// <summary>
        /// Caution when using the constants for base digits. Pay attention to case sensitivity.
        /// Example:
        /// when using Base16Digits
        ///     string myString = "01fa10";
        ///     Int64 myNumber = BaseConvert.FromBase( myString, BaseConvert.Base16Digits );
        /// will cause an exception.
        /// Instead use
        ///     string myString = "01fa10";
        ///     Int64 myNumber = BaseConvert.FromBase( myString.ToUpper(), BaseConvert.Base16Digits );
        /// </summary>
        public const string Base16Digits = "0123456789ABCDEF";
        public const string Base32Digits = "0123456789ABCDEFGHJKLMNPRTUVWXYZ";
        public const string Base36Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Base62Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public const string Base64Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/";

        public static string ToBase(UInt64 inputValue, string baseDigits, int numPadChars)
        {
            if (baseDigits.ContainsDuplicateChars())
                throw new BaseConvertException ( "Base Digits string contains one or more duplicates: " + baseDigits );

            StringBuilder builder = new StringBuilder();

            while (inputValue > 0)
            {
                int remainder = (int)(inputValue % (UInt64)(baseDigits.Length));
                builder.Insert(0, baseDigits[remainder]);

                inputValue /= (UInt64)baseDigits.Length;
            }

            return builder.ToString().PadLeft(numPadChars, baseDigits[0]);
        }

        public static string ToBase(BigInteger inputValueString, string baseDigits, int numPadChars)
        {
            if (baseDigits.ContainsDuplicateChars())
                throw new BaseConvertException("Base Digits string contains one or more duplicates: " + baseDigits);

            StringBuilder builder = new StringBuilder();

            while (inputValueString > 0)
            {
                int remainder = (int)(inputValueString % (baseDigits.Length));
                builder.Insert(0, baseDigits[remainder]);

                inputValueString /= baseDigits.Length;
            }

            return builder.ToString().PadLeft(numPadChars, baseDigits[0]);
        }

        public static UInt64 FromBase(string inputValueString, string baseCharacters)
        {
            UInt64 outnum = 0;
            long power = 0;

            while (inputValueString.Length > 0)
            {
                int index = (int)Array.IndexOf<char>(baseCharacters.ToCharArray(), inputValueString[inputValueString.Length - 1]);

                //InputString contains a character that doesn't exist in BaseCharacters. Throw an exception
                if (index == -1)
                    throw new BaseConvertException("The input string contains a digit that is not a base digit.");

                outnum += ((uint)index * (UInt64)Math.Pow(baseCharacters.Length, power));
                inputValueString = inputValueString.Remove(inputValueString.Length - 1);
                power++;
            }

            return outnum;
        }

        public static BigInteger FromBaseBigInteger(string inputString, string baseCharacters)
        {
            BigInteger outnum = 0;
            long power = 0;

            while (inputString.Length > 0)
            {
                int index = (int)Array.IndexOf<char>(baseCharacters.ToCharArray(), inputString[inputString.Length - 1]);

                //InputString contains a character that doesn't exist in BaseCharacters. Throw an exception
                if (index == -1)
                    throw new BaseConvertException("The input string contains a digit that is not a base digit.");

                outnum += ((uint)index * (BigInteger)Math.Pow(baseCharacters.Length, power));
                inputString = inputString.Remove(inputString.Length - 1);
                power++;
            }

            return outnum;
        }

        public class BaseConvertException : Exception
        {
            public BaseConvertException()
            {
            }

            public BaseConvertException(string message)
                : base(message)
            {
            }

            public BaseConvertException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

    }
}
