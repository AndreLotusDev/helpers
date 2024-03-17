public class DifferencesBetweenJson
{
    public bool IsDifferent { get; set; }
    public List<string> DifferencesAsMessage { get; set; }
    public List<(string previousValue, string newValue, string key)> ChangesAsJson { get; set; }
    public List<(string previousValueAsYml, string newValueAsYml, string key)> ChangesAsYml { get; set; }

    public DifferencesBetweenJson()
    {
        IsDifferent = false;
        DifferencesAsMessage = new();
        ChangesAsJson = new();
        ChangesAsYml = new();
    }
}
