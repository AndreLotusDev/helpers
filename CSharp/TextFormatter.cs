namespace Helpers
{
    public static class TextFormatter
    {
        public static string PlaceNewLines(string fullText)
        {
            string formattedString = "";

            if (fullText != null)
                for (int i = 0; i < fullText?.Length; i++)
                {
                    string isADotTabNewLine = "";
                    if (i + 1 < fullText?.Length)
                    {
                        isADotTabNewLine = $"{fullText[i]}{fullText[i+1]}";

                        if (". ".Equals(isADotTabNewLine))
                            formattedString += ". \r\n";
                        else
                            formattedString += fullText[i];
                    }
                }

            return formattedString;
        }
    }
}