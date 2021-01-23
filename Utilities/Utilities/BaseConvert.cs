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
        /// Converts an unsigned integer to
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="baseDigits"></param>
        /// <param name="numPadChars"></param>
        /// <returns></returns>
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

        public static UInt64 FromBase(string inputValueString, string baseCharacters)
        {
            UInt64 outnum = 0;
            int power = 0;

            while (inputValueString.Length > 0)
            {
                int index = Array.IndexOf<char>(baseCharacters.ToCharArray(), inputValueString[inputValueString.Length - 1]);

                //InputString contains a character that doesn't exist in BaseCharacters. Throw an exception
                if (index == -1)
                    throw new BaseConvertException($"The input string {inputValueString} contains digits that are not base digits. Base digits: {baseCharacters}.");

                outnum += ((uint)index * (UInt64)Math.Pow(baseCharacters.Length, power));
                inputValueString = inputValueString.Remove(inputValueString.Length - 1);
                power++;
            }

            return outnum;
        }

        public static BigInteger FromBaseBigInteger( string inputValueString, string baseCharacters )
        {
            BigInteger outnum = 0;
            int power = 0;

            while ( inputValueString.Length > 0 )
            {
                int index = Array.IndexOf<char>( baseCharacters.ToCharArray(), inputValueString[inputValueString.Length - 1] );

                //InputString contains a character that doesn't exist in BaseCharacters. Throw an exception
                if ( index == -1 )
                    throw new BaseConvertException( $"The input string {inputValueString} contains digits that are not base digits. Base digits: {baseCharacters}." );

                outnum = BigInteger.Add( outnum, (BigInteger)index * BigInteger.Pow( baseCharacters.Length, power ) );
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
