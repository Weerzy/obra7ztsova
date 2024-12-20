using System.Collections;

namespace OrgManagmentApp.Extensions;

public static class ListExtensions
{
    public static void AddRange(this IList list, IEnumerable range)
    {
        foreach (var item in range)
        {
            list.Add(item);
        }
    }
}