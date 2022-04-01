using System;

namespace Snowsoft
{
  public class Program
  {
    static void Main()
    {
      RunDeepestLetter();
      RunShiftArray();
      RunAsciiArtTartan();
    }

    private static void RunDeepestLetter()
    {
      Console.WriteLine(Functions.DeepestLetter("a")); // a
      Console.WriteLine(Functions.DeepestLetter("a(b)c")); // b
      Console.WriteLine(Functions.DeepestLetter("((a))(((b)))(c)(d)(e)(((f))(((g))))h(i)")); // g
      Console.WriteLine(Functions.DeepestLetter("((a)(b)c")); // Missing paratheses, fails
      Console.WriteLine(Functions.DeepestLetter("((a)))(b)c")); // Too many closing paratheses, fails
      Console.WriteLine(Functions.DeepestLetter("(8)")); // Has a number, fails
      Console.WriteLine(Functions.DeepestLetter("((a))(((b)))(c)(d)(e)(((f))(((G))))h(i)")); // has uppercase, fails
      Console.WriteLine(Functions.DeepestLetter("((a))(((b!)))(c)(d)(e)(((f))(((g))))h(i)")); // has a symbol in the string, fails
    }

    private static void RunShiftArray()
    {
      Console.WriteLine(Functions.ShiftArray(new char[] { 'A', 'B', 'C', 'D', 'E' }, 2)); // { 'D', 'E', 'A', 'B', 'C' }
      Console.WriteLine(Functions.ShiftArray(new char[] { 'Z', 'Q', 'K' }, -1)); // { 'Q', 'K', 'Z' }
      Console.WriteLine(Functions.ShiftArray(new char[] { 'Y', 'O' }, 5)); // { 'O', 'Y' }
      Console.WriteLine(Functions.ShiftArray(new char[] { 'Y', 'O' }, 3485)); // { 'O', 'Y' }
      Console.WriteLine(Functions.ShiftArray(new char[] { 'A', 'B', 'C', 'D', 'E' }, -2));  // { 'C', 'D', 'E', 'A', 'B' }
    }

    private static void RunAsciiArtTartan()
    {
      Console.WriteLine(Functions.AsciiArtTartan("#...#","....."));
      Console.WriteLine(Functions.AsciiArtTartan("+++++",".###."));
      Console.WriteLine(Functions.AsciiArtTartan(".+.+.", "#.+.#"));
      Console.WriteLine(Functions.AsciiArtTartan("...+.", "##+.#")); // One wierd plus
      Console.WriteLine(Functions.AsciiArtTartan("#+.....+#", "#+....+#")); // A box of sorts
      Console.WriteLine(Functions.AsciiArtTartan("..........+##+....................", "....+#+....")); // My attempt at the norwegian flag
    }
  }
}
