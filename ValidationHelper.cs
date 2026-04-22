namespace ValidationHelper
{
    public static class ValidationHelper
    {
        public static bool ValidateStringLength(string text, int min, int max = -1)
        {
            text = text.Trim();
            if (max == -1)
            {
                if (text.Length >= min)
                    return true;
            }
            else if (text.Length >= min && text.Length <= max)
                return true;

            return false;
        }
    }
}