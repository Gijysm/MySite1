using System.Globalization;

namespace MySite.Models;

public class RepozServise
{
    public static List<Product> Repozes { get; }= new ();

    public static int GetLaterRepose(DateTime date)
    {
        int? count = 0;
        var now = date;
        foreach (var repose in  Repozes)
        {
            if (repose.IsPublic && DateTime
                    .TryParseExact(repose.Time,
                        "yyyy-MM", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out var ReposeDate))
            {
                if (ReposeDate > now)
                {
                    count++;
                }
            }
        }
        return count ?? 0;
    }
}