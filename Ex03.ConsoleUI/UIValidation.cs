using System.Linq;

namespace Ex03.ConsoleUI
{
    public class UIValidation
    {
        public static bool ContainsOnlyLetters(string i_Input)
        {
            return i_Input.All(char.IsLetter);
        }

        public static bool ContainsOnlyDigits(string i_Input)
        {
            return i_Input.All(char.IsDigit);
        }

        public static bool UserInputIsADigit(string i_Input)
        {
           return int.TryParse(i_Input, out int o_UserInput);
        }
    }
}
