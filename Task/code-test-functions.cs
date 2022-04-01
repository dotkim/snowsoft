//
// Snow Software Code Tests
//
// Task 1: Please implement your choice of at least 3 of the following methods
// Task 2: Of the methods you implement, choose one and provide a written explanation of your solution in English
//
// You can complete the test at home and you can use any references that you like, but the implementations have to be your own work.
// You can use the development environment of your choice. If you do not have anything for C#, we suggest LINQPad as a free alternative: https://www.linqpad.net/
// 
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
		throw new NotImplementedException();
	}

	// Return a 10x5 character ASCII art string with rows separated by new-lines ('\n') that look like the examples
	// Example input -> output:
	// { (4, 2) } ->
	//     |     
	//     |     
	// ----O-----
	//     |     
	//     |     
	//
	// { (1, 1), (7, 3) } ->
	//  |     |  
	// -O-----+--
	//  |     |  
	// -+-----O--
	//  |     |  
	//
	// { (0, 0), (1, 1), (3, 3), (4, 4) } ->
	// O+-++-----
	// +O-++-----
	// || ||     
	// ++-O+-----
	// ++-+O-----
	//
	// Documentation for named-tuples (used in input): https://docs.microsoft.com/en-us/dotnet/csharp/tuples
	public static string AsciiArtTargets((int x, int y)[] points)
	{
		throw new NotImplementedException();
	}

	// Return new array where all elements are shifted by the amount in the 'shift' parameter (should handle negative values).
	// Example input -> output:
	// { 'A', 'B', 'C', 'D', 'E' }, 2 -> { 'D', 'E', 'A', 'B', 'C' }
	// { 'Z', 'Q', 'K' }, -1 -> { 'Q', 'K', 'Z' }
	// { 'Y', 'O' }, 5 -> { 'O', 'Y' }
	public static char[] ShiftArray(char[] array, int shift)
	{
		throw new NotImplementedException();
	}

    // For a given input 'size', return a string of that length, which begins and ends with a hash, and which contains
    // the maximum possible number of hashes.  All hashes must be separated by a gap of at least one space.  And all gaps in the string
    // must be of equal size.  For inputs which produce invalid strings, return null.
    //  1 -> null
    //  2 -> null
    //  3 -> "# #"
    //  4 -> "#  #"
    //  5 -> "# # #"
    //  6 -> "#    #"
    //  7 -> "# # # #"
    //  8 -> "#      #"
    //  9 -> "# # # # #"
    // 10 -> "#  #  #  #"
    // 11 -> "# # # # # #"
    public static string EvenlySpacedHashes(int size)
    {
        throw new NotImplementedException();
    }

    // For a given set of numeric inputs, reassign their values, such that the maximum number
    // of inputs have a different value than they started with.
    // (1, 2, 3, 4) -> (4, 3, 2, 1)
    // (1000, 256, -53, 1) -> (1, 1000, 256, -53)	
    public static void ShuffleInputs(ref long a, ref int b, ref short c, ref sbyte d)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}
