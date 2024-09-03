namespace TGNH
{
    public static class String
    {
        static String()
        {

        }

        public static string Fix(this string text)
        {
            if (text is null)
            {
                return null;
            }

            text = text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }

            return text;
        }
    }
}
