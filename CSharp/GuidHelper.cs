public static bool IsNullOrEmptyGuid(string input)
{
    if (string.IsNullOrEmpty(input))
        return true;

    Guid result;
    return Guid.TryParse(input, out result);
}
