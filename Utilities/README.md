# Utilities

This project contains classes and methods that are found to be commonly used in other software systems. The package contains the following classes.

* **BaseConvert** - Number base conversion
* **StringExtensions** - Methods for extending string type

---
## BaseConvert
<h4><u>Constants</u></h4>

The following base digit strings are predefined in the BaseConvert class. Base digit strings contain all digits in a number base. The order of digits in the string is lowest value (usually 0) to highest value.


```public const string Base10Digits = "0123456789";```  
```public const string Base16Digits = "0123456789ABCDEF"; ```  
```public const string Base36Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"; ```  
```public const string Base62Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"; ```  
```public const string Base64Digits =  "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/"; ```

<h4><u>Methods</u></h4>

#### ToBase - UInt64
Converts an unsigned integer to a string representation of a specified number base.

``` public static string ToBase( UInt64 inputValue, string baseDigits, int numPadChars = 0 ) ```

##### Parameters

* *inputValue* - Integer value to convert.
* *baseDigits* - Number base digits from lowest value to highest value.
* *numPadChars* - Minimum number of characters for the return value. The value will be padded with the lowest value digit if needed.

##### Return Value
string representation of *inputValue* converted to the number base specified by *baseDigits*.

##### Exceptions
*BaseConvertException* - Thrown if *baseDigits* contains one or more duplicate characters.


#### ToBase - BigInteger
Converts an unsigned integer to a string representation of a specified number base.

``` public static string ToBase( BigInteger inputValue, string baseDigits, int numPadChars = 0 ) ```

##### Parameters

* *inputValue* - Integer value to convert.
* *baseDigits* - Number base digits from lowest value to highest value.
* *numPadChars* - Minimum number of characters for the return value. The value will be padded with the lowest value digit if needed.

##### Return Value
string representation of *inputValue* converted to the number base specified by *baseDigits*.

##### Exceptions
*BaseConvertException* - Thrown if *baseDigits* contains one or more duplicate characters OR if *inputValue* is negative.

#### FromBase
Converts a string representation of a specified number base to an unsigned integer.

``` public static UInt64 FromBase(string inputValueString, string baseDigits) ```

##### Parameters

* *inputValueString* - String representation of value to convert.
* *baseDigits* - Number base digits from lowest value to highest value.

##### Return Value
Integer value of *inputValueString* converted from *baseDigits* number base.

##### Exceptions
*BaseConvertException* - Thrown if *baseDigits* contains one or more duplicate characters OR if *inputValueString* contains a character not in *baseDigits*.

#### FromBaseBigInteger
Converts a string representation of a specified number base to an unsigned integer.

``` public static BigInteger FromBaseBigInteger(string inputValueString, string baseDigits) ```

##### Parameters

* *inputValueString* - String representation of value to convert.
* *baseDigits* - Number base digits from lowest value to highest value.

##### Return Value
Integer value of *inputValueString* converted from *baseDigits* number base.

##### Exceptions
*BaseConvertException* - Thrown if *baseDigits* contains one or more duplicate characters OR if *inputValueString* contains a character not in *baseDigits*.

---
## StringExtensions
<h4><u>Enumerated Types</u></h4>

##### HandleLongWords
Used as a parameter for `LineBreaks` extension method. Specifies how the method is to handle words longer than *maxLength* parameter.

``` public enum HandleLongWords { CutOff, Allow, ThrowException } ```
<h4><u>Methods</u></h4>

#### SpecificCharCount
Counts the number of occurrences of a specific character in a string

```public static int SpecificCharCount( this string str, char character )```

##### Parameters

* *str* - This string
* *character* - The character to be counted

##### Return Value
Number of occurrences of *character* in the string

#### ContainsDuplicateChars
Determines if there are duplicate characters in the string

```public static bool ContainsDuplicateChars( this string str )```

##### Parameters

* *str* - This string

##### Return Value
True if the string contains a duplicate characters

#### ToByteArray
Returns a byte array containing the ASCII values of the characters of the string.

```public static byte[] ToByteArray( this string str )```

##### Parameters

* *str* - This string

##### Return Value
Byte array of ASCII values.

#### LineBreak
Breaks the string into 1 or more strings based on the delimiter and the maximum number of characters per string.

```public static string[] LineBreak( this String str, string separator, int maxLength, HandleLongWords handleLongWords = HandleLongWords.CutOff )```

##### Parameters

* *str* - This string
* *separator* - Separator or delimitter between words
* *maxLength* - Maximum length of each string in the returned array
* *handleLongWords* - Flag indicating how to handle words longer than maxLength

##### Return Value
An array of strings.

##### Exceptions
*LineBreakException* - Thrown when *handleLongWords = HandleLongWords.ThrowException* and a string token in the original string is longer than *maxLength*

##### Example

```csharp
string myString = "It has truly been a pleasure writing this method for you.";
string[] myLines = myString.LineBreak(" ", 15, HandleLongWords.CutOff);
foreach (string line in myLines)
   Console.WriteLine(line);

// Output:
// It has truly
// been a pleasure
// writing this
// method for you.
```
