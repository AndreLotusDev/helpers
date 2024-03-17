public static class DictionaryHelper
{
    public static string DictionaryToString<K, V>(this IDictionary<K, V> dict)
    {
        var items = dict.Select(kvp => kvp.ToString());
        return string.Join(", ", items);
    }

    public static IList<K> GetKeys<K, V>(this IDictionary<K, V> dict)
    {
        return dict.Select(s => s.Key).ToList();
    }

    public static void RenameKey<TKey, TValue>(this IDictionary<TKey, TValue> dic,
                                  TKey fromKey, TKey toKey)
    {
        TValue value = dic[fromKey];
        dic.Remove(fromKey);
        dic[toKey] = value;
    }

    /// <summary>
    /// Do not use in any scenario, with a lot of information inside the dic the performance will be really low (not the best Big O Notation)
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TNewKeyFormat"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dic"></param>
    /// <param name="formatOperation"></param>
    public static Dictionary<TNewKeyFormat, TValue> RenameKeyWithFormatting<TKey, TNewKeyFormat, TValue>(this IDictionary<TKey, TValue> dic, Func<TKey, TNewKeyFormat> formatOperation)
    {
        Dictionary<TNewKeyFormat, TValue> dictionary = new();

        foreach (var item in dic)
        {
            dictionary.Add(formatOperation(item.Key), item.Value);
        }

        return dictionary;
    }
}
