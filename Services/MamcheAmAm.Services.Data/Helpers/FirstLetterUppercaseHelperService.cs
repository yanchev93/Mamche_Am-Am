namespace MamcheAmAm.Services.Data.Helpers
{
    public class FirstLetterUppercaseHelperService : IFirstLetterUppercaseHelperService
    {
        private const int FirstLetter = 0;
        private const int StartIndex = 1;

        public string FirstLetterToUpperCase(string input)
        {
            var trimmedInput = input.Trim();

            // Check for empty string.
            if (string.IsNullOrEmpty(trimmedInput))
            {
                return string.Empty;
            }

            // Capitalize first letter of the string and concat the rest of it.
            var stringToReturn = char.ToUpper(trimmedInput[FirstLetter]) + trimmedInput[StartIndex..];

            // Return the trimmed string(word/s).
            return stringToReturn.Trim();
        }
    }
}
