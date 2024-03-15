namespace YOUR_NAMESPACE
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(T e) where T : System.Enum
        {
            var type = e.GetType();
            var member = System.Enum.GetName(type, e);
            var attribute = type.GetField(member).GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            return attribute.Length == 0 ? e.ToString() : ((System.ComponentModel.DescriptionAttribute)attribute[0]).Description;
        }
    }
}
