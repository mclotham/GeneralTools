using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Mcl.Utilities
{
    public class BaseConvert
    {
        /// <summary>
        /// Some predefined base digits strings
        /// 
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
        public const string Base10Digits = "0123456789";
        public const string Base16Digits = "0123456789ABCDEF";
        public const string Base36Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Base62Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public const string Base64Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/";

        /// <summary>
        /// Converts an unsigned integer to the specified number base as a string representation
        /// </summary>
        /// <param name="inputValue">Integer value to convert</param>
        /// <param name="baseDigits">Number base digits</param>
        /// <param name="numPadChars">Minimum number of characters for returned string</param>
        /// <returns>
        /// String representation of converted number
        /// </returns>
        /// <exception cref="BaseConvertException">Thrown if <c>baseDigits</c> contains one or more duplicate characters</exception>
        public static string ToBase( UInt64 inputValue, string baseDigits, int numPadChars = 0 )
        {
            if ( baseDigits.ContainsDuplicateChars() )
                throw new BaseConvertException( "Base Digits string contains one or more duplicates: " + baseDigits );

            StringBuilder builder = new StringBuilder();

            if ( inputValue == 0 )
                builder.Insert( 0, baseDigits[0] );
            else
                while ( inputValue > 0 )
                {
                    int remainder = (int)( inputValue % (UInt64)( baseDigits.Length ) );
                    builder.Insert( 0, baseDigits[remainder] );

                    inputValue /= (UInt64)baseDigits.Length;
                }

            return builder.ToString().PadLeft( numPadChars, baseDigits[0] );
        }

        /// <summary>
        /// Converts an unsigned integer to the specified number base as a string representation
        /// </summary>
        /// <param name="inputValue">Integer value to convert</param>
        /// <param name="baseDigits">Number base digits</param>
        /// <param name="numPadChars">Minimum number of characters for returned string</param>
        /// <returns>
        /// String representation of converted number
        /// </returns>
        /// <exception cref="BaseConvertException">Thrown if <c>baseDigits</c> contains one or more duplicate characters or if <c>inputValue is negative</c></exception>
        public static string ToBase( BigInteger inputValue, string baseDigits, int numPadChars = 0 )
        {
            if ( inputValue.Sign == -1 )
                throw new BaseConvertException( "Cannot do base conversion of a negative number: " + inputValue );
            if ( baseDigits.ContainsDuplicateChars() )
                throw new BaseConvertException( "Base Digits string contains one or more duplicates: " + baseDigits );

            StringBuilder builder = new StringBuilder();

            if ( inputValue == 0 )
                builder.Insert( 0, baseDigits[0] );
            else
                while ( inputValue > 0 )
                {
                    int remainder = (int)( inputValue % ( baseDigits.Length ) );
                    builder.Insert( 0, baseDigits[remainder] );

                    inputValue = BigInteger.Divide( inputValue, baseDigits.Length );
                }

            return builder.ToString().PadLeft( numPadChars, baseDigits[0] );
        }

        /// <summary>
        /// Converts a string representation of a value from its number base to an unsigned integer
        /// </summary>
        /// <param name="inputValueString">String representation of the value to convert</param>
        /// <param name="baseDigits">Number base digits</param>
        /// <returns>
        /// Converted unsigned integer
        /// </returns>
        /// <exception cref="BaseConvertException">Thrown if <c>baseDigits</c> contains one or more duplicate characters or if <c>inputValueString contains digits that are not base digits</c></exception>
        public static UInt64 FromBase(string inputValueString, string baseDigits)
        {
            if ( baseDigits.ContainsDuplicateChars() )
                throw new BaseConvertException( "Base Digits string contains one or more duplicates: " + baseDigits );

            UInt64 outnum = 0;
            int power = 0;

            while ( inputValueString.Length > 0)
            {
                int index = Array.IndexOf<char>( baseDigits.ToCharArray(), inputValueString[inputValueString.Length - 1]);

                //InputString contains a character that doesn't exist in BaseCharacters. Throw an exception
                if (index == -1)
                    throw new BaseConvertException($"The input string {inputValueString} contains digits that are not base digits. Base digits: {baseDigits}.");

                outnum += ((uint)index * (UInt64)Math.Pow( baseDigits.Length, power));
                inputValueString = inputValueString.Remove(inputValueString.Length - 1);
                power++;
            }

            return outnum;
        }

        /// <summary>
        /// Converts a string representation of a value from its number base to an unsigned integer
        /// </summary>
        /// <param name="inputValueString">String representation of the value to convert</param>
        /// <param name="baseDigits">Number base digits</param>
        /// <returns>
        /// Converted unsigned integer
        /// </returns>
        /// <exception cref="BaseConvertException">Thrown if <c>baseDigits</c> contains one or more duplicate characters or if <c>inputValueString contains digits that are not base digits</c></exception>
        public static BigInteger FromBaseBigInteger( string inputValueString, string baseDigits )
        {
            if ( baseDigits.ContainsDuplicateChars() )
                throw new BaseConvertException( "Base Digits string contains one or more duplicates: " + baseDigits );

            BigInteger outnum = 0;
            int power = 0;

            while ( inputValueString.Length > 0 )
            {
                int index = Array.IndexOf<char>( baseDigits.ToCharArray(), inputValueString[inputValueString.Length - 1] );

                //InputString contains a character that doesn't exist in BaseCharacters. Throw an exception
                if ( index == -1 )
                    throw new BaseConvertException( $"The input string {inputValueString} contains digits that are not base digits. Base digits: {baseDigits}." );

                outnum = BigInteger.Add( outnum, (BigInteger)index * BigInteger.Pow( baseDigits.Length, power ) );
                inputValueString = inputValueString.Remove( inputValueString.Length - 1 );
                power++;
            }

            return outnum;
        }

        public class BaseConvertException : Exception
        {
            public BaseConvertException()
            {
            }

            public BaseConvertException( string message )
                : base( message )
            {
            }

            public BaseConvertException( string message, Exception inner )
                : base( message, inner )
            {
            }
        }

    }
}
