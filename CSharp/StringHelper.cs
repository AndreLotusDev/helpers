public static class StringHelper
{
    public static string ToReverseString(this string value)
    {
        return new string(value.Reverse().ToArray());
    }

    public static int LastIndexOfReverse(this string value, string toFound)
    {
        return string.Concat(value.Reverse()).LastIndexOf(toFound);
    }

    public static string Remove(this string value, string partToRemove)
    {
        var stringWithRemovePart = value.Replace(partToRemove, string.Empty);
        return stringWithRemovePart;
    }

    public static string SubstringReverse(this string value, int index)
    {
        return value.ToReverseString().Substring(index).ToReverseString();
    }

    public static string FirstCharToUpper(this string input)
    {
        if(input.Length == 0)
        {
            return input;
        }

        if (!input.Contains(" "))
        {
            var firstLetter = input[0].ToString().ToUpper();
            var allOtherLetter = input.Substring(1).ToLower();

            return firstLetter + allOtherLetter;
        }

        var words = input.Split(" ").ToList();
        if(words.Last() == " " || words.Last() == "")
        {
            words.RemoveAt(words.IndexOf(words.Last()));
        }

        var wordsFormatted = words.Select(w => w[0].ToString().ToUpper() + w.Substring(1).ToLower() + " ").ToList();
        var toReturn = String.Concat(wordsFormatted);

        return toReturn;
    }

    public static string TranslateEnum(EReturnMessageOperation eReturnMessageOperation)
    {
        switch (eReturnMessageOperation) {
            case EReturnMessageOperation.SUCCESSFULLY_ADDED:
                return "Successfully added!";
            case EReturnMessageOperation.SUCCESSFULLY_UPDATED:
                return "Successfully updated!";
            case EReturnMessageOperation.SUCCESSFULLY_DELETED:
                return "Successfully deleted!";
            case EReturnMessageOperation.SUCCESSFULLY_EDITED:
                return "Successfully edited!";
            case EReturnMessageOperation.SUCCESSFULLY_UPLOADED:
                return "Successfully uploaded!";
            case EReturnMessageOperation.SOMETHING_WENT_WRONG:
                return "Something went wrong!";
            case EReturnMessageOperation.FOUND:
                return "Found!";
            case EReturnMessageOperation.NOT_FOUND:
                return "Not Found!";
            default:
                return String.Empty;
        }
    }

    public static string JointAllMessages(IEnumerable<string> messages)
    {
        return String.Join("",messages.Select(s => "| " + s + " |"));
    }

    public static string RemoveSpacingBetweenWordsAndPlaceaSCamelCase(this string toFormat)
    {
        return toFormat.Replace("_", string.Empty).ToCamelCase();
    }

    public static string RemoveUnderlines(this string toRemove)
    {
        return toRemove.Replace("_", string.Empty);
    }

    public static string ToCamelCase(this string str)
    {
        if (!string.IsNullOrEmpty(str) && str.Length > 1)
        {
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
        return str.ToLowerInvariant();
    }

    public static string ReplaceFirst(this string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos < 0)
        {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }

    public static string GenerateBreakLines(this string rawText)
    {
        var textAsHtml = rawText.Replace("\n", "<br/>");

        return textAsHtml;
    }

    public static string GenerateTabulation(this string rawText)
    {
        var textAsHtml = rawText.Replace("  ", "&nbsp;&nbsp;&nbsp;&nbsp;");

        return textAsHtml;
    }

    public static string ReplaceBeginningYml(this string rawText)
    {
        return rawText.ReplaceFirst("-", " ").Replace("\n-", "\n ");
    }
}
