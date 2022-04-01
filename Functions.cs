using System.Text.RegularExpressions;

namespace Snowsoft
{
  public static class Functions
  {
    // Return the letter (a-z, lowercase) that is found in the deepest parentheses-scope (if there are multiple letters in at the same depth the first in the input string takes priority)
    // Return '?' if the input string is malformed (contains charaters other than (a-z, lowercase) and parentheses or has unmatched parentheses) or no letter is found 
    // Example input -> output:
    // "a(b)c" -> 'b'
    // "((a))(((b)))(c)(d)(e)(((f))(((g))))h(i)" -> 'g'
    // "((a)(b)c" -> '?'
    // "(8)" -> '?'
    public static char DeepestLetter(string str)
    {
      if (String.IsNullOrEmpty(str)) return '?';

      // Find at least one lowercase character.
      string allowedCharacters = "abcdefghijklmnopqrstuvwxyz";
      if (str.IndexOfAny(allowedCharacters.ToCharArray()) == -1) return '?';

      // The string is only one valid character, return that.
      if (str.Length == 1) return char.Parse(str);

      // There should be as many opening as closing paratheses, else the string has unmatched parentheses.
      string[] openParatheses = str.Split("(");
      string[] closingParatheses = str.Split(")");
      if (openParatheses.Length != closingParatheses.Length) return '?';

      // Using a negated set regex pattern (match everything not in the set).
      // Check if any characters other than a-z(lowercase), ( and ) are present.
      string DeniedCharactersPattern = @"[^a-z()]";
      Regex findDeniedCharacters = new Regex(DeniedCharactersPattern);
      if (findDeniedCharacters.IsMatch(str)) return '?';

      // This is used for checking for unmatched paratheses and finding the deepest letter.
      int parathesesDepth = 0;
      // Store the deepest letter
      // The int is initiated at an impossible depth to ensure it will be set in the loop.
      (char, int) deepestLetter = ('a', -1);

      foreach (char c in str.ToCharArray())
      {
        // If the depth is negative, we have an unmatched parantheses.
        if (parathesesDepth < 0) return '?';

        if (c == '(')
        {
          parathesesDepth++;
          continue;
        }
        else if (c == ')')
        {
          parathesesDepth--;
          continue;
        }

        if (parathesesDepth > deepestLetter.Item2)
        {
          deepestLetter = (c, parathesesDepth);
        }
      }

      return deepestLetter.Item1;
    }

    // Return new array where all elements are shifted by the amount in the 'shift' parameter (should handle negative values).
    // Example input -> output:
    // { 'A', 'B', 'C', 'D', 'E' }, 2 -> { 'D', 'E', 'A', 'B', 'C' }
    // { 'Z', 'Q', 'K' }, -1 -> { 'Q', 'K', 'Z' }
    // { 'Y', 'O' }, 5 -> { 'O', 'Y' }
    public static char[] ShiftArray(char[] array, int shift)
    {
      if (array.Length <= 1) return array;
      if (shift == 0) return array;
      if (shift % array.Length == 0) return array;

      // Shorten the shift integer as if its longer than the array itself, the array will do a full rotation.
      int shortenedShift = shift % array.Length;

      // Create a string from the array, to use substring for shifting.
      string arrayAsString = new string(array);
      if (shift > 0)
      {
        // I chose to show two aproaches on this is, using the new C# 8.0 ranges and substring.
        // The substring is the same as:
        //string shiftedArray = arrayAsString[^shortenedShift..] + arrayAsString[..^shortenedShift];
        string shiftedArray = arrayAsString.Substring(arrayAsString.Length - shortenedShift)
                              + arrayAsString.Substring(0, arrayAsString.Length - shortenedShift);
        return shiftedArray.ToCharArray();
      }
      else
      {
        // Because the substring is done "the opposite" way, i turn the negative number into a positive so i can use substring properly.
        int absoluteShift = Math.Abs(shortenedShift);
        // The same as Substring(absoluteShift) + Subtring(0, absoluteShift)
        string shiftedArray = arrayAsString[absoluteShift..] + arrayAsString[..absoluteShift];
        return shiftedArray.ToCharArray();
      }
    }

    // For given input strings 'xPattern' and 'yPattern'
    // Return a patterned string which describes a grid of 'xPattern.Length*yPattern.Length'
    // Wherein:  'xPattern' describes the left-to-right patterning and
    //			 'yPattern' describes the top-to-bottom patterning
    // '#' takes priority over '+' which in turn takes priority over '.'
    // ("#...#",".....") ->
    // #...#
    // #...#
    // #...#
    // #...#
    // #...#
    // ("+++++",".###.") ->
    // +++++
    // #####
    // #####
    // #####
    // +++++
    // (".+.+.", "#.+.#") ->	
    // ##### 
    // .+.+.
    // +++++
    // .+.+.
    // #####
    public static string AsciiArtTartan(string xPattern, string yPattern)
    {
      int columns = xPattern.Length;
      int rows = yPattern.Length;

      Dictionary<char, int> priorityList = new Dictionary<char, int>
      {
        { '#', 0 },
        { '+', 1 },
        { '.', 2 }
      };

      string AsciiArtTable = "";

      for (int row = 0; rows > row; row++)
      {
        for (int column = 0; columns > column; column++)
        {
          // Get the index number (or priority) from the dictionary, this will be used for setting the correct symbol.
          int xPatPriorityIndex = priorityList[xPattern[column]];
          int yPatPriorityIndex = priorityList[yPattern[row]];

          // Get the lowest priority number, then use this index to get the correct symbol from the priorityList dict.
          int minPriorityIndex = Math.Min(xPatPriorityIndex, yPatPriorityIndex);

          char cellSymbol = priorityList.ElementAt(minPriorityIndex).Key;
          AsciiArtTable += cellSymbol;
        }
        AsciiArtTable += "\n";
      }

      return AsciiArtTable;
    }
  }
}
