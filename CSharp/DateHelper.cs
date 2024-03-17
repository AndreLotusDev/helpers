public static class DateHelper
{
    public static string ShortDateAndHour()
    {
        return DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
    }

    public static DateTime GetLastDayOfActualMonth(this DateTime datetime)
    {
        return new DateTime(datetime.Year, datetime.Month, 1).AddMonths(1).AddDays(-1);
    }

    public static DateTime GetFirstDayOfActualMonth(this DateTime datetime)
    {
        return new DateTime(datetime.Year, datetime.Month, 1);
    }

    public static DateTime ToUkFormat(this DateTime time) => DateTime.ParseExact(time.ToString(), "dd/MM/yyyy HH:mm:ss", null);
    public static string ToUkFormatString(this DateTime time) => ToUkFormat(time).ToString();
    public static DateTime ToUsFormat(this DateTime time) => DateTime.ParseExact(time.ToString(), "yyyy-MM-dd HH:mm:ss", null);
    public static string ToUsFormatString(this DateTime time) => ToUsFormat(time).ToString();
}
