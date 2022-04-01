# Explaination of DeepestLetter

I chose this method because i thought it was the most fun and thought processing.

I will first go over the validation process:

```csharp
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
```

The first is just a check if the string is null or empty, but for the second, I think this was a nice way of doing it. It checks the input for any of the `allowedCharacters` content. I use the `IndexOfAny` string method to check an array of char, this way i can find any lowercase character and tell the string contains atleast one valid character. If not i return the questionmark.

```csharp
// Find at least one lowercase character.
string allowedCharacters = "abcdefghijklmnopqrstuvwxyz";
if (str.IndexOfAny(allowedCharacters.ToCharArray()) == -1) return '?';

// The string is only one valid character, return that.
if (str.Length == 1) return char.Parse(str);
```

I also thought about doing this in regex, as it is a very simple one. While i am not sure of the perfomance difference for both of these methods, I think the method i chose was a short and simple way of validating the string.

The third check is there if the string is one character long, as its already been validated, I can just return the `str` back as a char.

Now the fourth check, for parantheses I asked if i could use Linq in these tasks mostly because of this. But i opted not to. This checks if there are as many opening as closing parentheses, if not there isn't any point in continuing. The method i use for counting is to split the string by the parantheses, this creates an array in the length of the amount of parantheses. I could also use Linq like this: `int openParatheses = str.Count(c => c == '(' );`.

At this point, I will not check if the paratheses are in the correct order. But it is a fast check for confirming that there wont be an unmatched pair at the end of the string. I check for the correct order later.

```csharp
// There should be as many opening as closing paratheses, else the string has unmatched parentheses.
string[] openParatheses = str.Split("(");
string[] closingParatheses = str.Split(")");
if (openParatheses.Length != closingParatheses.Length) return '?';
```

The fifth and last check is a regular expression, it is a fairly simple one, but still very powerfull for what i want to do. This check is used to invalidate the string if it has anything other than the valid characters. I don't want this regex to find anything, and what makes it different from the `allowedCharacters` check earlier is that it doesn't care if it contains any valid characters at all. The regex pattern is a negated set and will not match any character from a to z or (). Then check if its a match and return the questionmark if so.

```csharp
// Using a negated set regex pattern (match everything not in the set).
// Check if any characters other than a-z(lowercase), ( and ) are present.
string DeniedCharactersPattern = @"[^a-z()]";
Regex findDeniedCharacters = new Regex(DeniedCharactersPattern);
if (findDeniedCharacters.IsMatch(str)) return '?';
```

Over to the processing now that I know most of the string is valid.

I use an int to hold the current depth of the parantheses, this will be used after the for loop to check if all the opening parantheses has been closed. I store the deepest number in a tuple, where i put an impossible depth as the int so i always overwrite it even if the depth is 0.

```csharp
// This is used for checking for unmatched paratheses and finding the deepest letter.
int parathesesDepth = 0;
// Store the deepest letter
// The int is initiated at an impossible depth to ensure it will be set in the loop.
(char, int) deepestLetter = ('a', -1);
```

Now to the foreach loop, there is a check to see if the parantheses depth is less than 0. This will return the questionmark if there are too many closing parantheses (e.g. "(a))("). Then there's two if's to set the depth, simply increase depth on opening and decrease on closing.

```csharp
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
```

The last if in the loop checks the `deepestLetter` tuple if a letter is deeper than the current deepest letter. If there is another letter at the same depth, it will not overwrite the current deepest letter, as we always check if the depth is greater than the deepest letter and not equal.

In the end, i return the deepest letter.

```csharp
return deepestLetter.Item1;
```
