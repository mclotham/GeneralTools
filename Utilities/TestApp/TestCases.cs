using Mcl.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
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
            var random = new Random();

            var randomNumU64 = (UInt64)random.Next() * (UInt64)random.Next();
            string wackyBaseDigits = @"!@#$%^&*()_+[]{}|\;:,./<>?";
            BigInteger bigInt = (BigInteger)randomNumU64 * (BigInteger)randomNumU64;
            string b10min, b16min, b36min, b62min, b64min, bwkmin, b10max, b16max, b36max, b62max, b64max, bwkmax,
                b10rnd, b16rnd, b36rnd, b62rnd, b64rnd, bwkrnd, b10bnt, b16bnt, b36bnt, b62bnt, b64bnt, bwkbnt;
            Console.WriteLine( "***Minimum Value {0}", UInt64.MinValue );
            Console.WriteLine( "To Base 10: {0}", b10min = BaseConvert.ToBase( UInt64.MinValue, BaseConvert.Base10Digits ) );
            Console.WriteLine( "To Base 16: {0}", b16min = BaseConvert.ToBase( UInt64.MinValue, BaseConvert.Base16Digits ) );
            Console.WriteLine( "To Base 36: {0}", b36min = BaseConvert.ToBase( UInt64.MinValue, BaseConvert.Base36Digits ) );
            Console.WriteLine( "To Base 62: {0}", b62min = BaseConvert.ToBase( UInt64.MinValue, BaseConvert.Base62Digits ) );
            Console.WriteLine( "To Base 64: {0}", b64min = BaseConvert.ToBase( UInt64.MinValue, BaseConvert.Base64Digits ) );
            Console.WriteLine( "To Base Wacky: {0}", bwkmin = BaseConvert.ToBase( UInt64.MinValue, wackyBaseDigits ) );
            Console.WriteLine( "From Base 10: {0}", BaseConvert.FromBase( b10min, BaseConvert.Base10Digits ) );
            Console.WriteLine( "From Base 16: {0}", BaseConvert.FromBase( b16min, BaseConvert.Base16Digits ) );
            Console.WriteLine( "From Base 36: {0}", BaseConvert.FromBase( b36min, BaseConvert.Base36Digits ) );
            Console.WriteLine( "From Base 62: {0}", BaseConvert.FromBase( b62min, BaseConvert.Base62Digits ) );
            Console.WriteLine( "From Base 64: {0}", BaseConvert.FromBase( b64min, BaseConvert.Base64Digits ) );
            Console.WriteLine( "From Base Wacky: {0}", BaseConvert.FromBase( bwkmin, wackyBaseDigits ) );

            Console.WriteLine( "\n***Maximum Value {0}", UInt64.MaxValue );
            Console.WriteLine( "To Base 10: {0}", b10max = BaseConvert.ToBase( UInt64.MaxValue, BaseConvert.Base10Digits ) );
            Console.WriteLine( "To Base 16: {0}", b16max = BaseConvert.ToBase( UInt64.MaxValue, BaseConvert.Base16Digits ) );
            Console.WriteLine( "To Base 36: {0}", b36max = BaseConvert.ToBase( UInt64.MaxValue, BaseConvert.Base36Digits ) );
            Console.WriteLine( "To Base 62: {0}", b62max = BaseConvert.ToBase( UInt64.MaxValue, BaseConvert.Base62Digits ) );
            Console.WriteLine( "To Base 64: {0}", b64max = BaseConvert.ToBase( UInt64.MaxValue, BaseConvert.Base64Digits ) );
            Console.WriteLine( "To Base Wacky: {0}", bwkmax = BaseConvert.ToBase( UInt64.MaxValue, wackyBaseDigits ) );
            Console.WriteLine( "From Base 10: {0}", BaseConvert.FromBase( b10max, BaseConvert.Base10Digits ) );
            Console.WriteLine( "From Base 16: {0}", BaseConvert.FromBase( b16max, BaseConvert.Base16Digits ) );
            Console.WriteLine( "From Base 36: {0}", BaseConvert.FromBase( b36max, BaseConvert.Base36Digits ) );
            Console.WriteLine( "From Base 62: {0}", BaseConvert.FromBase( b62max, BaseConvert.Base62Digits ) );
            Console.WriteLine( "From Base 64: {0}", BaseConvert.FromBase( b64max, BaseConvert.Base64Digits ) );
            Console.WriteLine( "From Base Wacky: {0}", BaseConvert.FromBase( bwkmax, wackyBaseDigits ) );

            Console.WriteLine( "\n***Random Value {0}", randomNumU64 );
            Console.WriteLine( "To Base 10: {0}", b10rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base10Digits ) );
            Console.WriteLine( "To Base 16: {0}", b16rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base16Digits ) );
            Console.WriteLine( "To Base 36: {0}", b36rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base36Digits ) );
            Console.WriteLine( "To Base 62: {0}", b62rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base62Digits ) );
            Console.WriteLine( "To Base 64: {0}", b64rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base64Digits ) );
            Console.WriteLine( "To Base Wacky: {0}", bwkrnd = BaseConvert.ToBase( randomNumU64, wackyBaseDigits ) );
            Console.WriteLine( "From Base 10: {0}", BaseConvert.FromBase( b10rnd, BaseConvert.Base10Digits ) );
            Console.WriteLine( "From Base 16: {0}", BaseConvert.FromBase( b16rnd, BaseConvert.Base16Digits ) );
            Console.WriteLine( "From Base 36: {0}", BaseConvert.FromBase( b36rnd, BaseConvert.Base36Digits ) );
            Console.WriteLine( "From Base 62: {0}", BaseConvert.FromBase( b62rnd, BaseConvert.Base62Digits ) );
            Console.WriteLine( "From Base 64: {0}", BaseConvert.FromBase( b64rnd, BaseConvert.Base64Digits ) );
            Console.WriteLine( "From Base Wacky: {0}", BaseConvert.FromBase( bwkrnd, wackyBaseDigits ) );

            Console.WriteLine( "\n***Bigint Value {0}", bigInt );
//            Console.WriteLine( "To Base 10:   {0}", b10bnt = BaseConvert.ToBase( BigInteger.Parse( "307904046869357317162525862325927969"), BaseConvert.Base10Digits ) );
            Console.WriteLine( "To Base 10: {0}", b10bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base10Digits ) );
            Console.WriteLine( "To Base 16: {0}", b16bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base16Digits ) );
            Console.WriteLine( "To Base 36: {0}", b36bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base36Digits ) );
            Console.WriteLine( "To Base 62: {0}", b62bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base62Digits ) );
            Console.WriteLine( "To Base 64: {0}", b64bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base64Digits ) );
            Console.WriteLine( "To Base Wacky: {0}", bwkbnt = BaseConvert.ToBase( bigInt, wackyBaseDigits ) );
            Console.WriteLine( "From Base 10: {0}", BaseConvert.FromBaseBigInteger( b10bnt, BaseConvert.Base10Digits ) );
            Console.WriteLine( "From Base 16: {0}", BaseConvert.FromBaseBigInteger( b16bnt, BaseConvert.Base16Digits ) );
            Console.WriteLine( "From Base 36: {0}", BaseConvert.FromBaseBigInteger( b36bnt, BaseConvert.Base36Digits ) );
            Console.WriteLine( "From Base 62: {0}", BaseConvert.FromBaseBigInteger( b62bnt, BaseConvert.Base62Digits ) );
            Console.WriteLine( "From Base 64: {0}", BaseConvert.FromBaseBigInteger( b64bnt, BaseConvert.Base64Digits ) );
            Console.WriteLine( "From Base Wacky: {0}", BaseConvert.FromBaseBigInteger( bwkbnt, wackyBaseDigits ) );

            Console.WriteLine( "\n\n***ADD PADDING***********************************" );
            Console.WriteLine( "\n***Random Value {0}", randomNumU64 );
            Console.WriteLine( "To Base 10: {0}", b10rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base10Digits, 15 ) );
            Console.WriteLine( "To Base 16: {0}", b16rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base16Digits, 15 ) );
            Console.WriteLine( "To Base 36: {0}", b36rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base36Digits, 15 ) );
            Console.WriteLine( "To Base 62: {0}", b62rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base62Digits, 15 ) );
            Console.WriteLine( "To Base 64: {0}", b64rnd = BaseConvert.ToBase( randomNumU64, BaseConvert.Base64Digits, 15 ) );
            Console.WriteLine( "To Base Wacky: {0}", bwkrnd = BaseConvert.ToBase( randomNumU64, wackyBaseDigits, 15 ) );
            Console.WriteLine( "From Base 10: {0}", BaseConvert.FromBase( b10rnd, BaseConvert.Base10Digits ) );
            Console.WriteLine( "From Base 16: {0}", BaseConvert.FromBase( b16rnd, BaseConvert.Base16Digits ) );
            Console.WriteLine( "From Base 36: {0}", BaseConvert.FromBase( b36rnd, BaseConvert.Base36Digits ) );
            Console.WriteLine( "From Base 62: {0}", BaseConvert.FromBase( b62rnd, BaseConvert.Base62Digits ) );
            Console.WriteLine( "From Base 64: {0}", BaseConvert.FromBase( b64rnd, BaseConvert.Base64Digits ) );
            Console.WriteLine( "From Base Wacky: {0}", BaseConvert.FromBase( bwkrnd, wackyBaseDigits ) );

            Console.WriteLine( "\n***Bigint Value {0}", bigInt );
            //            Console.WriteLine( "To Base 10:   {0}", b10bnt = BaseConvert.ToBase( BigInteger.Parse( "307904046869357317162525862325927969"), BaseConvert.Base10Digits ) );
            Console.WriteLine( "To Base 10: {0}", b10bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base10Digits, 35 ) );
            Console.WriteLine( "To Base 16: {0}", b16bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base16Digits, 35 ) );
            Console.WriteLine( "To Base 36: {0}", b36bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base36Digits, 35 ) );
            Console.WriteLine( "To Base 62: {0}", b62bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base62Digits, 35 ) );
            Console.WriteLine( "To Base 64: {0}", b64bnt = BaseConvert.ToBase( bigInt, BaseConvert.Base64Digits, 35 ) );
            Console.WriteLine( "To Base Wacky: {0}", bwkbnt = BaseConvert.ToBase( bigInt, wackyBaseDigits, 35 ) );
            Console.WriteLine( "From Base 10: {0}", BaseConvert.FromBaseBigInteger( b10bnt, BaseConvert.Base10Digits ) );
            Console.WriteLine( "From Base 16: {0}", BaseConvert.FromBaseBigInteger( b16bnt, BaseConvert.Base16Digits ) );
            Console.WriteLine( "From Base 36: {0}", BaseConvert.FromBaseBigInteger( b36bnt, BaseConvert.Base36Digits ) );
            Console.WriteLine( "From Base 62: {0}", BaseConvert.FromBaseBigInteger( b62bnt, BaseConvert.Base62Digits ) );
            Console.WriteLine( "From Base 64: {0}", BaseConvert.FromBaseBigInteger( b64bnt, BaseConvert.Base64Digits ) );
            Console.WriteLine( "From Base Wacky: {0}", BaseConvert.FromBaseBigInteger( bwkbnt, wackyBaseDigits ) );

            Console.WriteLine( "\n***Invalid base characters" );
            Console.WriteLine( "***Random Value {0}", randomNumU64 );
            try
            {
                Console.WriteLine( "To Base 10: {0}", b10rnd = BaseConvert.ToBase( randomNumU64, "012344567890", 15 ) );

            }
            catch ( BaseConvert.BaseConvertException e )
            {
                Console.WriteLine( "***EXCEPTION!!! " + e.Message );
            }

            Console.WriteLine( "\n***Invalid base characters BigInt" );
            Console.WriteLine( "***BigInt Value {0}", bigInt );
            try
            {
                Console.WriteLine( "To Base 10: {0}", b10bnt = BaseConvert.ToBase( bigInt, "012344567890", 15 ) );

            }
            catch ( BaseConvert.BaseConvertException e )
            {
                Console.WriteLine( "***EXCEPTION!!! " + e.Message );
            }

            Console.WriteLine( "\n***Negative value BigInt" );
            Console.WriteLine( "***BigInt Value {0}", -1 * bigInt );
            try
            {
                Console.WriteLine( "To Base 10: {0}", b10bnt = BaseConvert.ToBase( -1 * bigInt, "01234567890", 15 ) );

            }
            catch ( BaseConvert.BaseConvertException e )
            {
                Console.WriteLine( "***EXCEPTION!!! " + e.Message );
            }

            Console.WriteLine( "\n***Invalid digits" );
            Console.WriteLine( "***From Base: {0}", BaseConvert.Base10Digits );
            try 
            {
                Console.WriteLine( "Input value: {0}, Number representation {1}", b64rnd, BaseConvert.FromBase( b64rnd, BaseConvert.Base10Digits ) );
            }
            catch ( BaseConvert.BaseConvertException e )
            {
                Console.WriteLine( "***EXCEPTION!!! " + e.Message );
            }

            Console.WriteLine( "\n***Invalid digits BigInt" );
            Console.WriteLine( "***From Base: {0}", BaseConvert.Base10Digits );
            try
            {
                Console.WriteLine( "Input value: {0}, Number representation {1}", b64bnt, BaseConvert.FromBaseBigInteger( b64bnt, BaseConvert.Base10Digits ) );
            }
            catch ( BaseConvert.BaseConvertException e )
            {
                Console.WriteLine( "***EXCEPTION!!! " + e.Message );
            }
        }
    }
}
